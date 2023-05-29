import React from "react";
import { Routes, Route } from 'react-router-dom';
import { Navigationbar } from "./Components/Navigationbar";
import { Login } from "./Pages/Login";
import Timeinout from "./Pages/Timeinout";
import NASActivities from "./Pages/NASActivities";

function App() {
  return (
    <>
      <Navigationbar/>
      <Routes>
        <Route path="/" element={<Login/>}/>
        <Route path="/timeinout" element={<Timeinout/>}/>
        <Route path="/NASActivities" element={<NASActivities/>}/>
      </Routes>
    </>
  );
}

export default App;
