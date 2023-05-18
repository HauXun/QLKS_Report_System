// import
import Hotel from "views/Dashboard/Hotel";
import StatisticalOfHotel from "views/Dashboard/StatisticalOfHotel";
import SignIn from "views/Auth/SignIn.js";

import {
	HomeIcon,
	RocketIcon
} from "components/Icons/Icons";

var dashRoutes = [
	{
		path: "/dashboard",
		name: "Khách sạn",
		icon: <HomeIcon color="inherit" />,
		component: Hotel,
		layout: "/admin",
	},
	{
		path: "/statistical-of-hotel/:id",
		name: "Thống kê của khách sạn",
		component: StatisticalOfHotel,
		layout: "/admin",
		hideOnSidebar: true
	},
	{
		path: "/signin",
		name: "Đăng xuất",
		icon: <RocketIcon color="inherit" />,
		component: SignIn,
		layout: "/auth",
	},
];
export default dashRoutes;
