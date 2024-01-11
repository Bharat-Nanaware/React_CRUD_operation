import React from 'react'
import "bootstrap/dist/css/bootstrap.min.css";
import { Link ,useNavigate} from "react-router-dom";
import Card from "react-bootstrap/Card";
import axios from "axios";
import apiurl from "./Env";
export default function EventDetails(EventDetail) {

  
  const navigate = useNavigate();


  const handleDelete = (eventId) => {

    axios
      .delete(apiurl +eventId)
      .then((res) => {
        alert("Delete successfully.");
        navigate("/Events");
      })
    
    
  };

  

  return (
    <div >
      <div >
        <center>
          <Card  className='conatainer' style={{backgroundColor:"rgb(73 80 87 / 11%)"}}>
            <Card.Header>
              <h3>
                <b>{EventDetail.evendetail.title}</b>
              </h3>
              <h5>
                <b>{EventDetail.evendetail.date}</b>
              </h5>
            </Card.Header>
            <Card.Body>
              <Card.Title>
                <img className="imagefiled" src={EventDetail.evendetail.imageUrl}></img>
              </Card.Title>
              <br></br>
              <Card.Text>
                <p>{EventDetail.evendetail.description}</p>
              </Card.Text>
            </Card.Body>

            <center>
              <Link to={`/NewEvent/${EventDetail.evendetail.eventId}`} className="btn btn-success" style={{ width: 120, marginRight: 25 }}>
                Edit
              </Link>
              <Link className="btn btn-danger" style={{ width: 120 }} onClick={() => handleDelete(EventDetail.evendetail.eventId)}>
                Delete
              </Link>
              <div style={{ height: 10 }}></div>
              <button className="btn btn-success" onClick={EventDetail.closeForm}>Close</button>
            </center>
          </Card>
        </center>

        <br />
      </div>

    </div>
  )
}

