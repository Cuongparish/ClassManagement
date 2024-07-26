import React, { useState } from 'react';
import { Table, Input, Button, Row, Col, notification } from 'antd';
import { ColumnsType } from 'antd/es/table';
import { FaSave } from "react-icons/fa";
import { IoSettingsOutline } from "react-icons/io5";
import { MdSystemUpdateAlt } from "react-icons/md";
import CreateScoreTableModal from './components/CreateScoreTable';
import SettingScoreModal from './components/SettingScoreModal';
import { GradeStructure } from './type';
import UpdateScoreModal from './components/UpdateScoreModal';

interface Student {
  id: string;
  name: string;
  studentId: string;
  scores: { [subject: string]: number };
  totalScore?: number;
}

const TeacherScoreTablePage: React.FC = () => {
  const students: Student[] = [
    {
      id: '1',
      name: 'Nguyen Van A',
      studentId: 'SV001',
      scores: { Homework: 8, Exam: 7 },
    },
    {
      id: '2',
      name: 'Tran Thi B',
      studentId: 'SV002',
      scores: { Homework: 9, Exam: 6 },
    },
  ];

  const gradeStructureData: GradeStructure = {
    idLop: '1',
    grades: [
      { name: 'Homework', percentage: 10, isPublic: false, isReconsiderable: false },
      { name: 'Exam', percentage: 90, isPublic: true, isReconsiderable: false },
    ],
  };

  const [dataSource, setDataSource] = useState<Student[]>(students);
  const [gradeStructure, setGradeStructure] = useState<GradeStructure | null>(gradeStructureData);
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [isEditModalVisible, setIsEditModalVisible] = useState(false);
  const [isUpdateScoreModal, setIsUpdateScoreModal] = useState(false);

  const handleScoreChange = (value: string, studentId: string, subjectName: string) => {
    if (gradeStructure) {
      const updatedData = dataSource.map(student => {
        if (student.id === studentId) {
          const newScores = { ...student.scores, [subjectName]: Number(value) };
          const totalScore = gradeStructure.grades.reduce((total, subject) => {
            return total + (newScores[subject.name] || 0) * (subject.percentage / 100);
          }, 0);
          return { ...student, scores: newScores, totalScore };
        }
        return student;
      });
      setDataSource(updatedData);
    }
  };

  const columns: ColumnsType<Student> = gradeStructure
    ? [
      {
        title: 'Họ Tên',
        dataIndex: 'name',
        key: 'name',
        className: 'text-center',
        render: (text: string) => <span className="text-center">{text}</span>,
      },
      {
        title: 'Mã Số Sinh Viên',
        dataIndex: 'studentId',
        key: 'studentId',
        className: 'text-center',
        render: (text: string) => <span className="text-center">{text}</span>,
      },
      ...gradeStructure.grades.map(grade => ({
        title: `${grade.name} (${grade.percentage}%)`,
        dataIndex: ['scores', grade.name],
        key: grade.name,
        className: 'text-center',
        render: (text: number, record: Student) => (
          <Input
            value={text}
            onChange={e => handleScoreChange(e.target.value, record.id, grade.name)}
            className="text-center"
          />
        ),
      })),
      {
        title: 'Tổng Kết',
        dataIndex: 'totalScore',
        key: 'totalScore',
        className: 'text-center',
        render: (text: number) => <span className="text-center">{text !== undefined ? text.toFixed(2) : ''}</span>,
      },
    ]
    : [];

  const showModal = () => {
    setIsModalVisible(true);
  };

  const handleModalCancel = () => {
    setIsModalVisible(false);
  };

  const handleModalSubmit = (newGradeStructure: GradeStructure) => {
    setGradeStructure(newGradeStructure);
    setIsModalVisible(false);
  };

  const handleSave = () => {
    notification.success({
      message: 'Lưu Thành Công',
      description: 'Dữ liệu đã được lưu thành công!',
      placement: 'bottomRight',
    });
  };

  const showEditModal = () => {
    setIsEditModalVisible(true);
  };

  const handleEditModalCancel = () => {
    setIsEditModalVisible(false);
  };

  const handleEditModalSubmit = (newGradeStructure: GradeStructure) => {
    setGradeStructure(newGradeStructure);
    setIsEditModalVisible(false);
  };

  const showUpdateScoreModal = () => {
    setIsUpdateScoreModal(true);
  };

  const handleUpdateScoreModalCancel = () => {
    setIsUpdateScoreModal(false);
  };

  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const handleExport = (_gradeName: string | null, _fileType: 'xlsx' | 'csv') => {
    // Implement export functionality
  };

  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const handleImport = (_gradeName: string, _fileType: 'xlsx' | 'csv') => {
    // Implement import functionality
  };

  const handleUpdate = (action: 'add' | 'delete', gradeName?: string, percentage?: number) => {
    if (gradeStructure) {
      const updatedGrades = [...gradeStructure.grades];
      if (action === 'add') {
        if (gradeName && percentage !== undefined) {
          updatedGrades.push({ name: gradeName, percentage, isPublic: false, isReconsiderable: false });
        }
      } else if (action === 'delete' && gradeName) {
        const indexToRemove = updatedGrades.findIndex(grade => grade.name === gradeName);
        if (indexToRemove !== -1) {
          updatedGrades.splice(indexToRemove, 1);
        }
      }
      setGradeStructure({ ...gradeStructure, grades: updatedGrades });
    }
  };

  return (
    <div className="container mx-auto">
      {gradeStructure ? (
        <div className="flex flex-col">
          <div className="flex-grow">
            <Table
              dataSource={dataSource}
              columns={columns}
              rowKey="id"
              className="w-full mt-4"
              pagination={false}
            />
          </div>
          <div className="flex justify-between items-center mt-4 mb-4">
            <div className="flex">
              <Button
                type="primary"
                icon={<FaSave />}
                onClick={handleSave}
                className="!bg-green-500 !border-green-500 !text-white hover:!bg-green-600 hover:!border-green-600"
              >
                Lưu bảng điểm
              </Button>
            </div>
            <div className="flex space-x-2">
              <Button
                type="primary"
                icon={<IoSettingsOutline />}
                onClick={() => showEditModal()}
                className="!bg-blue-500 !border-blue-500 !text-white hover:!bg-blue-600 hover:!border-blue-600"
              >
                Cài đặt bảng điểm
              </Button>
              <Button
                type="primary"
                icon={<MdSystemUpdateAlt />}
                onClick={showUpdateScoreModal}
                className="!bg-orange-500 !border-orange-500 !text-white hover:!bg-orange-600 hover:!border-orange-600"
              >
                Quản lý bảng điểm
              </Button>
            </div>
          </div>
          <SettingScoreModal
            visible={isEditModalVisible}
            gradeStructure={gradeStructure}
            onCancel={handleEditModalCancel}
            onSubmit={handleEditModalSubmit}
          />
          <UpdateScoreModal
            visible={isUpdateScoreModal}
            gradeStructure={gradeStructure}
            onCancel={handleUpdateScoreModalCancel}
            onExport={handleExport}
            onImport={handleImport}
            onUpdate={handleUpdate}
          />
        </div>
      ) : (
        <Row className="h-screen flex my-20 justify-center">
          <Col className="flex flex-col items-center">
            <img
              src={"/images/score_bg.png"}
              className="block pb-5 w-2/3"
              alt=""
            />
            <Button type="primary" onClick={showModal} className="block mx-auto">
              Tạo bảng điểm
            </Button>
          </Col>
        </Row>
      )}
      <CreateScoreTableModal
        visible={isModalVisible}
        onCancel={handleModalCancel}
        onSubmit={handleModalSubmit}
        gradeStructure={gradeStructure || { idLop: '1', grades: [] }}
      />
    </div>
  );
};

export default TeacherScoreTablePage;
