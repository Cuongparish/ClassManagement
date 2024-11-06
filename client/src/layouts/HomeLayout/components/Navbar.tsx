import React, { useState } from 'react';
import { Dropdown, Layout, Menu, Modal, Input, Button, Form } from 'antd';

import { CiCirclePlus } from "react-icons/ci";
import { VscBell } from "react-icons/vsc";
import { HiOutlineUserCircle } from "react-icons/hi2";
import { useNavigate } from 'react-router-dom';

import "../../../App.css";
import { useUser } from '../../../utils/UserContext';
import { creatClass } from '../../../services/class.service';

const { Header } = Layout;

interface CreateClassFormValue {
    className: string,
    subject: string,
    room?: string,
}

const Navbar: React.FC = () => {
    const navigate = useNavigate();

    const { user, setUser } = useUser();

    const [isJoinClassModalVisible, setJoinClassModalVisible] = useState(false);
    const [isCreateClassModalVisible, setCreateClassModalVisible] = useState(false);

    const showJoinClassModal = () => {
        setJoinClassModalVisible(true);
    };

    const handleJoinClassCancel = () => {
        setJoinClassModalVisible(false);
    };

    const showCreateClassModal = () => {
        setCreateClassModalVisible(true);
    };

    const handleCreateClassCancel = () => {
        setCreateClassModalVisible(false);
    };

    const handleJoinClassSubmit = (values: unknown) => {
        console.log('Join class with code:', values);
        setJoinClassModalVisible(false);
    };

    const handleCreateClassSubmit = async (values: CreateClassFormValue) => {
        try {
            if(user)
            {
                const res = await creatClass(values.className, values.subject, values.room, user.idUser, user.Token)
                // console.log(res);
                navigate(`/class/${res?.data.id}`);
            }

            setCreateClassModalVisible(false);
        } catch (error) {
            console.log(error);
        }
        
    };

    const logout = () => {
        sessionStorage.removeItem("user");
        setUser(null);
    };

    const dropdownStyle = {
        width: '200px',
        padding: '10px',
    };

    const plusMenu = (
        <Menu>
            <Menu.Item key="1" onClick={showJoinClassModal}>Tham gia lớp học</Menu.Item>
            <Menu.Item key="2" onClick={showCreateClassModal}>Tạo lớp học</Menu.Item>
        </Menu>
    );

    const listNotifycation = (
        <Menu>
            <Menu.Item key="1">Noti 1</Menu.Item>
            <Menu.Item key="2">Noti 2</Menu.Item>
        </Menu>
    );

    const userMenu = (
        <Menu>
            <Menu.Item key="1" onClick={() => navigate('/profile')}>Profile</Menu.Item>
            <Menu.Item key="2" onClick={logout}>Logout</Menu.Item>
        </Menu>
    );

    return (
        <Header
            style={{
                position: 'sticky',
                top: 0,
                zIndex: 1,
                width: '100%',
                display: 'flex',
                alignItems: 'center',
            }}
            className='menu-top justify-between'
        >
            <div className='flex items-center cursor-pointer' onClick={() => navigate('/home')}>
                <img
                    src={"/images/logo.png"}
                    className="inline w-12 h-12 mx-3"
                    alt="Logo"
                />
                <h3 className="text-white text-center text-xl mt-2">Grade Management</h3>
            </div>

            <div className='flex'>
                <Dropdown overlay={plusMenu} trigger={['click']} overlayStyle={dropdownStyle}>
                    <CiCirclePlus className='w-12 h-12 mx-3 cursor-pointer hover:text-fuchsia-400' />
                </Dropdown>
                <Dropdown overlay={listNotifycation} trigger={['click']} overlayStyle={dropdownStyle}>
                    <VscBell className='w-10 h-10 mt-1 mx-3 cursor-pointer hover:text-fuchsia-400' />
                </Dropdown>

                <Dropdown overlay={userMenu} trigger={['click']} overlayStyle={dropdownStyle}>
                    <HiOutlineUserCircle className='w-10 h-10 mt-1 mx-3 cursor-pointer hover:text-fuchsia-400' />
                </Dropdown>
            </div>

            <Modal
                title="Tham gia lớp học"
                visible={isJoinClassModalVisible}
                onCancel={handleJoinClassCancel}
                footer={null}
            >
                <Form onFinish={handleJoinClassSubmit}>
                    <Form.Item
                        name="classCode"
                        rules={[{ required: true, message: 'Vui lòng nhập mã lớp!' }]}
                    >
                        <Input placeholder="Mã lớp" />
                    </Form.Item>
                    <Form.Item>
                        <Button type="primary" htmlType="submit">
                            Tham gia
                        </Button>
                        <Button onClick={handleJoinClassCancel} style={{ marginLeft: '8px' }}>
                            Hủy
                        </Button>
                    </Form.Item>
                </Form>
            </Modal>

            <Modal
                title="Tạo lớp học"
                visible={isCreateClassModalVisible}
                onCancel={handleCreateClassCancel}
                footer={null}
            >
                <Form onFinish={handleCreateClassSubmit}>
                    <Form.Item
                        name="className"
                        rules={[{ required: true, message: 'Vui lòng nhập tên lớp học!' }]}
                        label="Tên lớp"
                    >
                        <Input placeholder="Tên lớp học" />
                    </Form.Item>
                    <Form.Item
                        name="subject"
                        rules={[{ required: true, message: 'Vui lòng nhập chủ đề!' }]}
                        label="Chủ đề"
                    >
                        <Input placeholder="Chủ đề" />
                    </Form.Item>
                    <Form.Item
                        name="room"
                        label="Phòng học"
                    >
                        <Input placeholder="Phòng" />
                    </Form.Item>
                    <Form.Item>
                        <Button type="primary" htmlType="submit">
                            Tạo
                        </Button>
                        <Button onClick={handleCreateClassCancel} style={{ marginLeft: '8px' }}>
                            Hủy
                        </Button>
                    </Form.Item>
                </Form>
            </Modal>
        </Header>
    );
};

export default Navbar;
