import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';

function TimeOutModal(props) {
  return (
    <Modal
        show={props.show}
        onHide={props.onHide}
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        centered
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          Non-Academic Scholar
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <h4>Summary of Daily Activities</h4>
        <p>
          Activities of the Week
          Skills Learned
          Values Learned
        </p>
      </Modal.Body>
      <Modal.Footer>
        <Button onClick={props.onHide}>Done</Button>
      </Modal.Footer>
    </Modal>
  );
}

export default TimeOutModal;