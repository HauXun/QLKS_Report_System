import React, { useEffect, useState } from "react";
// Chakra imports
import {
	Flex,
	IconButton,
	Input,
	InputGroup,
	InputLeftElement,
	useColorModeValue,
} from "@chakra-ui/react";
import Card from "components/Card/Card.js";
import HotelTable from "./components/HotelTable";
import HotelIcon from "../../../assets/img/hotel.png";
import { SearchIcon } from "@chakra-ui/icons";
import useDebounce from "../../../hooks/useDebounce";
import { Button } from "primereact/button";

export default function HotelManager() {
	const [searchValue, setSearchValue] = useState("");
	const searchValueDebounce = useDebounce(searchValue, 800);
	const [tableDataSave, setTableDataSave] = useState([]);
	const [tableData, setTableData] = useState([]);

	// Chakra Color Mode
	let mainTeal = useColorModeValue("teal.300", "teal.300");
	let inputBg = useColorModeValue("white", "gray.800");
	let mainText = useColorModeValue("gray.700", "gray.200");
	let searchIcon = useColorModeValue("gray.700", "gray.200");

	useEffect(() => {
		fetch(`${process.env.REACT_APP_API_URL}/khachsan`)
			.then((res) => res.json())
			.then((res) => {
				if (res.isSuccess && res.result) {
					const data = res.result.map((hotel) => ({
						...hotel,
						logo: HotelIcon,
						name: hotel.tenKhachSan,
						address: hotel.diaChi,
					}));
					setTableData(data);
					setTableDataSave(data);
				}
			})
			.catch((err) => {
				console.error(err);
			});
	}, []);

	useEffect(() => {
		if (!searchValueDebounce) {
			setTableData([...tableDataSave]);
		} else {
			const dataResult = tableDataSave.filter((i) =>
				i.name.includes(searchValueDebounce)
			);
			setTableData(dataResult);
		}
	}, [searchValueDebounce]);

	function resetTableData() {
		setTableData(tableDataSave);
		setSearchValue("");
	}

	return (
		<Flex flexDirection="column" pt={{ base: "120px", md: "75px" }}>
			<Card overflowX={{ sm: "scroll", xl: "hidden" }}>
				<div
					style={{
						display: "flex",
						alignItems: "flex-start",
					}}
				>
					<InputGroup
						style={{
							marginBottom: "24px",
							flex: "1",
						}}
						cursor="pointer"
						bg={inputBg}
						borderRadius="15px"
						me={{ sm: "auto", md: "20px" }}
						_focus={{
							borderColor: { mainTeal },
						}}
						_active={{
							borderColor: { mainTeal },
						}}
					>
						<InputLeftElement
							children={
								<IconButton
									bg="inherit"
									borderRadius="inherit"
									_hover="none"
									_active={{
										bg: "inherit",
										transform: "none",
										borderColor: "transparent",
									}}
									_focus={{
										boxShadow: "none",
									}}
									icon={
										<SearchIcon
											color={searchIcon}
											w="15px"
											h="15px"
										/>
									}
								></IconButton>
							}
						/>
						<Input
							py="11px"
							color={mainText}
							placeholder="Nhập tên khách sạn cần tìm ..."
							borderRadius="inherit"
							value={searchValue}
							onChange={(e) => setSearchValue(e.target.value.trim())}
						/>
					</InputGroup>
					<Button
						label="Tải lại danh sách"
						onClick={resetTableData}
						size="small"
					/>
				</div>
				<HotelTable
					title={"Danh sách khách sạn"}
					captions={["Khách sạn", ""]}
					data={tableData ?? []}
				/>
			</Card>
		</Flex>
	);
}
