import axios from "axios";
import { API_URL } from "../utils/env";

const creatClass = async (
  tenLop: string,
  chuDe: string,
  phong: string | undefined,
  userId: number,
  token: string
) => {
  try {
    const state = true;

    const res = await axios.post(
      `${API_URL}/api/class/${userId}`,
      {
        tenLop,
        chuDe,
        phong,
        state,
      },
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );

    return res;
  } catch (error) {
    console.log(error);
  }
};

const getClassList = async (userId: number, token: string) => {
  try {
    const res = await axios.get(`${API_URL}/api/class/all/${userId}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });

    return res;
  } catch (error) {
    console.log(error);
  }
};

const getDetailClass = async (classId: number, token: string) => {
  try {
    const res = await axios.get(`${API_URL}/api/class/${classId}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });

    return res;
  } catch (error) {
    console.log(error);
  }
};

export { creatClass, getClassList, getDetailClass };
