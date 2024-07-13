import React from 'react';
import LeftBanner from "./components/LeftBanner";
import { PrimaryButton } from "../../components/Button";
import { useNavigate } from "react-router-dom";
import "../../App.css";

const LandingPage = (): React.ReactElement => {
    const navigate = useNavigate();

    const handleButtonClick = () => {
        navigate('/login');
    };

    return (
        <div className="flex">
            <div className="left-banner h-screen w-1/3">
                <LeftBanner />
            </div>
            <div className="h-screen w-2/3">
                <img
                    src={"/images/content.png"}
                    className="block"
                    alt=""
                />
                <div className="text-center text-xl">
                    <h3 className="mt-5 font-bold">
                        MAKE YOUR GRADE SUMMARY EASIER AND FASTER
                    </h3>

                    <p className="mt-5">
                        The application supports easily restructuring scores, creating
                        scoreboards, easily tracking scores, and quickly receiving appeal
                        requests from students
                    </p>

                    <div className="mt-5">
                        <PrimaryButton name="Get Started" onClick={handleButtonClick} />
                    </div>
                </div>
            </div>
        </div>
    );
};

export default LandingPage;
