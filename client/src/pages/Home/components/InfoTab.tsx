import React from "react";
import { Row, Form, Input, Button, Select, notification } from "antd";
import { useUser } from "../../../utils/UserContext";

const InfoTab: React.FC = () => {
    const { user } = useUser();

    const openNotification = (message: string) => {
        notification.success({
            message: message,
            placement: 'topRight',
            duration: 3,
        });
    };

    const handleUpdate = (e: React.FormEvent) => {
        e.preventDefault();
        openNotification("Update thành công");
    };

    const handleInputChange = (field: string, value: string) => {
        //todo
        console.log(field);
        console.log(value);
    };

    return (
        <>
            <Row className="p-3">
                <h1>Thông tin cá nhân</h1>
            </Row>
            <Row className="mb-0 justify-center">
                <Form className="p-3 w-3/4 border-0" layout="vertical">
                    <Form.Item label="Fullname" className="mb-3">
                        <Input
                            id="fullname"
                            defaultValue={user?.FullName}
                            onChange={(e) => handleInputChange('FullName', e.target.value)}
                        />
                    </Form.Item>
                    <Form.Item label="Gender" className="mb-3">
                        <Select
                            defaultValue={user?.Sex}
                            onChange={(value) => handleInputChange('Sex', value)}
                        >
                            <Select.Option value="Male">Male</Select.Option>
                            <Select.Option value="Female">Female</Select.Option>
                            <Select.Option value="Other">Other</Select.Option>
                        </Select>
                    </Form.Item>
                    <Form.Item label="Email" className="mb-3">
                        <Input disabled id="mail" value={user?.Email} />
                    </Form.Item>
                    <Form.Item label="Date of Birth" className="mb-3">
                        <Input
                            id="dob"
                            type="date"
                            defaultValue={user?.DOB}
                            onChange={(e) => handleInputChange('DOB', e.target.value)}
                        />
                    </Form.Item>
                    <Form.Item label="Phone" className="mb-3">
                        <Input
                            id="phone"
                            type="tel"
                            defaultValue={user?.Phone}
                            onChange={(e) => handleInputChange('Phone', e.target.value)}
                        />
                    </Form.Item>
                    <Form.Item label="StudentID" className="mb-3">
                        <Input
                            id="studentid"
                            defaultValue={user?.StudentId}
                            onChange={(e) => handleInputChange('StudentId', e.target.value)}
                        />
                    </Form.Item>
                </Form>
            </Row>
            <Row className="d-flex align-items-end justify-content-end my-5">
                <Button type="primary" onClick={handleUpdate}>
                    Update
                </Button>
            </Row>
        </>
    );
};

export default InfoTab;
