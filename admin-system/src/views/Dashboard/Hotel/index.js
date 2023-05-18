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

export default function HotelManager() {
	const [searchValue, setSearchValue] = useState("");
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
					setTableData(
						res.result.map((hotel) => ({
							...hotel,
							logo: HotelIcon,
							name: hotel.tenKhachSan,
							address: hotel.diaChi,
						}))
					);
				}
			});
	}, [searchValue]);

	const handleSearch = () => {
		console.log(searchValue);
	};

	return (
		<Flex flexDirection="column" pt={{ base: "120px", md: "75px" }}>
			<Card overflowX={{ sm: "scroll", xl: "hidden" }}>
				<InputGroup
					style={{
						marginBottom: "24px",
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
									<SearchIcon color={searchIcon} w="15px" h="15px" />
								}
								onClick={handleSearch}
							></IconButton>
						}
					/>
					<Input
						py="11px"
						color={mainText}
						placeholder="Tìm kiếm khách sạn ..."
						borderRadius="inherit"
						value={searchValue}
						onChange={(e) => setSearchValue(e.target.value.trim())}
					/>
				</InputGroup>
				<HotelTable
					title={"Danh sách khách sạn"}
					captions={["Khách sạn", ""]}
					data={tableData}
				/>
			</Card>
		</Flex>
	);
}
