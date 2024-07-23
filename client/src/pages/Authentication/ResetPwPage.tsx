import React from 'react';
import { Link } from 'react-router-dom';
import { FaChevronLeft } from "react-icons/fa";
import { Input, notification } from 'antd';
import LeftBanner from "./components/LeftBanner";
import { PrimaryButton } from "../../components/Button";
import "../../App.css";

const ResetPasswordPage = (): React.ReactElement => {
    const handleSendClick = () => {
        notification.success({
            message: 'Success',
            description: 'New password has been sent to your email.',
            placement: 'bottomRight',
            duration: 3,
        });
    };

    return (
        <div className="flex">
            <div className="left-banner h-screen w-1/3">
                <LeftBanner />
            </div>
            <div className="h-screen w-2/3">
                <div className="flex justify-between">
                    <div className='text-xl pl-10 pt-5'>
                        <Link to="/login" className='flex items-center text-black'>
                            <FaChevronLeft className='inline' /> Return LOGIN PAGE
                        </Link>
                    </div>
                    <div className='text-xl pr-5 pt-5'>
                        <span>
                            Not a Member?
                            <a href="/signup">
                                {" "}
                                <span className='underline underline-offset-4 hover:text-blue-600'>SIGN UP NOW{" "}</span>
                            </a>
                        </span>
                    </div>
                </div>

                <div className='flex flex-col text-center mt-10 text-lg'>
                    <div className="mt-5 text-3xl font-semibold">FORGOT PASSWORD</div>
                    <div className="mt-2 mb-5">Please enter the email of your account!</div>

                    <form className='text-left w-1/3 mx-auto mt-3'>
                        <label className='block font-medium' htmlFor='email'>Mail</label>
                        <Input placeholder='Email' className='w-full border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500 mb-5' />

                        <div className='text-center mb-3'>
                            <PrimaryButton name='Send' onClick={handleSendClick} />
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default ResetPasswordPage;
