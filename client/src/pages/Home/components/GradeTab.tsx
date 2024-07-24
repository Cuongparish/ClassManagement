import React from "react";
import { Row, Table } from "antd";

// Định nghĩa kiểu dữ liệu cho cột
interface DataType {
  key: string;
  lớp: string;
  điểmTrungBình: number;
}

const GradeTab: React.FC = () => {
  // Tạo dữ liệu mẫu
  const data: DataType[] = [
    {
      key: '1',
      lớp: 'Lớp 1',
      điểmTrungBình: 8.0, // Điểm trung bình của lớp 1
    },
    {
      key: '2',
      lớp: 'Lớp 2',
      điểmTrungBình: 7.5, // Điểm trung bình của lớp 2
    },
    {
      key: '3',
      lớp: 'Lớp 3',
      điểmTrungBình: 8.2, // Điểm trung bình của lớp 3
    },
    // Có thể thêm nhiều hàng dữ liệu mẫu hơn ở đây
  ];

  // Định nghĩa cột cho bảng
  const columns = [
    {
      title: 'Lớp',
      dataIndex: 'lớp',
      key: 'lớp',
      className: 'text-center',
    },
    {
      title: 'Điểm Trung Bình',
      dataIndex: 'điểmTrungBình',
      key: 'điểmTrungBình',
      className: 'text-center',
    },
  ];

  return (
    <div className="flex flex-col items-center">
      <Row className="w-full justify-center">
        <div className="w-full max-w-4xl p-4"> {/* Điều chỉnh kích thước bảng */}
          <Table 
            className="m-0" 
            bordered 
            dataSource={data} 
            columns={columns}
            scroll={{ x: true }} // Cho phép cuộn ngang nếu bảng quá rộng
          />
        </div>
      </Row>
    </div>
  );
};

export default GradeTab;
