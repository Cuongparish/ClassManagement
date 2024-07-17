import React from 'react';

import Navbar from './components/Navbar';
import Sidebar from './components/Slidebar';

interface LayoutProp {
  children: React.ReactNode | React.ReactElement<unknown>;
}

function ClassLayout({ children }: LayoutProp) {
  return (
    <div style={{ backgroundColor: '#FFFFFF' }}>
      <Navbar />
      <div className='flex'>
        <div className='w-1/6'>
          <Sidebar />
        </div>
        <div className='w-5/6'>
          {React.cloneElement(children as React.ReactElement<unknown>)}
        </div>
      </div>
    </div>
  );
}

export default ClassLayout;