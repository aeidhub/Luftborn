/** @format */

import { deleteReq, getReq, postReq, putReq } from "./APIs";

export const getProducts = async () => {
  let response = await getReq("Products/GetAllProducts");

  return response;
};
export const addProducts = async (params) => {
  let response = await postReq("Products/AddProduct", params);
  console.log(response);
  
  return response;
};
export const updateProductData = async (params) => {
  let response = await putReq("Products/UpdateProduct", params);

  return response;
};
export const deleteProducts = async (params) => {
  let response = await deleteReq(`Products/DeleteProduct${params}`);

  return response;
};
