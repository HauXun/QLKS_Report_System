// Chakra imports
import {
	Table,
	Tbody,
	Text,
	Th,
	Thead,
	Tr,
	useColorModeValue,
} from "@chakra-ui/react";
// Custom components
import CardBody from "components/Card/CardBody.js";
import CardHeader from "components/Card/CardHeader.js";
import HotelItem from "./HotelItem";

const HotelTable = ({ title, captions, data }) => {
	const textColor = useColorModeValue("gray.700", "white");

	return (
		<>
			<CardHeader p="6px 0px 22px 0px">
				<Text fontSize="xl" color={textColor} fontWeight="bold">
					{title}
				</Text>
			</CardHeader>
			<CardBody>
				<Table variant="simple" color={textColor}>
					<Thead>
						<Tr my=".8rem" pl="0px" color="gray.400">
							{captions.map((caption, idx) => {
								return (
									<Th
										color="gray.400"
										key={idx}
										ps={idx === 0 ? "0px" : null}
									>
										{caption}
									</Th>
								);
							})}
						</Tr>
					</Thead>
					<Tbody>
						{data.map((row, index) => {
							return <HotelItem {...row} />;
						})}
					</Tbody>
				</Table>
			</CardBody>
		</>
	);
};

export default HotelTable;
