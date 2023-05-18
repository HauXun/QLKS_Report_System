import { useEffect, useState } from "react";
import ReactApexChart from "react-apexcharts";
import { Rating } from "primereact/rating";
// Chakra imports
import { Flex, SimpleGrid, useColorModeValue } from "@chakra-ui/react";
import Card from "components/Card/Card.js";
import { useParams } from "react-router-dom/cjs/react-router-dom.min";
import MiniStatistics from "./components/MiniStatistics";
import {
	CreditIcon,
	DocumentIcon,
	PersonIcon,
	WalletIcon,
} from "components/Icons/Icons.js";
import { Calendar } from "primereact/calendar";
import { Button } from "primereact/button";
import HotelIcon from "../../../assets/img/hotel.png";

const lineChartOptions = {
	chart: {
		toolbar: {
			show: false,
		},
	},
	tooltip: {
		theme: "dark",
	},
	dataLabels: {
		enabled: false,
	},
	stroke: {
		curve: "smooth",
	},
	xaxis: {
		categories: [
			"Jan",
			"Feb",
			"Mar",
			"Apr",
			"May",
			"Jun",
			"Jul",
			"Aug",
			"Sep",
			"Oct",
			"Nov",
			"Dec",
		],
		labels: {
			style: {
				colors: "#c8cfca",
				fontSize: "12px",
			},
		},
	},
	yaxis: {
		labels: {
			style: {
				colors: "#c8cfca",
				fontSize: "12px",
			},
		},
	},
	legend: {
		show: true,
	},
	grid: {
		strokeDashArray: 5,
	},
	fill: {
		type: "gradient",
		gradient: {
			shade: "light",
			type: "vertical",
			shadeIntensity: 0.5,
			gradientToColors: undefined, // optional, if not defined - uses the shades of same color in series
			inverseColors: true,
			opacityFrom: 0.8,
			opacityTo: 0,
			stops: [],
		},
		colors: ["#4FD1C5", "#2D3748"],
	},
	colors: ["#4FD1C5", "#2D3748"],
};

export default function StatisticalOfHotel() {
	const iconBoxInside = useColorModeValue("white", "white");
	const { id } = useParams();

	const [hotelInfo, setHotelInfo] = useState({});
	const [revenueData, setRevenueData] = useState({
		name: "Doanh thu",
		data: [],
	});
	const [expenseData, setExpenseData] = useState({
		name: "Chi phí",
		data: [],
	});
	const [dateFilter, setDateFilter] = useState({
		fromDate: null,
		toDate: null,
	});

	useEffect(() => {
		Promise.all([getHotelInfo(), getRevenue(), getExpense()]).then(
			([hotelInfo, revenue, expense]) => {
				if (hotelInfo.isSuccess && hotelInfo.result) {
					setHotelInfo(hotelInfo.result);
				}

				if (revenue.isSuccess && revenue.result) {
					setRevenueData((prevState) => ({
						...prevState,
						data: revenue.result.slice(0, 10).map((i) => i.tongDoanhThu),
					}));
				}

				if (expense.isSuccess && expense.result) {
					setExpenseData((prevState) => ({
						...prevState,
						data: expense.result.slice(0, 10).map((i) => i.tongChiPhi),
					}));
				}
			}
		);
	}, []);

	function getTotalRevenue() {
		if (revenueData.data) {
			return revenueData.data.reduce((a, b) => a + b, 0);
		}
	}
	function getTotalExpense() {
		if (expenseData.data) {
			return expenseData.data.reduce((a, b) => a + b, 0);
		}
	}
	async function getHotelInfo() {
		const res = await fetch(
			`${process.env.REACT_APP_API_URL}/khachsan/${id}`
		);
		return await res.json();
	}
	async function getRevenue() {
		const res = await fetch(
			`${process.env.REACT_APP_API_URL}/doanhthu?KhachSanId=${id}`
		);
		return await res.json();
	}
	async function getExpense() {
		const res = await fetch(
			`${process.env.REACT_APP_API_URL}/chiphi?KhachSanId=${id}`
		);
		return await res.json();
	}

	return (
		<Flex flexDirection="column" pt={{ base: "120px", md: "75px" }}>
			<Card>
				<div
					style={{
						marginTop: "16px",
						display: "flex",
					}}
				>
					<div
						style={{
							width: "120px",
							marginRight: "24px",
						}}
					>
						<img
							style={{
								margin: "0 auto",
							}}
							src={HotelIcon}
							alt="hotel"
						/>
					</div>
					<div>
						<h1
							style={{
								fontWeight: "bold",
								marginBottom: "10px",
							}}
						>
							Thông tin khách sạn
						</h1>
						<h3
							style={{
								marginTop: "5px",
							}}
						>
							Tên: {hotelInfo.tenKhachSan}
						</h3>
						<h6
							style={{
								marginTop: "5px",
							}}
						>
							Địa chỉ: {hotelInfo.diaChi}
						</h6>
						<h6
							style={{
								marginTop: "5px",
								display: "flex",
								alignItems: "center",
							}}
						>
							<span
								style={{
									display: "inline-block",
									minWidth: "172px",
								}}
							>
								Chất lượng khách sạn:
							</span>
							<Rating value={5} readOnly cancel={false} />
						</h6>
						<h6
							style={{
								marginTop: "5px",
								display: "flex",
								alignItems: "center",
							}}
						>
							<span
								style={{
									display: "inline-block",
									minWidth: "172px",
								}}
							>
								Chất lượng dịch vụ:
							</span>
							<Rating value={4} readOnly cancel={false} />
						</h6>
					</div>
				</div>
			</Card>

			<SimpleGrid
				columns={{ sm: 1, md: 2, xl: 2 }}
				spacing="16px"
				style={{
					marginTop: "16px",
				}}
			>
				<MiniStatistics
					title={"Tổng doanh thu"}
					amount={getTotalRevenue().toLocaleString("it-IT", {
						style: "currency",
						currency: "VND",
					})}
					percentage={10}
					icon={<WalletIcon h={"24px"} w={"24px"} color={iconBoxInside} />}
				/>
				<MiniStatistics
					title={"Tổng chi phí"}
					amount={getTotalExpense().toLocaleString("it-IT", {
						style: "currency",
						currency: "VND",
					})}
					percentage={-5}
					icon={<CreditIcon h={"24px"} w={"24px"} color={iconBoxInside} />}
				/>
			</SimpleGrid>
			<SimpleGrid
				columns={{ sm: 1, md: 3, xl: 3 }}
				spacing="16px"
				style={{
					marginTop: "16px",
				}}
			>
				<MiniStatistics
					title={"Tổng nhân viên"}
					amount={120}
					percentage={3}
					icon={<PersonIcon h={"24px"} w={"24px"} color={iconBoxInside} />}
				/>
				<MiniStatistics
					title={"Tổng khách hàng"}
					amount={3600}
					percentage={14}
					icon={<PersonIcon h={"24px"} w={"24px"} color={iconBoxInside} />}
				/>
				<MiniStatistics
					title={"Tổng phòng"}
					amount={68}
					percentage={2}
					icon={
						<DocumentIcon h={"24px"} w={"24px"} color={iconBoxInside} />
					}
				/>
			</SimpleGrid>

			<Card
				overflowX={{ sm: "scroll", xl: "hidden" }}
				style={{
					marginTop: "16px",
				}}
			>
				<div>
					<h4>Chọn mốc thời gian thống kê</h4>
					<SimpleGrid
						columns={{ sm: 1, md: 2, xl: 2 }}
						spacing="16px"
						style={{
							marginTop: "16px",
						}}
					>
						<Calendar
							value={dateFilter.fromDate}
							onChange={(e) =>
								setDateFilter((prevState) => ({
									...prevState,
									fromDate: e.value,
								}))
							}
							showIcon
							size
						/>
						<Calendar
							value={dateFilter.toDate}
							onChange={(e) =>
								setDateFilter((prevState) => ({
									...prevState,
									toDate: e.value,
								}))
							}
							showIcon
						/>
					</SimpleGrid>
					<Button
						style={{
							marginTop: "16px",
						}}
						label="Lọc dữ liệu"
						size="small"
					/>
				</div>
				<div
					style={{
						marginTop: "32px",
					}}
				>
					<h4>Biểu đồ doanh thu và chi phí</h4>
					<ReactApexChart
						options={lineChartOptions}
						series={[revenueData, expenseData]}
						type="area"
						width="100%"
						height="100%"
					/>
				</div>
				<Button
					style={{
						marginTop: "16px",
						width: "max-content",
					}}
					label="Xem danh sách doanh thu"
					size="small"
					outlined
				/>
			</Card>
		</Flex>
	);
}
