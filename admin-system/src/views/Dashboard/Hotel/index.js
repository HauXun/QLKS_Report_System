import React from "react";
// Chakra imports
import { Flex, useColorModeValue } from "@chakra-ui/react";
import HotelTable from "./components/HotelTable";
import HotelIcon from "../../../assets/img/hotel.png";

const tablesTableData = [
	{
		logo: HotelIcon,
		name: "Esthera Jackson",
		address: "alexa@simmmple.com",
	},
	{
		logo: HotelIcon,
		name: "Alexa Liras",
		address: "laurent@simmmple.com",
	},
	{
		logo: HotelIcon,
		name: "Laurent Michael",
		address: "laurent@simmmple.com",
	},
	{
		logo: HotelIcon,
		name: "Freduardo Hill",
		address: "freduardo@simmmple.com",
	},
	{
		logo: HotelIcon,
		name: "Daniel Thomas",
		address: "daniel@simmmple.com",
	},
	{
		logo: HotelIcon,
		name: "Mark Wilson",
		address: "mark@simmmple.com",
	},
];

export default function Dashboard() {
	return (
		<Flex flexDirection="column" pt={{ base: "120px", md: "75px" }}>
			<HotelTable
				title={"Danh sách khách sạn"}
				captions={["Khách sạn", ""]}
				data={tablesTableData}
			/>
		</Flex>
	);
}
