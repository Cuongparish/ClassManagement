import React, { useState } from "react";
import { Tabs } from "antd";
import { News, ReviewPage, StudentPeoplePage, TeacherPeoplePage } from "./SubPage";
import StudentScoreTablePage from "./SubPage/student/StudentScoreTablePage";
import TeacherScoreTablePage from "./SubPage/teacher/TeacherScoreTablePage";
// import { useUser } from "../../utils/UserContext";

const { TabPane } = Tabs;

const ClassPage = (): React.ReactElement => {
  const [tab, setTab] = useState<string>("news");

  // const { user } = useUser();

  const DetailClass = {
    MaLop: "ABC123",
    idLop: "123456",
    TenLop: "Lớp học React",
  };

  type Role = "Student" | "Teacher";

  const UserRoleInClass: Role = "Teacher";

  const teachers = [
    { FullName: "Giáo viên 1" },
    { FullName: "Giáo viên 2" },
    { FullName: "Giáo viên 3" },
  ];

  const students = [
    { FullName: "Sinh viên 1", StudentId: "SV001" },
    { FullName: "Sinh viên 2", StudentId: "SV002" },
    { FullName: "Sinh viên 3", StudentId: "SV003" },
  ];

  const isTeacher = (role: Role): boolean => {
    return role === "Teacher";
  };

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

        {/* Màn hình mọi người */}
        <TabPane tab="Mọi người" key="members">
          {isTeacher(UserRoleInClass) ? (
            <TeacherPeoplePage DetailClass={DetailClass} TeacherInClass={teachers} StudentInClass={students} />
          ) : (
            <StudentPeoplePage TeacherInClass={teachers} StudentInClass={students} />
          )}
        </TabPane>

        {/* Màn hình điểm */}
        <TabPane tab="Điểm" key="score">
          {isTeacher(UserRoleInClass) ? (
            <TeacherScoreTablePage />
          ) : (
            <StudentScoreTablePage />
          )}
        </TabPane>

        {/* Màn hình trao đổi */}
        <TabPane tab="Trao đổi" key="communication" className="h-100 bg-body-white p-2">
          {DetailClass && <ReviewPage />}
        </TabPane>
      </Tabs>
    </div>
  );
};

export default ClassPage;
