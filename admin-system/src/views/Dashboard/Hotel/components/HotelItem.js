import {
	Avatar,
	Flex,
	Td,
	Text,
	Tr,
	useColorModeValue,
} from "@chakra-ui/react";
import { SplitButton } from "primereact/splitbutton";

import React from "react";

function HotelItem(props) {
	const { logo, name, address } = props;
	const textColor = useColorModeValue("gray.700", "white");

	const items = [
		{
			label: "Update",
			icon: "pi pi-refresh",
			command: () => {
				toast.current.show({
					severity: "success",
					summary: "Updated",
					detail: "Data Updated",
				});
			},
		},
		{
			label: "Delete",
			icon: "pi pi-times",
			command: () => {
				toast.current.show({
					severity: "warn",
					summary: "Delete",
					detail: "Data Deleted",
				});
			},
		},
		{
			label: "React Website",
			icon: "pi pi-external-link",
			command: () => {
				window.location.href = "https://reactjs.org/";
			},
		},
		{
			label: "Upload",
			icon: "pi pi-upload",
			command: () => {
				//router.push('/fileupload');
			},
		},
	];

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
				<SplitButton
					label="Tùy chọn"
					icon="pi pi-plus"
					model={items}
				/>
			</Td>
		</Tr>
	);
}

export default HotelItem;
