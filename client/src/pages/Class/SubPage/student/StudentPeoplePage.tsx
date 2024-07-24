import React from 'react';
import { Row, Col, Table } from 'antd';

interface PersonProps {
  TeacherInClass: { FullName: string }[];
  StudentInClass: { FullName: string; StudentId: string }[];
}

const StudentPeoplePage: React.FC<PersonProps> = ({ TeacherInClass, StudentInClass }) => {
  return (
    <div className="mt-3">
      <Row className="mb-4 border-b-2 border-black">
        <Col span={24}>
          <div className="font-semibold text-2xl">Giáo viên</div>
        </Col>
      </Row>

      <Table dataSource={TeacherInClass} pagination={false} rowKey={(record) => record.FullName}>
        {/* <Table.Column title="Chọn" render={() => <Checkbox />} /> */}
        <Table.Column title="Tên" dataIndex="FullName" />
      </Table>

      <Row className="mt-4 mb-4 border-b-2 border-black">
        <Col span={24}>
          <div className="font-semibold text-2xl">Sinh viên</div>
        </Col>
      </Row>

      <Table dataSource={StudentInClass} pagination={false} rowKey={(record) => record.StudentId}>
        <Table.Column title="Tên" dataIndex="FullName" />
        <Table.Column title="Mã Sinh Viên" dataIndex="StudentId" />
      </Table>
    </div>
  );
};

export default StudentPeoplePage;
