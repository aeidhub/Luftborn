/** @format */

import React, { useEffect, useState } from "react";
import AddOrEditProduct from "../../Components/AddOrEditProducts";
import DeleteProduct from "../../Components/DeleteModal";
import Navbar from "../../Components/Navbar";
import Products from "../../Components/Products";
import ErrorModal from "../../Components/ErrorModal";
import {
  addProducts,
  deleteProducts,
  getProducts,
  updateProductData,
} from "../../Services/Products";
import "./index.scss";
export default function Home() {
  const [allProducts, setProducts] = useState([]);
  const [isOpen, setOpen] = useState({
    delete: false,
    update: false,
    add: false,
    error: false,
  });
  const [selectedProductData, setData] = useState("");
  const [errorMsg, setErrorMsg] = useState("");
  useEffect(() => {
    let products = [
      { name: "test", amount: 5, cost: 10, id: 12553 },
      { name: "test", amount: 5, cost: 10, id: 123 },
      { name: "test", amount: 5, cost: 10, id: 123 },
      { name: "test", amount: 5, cost: 10, id: 123 },
      { name: "test", amount: 5, cost: 10, id: 123 },
    ];
    getProducts().then((res) => setProducts(res.data.response ));
  }, []);
  const toggleModal = (modalName, product) => {
    if (!isOpen[modalName] && modalName !== "add") {
      setData(product);
    } else {
      setData({});
    }
    setOpen({ ...isOpen, [modalName]: !isOpen[modalName] });
  };
  const updateProduct = async (params) => {
    let res = await updateProductData(params);
    if (!res.data.success) {
      setOpen({ delete: false, update: false, add: false, error: true });
      setErrorMsg(res.data.errors[0]);
    } else {
      toggleModal("update");
      let allProductsClone = [...allProducts];
      let productIndex = allProductsClone.findIndex(
        (product) => (product.id == params.id)
      );
      allProductsClone[productIndex] = params;
      setProducts(allProductsClone);
    }
  };
  const deleteProductData = async (params) => {
    let res = await deleteProducts(params);
    if (!res.data.success) {
      setOpen({ delete: false, update: false, add: false, error: true });
      setErrorMsg(res.data.errors[0]);
    } else {
      toggleModal("delete");
      let allProductsClone = [...allProducts];
      allProductsClone = allProductsClone.filter(
        (product) => product.id !== params
      );
      setProducts(allProductsClone);
    }
  };
  const addNewProducts = async (params) => {
    delete params.id;
    let res = await addProducts(params);
    if (!res.data.success) {
      setOpen({ delete: false, update: false, add: false, error: true });
      setErrorMsg(res.data.errors[0]);
    } else {
      toggleModal("add");
      setProducts([...allProducts,res.data.response])
    }
  };
  return (
    <div>
{sessionStorage.getItem("token") ? null : <Navbar />}      <div className='allProducts-cont'>
        <div className='allProducts-cont__header'>
          <h1>Products</h1>
          <button
            onClick={() => {
              toggleModal("add");
            }}>
            Add product
          </button>
        </div>
        {allProducts.map((product) => (
          <Products
            name={product.name}
            amount={product.amount}
            cost={product.cost}
            id={product.id}
            toggleModal={toggleModal}
            product={product}
          />
        ))}
      </div>
      {isOpen.update ? (
        <AddOrEditProduct
          title='Update'
          {...selectedProductData}
          toggleModal={toggleModal}
          isOpen={isOpen.update}
          action={updateProduct}
          stateName='update'
        />
      ) : null}
      {isOpen.add ? (
        <AddOrEditProduct
          title='Add'
          toggleModal={toggleModal}
          isOpen={isOpen.add}
          action={addNewProducts}
          stateName='add'
        />
      ) : null}
      {isOpen.delete ? (
        <DeleteProduct
          id={selectedProductData.id}
          toggleModal={toggleModal}
          isOpen={isOpen.delete}
          action={deleteProductData}
          stateName='delete'
        />
      ) : null}
      {isOpen.error ? (
        <ErrorModal
          toggleModal={toggleModal}
          isOpen={isOpen.error}
          msg={errorMsg}
          stateName='error'
        />
      ) : null}
    </div>
  );
}
