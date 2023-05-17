import PropTypes from "prop-types";
import classNames from "classnames/bind";
import styles from "./RevenueDialog.module.scss";

import { Dialog } from "primereact/dialog";

const cx = classNames.bind(styles);

RevenueDialog.propTypes = {
	visible: PropTypes.bool.isRequired,
	setVisible: PropTypes.func.isRequired,
	item: PropTypes.object,
};

RevenueDialog.defaultProps = {
	item: {},
};

function RevenueDialog({ visible, setVisible, item }) {
	return (
		<Dialog
			header="DOANH THU KHÁCH SẠN"
			visible={visible}
			style={{ width: "880px" }}
			onHide={() => setVisible(false)}
		>
			{item && <h1>{item.name}</h1>}
		</Dialog>
	);
}

export default RevenueDialog;
