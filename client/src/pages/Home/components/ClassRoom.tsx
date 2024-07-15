import React from 'react';
import { Card, Button } from 'antd';
import { RxEnter } from 'react-icons/rx';
import { ImCancelCircle } from 'react-icons/im';

interface ClassRoomProps {
    TenLop: string;
    ChuDe: string;
    detail_class_link: string;
    handleClick: () => void;
}

const ClassRoom: React.FC<ClassRoomProps> = ({ TenLop, ChuDe, detail_class_link, handleClick }) => (
    <Card className="relative w-[350px] h-[250px] m-[30px] mt-[20px] border border-solid border-gray-300">
        <div className="relative w-full h-20 pb-3">
            <img
                className="w-full h-full object-cover"
                src={'/images/class_bg.png'}
                alt="Class Background"
            />
        </div>
        <Card.Meta
            title={TenLop}
            description={<span className="mb-2 text-muted">{ChuDe}</span>}
        />
        <div className="absolute bottom-0 left-0 right-0 p-2 flex justify-end">
            <Button href={detail_class_link} onClick={handleClick} type="primary">
                Truy cập <RxEnter />
            </Button>
            <Button type="primary" danger className="mx-2">
                Hủy <ImCancelCircle />
            </Button>
        </div>
        <div className="absolute bg-center bg-[url('/images/user_icon.png')] bg-no-repeat top-[50px] right-[10px] w-[65px] h-[65px] bg-[rgba(0,0,0,0.21)] border-2 border-white rounded-full"></div>
    </Card>
);

export default ClassRoom;
