import React from 'react';
import ClassList from './components/ClassList';

const HomePage = (): React.ReactElement => {
    // Tạo dữ liệu giả
    const fakeClassData = [
        { TenLop: 'Class 1', ChuDe: 'Math', detail_class_link: '/class/1' },
        { TenLop: 'Class 2', ChuDe: 'Science', detail_class_link: '/class/2' },
        { TenLop: 'Class 3', ChuDe: 'History', detail_class_link: '/class/3' },
        { TenLop: 'Class 4', ChuDe: 'Geography', detail_class_link: '/class/4' },
        // Thêm dữ liệu giả nếu cần
    ];

    return (
        <div className='pl-5 pt-5'>
            <ClassList ClassData={fakeClassData} />
        </div>
    );
}

export default HomePage;