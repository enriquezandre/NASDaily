import React from "react";
import { Routes, Route } from 'react-router-dom';
import { Navigationbar } from "./Components/Navigationbar";
import { Login } from "./Pages/Login";
import { OASProfile } from "./Pages/OASProfile";
import { Attendance } from "./Pages/Attendance"
import Timeinout from "./Pages/Timeinout";

function App() {
  return (
    <>
      <Navigationbar/>
      <Routes>
        <Route path="/" element={<Login/>}/>
        <Route path="/timeinout" element={<Timeinout/>}/>
        <Route path="/oasprofile" element={<OASProfile/>} />
        <Route path="/attendance" element={<Attendance/>} />
      </Routes>
    </>
  );
}

export default App;
