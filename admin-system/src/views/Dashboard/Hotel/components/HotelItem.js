import { Link } from "react-router-dom";
import {
	Avatar,
	Flex,
	Td,
	Text,
	Tr,
	useColorModeValue,
} from "@chakra-ui/react";
import { Button } from "primereact/button";

import React from "react";

function HotelItem({ id, logo, name, address }) {
	const textColor = useColorModeValue("gray.700", "white");

	return (
		<Tr>
			<Td minWidth={{ sm: "250px" }} pl="0px">
				<Flex align="center" py=".8rem" minWidth="100%" flexWrap="nowrap">
					<Avatar src={logo} w="50px" borderRadius="12px" me="18px" />
					<Flex direction="column">
						<Text
							fontSize="md"
							color={textColor}
							fontWeight="bold"
							minWidth="100%"
						>
							{name}
						</Text>
						<Text fontSize="sm" color="gray.400" fontWeight="normal">
							{address}
						</Text>
					</Flex>
				</Flex>
			</Td>
			<Td>
				<Link to={`/admin/statistical-of-hotel/${id}`}>
					<Button
						label="Xem thống kê"
						outlined
						size="small"
					/>
				</Link>
			</Td>
		</Tr>
	);
}

export default HotelItem;
