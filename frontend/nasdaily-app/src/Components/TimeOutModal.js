import React, { useState } from 'react';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import Form from 'react-bootstrap/Form';
import './TimeOutModal.css';

const TimeOutModal = ({ show, onHide, onDone }) => {
  const [activitiesDone, setActivitiesDone] = useState('');
  const [skillsLearned, setSkillsLearned] = useState('');
  const [valuesLearned, setValuesLearned] = useState('');

  const handleDoneClick = () => {
    onDone(activitiesDone, skillsLearned, valuesLearned);
  };

  return (
    <Modal
      show={show}
      onHide={onHide}
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
            <Form.Group className="mb-3" controlId="activitiesDone">
              <Form.Label>Activities Done</Form.Label>
              <Form.Control
                as="textarea"
                rows={3}
                className="text-area"
                value={activitiesDone}
                onChange={(e) => setActivitiesDone(e.target.value)}
              />
            </Form.Group>
          </Form>
          <Form>
            <Form.Group className="mb-3" controlId="skillsLearned">
              <Form.Label>Skills Learned</Form.Label>
              <Form.Control
                as="textarea"
                rows={3}
                className="text-area"
                value={skillsLearned}
                onChange={(e) => setSkillsLearned(e.target.value)}
              />
            </Form.Group>
          </Form>
          <Form>
            <Form.Group className="mb-3" controlId="valuesLearned">
              <Form.Label>Values Learned</Form.Label>
              <Form.Control
                as="textarea"
                rows={3}
                className="text-area"
                value={valuesLearned}
                onChange={(e) => setValuesLearned(e.target.value)}
              />
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button onClick={handleDoneClick} className='timeoutmodal-btn'>Done</Button>
        </Modal.Footer>
      </div>
    </Modal>
  );
};

export default TimeOutModal;
