import { useState } from "react";
import PropTypes from "prop-types";

import { Dialog } from "primereact/dialog";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Paginator } from "primereact/paginator";

RevenueDialog.propTypes = {
	visible: PropTypes.bool.isRequired,
	setVisible: PropTypes.func.isRequired,
	hotelInfo: PropTypes.object,
	params: PropTypes.object,
};

RevenueDialog.defaultProps = {
	hotelInfo: {},
	params: {},
};

function RevenueDialog({ visible, setVisible, hotelInfo, params }) {
	//? States
	const [tableData, setTableData] = useState([]);
	const [selectedItem, setSelectedItem] = useState(null);

	const handleGetTableData = () => {
		if (hotelInfo) {
			(async () => {
				const res = await fetch(
					`${process.env.REACT_APP_API_URL}/doanhthu?KhachSanId=${hotelInfo.id}&${params}`
				);
				const data = await res.json();
				if (data.isSuccess && data.result) {
					setTableData(data.result.slice(0, 10));
				}
			})();
		}
	};
	const handleBeforeShowDialog = () => {
		handleGetTableData();
	};

	return (
		<Dialog
			header="DANH SÁCH DOANH THU"
			visible={visible}
			style={{ width: "1000px" }}
			onHide={() => setVisible(false)}
			onShow={handleBeforeShowDialog}
		>
			<DataTable
				value={tableData}
				rows={10}
				stripedRows
				showGridlines
				scrollable
				selection={selectedItem}
				onSelectionChange={(e) => setSelectedItem(e.value)}
				selectionMode="single"
				dataKey="id"
				emptyMessage="Không có kết quả"
				tableStyle={{ minWidth: "max-content" }}
			>
				<Column field="tenDoanhThu" header="Tên doanh thu" frozen />
				<Column
					field="tongDoanhThu"
					header="Tổng doanh thu"
					body={(row) =>
						row.tongDoanhThu.toLocaleString("it-IT", {
							style: "currency",
							currency: "VND",
						})
					}
				/>
				<Column
					field="moTa"
					header="Mô tả"
					style={{
						maxWidth: "420px",
					}}
				/>
				<Column
					field="thoiGianTao"
					header="Thời gian tạo"
					body={(row) => new Date(row.thoiGianTao).toDateString()}
				/>
			</DataTable>
			<Paginator
				className="mt-4"
				first={0}
				rows={10}
				totalRecords={tableData.length}
				rowsPerPageOptions={[10, 20, 50]}
			/>
		</Dialog>
	);
}

export default RevenueDialog;
