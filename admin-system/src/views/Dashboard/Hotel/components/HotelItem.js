import {
	Avatar,
	Button,
	Flex,
	Icon,
	Td,
	Text,
	Tr,
	useColorModeValue,
} from "@chakra-ui/react";
import { FaEllipsisV } from "react-icons/fa";
import React from "react";

function HotelItem(props) {
	const { logo, name, address } = props;
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
				<Button p="0px" bg="transparent">
					<Icon as={FaEllipsisV} color="gray.400" cursor="pointer" />
				</Button>
			</Td>
		</Tr>
	);
}

export default HotelItem;
