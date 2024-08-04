import React, { useEffect } from 'react';
import { Modal, Form, Select, Button, notification } from 'antd';
import { GradeStructure } from '../type';

interface EditSubjectModalProps {
  visible: boolean;
  gradeStructure: GradeStructure;
  onCancel: () => void;
  onSubmit: (updatedGradeStructure: GradeStructure) => void;
}

interface FormValues {
  gradeName: string;
  isPublic: 'public' | 'not_public';
  isReconsiderable: 'reconsiderable' | 'not_reconsiderable';
}

const SettingScoreModal: React.FC<EditSubjectModalProps> = ({ visible, gradeStructure, onCancel, onSubmit }) => {
  const [form] = Form.useForm();

  useEffect(() => {
    if (gradeStructure.grades.length > 0) {
      const firstGrade = gradeStructure.grades[0];
      form.setFieldsValue({
        gradeName: firstGrade.name,
        isPublic: firstGrade.isPublic ? 'public' : 'not_public',
        isReconsiderable: firstGrade.isReconsiderable ? 'reconsiderable' : 'not_reconsiderable',
      });
    }
  }, [gradeStructure, form]);

  const handleGradeChange = (gradeName: string) => {
    const selectedGrade = gradeStructure.grades.find(grade => grade.name === gradeName);
    if (selectedGrade) {
      form.setFieldsValue({
        isPublic: selectedGrade.isPublic ? 'public' : 'not_public',
        isReconsiderable: selectedGrade.isReconsiderable ? 'reconsiderable' : 'not_reconsiderable',
      });
    }
  };

  const handleSubmit = (values: FormValues) => {
    const updatedGrades = gradeStructure.grades.map(grade => {
      if (grade.name === values.gradeName) {
        return {
          ...grade,
          isPublic: values.isPublic === 'public',
          isReconsiderable: values.isReconsiderable === 'reconsiderable',
        };
      }
      return grade;
    });
    onSubmit({ ...gradeStructure, grades: updatedGrades });

    // Show success notification
    notification.success({
      message: 'Thành công',
      description: `Cột điểm ${values.gradeName} đã được cập nhật thành công`,
    });
  };

  return (
    <Modal
      title="Chỉnh sửa cột điểm"
      visible={visible}
      onCancel={onCancel}
      footer={null}
    >
      <Form
        form={form}
        layout="vertical"
        onFinish={handleSubmit}
      >
        <Form.Item
          name="gradeName"
          label="Chọn Cột Điểm"
          rules={[{ required: true, message: 'Vui lòng chọn cột điểm' }]}
        >
          <Select onChange={handleGradeChange}>
            {gradeStructure.grades.map(grade => (
              <Select.Option key={grade.name} value={grade.name}>
                {grade.name} ({grade.percentage}%)
              </Select.Option>
            ))}
          </Select>
        </Form.Item>

        <Form.Item
          name="isPublic"
          label="Công bố"
          rules={[{ required: true, message: 'Vui lòng chọn công bố' }]}
        >
          <Select>
            <Select.Option value="public">Công bố</Select.Option>
            <Select.Option value="not_public">Không công bố</Select.Option>
          </Select>
        </Form.Item>

        <Form.Item
          name="isReconsiderable"
          label="Phúc khảo"
          rules={[{ required: true, message: 'Vui lòng chọn phúc khảo' }]}
        >
          <Select>
            <Select.Option value="reconsiderable">Có thể phúc khảo</Select.Option>
            <Select.Option value="not_reconsiderable">Không thể phúc khảo</Select.Option>
          </Select>
        </Form.Item>

        <Form.Item>
          <Button type="primary" htmlType="submit">
            Lưu
          </Button>
        </Form.Item>
      </Form>
    </Modal>
  );
};

export default SettingScoreModal;
