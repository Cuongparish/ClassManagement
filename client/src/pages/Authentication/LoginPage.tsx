import React from 'react';
import LeftBanner from "./components/LeftBanner";
import { PrimaryButton, GoogleButton, FaceBookButton } from "../../components/Button";

import { Link } from 'react-router-dom';
import { FaChevronLeft } from "react-icons/fa";
import { Input } from 'antd';

import "../../App.css";

const LoginPage = (): React.ReactElement => {
    return (
        <div className="flex">
            <div className="left-banner h-screen w-1/3">
                <LeftBanner />
            </div>
            <div className="h-screen w-2/3">
                <div className="flex justify-between">
                    <div className='text-xl pl-10 pt-5'>
                        <Link to="/" className='flex items-center text-black'>
                            <FaChevronLeft className='inline' /> Return Home
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
                    <div className="mt-5 text-3xl font-semibold">WELCOME BACK EXCLUSIVE MEMBER</div>
                    <div className="mt-2 mb-5">LOGIN TO CONTINUE</div>

                    <form className='text-left w-1/3 mx-auto mt-3'>
                        <label className='block font-medium' htmlFor='email'>Mail</label>
                        <Input placeholder='Email' className='w-full border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500 mb-5' />

                        <label className='block font-medium' htmlFor='email'>Password</label>
                        <Input.Password placeholder='Password' className='w-full border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500 mb-5' />

                        <div className='text-center mb-3'>
                            <PrimaryButton name='Login' />
                        </div>
                    </form>

                    <a href="/ResetPW">
                        <p className='underline underline-offset-4 hover:text-blue-600 mb-5'>Having Issues with your Password?</p>
                    </a>

                    <p className="font-middle">OR LOGIN WITH</p>

                    <div className='flex justify-center gap-4 mt-3'>
                        <GoogleButton name='Google' />
                        <FaceBookButton name='FaceBook' />
                    </div>
                </div>
            </div>
        </div>
    );
};

export default LoginPage;
