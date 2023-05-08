import axios from "axios"

const getData = async () =>{
    return await axios.get('http://localhost:5190/StatusCodes').then(res=>{return res})
}

const postData = (data:any) =>{
    axios.put('http://localhost:5190/StatusCodes',{...data})
}



export { getData, postData }