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
import PropTypes from "prop-types";

HotelItem.propTypes = {
	onOpenDialog: PropTypes.func,
};

HotelItem.defaultProps = {
	onOpenDialog: () => {},
};

function HotelItem({ logo, name, address, onOpenDialog }) {
	const textColor = useColorModeValue("gray.700", "white");

	const actions = [
		{
			label: "Doanh thu",
			icon: "pi pi-cart-plus",
			command: () => {
				onOpenDialog("RevenueDialog");
			},
		},
		{
			label: "Chi phí",
			icon: "pi pi-calculator",
			command: () => {
				onOpenDialog("RevenueDialog");
			},
		},
		{
			label: "Đánh giá",
			icon: "pi pi-star",
			command: () => {
				onOpenDialog("RevenueDialog");
			},
		},
		{
			label: "Khách hàng",
			icon: "pi pi-user",
			command: () => {
				onOpenDialog("RevenueDialog");
			},
		},
		{
			label: "Nhân viên",
			icon: "pi pi-users",
			command: () => {
				onOpenDialog("RevenueDialog");
			},
		},
		{
			label: "Phòng",
			icon: "pi pi-stop",
			command: () => {
				onOpenDialog("RevenueDialog");
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
					model={actions}
					outlined
					size="small"
				/>
			</Td>
		</Tr>
	);
}

export default HotelItem;
