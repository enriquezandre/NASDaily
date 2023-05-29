import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import './TimeOutModal.css'

function TimeOutModal(props) {
  return (
    <Modal
        show={props.show}
        onHide={props.onHide}
        size="lg"
        aria-labelledby="contained-modal-title-vcenter"
        centered
    >
      <div className='timeoutmodal-container'>
        <Modal.Header closeButton>
          <Modal.Title id="contained-modal-title-vcenter">
            NAS Daily Activity
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group
              className="mb-3"
              controlId="exampleForm.ControlTextarea1"
            >
              <Form.Label>Activities Done</Form.Label>
              <Form.Control as="textarea" rows={3} className="text-area"/>
            </Form.Group>
          </Form>
          <Form>
            <Form.Group
              className="mb-3"
              controlId="exampleForm.ControlTextarea1"
            >
              <Form.Label>Skills Learned</Form.Label>
              <Form.Control as="textarea" rows={3} className="text-area"/>
            </Form.Group>
          </Form>
          <Form>
            <Form.Group
              className="mb-3"
              controlId="exampleForm.ControlTextarea1"
            >
              <Form.Label>Values Learned</Form.Label>
              <Form.Control as="textarea" rows={3} className="text-area"/>
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button onClick={props.onHide} className='timeoutmodal-btn'>Done</Button>
        </Modal.Footer>
        </div>
      </Modal>
  );
}

export default TimeOutModal;