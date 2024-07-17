import React, { useState } from "react";
import { Tabs } from "antd";
import { News } from "./SubPage"; // Adjust the import path as necessary


const { TabPane } = Tabs;

const ClassPage = (): React.ReactElement => {
  const [tab, setTab] = useState<string>("news");

  const DetailClass = {
    MaLop: "ABC123",
    TenLop: "Lớp học React",
  };

  const UserRoleInClass = "Teacher"; // Example role

  return (
    <div className="w-100 h-100 tab-menu">
      <Tabs
        defaultActiveKey={tab}
        onChange={(key) => setTab(key)}
        className="border-bottom border-2 px-3"
      >
        {/* Màn hình bảng tin */}
        <TabPane tab="Bảng tin" key="news">
          <News DetailClass={DetailClass} />
        </TabPane>

        {/* Màn hình bài tập */}
        <TabPane tab="Bài tập trên lớp" key="homework">
          <div>Bài tập trên lớp</div>
        </TabPane>

        {/* Màn hình mọi người */}
        <TabPane tab="Mọi người" key="members">
          {UserRoleInClass === "Teacher" ? (
            <div>Teacher's view of People</div>
          ) : (
            <div>Student's view of People</div>
          )}
        </TabPane>

        {/* Màn hình điểm */}
        <TabPane tab="Điểm" key="score">
          <div>Điểm</div>
        </TabPane>

        {/* Màn hình trao đổi */}
        <TabPane tab="Trao đổi" key="communication" className="h-100 bg-body-white p-2">
          {DetailClass && <div>List Review Component</div>}
        </TabPane>
      </Tabs>
    </div>
  );
};

export default ClassPage;
