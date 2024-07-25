import React, { useState, useEffect } from "react";
import Review from "./components/Review";
import DetailReview from "./components/DetailReview";
import { useUser } from "../../../utils/UserContext";

interface ReviewData {
  idPhucKhao: number;
  TL: string;
  TenCotDiem: string;
  FullName: string;
}

const ReviewPage: React.FC = () => {
  const { user } = useUser();

  const [ListReviewData, setListReviewData] = useState<ReviewData[]>([]);
  const [ReviewClicked, setReviewClicked] = useState<ReviewData | null>(null);
  const [showDetail, setShowDetail] = useState(false);

  const handleShowDetail = (review: ReviewData) => {
    setShowDetail(true);
    setReviewClicked(review);
  };

  const handleHideDetail = () => {
    setShowDetail(false);
  };

  const GetDataReview = async () => {
    // Mock data for example
    const mockData = [
      { idPhucKhao: 1, TL: "1", TenCotDiem: "Toán", FullName: "Nguyễn Văn A" },
      { idPhucKhao: 2, TL: "0", TenCotDiem: "Lý", FullName: "Trần Thị B" },
    ];
    setListReviewData(mockData);
  };

  useEffect(() => {
    GetDataReview();
  }, [user]);

  useEffect(() => {
    if (sessionStorage.getItem("idPhucKhao")) {
      const idPhucKhao = sessionStorage.getItem("idPhucKhao")!;
      const foundReview = ListReviewData.find((review) => String(review.idPhucKhao) === idPhucKhao);

      if (foundReview) {
        setReviewClicked(foundReview);
        setShowDetail(true);
      }
    }
  }, [ListReviewData]);

  return (
    <>
      {showDetail && ReviewClicked ? (
        <DetailReview onClick={handleHideDetail} reviewClicked={ReviewClicked} />
      ) : (
        <>
          {ListReviewData.map((review) => (
            <Review key={review.idPhucKhao} review={review} onClick={() => handleShowDetail(review)} />
          ))}
        </>
      )}
    </>
  );
};

export default ReviewPage;
