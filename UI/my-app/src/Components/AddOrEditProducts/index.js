/** @format */

import React, { useEffect, useState } from "react";
import Modal from "@mui/material/Modal";
export default function AddOrEditProduct(props) {
  const [productData, setProductData] = useState({
    name: "",
    amount: "",
    cost: "",
  });
  useEffect(() => {
    if (props.title === "Update") {
      setProductData({
        name: props.name,
        amount: props.amount,
        cost: props.cost,
      });
    }
  }, [props.isOpen]);
  const getProductData = (stateName, event) => {
    setProductData({ ...productData, [stateName]: event.target.value });
  };

  return (
    <Modal
      open={props.isOpen}
      onClose={() => props.toggleModal(props.stateName)}>
      <div className='modal-cont'>
        <h3>Product data</h3>
        <label>Name:</label>
        <input
          value={productData.name}
          type='text'
          placeholder='Enter product name'
          required
          onChange={(event) => getProductData("name", event)}
        />
        <label>Amount:</label>
        <input
          value={productData.amount}
          type='number'
          placeholder='Enter product amount'
          required
          onChange={(event) => getProductData("amount", event)}
        />
        <label>Cost:</label>
        <input
          value={productData.cost}
          type='number'
          placeholder='Enter product cost'
          required
          onChange={(event) => getProductData("cost", event)}
        />

        <button onClick={() => props.action({ ...productData, id: props.id })}>
          {props.title}
        </button>
      </div>
    </Modal>
  );
}
