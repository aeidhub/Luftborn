/** @format */

import React from "react";
import Modal from "@mui/material/Modal";
export default function ErrorModal(props) {
  return (
    <Modal
      open={props.isOpen}
      onClose={() => props.toggleModal(props.stateName)}>
      <div className='modal-cont'>
        <h3>{props.msg}</h3>
        <button onClick={() => props.toggleModal(props.stateName)}>Ok</button>
      </div>
    </Modal>
  );
}
