import React, { useState, useEffect } from 'react';
import axios from 'axios';

function App() {

  const [country, setCountry] = useState();
  const [city, setCity] = useState();
  const [countryId, setCountryId] = useState(0);
  const [cityId, setCityId] = useState(0);
  const [cash, setCash] = useState();
  const [startTime, setStartTime] = useState();
  const [endTime, setEndTime] = useState();
  const [travel, setTravel] = useState();
  const [totalCash, setTotalCash] = useState();
  const [totalDay, setTotalDay] = useState();
  const [totalCountry, setTotalCountry] = useState();
  const [orderId, setOrderId] = useState(null);


  useEffect(() => {
    axios.get('https://localhost:7244/api/Country/GetAllCountry')
      .then(res => {
        setCountry(res.data);
      })
      .catch(err => {
        console.log(err);
      })

    axios.get("https://localhost:7244/api/Order/GetAllOrder")
      .then(res => {
        setTravel(res.data);
        let totalc = 0;
        let totald = 0;
        res.data.forEach(element => {
          totalc += element.cash;
          totald += new Date(element.endTime) - new Date(element.startTime);
        });
        setTotalCash(totalc);
        setTotalDay(Math.ceil(totald / (1000 * 3600 * 24)));


      })
      .catch(err => {
        console.log(err);
      })

  }, []);

  function handleCountryChange(e) {
    setCountryId(e.target.value);
    const selectedCountry = e.target.value;
    axios.get('https://localhost:7244/api/City/GetAllByCountryId/' + selectedCountry)
      .then(res => {
        setCity(res.data);
      })
      .catch(err => {
        console.log(err);
      })
  }

  function handleCityChange(e) {
    setCityId(e.target.value);
  }

  function putOrder() {
    if (orderId == null) {
      let order = {
        cash: cash,
        countryId: countryId,
        cityId: cityId,
        startTime: startTime,
        endTime: endTime
      }

      axios.post('https://localhost:7244/api/Order/CreateOrder', order)
        .then(res => {
          if (res.status === 200) {
            alert("Order created successfully");
            document.getElementById("close").click();
            axios.get("https://localhost:7244/api/Order/GetAllOrder")
              .then(res => {
                setTravel(res.data);
                let totalc = 0;
                let totald = 0;
                res.data.forEach(element => {
                  totalc += element.cash;
                  totald += new Date(element.endTime) - new Date(element.startTime);
                });
                setTotalCash(totalc);
                setTotalDay(Math.ceil(totald / (1000 * 3600 * 24)));
                setOrderId(null);
              })
              .catch(err => {
                console.log(err);
              })
          }
        })
        .catch(err => {

        })

    } else {
      let order = {
        id: orderId,
        cash: cash,
        countryId: countryId,
        cityId: cityId,
        startTime: startTime,
        endTime: endTime
      }

      axios.put('https://localhost:7244/api/Order/UpdateOrder', order)
        .then(res => {
          if (res.status === 200) {
            alert("Order updated successfully");
            document.getElementById("close").click();
            axios.get("https://localhost:7244/api/Order/GetAllOrder")
              .then(res => {
                setTravel(res.data);
                let totalc = 0;
                let totald = 0;
                res.data.forEach(element => {
                  totalc += element.cash;
                  totald += new Date(element.endTime) - new Date(element.startTime);
                });
                setTotalCash(totalc);
                setTotalDay(Math.ceil(totald / (1000 * 3600 * 24)));
                setOrderId(null);
              })
              .catch(err => {
                console.log(err);
              })
          }
        })
        .catch(err => {

        })
    }
  }


  function checkEndTime(e) {
    if (e.target.value < startTime) {
      alert("Son tarix baslangic tarixinden kicik ola bilmez");
    }
    else {
      setEndTime(e.target.value);
    }
  }

  function deleteOrder(id) {
    console.log(id);
    axios.delete('https://localhost:7244/api/Order/DeleteOrder/' + id)
      .then(res => {
        console.log(res);
        window.location.reload();
      }
      )
      .catch(err => {
        console.log(err);
      }
      )
  }


  function filterTravlesByCountry(country) {
    axios.get('https://localhost:7244/api/Order/GetByCountryId/' + country)
      .then(res => {
        setTravel(res.data);
        let total = 0;
        res.data.forEach(element => {
          total += element.cash;
        });
        setTotalCash(total);
      })
      .catch(err => {
        console.log(err);
      })
  }


  function sortTravels() {
    let descorasc = document.getElementById("descorasc").value;
    let sortby = document.getElementById("sortby").value;


    if (descorasc === "asc") {
      if (sortby === "cash") {
        let sorted = travel.sort((a, b) => a.cash - b.cash)
        setTravel(sorted);
      }
      else if (sortby === "day") {
        setTravel(travel.sort((a, b) => new Date(a.startTime) - new Date(b.startTime)));
      }
    }

    else if (descorasc === "desc") {
      if (sortby === "cash") {
        setTravel(travel.sort((a, b) => b.cash - a.cash));
      }
      else if (sortby === "day") {
        setTravel(travel.sort((a, b) => new Date(b.startTime) - new Date(a.startTime)));
      }
    }

  

    

    //append to table
    let table = document.getElementById("table");
    table.innerHTML = "";
    let index=1;
    travel.forEach(item => {
      table.innerHTML += `<th scope="row">${index + 1}</th>
      <td>${item?.city?.country.name}</td>
      <td>${item?.city?.name}</td>
      <td>${item?.startTime}</td>
      <td>${item?.endTime}</td>
      <td>${item?.cash}</td>`
      index++;
    });


  }







  return (
    <div className="App">
      <div className="container">
        <div className="row d-flex justify-content-between mb-3">
          <div className="col-9 ">
            <h1 className="d-inline float-left">Seyahet Tarixcesi</h1>
          </div>
          <div className="col-3">
            <button type="button" className="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
              Yeni Seyahet
            </button>

            <div className="modal fade" id="exampleModal" tabIndex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
              <div className="modal-dialog" role="document">
                <div className="modal-content">
                  <div className="modal-header">
                    <h5 className="modal-title" id="exampleModalLabel">Modal title</h5>
                    <button type="button" id='close' className="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                  <div className="modal-body">
                    <div className="row">
                      <div className="col-6">
                        <h5>Olke</h5>
                        <select className="form-select" defaultValue={countryId} onChange={(e) => handleCountryChange(e)}>
                          <option value="0" disabled>Olke secin</option>
                          {country && country.map((item, index) => {
                            return (
                              <option key={index} value={item.id}>{item.name}</option>
                            )
                          })}
                        </select>
                      </div>
                      <div className="col-6">
                        <h5>Seher</h5>
                        <select className="form-select" defaultValue={cityId} onChange={(e) => handleCityChange(e)}>
                          <option value="0" disabled>Seher secin</option>
                          {city && city.map((item, index) => {
                            return (
                              <option key={index} value={item.id}>{item.name}</option>
                            )
                          })}
                        </select>
                      </div>
                    </div>
                    <div className="row">
                      <div className="col-6">
                        <h5>Baslama tarixi</h5>
                        <input type="date" className="form-control" id="exampleFormControlInput1" defaultValue={startTime} onChange={(e) => setStartTime(e.target.value)} />
                      </div>
                      <div className="col-6">
                        <h5>Bitme tarixi</h5>
                        <input type="date" className="form-control" id="exampleFormControlInput1" defaultValue={endTime} onChange={(e) => checkEndTime(e)} />
                      </div>
                    </div>
                    <div className="row">
                      <div className="col-6">
                        <h5>Istifade olunan mebleg</h5>
                        <input type="number" className="form-control" id="exampleFormControlInput1" defaultValue={cash} onChange={(e) => setCash(e.target.value)} />
                      </div>
                    </div>

                  </div>
                  <div className="modal-footer">
                    <button type="button" className="btn btn-secondary" data-dismiss="modal">Imtina</button>
                    <button type="button" className="btn btn-primary" onClick={() => putOrder()}>Yaddas</button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div className="row d-flex justify-content-between">
          <div className="col-4">
            <select className="form-select float-left" defaultValue={"0"} onChange={(e) => filterTravlesByCountry(e.target.value)}>
              <option value="0" disabled>Olke secin</option>
              {country && country.map((item, index) => {
                return (
                  <option key={index} value={item.id}>{item.name}</option>
                )
              })}

            </select>
          </div>
          <div className="col-3 float-right">
            <div className="row">
              <div className="col-4">
                <select className="form-select float-left" id='sortby' aria-label="Default select example">
                  <option value="day">Gun</option>
                  <option value="cash">Qiymet</option>
                </select>
              </div>
              <div className="col-4">
                <select className="form-select float-left" id='descorasc' aria-label="Default select example">
                  <option value="asc">Artan</option>
                  <option value="desc">Azalan</option>
                </select>
              </div>
              <div className="col-4">
                <button onClick={() => sortTravels()}>Sirala</button>
              </div>
            </div>
          </div>
        </div>
        <div className="row">
          <div className="col-12">
            <table className="table">
              <thead>
                <tr>
                  <th scope="col">No</th>
                  <th scope="col">Olke</th>
                  <th scope="col">Seher</th>
                  <th scope="col">Baslangic Tarix</th>
                  <th scope="col">Bitme Tarix</th>
                  <th scope="col">Qiymet</th>
                  <th scope="col">Settings</th>
                </tr>
              </thead>
              <tbody id='table'>

                {travel && travel.map((item, index) => {
                  return (
                    <tr key={index}>
                      <th scope="row">{index + 1}</th>
                      <td>{item?.city?.country.name}</td>
                      <td>{item?.city?.name}</td>
                      <td>{item?.startTime}</td>
                      <td>{item?.endTime}</td>
                      <td>{item?.cash}</td>
                      <td>
                        <button type="button" className="btn btn-primary" data-toggle="modal" data-target="#exampleModal" onClick={() => setOrderId(item.id)}>
                          Edit
                        </button>
                        <button type="button" className="btn btn-danger" onClick={() => deleteOrder(item.id)}>
                          Delete
                        </button>
                      </td>
                    </tr>
                  )
                })}
              </tbody>
            </table>
          </div>
        </div>
        <div className="row">
          <div className="col-3">
            <div className="row">
              <p >Olke Sayi {totalCountry}</p>
            </div>
            <div className="row">
              <p>Serf olunan gun {totalDay}</p>
            </div>
            <div className="row">
              <p>Serf olunan mebleg {totalCash}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
