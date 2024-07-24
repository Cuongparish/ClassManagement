import React from "react";
import { Tabs } from "antd";
import InfoTab from "./components/InfoTab";
import GradeTab from "./components/GradeTab";

const { TabPane } = Tabs;

const ProfilePage = (): React.ReactElement => {

    return (
        <div className="w-full h-full tab-menu">
            <Tabs defaultActiveKey="info" className="border-b-2 px-3">
                <TabPane tab="Thông tin" key="info">
                    <InfoTab />
                </TabPane>
                <TabPane tab="Điểm" key="score">
                    <GradeTab />
                </TabPane>
            </Tabs>
        </div>
    );
};

export default ProfilePage;
