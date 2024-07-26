import React from 'react';
import { Modal, Form, Input, InputNumber, Button, Space } from 'antd';
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons';
import { GradeStructure } from '../type';

interface CreateScoreTableModalProps {
  visible: boolean;
  onCancel: () => void;
  onSubmit: (gradeStructure: GradeStructure) => void;
  gradeStructure: GradeStructure;
}

const CreateScoreTableModal: React.FC<CreateScoreTableModalProps> = ({ visible, onCancel, onSubmit, gradeStructure }) => {
  const [form] = Form.useForm();

  const handleFinish = (values: GradeStructure) => {
    const newGradeStructure: GradeStructure = {
      idLop: values.idLop,
      grades: values.grades,
    };
    onSubmit(newGradeStructure);
  };

  return (
    <Modal
      title="Tạo bảng điểm"
      visible={visible}
      onCancel={onCancel}
      footer={null}
      className="p-4" // Optional: Add padding to the modal
    >
      <Form
        form={form}
        layout="vertical"
        initialValues={{ idLop: gradeStructure.idLop, subjects: gradeStructure.grades }}
        onFinish={handleFinish}
      >
        <Form.Item
          name="idLop"
          label="Mã lớp"
          className="mb-4"
        >
          <Input placeholder="Nhập mã lớp" disabled className="w-full" />
        </Form.Item>
        <Form.List name="subjects">
          {(fields, { add, remove }) => (
            <>
              {fields.map(({ key, name, fieldKey, ...restField }) => (
                <Space key={key || name} style={{ display: 'flex', marginBottom: 8, width: '100%' }} align="baseline">
                  <Form.Item
                    {...restField}
                    name={[name, 'name']}
                    fieldKey={[fieldKey!, 'name']}
                    rules={[{ required: true, message: 'Vui lòng nhập tên môn học' }]}
                    className="w-full"
                  >
                    <Input placeholder="Tên cột điểm" className="w-full" />
                  </Form.Item>
                  <Form.Item
                    {...restField}
                    name={[name, 'percentage']}
                    fieldKey={[fieldKey!, 'percentage']}
                    rules={[{ required: true, message: 'Vui lòng nhập phần trăm điểm' }]}
                    className="w-full"
                  >
                    <InputNumber placeholder="Phần trăm điểm" min={0} max={100} className="w-full" />
                  </Form.Item>
                  <MinusCircleOutlined onClick={() => remove(name)} />
                </Space>
              ))}
              <Form.Item>
                <Button type="dashed" onClick={() => add()} block icon={<PlusOutlined />}>
                  Thêm cột điểm
                </Button>
              </Form.Item>
            </>
          )}
        </Form.List>
        <Form.Item>
          <Button type="primary" htmlType="submit" className="w-full">
            Tạo bảng điểm
          </Button>
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default CreateScoreTableModal;
