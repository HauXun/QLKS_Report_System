import { useState } from "react";
import PropTypes from "prop-types";

import { Dialog } from "primereact/dialog";
import { DataTable } from "primereact/datatable";
import { Column } from "primereact/column";
import { Paginator } from "primereact/paginator";

ExpenseDialog.propTypes = {
	visible: PropTypes.bool.isRequired,
	setVisible: PropTypes.func.isRequired,
	item: PropTypes.object,
};

ExpenseDialog.defaultProps = {
	item: {},
};

function ExpenseDialog({ visible, setVisible, item }) {
	//? States
	const [tableData, setTableData] = useState([]);
	const [selectedItem, setSelectedItem] = useState(null);

	const handleGetTableData = () => {
		if (item) {
			(async () => {
				const res = await fetch(
					`${process.env.REACT_APP_API_URL}/chiphi?KhachSanId=${item.id}`
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
			header="DANH SÁCH CHI PHÍ"
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
				<Column field="tenChiPhi" header="Tên chi phí" frozen />
				<Column
					field="tongChiPhi"
					header="Tổng chi phí"
					body={(row) =>
						row.tongChiPhi.toLocaleString("it-IT", {
							style: "currency",
							currency: "VND",
						})
					}
				/>
				<Column
					field="chiPhiVao"
					header="Chi phí vào"
					body={(row) =>
						row.chiPhiVao.toLocaleString("it-IT", {
							style: "currency",
							currency: "VND",
						})
					}
				/>
				<Column
					field="chiPhiRa"
					header="Chi phí ra"
					body={(row) =>
						row.chiPhiRa.toLocaleString("it-IT", {
							style: "currency",
							currency: "VND",
						})
					}
				/>
				<Column
					field="mucDich"
					header="Mục đích"
					style={{
						maxWidth: "420px",
					}}
				/>
				<Column
					field="ghiChu"
					header="Ghi chú"
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

export default ExpenseDialog;
