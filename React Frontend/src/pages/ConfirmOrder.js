import React, { useEffect, useState, useRef } from 'react';
import { Container, Row, Col, Button } from 'react-bootstrap';
import logo from '../assets/Extra Images/VitaLogo.png'; 
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import Barcode from 'react-barcode';

const ConfirmOrder = () => {
  const [userData, setUserData] = useState(null);
  const [invoiceData, setInvoiceData] = useState({});
  const [standardComponents, setStandardComponents] = useState([]);
  const invoiceRef = useRef(null);

  const userId = sessionStorage.getItem('userid');
  const myOrder = JSON.parse(sessionStorage.getItem('myOrder')) || [];
  const basePrice = JSON.parse(sessionStorage.getItem('myPrice')) || '0.00';
  const myQuantity = JSON.parse(sessionStorage.getItem('myQuantity')) || 1;

  useEffect(() => {
    //http://localhost:5248/api/User/userForInvoice/${userId}
    //java  
    fetch(`http://localhost:8080/api/user/userForInvoice/${userId}`)
      .then(response => response.json())
      .then(data => setUserData(data))
      .catch(error => console.error('Error fetching user data:', error));

    setInvoiceData({
      invoiceDate: new Date().toLocaleDateString(),
      invoiceNumber: 'X9AT6-240' + (myQuantity || 'N/A'),
      orderedQty: myQuantity,
    });

    const storedComponents = JSON.parse(sessionStorage.getItem('standardComponents')) || [];
    setStandardComponents(storedComponents);
  }, [userId, myQuantity]);

  const basePriceTotal = parseFloat(basePrice) * myQuantity;
  const selectedItemsTotal = myOrder.reduce((total, item) => total + parseFloat(item.price) * myQuantity, 0);
  const totalWithoutGST = basePriceTotal + selectedItemsTotal;
  const gstRate = 0.28;
  const gstAmount = totalWithoutGST * gstRate;
  const totalWithGST = totalWithoutGST + gstAmount;

  const handleDownload = () => {
    html2canvas(invoiceRef.current, { scale: 1.5 }).then((canvas) => {
      const imgData = canvas.toDataURL('image/jpeg', 0.5);
      const pdf = new jsPDF({
        orientation: 'portrait',
        unit: 'mm',
        format: 'a4',
        compress: true,
      });

      pdf.addImage(imgData, 'JPEG', 15, 10, 180, 160, undefined, 'FAST');
      const time = new Date().getHours() + '' + new Date().getMinutes() + new Date().getSeconds();
      const pdfName = 'invoice' + userId + time;
     
      pdf.save(pdfName);

      const abspdfpath = `C:/Users/Lenovo/Downloads/${pdfName}.pdf`;
        //http://localhost:5248/api/Email/mailInvoice
        // Java 
      setTimeout(() => {
        fetch('http://localhost:8080/api/email/mailInvoice', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            sendTo: userData?.email,
            path: abspdfpath,
          }),
        })
        .then(response => response.json())
        .then(data => console.log('Email sent:', data))
        .catch(error => console.error('Error sending email:', error));
      }, 1000);
    });
  };

  return (
    <Container fluid>
      <div style={containerStyle} ref={invoiceRef}>
        <Row className="mb-4">
          <Col className="text-center">
            <img src={logo} alt="Logo" style={logoStyle} />
          </Col>
        </Row>
        <Row className="mb-4">
          <Col className="text-center">
            <div style={bannerStyle}>Invoice</div>
            <div style={barcodeContainerStyle}>
              <Barcode
                value={`${userId}-${new Date().getTime()}`}
                format="CODE39"
                width={1.5}
                height={50}
                background="#ffffff" // Set background to white
                lineColor="#000000"  // Set line color to black
                displayValue={false}
                style={barcodeStyle} // Ensure this style is applied
              />
            </div>
          </Col>
        </Row>

        <Row className="mb-4">
          <Col md={6}>
            <table className="table">
              <tbody>
                <tr>
                  <td><strong>User ID:</strong></td>
                  <td>{userId}</td>
                </tr>
                <tr>
                  <td><strong>Invoice Date:</strong></td>
                  <td>{invoiceData?.invoiceDate || new Date().toLocaleDateString()}</td>
                </tr>
                <tr>
                  <td><strong>Invoice Number:</strong></td>
                  <td>{invoiceData?.invoiceNumber || 'X9AT6-240' + invoiceData?.orderedQty || 'N/A'}</td>
                </tr>
                <tr>
                  <td><strong>Car Quantity:</strong></td>
                  <td>{invoiceData?.orderedQty || 'N/A'}</td>
                </tr>
              </tbody>
            </table>
          </Col>
          <Col md={6}>
            {userData && (
              <table className="table">
                <tbody>
                  <tr>
                    <td><strong>Username:</strong></td>
                    <td>{userData.username}</td>
                  </tr>
                  <tr>
                    <td><strong>Company Name:</strong></td>
                    <td>{userData.company_name}</td>
                  </tr>
                  <tr>
                    <td><strong>GST Number:</strong></td>
                    <td>{userData.gst_number}</td>
                  </tr>
                  <tr>
                    <td><strong>Address:</strong></td>
                    <td>{userData.address_line1}, {userData.address_line2}, {userData.city}</td>
                  </tr>
                  <tr>
                    <td><strong>Email:</strong></td>
                    <td>{userData.email}</td>
                  </tr>
                  <tr>
                    <td><strong>Telephone:</strong></td>
                    <td>{userData.telephone}</td>
                  </tr>
                </tbody>
              </table>
            )}
          </Col>
        </Row>
        <hr></hr>
        <Row className="mb-4">
          <Col md={6}>
            <table className="table">
              <thead>
                <tr>
                  <th>#</th>
                  <th>Standard Component</th>
                </tr>
              </thead>
              <tbody>
                {standardComponents.length > 0 ? (
                  standardComponents.map((item, index) => (
                    <tr key={item.comp_id}>
                      <td>{index + 1}</td>
                      <td>{item.comp_name}</td>
                    </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan="2">No standard components found</td>
                  </tr>
                )}
              </tbody>
            </table>
          </Col>
          <Col md={6}>
            <table className="table">
              <thead>
                <tr>
                  <th> Original--> Modified Alternate </th>
                  <th>Price</th>
                  <th>Quantity</th>
                </tr>
              </thead>
              <tbody>
                {Array.isArray(myOrder) && myOrder.length > 0 ? (
                  myOrder.map((item, index) => (
                    <tr key={index}>
                      <td>{item.name}</td>
                      <td>₹{item.price}</td>
                      <td>{myQuantity}</td>
                    </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan="3">No alternative components found</td>
                  </tr>
                )}
                <tr>
                  <td>Base Price</td>
                  <td>₹{basePrice}</td>
                  <td>{myQuantity}</td>
                </tr>
                <tr>
                  <td>Total</td>
                  <td colSpan="2">₹{totalWithoutGST.toFixed(2)}</td>
                </tr>
                <tr>
                  <td>GST (28%)</td>
                  <td colSpan="2">₹{gstAmount.toFixed(2)}</td>
                </tr>
                <tr>
                  <td><strong>Net Payable Amount</strong></td>
                  <td colSpan="2"><strong>₹{totalWithGST.toFixed(2)}</strong></td>
                </tr>
              </tbody>
            </table>
          </Col>
        </Row>
      </div>
    
      <div style={buttonContainerStyle}>
        <Button variant="primary" onClick={handleDownload}>
          Download Invoice
        </Button>
      </div>
     
    </Container>
  );
};

// Styles similar to InvoicePage
const containerStyle = {
  padding: '20px',
  width: '80%',
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
  width: '200px',
  height: '50px',
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

const buttonContainerStyle = {
  textAlign: 'center',
  marginTop: '20px',
};

export default ConfirmOrder;
