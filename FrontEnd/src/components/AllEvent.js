import React from "react";
import "../App.css";
import Event from '../components/Event';
import Table from 'react-bootstrap/Table';
import axios from 'axios';
import { useEffect, useState } from "react";
import EventDetails from '../components/EventDetails';
import apiurl from './Env';

export default function AllEvent() {


    const [EventList, eventchange] = useState([]);
    const [EventDetail, setEventDetails] = useState(null);


    useEffect(() => {
        axios.get(apiurl)
            .then(res => { eventchange(res.data); })
            .catch(err => console.log(err));
    }, [])

    const RowClick = (tablerow) => {
        setEventDetails(tablerow);

        let offsetTop = document.getElementById("scrollr").offsetTop;
        window.scrollTo({
            top: offsetTop - 100,
            behavior: "smooth"
        });

    }


    const closeformfunction = () => {
        setEventDetails(null);

    }
    return (
        <>
            <Event />
            <div id="scrollr">
                {EventDetail && <EventDetails evendetail={EventDetail} closeForm={closeformfunction} />}
            </div>
            <div className="tableContainer">
                <container>
                    <center>
                        <Table >
                            <tbody>
                                {
                                    EventList && EventList.length > 0
                                        ?
                                        EventList.map((item, index) => {
                                            return (

                                                <tr onClick={() => RowClick(item)}>
                                                    <td className="imagefiled">
                                                        <img className="imgtble" src={item.imageUrl} />
                                                    </td>
                                                    <td >
                                                        <b><h3>{item.title}</h3></b>
                                                        <b><h5>{item.date}</h5></b>
                                                        <br></br>
                                                        <h6> {item.description}</h6>
                                                    </td>
                                                </tr>

                                            );
                                        })

                                        : "Loading.."}
                            </tbody>
                        </Table>

                    </center>
                </container>
            </div>

        </>
    );
}