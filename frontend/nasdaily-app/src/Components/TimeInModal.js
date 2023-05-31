import React from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import './TimeInModal.css'

class TimeInModal extends React.Component {
  render() {
    return (
      <Modal
        {...this.props}
        size="sm"
        aria-labelledby="contained-modal-title-vcenter"
        centered
      >
        <Modal.Header closeButton>
          <Modal.Title id="contained-modal-title-vcenter">
            Status
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <p>
            Timed in <b>successfully!</b>
          </p>
        </Modal.Body>
        <Modal.Footer>
          <Button onClick={this.props.onHide} className='timeinmodal-btn'>Okay</Button>
        </Modal.Footer>
      </Modal>
    );
  }
}

export default TimeInModal;
