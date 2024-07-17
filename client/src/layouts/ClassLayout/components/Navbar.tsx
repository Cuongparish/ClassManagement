import React from 'react';
import { Dropdown, Layout, Menu } from 'antd';

import { VscBell } from "react-icons/vsc";
import { HiOutlineUserCircle } from "react-icons/hi2";
// import { VscBellDot } from "react-icons/vsc";

import "../../../App.css"


const { Header } = Layout;


const Navbar: React.FC = () => {
    const dropdownStyle = {
        width: '200px',
        padding: '10px',
    };

    const listNotifycation = (
        <Menu>
            <Menu.Item key="1">Noti 1</Menu.Item>
            <Menu.Item key="2">Noti 2</Menu.Item>
        </Menu>
    );

    const userMenu = (
        <Menu>
            <Menu.Item key="1">Profile</Menu.Item>
            <Menu.Item key="2">Logout</Menu.Item>
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
            <div className='flex'>
                <img
                    src={"/images/logo.png"}
                    className="inline w-12 h-12 mx-3"
                    alt=""
                />
                <h3 className="text-white text-center text-xl mt-2">Grade Management</h3>
            </div>

            <div className='flex'>
                <Dropdown overlay={listNotifycation} trigger={['click']} overlayStyle={dropdownStyle}>
                    <VscBell className='w-10 h-10 mt-1 mx-3 cursor-pointer hover:text-fuchsia-400' />
                </Dropdown>

                <Dropdown overlay={userMenu} trigger={['click']} overlayStyle={dropdownStyle}>
                    <HiOutlineUserCircle className='w-10 h-10 mt-1 mx-3 cursor-pointer hover:text-fuchsia-400' />
                </Dropdown>
            </div>
        </Header>

    );
};

export default Navbar;