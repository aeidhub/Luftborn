/** @format */

import "./index.scss";
export default function Products(props) {
  return (
    <div key={props.id} className='product-cont'>
      <span>
        <b> Name </b>: {props.name}
      </span>
      <span>
        <b> Amount </b> : {props.amount}
      </span>
      <span>
        <b> Cost </b> : {props.cost}
      </span>
      <div className='product-cont__actionBtns'>
        <button onClick={() => props.toggleModal("update", props.product)}>
          Edit
        </button>
        <button onClick={() => props.toggleModal("delete", props.product)}>
          Delete
        </button>
      </div>

      {/* <Modal></Modal> */}
    </div>
  );
}
