import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';

function TimeInModal(props) {
  return (
    <Modal
      {...props}
      size="sm"
      aria-labelledby="contained-modal-title-vcenter"
      centered
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          Modal heading
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <h4>i</h4>
        <p>
          Timed in successfully!
        </p>
      </Modal.Body>
      <Modal.Footer>
        <Button onClick={props.onHide}>Okay</Button>
      </Modal.Footer>
    </Modal>
  );
}

export default TimeInModal;