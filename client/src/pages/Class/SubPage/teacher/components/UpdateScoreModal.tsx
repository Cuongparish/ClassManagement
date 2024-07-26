import React, { useState } from 'react';
import { Modal, Form, Select, Button, Tabs, Input, notification } from 'antd';
import { GradeStructure } from '../type';

interface TabbedModalProps {
  visible: boolean;
  gradeStructure: GradeStructure;
  onCancel: () => void;
  onExport: (gradeName: string | null, fileType: 'xlsx' | 'csv') => void;
  onImport: (gradeName: string, fileType: 'xlsx' | 'csv') => void;
  onUpdate: (action: 'add' | 'delete', gradeName?: string, percentage?: number) => void;
}

const { TabPane } = Tabs;

const UpdateScoreModal: React.FC<TabbedModalProps> = ({ visible, gradeStructure, onCancel, onExport, onImport, onUpdate }) => {
  const [exportForm] = Form.useForm();
  const [importForm] = Form.useForm();
  const [updateForm] = Form.useForm();
  const [selectedAction, setSelectedAction] = useState<'add' | 'delete'>('add');

  const defaultGradeName = gradeStructure.grades.length > 0 ? gradeStructure.grades[0].name : '';
  const defaultFileType = 'xlsx';

  const handleExport = (values: { gradeName: string | null; fileType: 'xlsx' | 'csv'; }) => {
    const { gradeName, fileType } = values;
    onExport(gradeName === 'all' ? null : gradeName, fileType);
    notification.success({
      message: 'Thành công',
      description: 'Export thành công',
    });
  };

  const handleImport = (values: { gradeName: string; fileType: 'xlsx' | 'csv'; }) => {
    const { gradeName, fileType } = values;
    onImport(gradeName, fileType);
    notification.success({
      message: 'Thành công',
      description: 'Import thành công',
    });
  };

  const handleUpdate = (values: { gradeName: string; percentage?: number; }) => {
    if (selectedAction === 'add') {
      const { gradeName, percentage } = values;
      onUpdate('add', gradeName, percentage);
    } else if (selectedAction === 'delete') {
      const { gradeName } = values;
      onUpdate('delete', gradeName);
    }
    notification.success({
      message: 'Thành công',
      description: 'Update thành công',
    });
  };

  return (
    <Modal
      title="Quản lý cột điểm"
      visible={visible}
      onCancel={onCancel}
      footer={null}
    >
      <Tabs defaultActiveKey="1">
        <TabPane tab="Export" key="1">
          <Form
            form={exportForm}
            layout="vertical"
            onFinish={handleExport}
            initialValues={{ gradeName: defaultGradeName, fileType: defaultFileType }}
          >
            <Form.Item
              name="gradeName"
              label="Chọn Cột Điểm"
              rules={[{ required: true, message: 'Vui lòng chọn cột điểm' }]}
            >
              <Select defaultValue={defaultGradeName}>
                <Select.Option value="all">Cả bảng điểm</Select.Option>
                {gradeStructure.grades.map(grade => (
                  <Select.Option key={grade.name} value={grade.name}>
                    {grade.name}
                  </Select.Option>
                ))}
              </Select>
            </Form.Item>
            <Form.Item
              name="fileType"
              label="Chọn loại file"
              rules={[{ required: true, message: 'Vui lòng chọn loại file' }]}
            >
              <Select defaultValue={defaultFileType}>
                <Select.Option value="xlsx">xlsx</Select.Option>
                <Select.Option value="csv">csv</Select.Option>
              </Select>
            </Form.Item>
            <Form.Item>
              <Button type="primary" htmlType="submit">
                Export
              </Button>
            </Form.Item>
          </Form>
        </TabPane>
        <TabPane tab="Import" key="2">
          <Form
            form={importForm}
            layout="vertical"
            onFinish={handleImport}
            initialValues={{ gradeName: defaultGradeName, fileType: defaultFileType }}
          >
            <Form.Item
              name="gradeName"
              label="Chọn Cột Điểm"
              rules={[{ required: true, message: 'Vui lòng chọn cột điểm' }]}
            >
              <Select defaultValue={defaultGradeName}>
                {gradeStructure.grades.map(grade => (
                  <Select.Option key={grade.name} value={grade.name}>
                    {grade.name}
                  </Select.Option>
                ))}
              </Select>
            </Form.Item>
            <Form.Item
              name="fileType"
              label="Chọn loại file"
              rules={[{ required: true, message: 'Vui lòng chọn loại file' }]}
            >
              <Select defaultValue={defaultFileType}>
                <Select.Option value="xlsx">xlsx</Select.Option>
                <Select.Option value="csv">csv</Select.Option>
              </Select>
            </Form.Item>
            <Form.Item>
              <Button type="primary" htmlType="submit">
                Import
              </Button>
            </Form.Item>
          </Form>
        </TabPane>
        <TabPane tab="Update" key="3">
          <Form
            form={updateForm}
            layout="vertical"
            onFinish={handleUpdate}
          >
            <Form.Item
              name="action"
              label="Chọn thao tác"
              rules={[{ required: true, message: 'Vui lòng chọn thao tác' }]}
            >
              <Select onChange={(value: 'add' | 'delete') => setSelectedAction(value)} defaultValue="add">
                <Select.Option value="add">Thêm</Select.Option>
                <Select.Option value="delete">Xóa</Select.Option>
              </Select>
            </Form.Item>
            {selectedAction === 'add' ? (
              <>
                <Form.Item
                  name="gradeName"
                  label="Tên Cột Điểm"
                  rules={[{ required: true, message: 'Vui lòng nhập tên cột điểm' }]}
                >
                  <Input placeholder='Tên cột điểm'/>
                </Form.Item>
                <Form.Item
                  name="percentage"
                  label="Phần Trăm"
                  rules={[{ required: true, message: 'Vui lòng nhập phần trăm' }]}
                >
                  <Input type="number" placeholder='Phần trăm cột điểm' />
                </Form.Item>
              </>
            ) : (
              <Form.Item
                name="gradeName"
                label="Chọn Cột Điểm"
                rules={[{ required: true, message: 'Vui lòng chọn cột điểm' }]}
              >
                <Select defaultValue={defaultGradeName}>
                  {gradeStructure.grades.filter(grade => !grade.isPublic).map(grade => (
                    <Select.Option key={grade.name} value={grade.name}>
                      {grade.name}
                    </Select.Option>
                  ))}
                </Select>
              </Form.Item>
            )}
            <Form.Item>
              <Button type="primary" htmlType="submit">
                Lưu
              </Button>
            </Form.Item>
          </Form>
        </TabPane>
      </Tabs>
    </Modal>
  );
};

export default UpdateScoreModal;
