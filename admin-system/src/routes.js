// import
import Dashboard from "views/Dashboard/Dashboard";
import Tables from "views/Dashboard/Tables";
import Billing from "views/Dashboard/Billing";
import SignIn from "views/Auth/SignIn.js";

import {
	HomeIcon,
	StatsIcon,
	CreditIcon,
	RocketIcon
} from "components/Icons/Icons";

var dashRoutes = [
	{
		path: "/dashboard",
		name: "Dashboard",
		icon: <HomeIcon color="inherit" />,
		component: Dashboard,
		layout: "/admin",
	},
	{
		path: "/tables",
		name: "Tables",
		icon: <StatsIcon color="inherit" />,
		component: Tables,
		layout: "/admin",
	},
	{
		path: "/billing",
		name: "Billing",
		icon: <CreditIcon color="inherit" />,
		component: Billing,
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
