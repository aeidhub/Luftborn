/** @format */

import React from "react";
import Modal from "@mui/material/Modal";
export default function DeleteProduct(props) {
  return (
    <Modal
      open={props.isOpen}
      onClose={() => props.toggleModal(props.stateName)}>
      <div className='modal-cont'>
        <h3>Are you sure you want to delete this product ?</h3>
        <button onClick={() => props.action(props.id)}>Delete</button>
      </div>
    </Modal>
  );
}
