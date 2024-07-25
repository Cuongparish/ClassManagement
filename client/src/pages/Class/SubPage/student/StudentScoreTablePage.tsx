import React, { useState, useEffect } from "react";
import { Row, Col, Table, Modal, Card, Button, Form, Input, Select, notification } from "antd";
import { useUser } from "../../../../utils/UserContext";
import "../../../../App.css";

const { Option } = Select;
const { TextArea } = Input;

interface GradeStructure {
    idLop: string;
    TenCotDiem: string;
    PhanTramDiem: number;
    AcpPhucKhao: number;
}

interface StudentScore {
    FullName: string;
    StudentId: string;
    Diem: number[];
    total: number;
}

interface State {
    showRequest: boolean;
    studentHaveScore: StudentScore | undefined;
    gradeStructuresPublic: GradeStructure[] | null;
    totalPercent: number;
    selectedGradeColumn: GradeStructure | undefined;
    gradeCurrent: number;
    gradeExpect: number | undefined;
    reason: string;
    gradeErrors: boolean;
}

const StudentScoreTablePage: React.FC = () => {
    const gradestructure: GradeStructure[] | null = [
        {
            idLop: "123456",
            TenCotDiem: "Điểm giữa kỳ",
            PhanTramDiem: 10,
            AcpPhucKhao: 1,
        },
        {
            idLop: "123456",
            TenCotDiem: "Điểm cuối kỳ",
            PhanTramDiem: 30,
            AcpPhucKhao: 0,
        },
        {
            idLop: "123456",
            TenCotDiem: "Điểm bài tập",
            PhanTramDiem: 20,
            AcpPhucKhao: 1,
        },
        {
            idLop: "123456",
            TenCotDiem: "Điểm thuyết trình",
            PhanTramDiem: 20,
            AcpPhucKhao: 0,
        },
        {
            idLop: "123456",
            TenCotDiem: "Điểm tham gia",
            PhanTramDiem: 20,
            AcpPhucKhao: 1,
        },
    ];

    const { user } = useUser();

    const [state, setState] = useState<State>({
        showRequest: false,
        studentHaveScore: undefined,
        gradeStructuresPublic: gradestructure,
        totalPercent: 0,
        selectedGradeColumn: undefined,
        gradeCurrent: 0,
        gradeExpect: undefined,
        reason: "",
        gradeErrors: false,
    });

    useEffect(() => {
        if (state.gradeStructuresPublic && state.gradeStructuresPublic.length > 0) {
            const studentWithScore: StudentScore = {
                FullName: user?.FullName || "Student Name",
                StudentId: user?.StudentId || "S123456",
                Diem: [8, 9],
                total: 4.5,
            };

            const selectedGradeColumn = state.gradeStructuresPublic.find(gs => gs.AcpPhucKhao === 1);
            const gradeIndex = state.gradeStructuresPublic.findIndex(gs => gs.AcpPhucKhao === 1);

            setState({
                ...state,
                studentHaveScore: studentWithScore,
                selectedGradeColumn,
                gradeCurrent: studentWithScore.Diem[gradeIndex],
            });

            const total = state.gradeStructuresPublic.reduce((acc, { PhanTramDiem }) => acc + PhanTramDiem, 0);
            setState((prevState) => ({ ...prevState, totalPercent: total }));
        }
    }, [state.gradeStructuresPublic, user]);

    const handleSendReview = async () => {
        // Here you can add your logic to send the review
        // For example, make an API call to submit the review

        // After the review is successfully sent
        notification.success({
            message: "Phúc khảo thành công",
            description: "Yêu cầu phúc khảo của bạn đã được gửi thành công.",
        });

        // Close the modal
        setState((prevState) => ({ ...prevState, showRequest: false }));
    };

    const columns = [
        {
            title: 'Họ và tên',
            dataIndex: 'FullName',
            key: 'FullName',
        },
        {
            title: 'MSSV',
            dataIndex: 'StudentId',
            key: 'StudentId',
        },
        ...(state.gradeStructuresPublic && state.gradeStructuresPublic.length > 0
            ? state.gradeStructuresPublic.map((gradeStructure, index) => ({
                title: (
                    <div>
                        <div>{gradeStructure.TenCotDiem}</div>
                        <div>{gradeStructure.PhanTramDiem}%</div>
                    </div>
                ),
                dataIndex: `Diem_${index}`,
                key: `Diem_${index}`,
                render: (_: unknown, record: StudentScore) => record.Diem[index],
            }))
            : []),
        {
            title: (
                <div>
                    <div>Tổng kết</div>
                    <div>{state.totalPercent}%</div>
                </div>
            ),
            dataIndex: 'total',
            key: 'total',
        },
    ];

    return (
        <>
            {state.gradeStructuresPublic && state.gradeStructuresPublic.length > 0 ? (
                <>
                    <Row className="d-flex align-items-center justify-center">
                        <Table
                            dataSource={state.studentHaveScore ? [state.studentHaveScore] : []}
                            columns={columns}
                            pagination={false}
                            bordered
                            className="m-0"
                        />
                    </Row>

                    <Row className="d-flex align-items-end justify-end my-5">
                        <Col>
                            <Button type="primary" onClick={() => setState((prevState) => ({ ...prevState, showRequest: true }))}>
                                Phúc khảo
                            </Button>
                        </Col>
                    </Row>

                    <Modal
                        title="Thông tin phúc khảo"
                        visible={state.showRequest}
                        onCancel={() => setState((prevState) => ({ ...prevState, showRequest: false }))}
                        footer={[
                            <Button key="cancel" onClick={() => setState((prevState) => ({ ...prevState, showRequest: false }))}>
                                Hủy
                            </Button>,
                            <Button key="submit" type="primary" onClick={handleSendReview}>
                                Gửi
                            </Button>,
                        ]}
                    >
                        <Card className="border-0">
                            <Form layout="vertical">
                                <Form.Item label="Cột điểm có thể phúc khảo">
                                    <Select
                                        value={state.selectedGradeColumn?.TenCotDiem}
                                        onChange={(value) => {
                                            if (state.gradeStructuresPublic) {
                                                const gradeIndex = state.gradeStructuresPublic.findIndex(gs => gs.TenCotDiem === value);
                                                const gradeColumn = state.gradeStructuresPublic.find(gs => gs.TenCotDiem === value);
                                                setState((prevState) => ({
                                                    ...prevState,
                                                    selectedGradeColumn: gradeColumn,
                                                    gradeCurrent: state.studentHaveScore ? state.studentHaveScore.Diem[gradeIndex] : 0,
                                                }));
                                            }
                                        }}
                                    >
                                        {state.gradeStructuresPublic.filter(gs => gs.AcpPhucKhao === 1).map((gradeStructure, index) => (
                                            <Option key={index} value={gradeStructure.TenCotDiem}>
                                                {gradeStructure.TenCotDiem}
                                            </Option>
                                        ))}
                                    </Select>
                                </Form.Item>
                                <Form.Item label="Điểm hiện tại">
                                    <Input value={state.gradeCurrent} disabled />
                                </Form.Item>
                                <Form.Item
                                    label="Điểm kỳ vọng"
                                    validateStatus={state.gradeErrors ? "error" : ""}
                                    help={state.gradeErrors ? "Số điểm không phù hợp" : ""}
                                >
                                    <Input
                                        type="number"
                                        min="0"
                                        max="10"
                                        step="0.25"
                                        placeholder="/10"
                                        onChange={(event) => {
                                            const grade = parseFloat(event.target.value);
                                            if (!isNaN(grade) && grade >= 0 && grade <= 10) {
                                                setState((prevState) => ({
                                                    ...prevState,
                                                    gradeExpect: grade,
                                                    gradeErrors: false,
                                                }));
                                            } else {
                                                setState((prevState) => ({
                                                    ...prevState,
                                                    gradeErrors: true,
                                                }));
                                            }
                                        }}
                                    />
                                </Form.Item>
                                <Form.Item label="Lý do">
                                    <TextArea
                                        style={{ height: 120, resize: "none" }}
                                        placeholder="Vui lòng nhập lý do"
                                        onChange={(event) => setState((prevState) => ({ ...prevState, reason: event.target.value }))}
                                    />
                                </Form.Item>
                            </Form>
                        </Card>
                    </Modal>
                </>
            ) : (
                <Row className="h-screen flex items-center justify-center">
                    <Col className="flex flex-col items-center">
                        <img
                            src={"/images/score_table_student.png"}
                            className="block pb-5 w-1/3"
                            alt=""
                        />
                        <h1 className="text-center text-3xl">Rất tiếc chưa có điểm</h1>
                    </Col>
                </Row>

            )}
        </>
    );
};

export default StudentScoreTablePage;
