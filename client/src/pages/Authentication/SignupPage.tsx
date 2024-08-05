import React, { useState } from 'react';
import LeftBanner from "./components/LeftBanner";
import { PrimaryButton } from "../../components/Button";
import { Dayjs } from 'dayjs';
import { Link, useNavigate } from 'react-router-dom';
import { FaChevronLeft } from "react-icons/fa";
import { Checkbox, DatePicker, Form, Input, Select, notification } from 'antd';

import "../../App.css";
import { register } from '../../services/authentication.service';
import { useUser } from '../../utils/UserContext';

interface SignupFormValues {
  fullName: string;
  sex: string;
  email: string;
  dob: Dayjs;
  password: string;
  phone: string;
}

interface User {
    idUser: string;
    Email: string;
    Pw: string;
    FullName: string;
    DOB: string;
    Sex: string;
    Phone: string;
    StudentId?: string;
    Token?: string;
}

const SignupPage = (): React.ReactElement => {
  const [termsAccepted, setTermsAccepted] = useState(false);

  const { setUser } = useUser();
  const navigate = useNavigate();

  const handleSubmit = async (values: SignupFormValues) => {
    if (!termsAccepted) {
        notification.error({
            message: 'Error',
            description: 'You must accept the terms and conditions.',
            placement: 'bottomRight',
            duration: 3,
        });
        return;
    }

    const formattedDob = values.dob.set('hour', 0).set('minute', 0).set('second', 0).set('millisecond', 0).toISOString();

    try {
      const res = await register(
        values.email,
        values.password,
        values.fullName,
        formattedDob,
        values.sex,
        values.phone
      );
      if(res?.status == 200)
      {
        const result: User = {
            idUser: res.data.id,
            Email: res.data.email,
            FullName: res.data.fullName,
            Phone: res.data.phone,
            Pw: res.data.pw,
            Sex: res.data.sex,
            Token: res.data.token,
            DOB: res.data.dob,
            StudentId: res.data.studentId,
        }
        setUser(result);
        navigate('/home');
      }
    } catch (error) {
      console.log(error);
    }
  };

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

          <Form
            className='text-left w-4/5 mx-auto mt-3'
            onFinish={handleSubmit}
            layout="vertical"
          >
            <div className="flex flex-wrap -mx-5">
              <div className="w-1/2 px-5 mb-5">
                <Form.Item
                  name="fullName"
                  label="Fullname"
                  rules={[{ required: true, message: 'Full Name is required' }]}
                >
                  <Input
                    placeholder="Full Name"
                    className="w-full border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500"
                  />
                </Form.Item>
              </div>

              <div className="w-1/2 px-5 mb-5">
                <Form.Item
                  name="sex"
                  label="Gender"
                  initialValue="male"
                  rules={[{ required: true, message: 'Gender is required' }]}
                >
                  <Select
                    className="w-full border-2 rounded-lg border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500"
                    options={[
                      { value: 'male', label: 'Male' },
                      { value: 'female', label: 'Female' },
                      { value: 'other', label: 'Other' },
                    ]}
                  />
                </Form.Item>
              </div>

              <div className="w-1/2 px-5 mb-5">
                <Form.Item
                  name="email"
                  label="Email"
                  rules={[
                    { required: true, message: 'Email is required' },
                    { type: 'email', message: 'Invalid email' },
                  ]}
                >
                  <Input
                    placeholder="Email"
                    className="w-full border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500"
                  />
                </Form.Item>
              </div>

              <div className="w-1/2 px-5 mb-5">
                <Form.Item
                  name="dob"
                  label="Date of Birth"
                  rules={[{ required: true, message: 'Date of Birth is required' }]}
                >
                  <DatePicker
                    format="DD/MM/YYYY"
                    className='w-full border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500'
                  />
                </Form.Item>
              </div>

              <div className="w-1/2 px-5 mb-5">
                <Form.Item
                  name="password"
                  tooltip="Password must contain numbers, lowercase, uppercase letters, and special characters"
                  label="Password"
                  validateFirst
                  rules={[
                    { required: true, message: 'Password is required' },
                    { max: 20, message: 'Password cannot exceed 20 characters' },
                    {
                      pattern: /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).{6,20}$/,
                      message: 'Password must contain numbers, lowercase, uppercase letters, and special characters',
                    },
                  ]}
                >
                  <Input.Password
                    placeholder="Password"
                    className="w-full border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500"
                  />
                </Form.Item>
              </div>

              <div className="w-1/2 px-5 mb-5">
                <Form.Item
                  name="phone"
                  rules={[{ required: true, message: 'Phone number is required' }]}
                  label="Phone number"
                >
                  <Input
                    placeholder="Phone Number"
                    className="w-full border-2 border-indigo-500/75 hover:border-indigo-500 focus:border-indigo-500"
                  />
                </Form.Item>
              </div>
            </div>

            <div className='text-center mb-5'>
              <Checkbox checked={termsAccepted} onChange={(e) => setTermsAccepted(e.target.checked)}>
                I Accept The Terms & Conditions
              </Checkbox>
            </div>

            <div className='text-center mb-5'>
              <PrimaryButton name='Become a Member' className='w-1/2' htmlType="submit" />
            </div>
          </Form>
        </div>
      </div>
    </div>
  );
};

export default SignupPage;
