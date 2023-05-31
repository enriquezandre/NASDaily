import React from "react";
import { Routes, Route } from 'react-router-dom';
import { Navigationbar } from "./Components/Navigationbar";
import { Login } from "./Pages/Login";
import Timeinout from "./Pages/Timeinout";
import NASActivities from "./Pages/NASActivities";
import OASAttendance from "./Pages/OAS/OASAttendance";

class App extends React.Component {
  render() {
    return (
      <>
        <Navigationbar/>
        <Routes>
          <Route path="/" element={<Login/>}/>
          <Route path="/:username/timeinout" element={<Timeinout />} />
          <Route path="/:username/NASActivities" element={<NASActivities/>}/>
          <Route path="/OASAttendance" element={<OASAttendance/>}/>
        </Routes>
      </>
    );
  }
}

export default App;
