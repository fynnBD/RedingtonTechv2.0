import axios from "axios";

axios.interceptors.request.use(request => {
    console.log('Starting Request', JSON.stringify(request, null, 2))
    return request
})

export default
    axios.create({
    baseURL: "https://redingtonapi-ddhnfsftajb8fhg3.canadacentral-01.azurewebsites.net/api/Probability",
  headers: {
      "Content-type": "application/json",
      'Access-Control-Allow-Origin': '*',
  }
});