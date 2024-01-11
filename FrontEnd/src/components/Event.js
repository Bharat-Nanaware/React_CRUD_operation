import { Link, useNavigate } from "react-router-dom";

function Event() {

  const navigate = useNavigate();
 
  const LoadAddEdit = (id) => {
    navigate("/NewEvent/" + id);
}
 
  return (
    <>
      <div className='conatainer'>
        <center>
          <Link className="btn btn-add" to="/AllEvent">All Events</Link>
          <a onClick={() => { LoadAddEdit(0) }} className="btn btn-add">New Events</a>
        </center>
      </div>
  

    </>)
}

export default Event;

