import { ReactElement } from "react";
import "../../../App.css";

const LeftBanner = (): ReactElement => {
  return (
    <div>
      <img
        src={"/images/logo.png"}
        className="block mx-auto mt-10"
        alt=""
      />
      <h1 id="brand_name" className="text-white text-center">Grade Management</h1>
      <img
        src={"/images/shake-hand.png"}
        className="block mt-10"
        alt=""
      />
      <div className="text-white text-center mt-10">
        <h1>Your class partner</h1>
        <p>Reduce the time spent managing your class grades</p>
      </div>
    </div>
  );
};

export default LeftBanner;
