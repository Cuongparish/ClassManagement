import React, { useState } from 'react';
import { Row, Col, Modal, Button, Table, Input, Select } from 'antd';
import { FaUserPlus } from 'react-icons/fa';
import { DownloadButton, UploadButton } from '../../../../components/Button';

interface PersonProps {
  DetailClass: { MaLop: string; idLop: string };
  TeacherInClass: { FullName: string }[];
  StudentInClass: { FullName: string; StudentId: string }[];
}

const TeacherPeoplePage: React.FC<PersonProps> = ({ DetailClass, TeacherInClass, StudentInClass }) => {
  const malop = DetailClass?.MaLop;

  const [addTeacher, setAddTeacher] = useState(false);
  const [addStudent, setAddStudent] = useState(false);
  const [Email, setEmail] = useState('');
  const [Type, setType] = useState('xlsx');

  const handleSendToTeacher = async () => {
    // todo
    console.log(Email);
    console.log(malop);
  };

  const handleSendToStudent = async () => {
    // todo
  };

  const handleDownloadStudentList = async () => {
    // todo
  };

  const handleUploadStudentList = async () => {
    // todo
  };

  const handleFileChange = () => {
    // todo
  };

  return (
    <div className="mt-3">
      <Row className="mb-4 border-b-2 border-black">
        <Col span={12}>
          <div className="font-semibold text-2xl">Giáo viên</div>
        </Col>
        <Col span={12} className="text-right">
          <h3>
            <Button type="text" icon={<FaUserPlus />} onClick={() => setAddTeacher(true)} />
          </h3>
        </Col>
      </Row>

      <Table dataSource={TeacherInClass} pagination={false} rowKey={(record) => record.FullName}>
        <Table.Column title="Tên" dataIndex="FullName" />
      </Table>

      <Row className="mt-4 mb-4 border-b-2 border-black">
        <Col span={12}>
          <div className="font-semibold text-2xl">Sinh viên</div>
        </Col>
        <Col span={12} className="text-right">
          <h3>
            <Button type="text" icon={<FaUserPlus />} onClick={() => setAddStudent(true)} />
          </h3>
        </Col>
      </Row>

      <Table dataSource={StudentInClass} pagination={false} rowKey={(record) => record.StudentId}>
        <Table.Column title="Tên" dataIndex="FullName" />
        <Table.Column title="Mã Sinh Viên" dataIndex="StudentId" />
      </Table>

      <Row className="mt-4 mb-4">
        <Col span={12} className="flex flex-col items-center justify-center">
          <input type="file" onChange={handleFileChange} className="mb-3 w-2/3 border border-gray-300 rounded-r-md" />
          <UploadButton name="Upload Student List" onClick={handleUploadStudentList} className='w-2/3'/>
        </Col>
        <Col span={12} className="flex flex-col items-center justify-center">
          <Select defaultValue={Type} onChange={setType} className="mb-3 w-2/3 border border-gray-400 rounded-md">
            <Select.Option value="xlsx">xlsx</Select.Option>
            <Select.Option value="csv">csv</Select.Option>
          </Select>
          <DownloadButton name="Download Student List" onClick={handleDownloadStudentList} className='w-2/3'/>
        </Col>
      </Row>

      <Modal visible={addTeacher} title="Mời giáo viên" onCancel={() => setAddTeacher(false)} onOk={handleSendToTeacher}>
        <Input type="email" placeholder="name@example.com" onChange={(e) => setEmail(e.target.value)} />
      </Modal>

      <Modal visible={addStudent} title="Mời sinh viên" onCancel={() => setAddStudent(false)} onOk={handleSendToStudent}>
        <Input type="email" placeholder="name@example.com" onChange={(e) => setEmail(e.target.value)} />
      </Modal>
    </div>
  );
};

export default TeacherPeoplePage;
