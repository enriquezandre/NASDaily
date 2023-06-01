import React, { Component } from 'react'
import Header from '../../Components/Header.js';
import Button from '../../Components/Common/Buttons/Button.js'
import SummaryAttendanceOAS from '../../Components/OAS/SummaryAttendanceOAS.js';
import '../OAS/OASAttendance.css'


export class OASAttendance extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nasProfiles: [],
      logs: [],
      searchTerm: '',
      fullName: '',
      check: false,
    };
  }

  componentDidMount(){
    this.fetchNasProfiles();
  }

  fetchNasProfiles = async () => {
    try {
      const response = await fetch('https://localhost:7047/api/nas', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      });
      if(response.ok){
        const nasList = await response.json();
        const names = nasList.map((nas) => nas.username);
        this.setState({ nasProfiles: names });
      } else{
        console.log('API request failed:', response.status);
      }
    } catch (error) {
      console.error('Error:', error);
    }
  }; 

  render() {
    const { nasProfiles, logs, searchTerm, fullName, check } = this.state;
    
    const filteredProfiles = nasProfiles.filter(
      (name) =>
        name &&
        (name.toLowerCase().startsWith(searchTerm.toLowerCase()))
    )

    const handleSearch = async (e) => {
      e.preventDefault();

      const response = await fetch(`https://localhost:7047/api/nas/username/${searchTerm}`);
      const userData = await response.json();

      this.setState({
        fullName: userData.name,
        logs: userData.logs,
        check: true,
      });
    };

    return (
      <>
        <div>
          <Header username={"OAS"} onLogout={null} />
        </div>

        <div className='menuNav'>
          <Button
            style={"yellow-button"}
            onClick={null}
            name={"Offices"}
          />
          <Button
            style={"red-button"}
            onClick={null}
            name={"Attendance"}
          />
          <Button
            style={"yellow-button"}
            onClick={null}
            name={"Evaluation"}
          />
          <Button
            style={"yellow-button"}
            onClick={null}
            name={"Grades"}
          />
          <Button
            style={"yellow-button"}
            onClick={null}
            name={"Validation"}
          />
          <Button
            style={"yellow-button"}
            onClick={null}
            name={"NAS Master List"}
          />
        </div>

        <div className='row'>
          <div className='heading'>
            <p className='name'>{fullName}</p>
            <form className='searchBar' onSubmit={handleSearch}>
              <input
                className='searchBarInput'
                type='text'
                placeholder='Search...'
                value={searchTerm}
                onChange={(e) => this.setState({ searchTerm: e.target.value })}
                list='nasSearch'
              />
              <datalist id='nasSearch'>
                {filteredProfiles.map((name, index) => (
                  <option key={index} value={name} />
                ))}
              </datalist>
              <button type='submit'>
                <i className='material-icons search-icon'>search</i>
              </button>
            </form>
          </div>

          <div className='dropDownButtons'>
            <label className='labelDropDown'>
              SEMESTER:
              <select>
                <option value="semester">2nd Semester 2022-2023</option>
              </select>
            </label>
            <label className='labelDropDown'>
              MONTH:
              <select>
                <option value="month">June</option>
                <option value="month">May</option>
                <option value="month">April</option>
                <option value="month">March</option>
                <option value="month">February</option>
                <option value="month">January</option>
              </select>
            </label>
          </div>

          <div className='data'>
            <SummaryAttendanceOAS
              check={check}
              logTable={logs}
            />
          </div>
        </div>
      </>
    )
  }
}

export default OASAttendance