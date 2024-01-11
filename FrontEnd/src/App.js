
import "bootstrap/dist/css/bootstrap.min.css";
import './App.css';
import { BrowserRouter as Router, Routes, Route, createBrowserRouter, RouterProvider } from "react-router-dom";
import Events from './components/Event';
import Home from './components/Home';
import NewEvent from './components/NewEvent';
import AllEvent from './components/AllEvent';
import Startingpoint from "./components/Startingpoint";

function App() {

  const applicationRouting = createBrowserRouter([{
    path: "/",
    element: <Startingpoint />,
    children: [
      {
        index:true,
        element: <Home />
      },
      {
        path: "/Events",
        element: <Events />
      },
      {
        path: "/AllEvent",
        element: <AllEvent />
      },
      {
        path: "/NewEvent/:id",
        element: <NewEvent />
      } 
    ]


  }]);

  return (
    <>
      <RouterProvider router={applicationRouting} />
    </>
  );
}

export default App;
