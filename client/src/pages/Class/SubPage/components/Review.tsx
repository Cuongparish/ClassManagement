import React from "react";
import { Card, Col, Row, Typography } from "antd";

const { Text, Title } = Typography;

interface ReviewProps {
  review: {
    TL: string;
    TenCotDiem: string;
    FullName: string;
  };
  onClick: () => void;
}

const Review: React.FC<ReviewProps> = ({ review, onClick }) => {
  const handleReviewClick = () => {
    onClick();
  };

  return (
    <Card
      onClick={handleReviewClick}
      hoverable
      className={`mb-6 cursor-pointer ${
        review.TL === "1" ? "bg-green-600" : "bg-red-600"
      }`}
    >
      <Row gutter={16} align="middle">
        <Col span={2}>
          <div
            className={`text-center font-bold text-white`}
          >
            {review.TL === "1" ? "Đã trả lời" : "Chưa trả lời"}
          </div>
        </Col>
        <Col span={22}>
          <div className="border border-gray-300 p-4 rounded-lg bg-white">
            <Title level={4}>
              Phúc khảo điểm {review?.TenCotDiem}
            </Title>
            <Text>Phúc khảo bởi học sinh {review?.FullName}</Text>
          </div>
        </Col>
      </Row>
    </Card>
  );
};

export default Review;
