// import
import Hotel from "views/Dashboard/Hotel";
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
		path: "/signin",
		name: "Đăng xuất",
		icon: <RocketIcon color="inherit" />,
		component: SignIn,
		layout: "/auth",
	},
];
export default dashRoutes;
