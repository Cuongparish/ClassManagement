import React from "react";
import { Row, Col, Card, Button, Input, notification } from "antd";
import { FaRegCopy, FaLink } from "react-icons/fa";
import { IoSettingsOutline } from "react-icons/io5";
import copy from "clipboard-copy";

const Client_URL = "http://localhost:3000";

interface DetailClassType {
  MaLop: string;
  TenLop: string;
}

interface NewsProps {
  DetailClass: DetailClassType;
}

const News: React.FC<NewsProps> = ({ DetailClass }) => {
  const link = `${Client_URL}/join-class/${DetailClass.MaLop}/hs`;

  const CopyCode = async (code: string) => {
    try {
      await copy(code);
      notification.success({
        message: "Success",
        description: "Đã sao chép mã!",
      });
    } catch (err) {
      notification.error({
        message: "Error",
        description: `Lỗi khi sao chép: ${err}`,
      });
    }
  };

  const CopyLink = async (link: string) => {
    try {
      await copy(link);
      notification.success({
        message: "Success",
        description: "Đã sao chép link!",
      });
    } catch (err) {
      notification.error({
        message: "Error",
        description: `Lỗi khi sao chép: ${err}`,
      });
    }
  };

  return (
    <div className="px-[5%] mb-5 mt-3 ">
      <Row className="mb-4 relative h-[250px] rounded-lg" style={{ backgroundImage: "url('images/detail_class_bg.png')" }}>
        <h1 className="absolute bottom-2.5 left-2.5 text-white m-0 p-0">{DetailClass.TenLop}</h1>
      </Row>

      <Row>
        <Col span={8} className="pr-4">
          <Card className="mb-4 border-2 border-gray-200">
            <Card.Meta title="Mã lớp" className="pb-2" />
            <Card className="border-t border-gray-200">
              <p className="text-2xl font-bold pb-2">{DetailClass.MaLop}</p>
              <Row gutter={16}>
                <Col span={12}>
                  <Button
                    onClick={() => CopyCode(DetailClass.MaLop)}
                    icon={<FaRegCopy />}
                  >
                    Copy Code
                  </Button>
                </Col>
                <Col span={12}>
                  <Button
                    onClick={() => CopyLink(link)}
                    icon={<FaLink />}
                  >
                    Copy Link
                  </Button>
                </Col>
              </Row>
            </Card>
          </Card>

          <Card className="border-2 border-gray-200">
            <Card.Meta title="Sắp đến hạn" className="pb-2"/>
            <Card className="border-t border-gray-200">
              <p className="text-muted">Không có bài tập nào sắp đến hạn</p>
              <Row justify="end">
                <a className="button">
                  Xem tất cả
                </a>
              </Row>
            </Card>
          </Card>
        </Col>

        <Col span={16}>
          <Input
            placeholder="Thông báo nội dung nào đó cho lớp học của ban"
            className="mb-4"
            disabled
          />

          <Card style={{ width: "100%" }} className="border-2 border-gray-200">
            <Card className="border-t border-gray-200">
              <h3>Đây là nơi bạn giao tiếp với cả lớp học của mình</h3>
              <p className="mb-4 text-muted">
                Sử dụng bảng tin để thông báo, đăng bài tập và trả lời câu hỏi
                của học viên
              </p>
              <Button
                icon={<IoSettingsOutline />}
                className="float-right"
                disabled
              >
                Cài đặt bảng tin
              </Button>
            </Card>
          </Card>
        </Col>
      </Row>
    </div>
  );
};

export default News;
