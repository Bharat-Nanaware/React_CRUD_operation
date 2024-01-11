import React from "react";
import "../App.css";
import { Link, useNavigate, useParams } from "react-router-dom";
import Event from '../components/Event';
import { useEffect, useState } from "react";
import apiurl from "./Env";
export default function NewEvent() {

  const [eventId, Seteventid] = useState("");
  const [imageUrl, Seteventimagechange] = useState("");
  const [title, Seteventnamechange] = useState("");
  const [date, Seteventdatechange] = useState(null);
  const [description, Seteventdescripton] = useState("");

  const { id } = useParams();


  useEffect(() => {
    if (id > 0) {
      fetch(apiurl + id)
        .then((res) => {
           return res.json()
        })
        .then((resp) => {
           Seteventid(resp.eventId);
           Seteventimagechange(resp.imageUrl);
          Seteventnamechange(resp.title);
           Seteventdatechange(resp.date);
           Seteventdescripton(resp.description);
        })
        .catch((err) => {
          console.log(err.message);
        });
        
    }
  }, []);

  const navigate = useNavigate();

  const handlesubmit = (e) => {

    e.preventDefault();

    const eventAddData = { imageUrl, title, date, description };
    const eventEditdata = { eventId, imageUrl, title, date, description };

    if (eventId == 0) {
      fetch("https://localhost:44374/api/Event/", {
        method: "POST",
        headers: { "content-type": "application/json" },
        body: JSON.stringify(eventAddData),
      })
        .then((res) => {
          alert("Saved successfully.");
          navigate("/AllEvent");
        })
        .catch((err) => {
          console.log(err.message);
        });
    } else {
      fetch(apiurl + eventId, {
        method: "PUT",
        headers: { "content-type": "application/json" },
        body: JSON.stringify(eventEditdata),
      })
        .then((res) => {
          alert("Update successfully.");
          navigate("/AllEvent");
          
        })
        .catch((err) => {
          console.log(err.message);
        });
    }
  };

  return (

    <>

      
      <div className="conatainer">
      <Event />
        <div className="row">
          <div>
            <form className="container" onSubmit={handlesubmit}>
              <br/>
              <div className="card" style={{ textAlign: "left" }}>
                <div className="card-title">
                  <h2></h2>
                </div>
                <div className="card-body">
                  <div className="row">
                    <div className="col-lg-12">
                      <div className="form-group">
                        <label>Title</label>
                        <input required
                          value={title}
                          onChange={(e) => Seteventnamechange(e.target.value)}
                          className="form-control"
                        ></input>
                      </div>
                    </div>
  
                    <div className="col-lg-12">
                      <div className="form-group">
                        <label>Image URL</label>
                        <input
                          required
                         value={imageUrl}
                         onChange={(e) => Seteventimagechange(e.target.value)}
                          className="form-control"
                        ></input>
                      </div>
                    </div>
  
                    <div className="col-lg-12">
                      <div className="form-group">
                        <label>Date</label>
                        <input required
                        type="date"
                          value={date}
                          onChange={(e) => Seteventdatechange(e.target.value)}
                          className="form-control"
                        ></input>
                      </div>
                    </div>

                    <div className="col-lg-12">
                      <div className="form-group">
                        <label>Description</label>
                        <textarea required
                          type="text-area"
                         value={description}
                         onChange={(e) => Seteventdescripton(e.target.value)}
                          className="form-control"
                        ></textarea>
                      </div>
                    </div>
  
                    <div className="submit">
                      <div className="form-group">
                        <button className="btn btn-success" type="submit">
                          Save
                        </button>
                        &nbsp;
                        <Link to="/" className="btn btn-danger">
                          Cancel
                        </Link>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </form>
          </div>
        </div>
      </div>

    </>
  )

}

