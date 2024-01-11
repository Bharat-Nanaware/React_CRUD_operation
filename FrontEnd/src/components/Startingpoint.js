import React, { Fragment } from 'react'
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { Outlet } from 'react-router-dom';

export default function Startingpoint() {
  return (
    <>
    <div>
       <Navbar bg="dark" data-bs-theme="dark">
          <Nav variant="tabs" defaultActiveKey="/">
            <Nav.Item>
              <Nav.Link href="/">Home</Nav.Link>
            </Nav.Item>
            <Nav.Item>
              <Nav.Link href="/AllEvent">Events</Nav.Link>
            </Nav.Item>
          </Nav>
        </Navbar>
    </div>
    <main>
        <Outlet/>
    </main>
    </>
  )
}
