import React from 'react';
import { Button } from 'antd';
import { useNavigate, useLocation } from 'react-router-dom';
// import ClassService from "../service/class.service";
import { useUser } from '../../utils/UserContext';

const JoinClassPage = (): React.ReactElement => {
    const { user } = useUser();
    //   const { malop, role } = useParams();
    const role = "gv";
    const navigate = useNavigate();
    const location = useLocation();

    const handleLoginPage = () => {
        navigate("/login", { state: { from: location } });
    };

    const handleCancel = async () => {
        navigate(`/home`);
        window.location.reload();
    };

    const handleConfirm = async () => {
        //todo
    };

    const borderStyle = 'border-2 p-4 rounded-lg absolute top-1/2 left-1/2 transform -translate-x-1/2 -translate-y-1/2';

    if (!user) {
        return (
            <div className={`${borderStyle} border-black flex flex-col items-center justify-center`}>
                <p className='pb-2'>Bạn chưa đăng nhập, vui lòng chuyển sang trang đăng nhập. Cảm ơn !!!!!!!</p>
                <Button type="primary" onClick={handleLoginPage} className="rounded-2">Chuyển sang trang login</Button>
            </div>
        );
    }

    const roleText = role === "gv" ? "giáo viên" : role === "hs" ? "học sinh" : role;

    return (
        <div className={`${borderStyle} border-blue-500 flex flex-col items-center justify-center`}>
            <p className='pb-2'>Bạn sẽ tham gia lớp học với vai trò là {roleText}?</p>
            <Button type="primary" danger onClick={handleCancel} className="rounded-2">Hủy</Button>
            <div className="my-2" />
            <Button type="primary" onClick={handleConfirm} className="rounded-2">Xác nhận</Button>
        </div>
    );
};

export default JoinClassPage;
