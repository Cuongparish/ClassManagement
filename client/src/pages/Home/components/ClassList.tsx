import React from 'react';
import ClassRoom from './ClassRoom';

interface ClassItem {
  TenLop: string;
  ChuDe: string;
  detail_class_link: string;
}

interface ClassListProps {
  ClassData: ClassItem[];
}

const ClassList: React.FC<ClassListProps> = ({ ClassData }) => (
  <div className="grid grid-cols-[repeat(auto-fill,_minmax(300px,_1fr))] gap-5">
    {ClassData.map((classItem, index) => (
      <ClassRoom
        key={index} // Consider using a unique identifier from your data if available
        TenLop={classItem.TenLop}
        ChuDe={classItem.ChuDe}
        detail_class_link={classItem.detail_class_link}
        handleClick={() => console.log(`Clicked on class ${classItem.TenLop}`)}
      />
    ))}
  </div>
);

export default ClassList;
