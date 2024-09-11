import React, { useEffect, useRef, useState } from 'react';
import { Button, Container, Row, Col } from 'react-bootstrap';
import { jsPDF } from 'jspdf';
import html2canvas from 'html2canvas';
import { useLocation } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import logo from '../assets/Extra Images/VitaLogo.png';
import Barcode from 'react-barcode';

const InvoicePage = () => {
  const invoiceRef = useRef();
  const location = useLocation();
  const { invoiceData } = location.state || {};

  const [userData, setUserData] = useState(null);
  const userId = sessionStorage.getItem('userid');

  useEffect(() => {
    //http://localhost:5248/api/User/userForInvoice/${userId}
    
    fetch(`http://localhost:8080/api/user/userForInvoice/${userId}  `)
      .then(response => response.json())
      .then(data => setUserData(data))
      .catch(error => console.error('Error fetching user data:', error));
  
  }, [userId]);

  const handlePrint = () => {
    html2canvas(invoiceRef.current, { scale: 2 }).then((canvas) => {
      const imgData = canvas.toDataURL('image/jpeg', 0.5);
      const pdf = new jsPDF();

      pdf.addImage(imgData, 'JPEG', 15, 10, 180, 160, '', 'FAST');

      const time = new Date().getHours() + '' + new Date().getMinutes() + new Date().getSeconds();
      const pdfName = 'invoice' + userId + time;
      pdf.save(pdfName);

      setTimeout(() => {
       // Dot net http://localhost:5248/api/Email/mailInvoice
        
        fetch('http://localhost:8080/api/email/mailInvoice', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            sendTo: userData?.email,
            path: 'C:/Users/Lenovo/Downloads/' + pdfName + '.pdf'
          }),
        })
          .then(response => response.json())
          .then(data => console.log('Email sent:', data))
          .catch(error => console.error('Error sending email:', error));
      }, 1000);
    });
  };

  const containerStyle = {
    padding: '20px',
    width: '100%',
    maxWidth: '800px',
    border: '1px solid #ddd',
    borderRadius: '8px',
    backgroundColor: '#fff',
    margin: 'auto',
  };

  const logoStyle = {
    width: '120px',
    display: 'block',
    margin: 'auto',
  };

  const barcodeContainerStyle = {
    display: 'flex',
    justifyContent: 'center',
    marginTop: '10px',
  };

  const barcodeStyle = {
    width: '80px',
    height: '30px',
  };

  const bannerStyle = {
    fontSize: '24px',
    fontWeight: 'bold',
    padding: '10px',
    backgroundColor: '#f0f0f0',
    border: '1px solid #ddd',
    textAlign: 'center',
    marginBottom: '20px',
  };

  const listContainerStyle = {
    border: '1px solid #ddd',
    padding: '10px',
    marginBottom: '20px',
    backgroundColor: '#f9f9f9',
  };

  const listStyle = {
    listStyleType: 'none',
    padding: '0',
    margin: '0',
  };

  const listItemStyle = {
    padding: '5px 0',
  };

  const buttonContainerStyle = {
    textAlign: 'center',
    marginTop: '20px',
  };

  // Calculation of amounts
  const basicAmount = invoiceData?.totalPrice || 0;
  console.log(basicAmount);
  const taxAmount = basicAmount * 0.28;
  const totalAmount = basicAmount + taxAmount;

  return (
    <Container fluid>
      <div ref={invoiceRef} style={containerStyle}>
        <Row className="mb-4">
          <Col className="text-center">
            <img src={logo} alt="Logo" style={logoStyle} />
            <div style={barcodeContainerStyle}>
              <Barcode
                value={`${userId}-${new Date().getTime()}`}
                format="CODE39"
                width={1.0}
                height={20}
                displayValue={false}
                style={barcodeStyle}
              />
            </div>
          </Col>
        </Row>
        <Row className="mb-4">
          <Col className="text-center">
            <div style={bannerStyle}>Invoice</div>
          </Col>
        </Row>
        <Row className="mb-4">
          <Col md={6}>
            <p><strong>User ID:</strong> {userId}</p>
            {userData && (
              <>
                <p><strong>Username:</strong> {userData.username}</p>
                <p><strong>Company Name:</strong> {userData.company_name}</p>
              </>
            )}
          </Col>
          <Col md={6}>
            <p><strong>Invoice Date:</strong> {invoiceData?.invoiceDate || new Date().toLocaleDateString()}</p>
            <p><strong>Invoice Number:</strong> {invoiceData?.invoiceNumber || 'QRDK-240' + (invoiceData?.orderedQty || 'N/A')}</p>
            <p><strong>Quantity:</strong> {invoiceData?.orderedQty || 'N/A'}</p>
          </Col>
        </Row>
        <hr />
        <div style={{ paddingBottom: '20px', marginTop: '10px', fontWeight: 'bold', fontSize: '20px' }}>
          Standard Components:
        </div>
        <Row className="mb-4">
          <Col>
            <div style={listContainerStyle}>
              <ul style={listStyle}>
                {invoiceData?.components?.map((component, index) => (
                  <li key={index} style={listItemStyle}>
                    {index + 1}. {component.name}
                  </li>
                ))}
              </ul>
            </div>
            <div style={{ borderTop: '1px solid #ddd', paddingTop: '10px', marginTop: '10px' }}>
              <p>Basic Amount: ₹{basicAmount.toFixed(2)}</p>
              <p>Tax (28% GST): ₹{taxAmount.toFixed(2)}</p>
              <p><strong>Net Payable Amount:</strong> ₹{totalAmount.toFixed(2)}</p>
            </div>
          </Col>
        </Row>
      </div>
      <div style={buttonContainerStyle}>
        <Button variant="primary" onClick={handlePrint}>
          Download Invoice
        </Button>
      </div>
    </Container>
  );
};

export default InvoicePage;
