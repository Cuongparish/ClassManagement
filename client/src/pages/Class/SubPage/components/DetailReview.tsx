import React, { useState } from "react";
import { Button, Input, Card, Typography } from "antd";

const { TextArea } = Input;
const { Title, Text } = Typography;

interface DetailReviewProps {
  reviewClicked: {
    idPhucKhao: number;
    TenCotDiem: string;
  };
  user: {
    FullName: string;
  };
  onClick: () => void;
}

const DetailReview: React.FC<DetailReviewProps> = ({ reviewClicked, user, onClick }) => {
  const [Replies, setReplies] = useState([
    {
      FullName: "Mai Anh Tuấn",
      ThoiGian: new Date(),
      TraoDoi: "Oke em thích thì tôi chiều",
    },
  ]);
  const [Content, setContent] = useState("");

  const handleReturnClick = () => {
    onClick();
  };

  const handleSendReply = () => {
    const newReply = {
      FullName: user.FullName,
      ThoiGian: new Date(),
      TraoDoi: Content,
    };
    setReplies([...Replies, newReply]);
    setContent("");
  };

  return (
    <>
      <div className="mb-2 flex justify-between items-center bg-white p-2">
        <Button type="link" onClick={handleReturnClick}>
          &lt; Return
        </Button>
      </div>
      <Card className="mb-2 border border-slate-400" bordered>
        <Title level={4} className="text-blue-500">
          Phúc khảo cột điểm {reviewClicked.TenCotDiem}
        </Title>
        <div className="mb-3">Sinh viên: {user.FullName}</div>
        <TextArea
          className="mb-2 border border-slate-400"
          value="Lý do phúc khảo"
          readOnly
        />
        <Input
          type="number"
          className="mb-2 border border-slate-400"
          value="10"
          readOnly
        />
        <Input
          type="number"
          className="mb-2 border border-slate-400"
          value="8"
          readOnly
        />
      </Card>
      <Card className="mb-2 bg-green-300">
        <Title level={5}>Đã trả lời</Title>
        {Replies.map((reply, index) => (
          <div key={index} className="mb-2">
            <Text strong>{reply.FullName}</Text> đã trả lời: <Text strong>{reply.ThoiGian.toLocaleString()}</Text>
            <TextArea
              className="mb-2"
              value={reply.TraoDoi}
              readOnly
            />
          </div>
        ))}
        <TextArea
          className="mb-2"
          placeholder="Viết phản hồi ..."
          value={Content}
          onChange={(e) => setContent(e.target.value)}
        />
        <Button type="primary" onClick={handleSendReply}>
          Gửi
        </Button>
      </Card>
    </>
  );
};

export default DetailReview;
