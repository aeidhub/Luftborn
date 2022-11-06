/** @format */

import { postReq } from "./APIs";

export const registerUser = async (params) => {
  let response = await postReq("Auth/register", params);
  if (response.data.isAuthenticated) {
    sessionStorage.setItem("token", response.data.token);
  }
  return response;
};
export const userLogin = async (params) => {
  let response = await postReq("Auth/token", params);
  if (response.data.isAuthenticated) {
    sessionStorage.setItem("token", response.data.token);
  }
  return response;
};
