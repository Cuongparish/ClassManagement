import axios from "axios";
import { API_URL } from "../utils/env";

const login = async ({
  username,
  password,
}: {
  username: string;
  password: string;
}) => {
  try {
    const res = await axios.post(`${API_URL}/api/account/login`, {
      username,
      password,
    });
  
    return res;
  } catch (error) {
    console.log(error);
  }
  
};

const register = async (
  email: string,
  password: string,
  fullName: string,
  dob: Date,
  sex: string,
  phone: string
) => {
  try {
    const res = await axios.post(`${API_URL}/api/account/register`, {
      email,
      password,
      fullName,
      dob,
      sex,
      phone,
    });

    return res;
  } catch (error) {
    console.log(error);
  }
};

const resetPw = async ({ email }: { email: string }) => {
  try {
    const res = await axios.post(`${API_URL}/api/account/resetpw`, { email });

    return res;
  } catch (error) {
    console.log(error);
  }
};

export { login, register, resetPw };
