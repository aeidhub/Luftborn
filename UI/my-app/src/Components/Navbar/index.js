/** @format */

import React, { useState } from "react";
import Modal from "@mui/material/Modal";
import "./index.scss";
import { registerUser, userLogin } from "../../Services/LoginAndRegister";
let initialLoginValue = { email: "", password: "" };
let initialSignupValue = {
  email: "",
  password: "",
  firstName: "",
  lastName: "",
  username: "",
};
export default function Navbar() {
  const [isOpen, setOpen] = useState({ login: false, signUp: false });
  const [loginData, setLoginData] = useState(initialLoginValue);
  const [signUpData, setSignUpData] = useState(initialSignupValue);
  const [showErrorMsg, toggleErrorMsg] = useState(false);

  const toggleModal = (modalName) => {
    setOpen({ ...isOpen, [modalName]: !isOpen[modalName] });
  };
  const getLoginData = (stateName, event) => {
    if (stateName === "email") {
      toggleErrorMsg(false);
    }
    setLoginData({ ...loginData, [stateName]: event.target.value });
  };
  const getSignUpData = (stateName, event) => {
    if (stateName === "email") {
      toggleErrorMsg(false);
    }
    setSignUpData({
      ...signUpData,
      [stateName]: event.target.value,
    });
  };
  const validatEmail = (value) => {
    let regex = new RegExp("[a-z0-9]+@[a-z]+.[a-z]{2,3}");
    if (!regex.test(value)) {
      toggleErrorMsg(true);
    }
  };
  const login = async (event) => {
    event.preventDefault();
    let res = await userLogin(loginData);
    console.log(res);
    if (res.data.isAuthenticated) {
      setLoginData(initialLoginValue);
      toggleModal("login");
    }
  };
  const signUp = async (event) => {
    event.preventDefault();
    let res = await registerUser(signUpData);
    if (res.data.isAuthenticated) {
      setLoginData(initialSignupValue);
      toggleModal("signUp");
    }
  };
  return (
    <div>
      <button onClick={() => toggleModal("signUp")}>Sign up</button>
      <button onClick={() => toggleModal("login")}>Log in</button>
      <Modal open={isOpen.login} onClose={() => toggleModal("login")}>
        <form id='loginForm' action='#' className='modal-cont'>
          <h3>Login</h3>
          <label>Email:</label>
          <input
            value={loginData.email}
            type='text'
            placeholder='Enter your email'
            required
            onChange={(event) => getLoginData("email", event)}
            onBlur={() => validatEmail(loginData.email)}
          />
          {showErrorMsg ? <span>pleaes enter a valid email</span> : null}

          <label>password:</label>

          <input
            value={loginData.password}
            type='password'
            className='password'
            placeholder='Enter your password'
            required
            onChange={(event) => getLoginData("password", event)}
          />
          <input type='submit' value='Login' onClick={login}></input>
          {/* <button disabled={showErrorMsg} onClick={login}>
            Login
          </button> */}
        </form>
      </Modal>
      <Modal open={isOpen.signUp} onClose={() => toggleModal("signUp")}>
        <form d='signUpForm' action='#' className='modal-cont'>
          <h3>Sign up</h3>
          <label>First name:</label>
          <input
            value={signUpData.firstName}
            type='text'
            placeholder='Enter your first name'
            required
            onChange={(event) => getSignUpData("firstName", event)}
          />
          <label>Last name:</label>
          <input
            value={signUpData.lastName}
            type='text'
            placeholder='Enter your last name'
            required
            onChange={(event) => getSignUpData("lastName", event)}
          />
          <label>User name:</label>
          <input
            value={signUpData.username}
            type='text'
            placeholder='Enter your user name'
            required
            onChange={(event) => getSignUpData("username", event)}
          />
          <label>Email:</label>
          <input
            value={signUpData.email}
            type='text'
            placeholder='Enter your email'
            required
            onChange={(event) => getSignUpData("email", event)}
            onBlur={() => validatEmail(signUpData.email)}
          />
          <label>Password:</label>
          <input
            value={signUpData.password}
            type='password'
            class='password'
            placeholder='Create a password'
            required
            onChange={(event) => getSignUpData("password", event)}
          />

          <button disabled={showErrorMsg} onClick={signUp}>
            Signup
          </button>
        </form>
      </Modal>
    </div>
  );
}
