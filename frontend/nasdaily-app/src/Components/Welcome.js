import React from 'react';
import './Welcome.css';

class Welcome extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      currentDate: '',
      currentTime: '',
      user: null
    };
  }

  componentDidMount() {
    this.updateDateTime();
    this.fetchUserData();

    this.timer = setInterval(this.updateDateTime, 1000);
  }

  componentWillUnmount() {
    clearInterval(this.timer);
  }

  updateDateTime = () => {
    const now = new Date();
    const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
    this.setState({
      currentDate: now.toLocaleDateString(undefined, options),
      currentTime: now.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
    });
  };

  fetchUserData = async () => {
    try {
      const response = await fetch('https://localhost:7047/api/nas');
      if (response.ok) {
        const userData = await response.json();
        const user = userData[0];
        this.setState({ user });
      } else {
        throw new Error('Failed to fetch user data');
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  getFirstName = (fullName) => {
    const names = fullName.split(' ');
    if (names.length > 0) {
      return names[0];
    }
    return '';
  };

  render() {
    const { currentDate, currentTime, user } = this.state;
    const firstName = user ? this.getFirstName(user.name) : '';

    return (
      <div className="welcome-container">
        <p className="welcome-text">HELLO, {firstName}!</p>
        <div className="date-time">
          <p className="date">{currentDate}</p>
          <p className="time">{currentTime}</p>
        </div>
      </div>
    );
  }
}

export default Welcome;
