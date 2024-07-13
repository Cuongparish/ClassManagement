import React from 'react';
import LeftBanner from "./components/LeftBanner";
import { PrimaryButton } from "../../components/Button";

import { Link } from 'react-router-dom';
import { FaChevronLeft } from "react-icons/fa";
import { Checkbox, DatePicker, Input, Select } from 'antd';

import "../../App.css";

const SignupPage = (): React.ReactElement => {
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
                            Already a Member?
                            <a href="/login">
                                {" "}
                                <span className='underline underline-offset-4 hover:text-blue-600'>LOGIN NOW{" "}</span>
                            </a>
                        </span>
                    </div>
                </div>

                <div className='flex flex-col text-center mt-10 text-lg'>
                    <div className="mt-5 text-3xl font-semibold">BECOME AN EXCLUSIVE MEMBERS</div>
                    <div className="mt-2 mb-5">SIGN UP AND JOIN OUR MEMBER</div>

                    <form className='text-left w-4/5 mx-auto mt-3'>
                        <div className="flex flex-wrap -mx-5">
                            <div className="w-1/2 px-5 mb-5">
                                <label className="block font-medium" htmlFor="fullname">Fullname</label>
                                <Input placeholder="Full Name" className="w-full border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500 mb-5" />
                            </div>

                            <div className="w-1/2 px-5 mb-5">
                                <label className="block font-medium" htmlFor="password">Gender</label>
                                <Select
                                    defaultValue="male"
                                    // onChange={handleChange}
                                    options={[
                                        { value: 'male', label: 'Male' },
                                        { value: 'femal', label: 'Female' },
                                        { value: 'other', label: 'Other' },
                                    ]}
                                    className="w-full border-2 rounded-lg border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500 mb-5"
                                />
                            </div>

                            <div className="w-1/2 px-5 mb-5">
                                <label className="block font-medium" htmlFor="email">Mail</label>
                                <Input placeholder="Email" className="w-full border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500 mb-5" />
                            </div>

                            <div className="w-1/2 px-5 mb-5">
                                <label className="block font-medium" htmlFor="lastName">Date of Birth</label>
                                <DatePicker format="DD/MM/YYYY" className='w-full border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500 mb-5' />
                            </div>

                            <div className="w-1/2 px-5 mb-5">
                                <label className="block font-medium" htmlFor="phone">Password</label>
                                <Input.Password placeholder="Password" className="w-full border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500 mb-5" />
                            </div>

                            <div className="w-1/2 px-5 mb-5">
                                <label className="block font-medium" htmlFor="address">Phone number</label>
                                <Input placeholder="Phone Number" className="w-full border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500 mb-5" />
                            </div>
                        </div>

                        <div className='text-center mb-5'>
                            <Checkbox>I Accept The Terms & Conditions</Checkbox>
                        </div>

                        <div className='text-center mb-5'>
                            <PrimaryButton name='Become a Member' className='w-1/2' />
                        </div>
                    </form>

                    <div className="mt-2 w-5/6 mx-auto text-base text-center">
                        The confirmation code will be sent to the email you registered
                        with as soon as you click the "Become a Member".
                    </div>

                    <div className="flex items-center justify-between text-left w-[40%] mx-auto mt-3">
                        <label className="flex-shrink-0 font-medium mr-2" htmlFor="email">Your Code</label>
                        <Input
                            placeholder="Verify code"
                            className="flex-grow border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500 mr-2"
                        />
                        <PrimaryButton name="Verify" className='h-10' />
                    </div>


                </div>
            </div>
        </div>
    );
};

export default SignupPage;
