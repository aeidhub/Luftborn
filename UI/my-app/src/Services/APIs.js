/** @format */

import axios from "axios";
let baseUrl = "https://localhost:7109/api/";
const prepareHeader = () => {
  let config = {
    headers: {
      "Access-Control-Expose-Headers": "*,X-Pagination",
      "Access-Control-Allow-Origin": "*",
      "Content-Type": "application/json",

      Authorization: `Bearer ${sessionStorage.getItem("token")}`,
    },
  };
  return config;
};
export const postReq = async (url, params) => {
  let config = prepareHeader();
  // params = JSON.stringify(params);
  try {
    let response = await axios.post(`${baseUrl}${url}`, params, config);
    return response;
  } catch (error) {
    return error.response;
  }
};
export const putReq = async (url, params) => {
  let config = prepareHeader();
  // params = JSON.stringify(params);
  try {
    let response = await axios.put(`${baseUrl}${url}`, params, config);
    return response;
  } catch (error) {
    return error.response;
  }
};
export const deleteReq = async (url, params) => {
  let config = prepareHeader();
  // params = JSON.stringify(params);
  try {
    let response = await axios.delete(`${baseUrl}${url}`, config);
    return response;
  } catch (error) {
    return error.response;
  }
};
export const getReq = async (url) => {
  let config = prepareHeader();
  // params = JSON.stringify(params);
  try {
    let response = await axios.get(`${baseUrl}${url}`, config);
    return response;
  } catch (error) {
    return error.response;
  }
};
