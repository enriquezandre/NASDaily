import React from "react";
import { Routes, Route } from 'react-router-dom';
import { Navigationbar } from "./Components/Navigationbar";
import { Login } from "./Pages/Login";
import Timeinout from "./Pages/Timeinout";
import NASActivities from "./Pages/NASActivities";
import OASAttendance from "./Pages/OAS/OASAttendance";

function App() {
  return (
    <>
      <Navigationbar/>
      <Routes>
        <Route path="/" element={<Login/>}/>
        <Route path="/timeinout" element={<Timeinout/>}/>
        <Route path="/NASActivities" element={<NASActivities/>}/>
        <Route path="/OASAttendance" element={<OASAttendance/>}/>
      </Routes>
    </>
  );
}

export default App;
