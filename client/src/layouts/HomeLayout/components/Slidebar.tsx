import React from 'react';

import { Layout, Menu } from 'antd';
import type { MenuProps } from 'antd';

import "../../../App.css"

const { Sider } = Layout;

type MenuItem = Required<MenuProps>['items'][number];

function getItem(
    label: React.ReactNode,
    key: React.Key,
    icon?: React.ReactNode,
    children?: MenuItem[],
): MenuItem {
    return {
        key,
        icon,
        children,
        label,
    } as MenuItem;
}

const items: MenuItem[] = [
    getItem('Option 1', '1'),
    getItem('Option 2', '2'),
    getItem('User', 'sub1', <></>, [
        getItem('Tom', '3'),
        getItem('Bill', '4'),
        getItem('Alex', '5'),
    ]),
    getItem('Team', 'sub2', <></>, [getItem('Team 1', '6'), getItem('Team 2', '8')]),
    getItem('Files', '9'),
];


const Sidebar: React.FC = () => {

    return (
        <Sider className='fixed overflow-auto h-full bg-[#59599b]'>
            <Menu className='bg-[#59599b] font-semibold' defaultSelectedKeys={['1']} mode="inline" items={items} />
        </Sider>
    )
}

export default Sidebar;