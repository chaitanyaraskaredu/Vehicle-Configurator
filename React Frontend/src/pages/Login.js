import React, { useState } from 'react';
import bg001 from '../assets/Login Page Images/log.jpg';

const LoginPage = () => {
  const styles = {
    body: {
      fontFamily: 'Arial, sans-serif',
      backgroundColor: '#f7f7f7',
      margin: 0,
      padding: 0,
      backgroundImage: `url(${bg001})`,
      backgroundSize: 'cover',
      backgroundRepeat: 'no-repeat',
      backgroundPosition: 'center center'
    },
    container: {
      display: 'flex',
      justifyContent: 'center',
      alignItems: 'center',
      height: '100vh'
    },
    formMain: {
      backgroundColor: '#fff',
      padding: '40px',
      borderRadius: '10px',
      boxShadow: '0 0 15px rgba(0, 0, 0, 0.1)',
      width: '100%',
      maxWidth: '400px',
      position: 'relative'
    },
    formHead: {
      textAlign: 'center',
      marginBottom: '20px'
    },
    formGroup: {
      marginBottom: '15px'
    },
    formControl: {
      width: '100%',
      padding: '10px',
      margin: '8px 0',
      display: 'inline-block',
      border: '1px solid #ccc',
      borderRadius: '4px',
      boxSizing: 'border-box'
    },
    formButton: {
      width: '100%',
      backgroundColor: '#4CAF50',
      color: 'white',
      padding: '14px 20px',
      margin: '8px 0',
      border: 'none',
      borderRadius: '4px',
      cursor: 'pointer'
    },
    formButtonHover: {
      backgroundColor: '#45a049'
    },
    error: {
      color: 'red',
      marginTop: '10px'
    }
  };

  const [userid, setUserid] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const handleLogin = async (event) => {
    event.preventDefault();

    try {
      //java http://localhost:8080/api/user/login?userid=${userid}&password=${password}
      //http://localhost:5248/api/User/login?userid=${userid}&password=${password}
      const response = await fetch(`http://localhost:8080/api/user/login?userid=${userid}&password=${password}`, {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json'
        }
      });

      if (response.ok) {
        sessionStorage.setItem('userid', userid); // Store userid in sessionStorage
        sessionStorage.setItem('loggedIn', true);
        window.location.href = '/dropDownPage'; // Redirect to dropdownpage page upon successful login
      } else {
        const result = await response.text();
        setError(result);
      }
    } catch (error) {
      console.error('Error:', error);
      setError('An error occurred during login.');
    }
  };

  return (
    <div style={styles.body}>
      <section style={styles.container}>
        <div style={styles.formMain}>
          <div style={styles.formHead}>
            <h2>Welcome Back!</h2>
          </div>
          <form onSubmit={handleLogin}>
            <div style={styles.formGroup}>
              <label>User ID:</label>
              <input
                type="text"
                name="userid"
                style={styles.formControl}
                placeholder="Enter User ID"
                value={userid}
                onChange={(e) => setUserid(e.target.value)}
                required
              />
            </div>
            <div style={styles.formGroup}>
              <label>Password:</label>
              <input
                type="password"
                name="password"
                style={styles.formControl}
                placeholder="Enter Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
              />
            </div>
            <div style={styles.formGroup}>
              <button
                type="submit"
                style={styles.formButton}
                onMouseOver={(e) => e.currentTarget.style.backgroundColor = styles.formButtonHover.backgroundColor}
                onMouseOut={(e) => e.currentTarget.style.backgroundColor = styles.formButton.backgroundColor}
              >
                Login
              </button>
            </div>
            {error && <p style={styles.error}>{error}</p>}
          </form>
        </div>
      </section>
    </div>
  );
};

export default LoginPage;
