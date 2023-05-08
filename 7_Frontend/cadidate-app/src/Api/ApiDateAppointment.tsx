import axios from "axios"

export interface IDateAppointment{
    appointmentID:number,
    startAppointment:string,
    endAppointment:string,
}

const getAllDateAppointment = async() =>{
    return await axios.get('http://localhost:5190/DateAppointment').then(response=>response.data)
}

const postDateAppointment = async(dateAppointment:IDateAppointment) =>{
    return await axios.put('http://localhost:5190/DateAppointment',).then()
}

export { getAllDateAppointment, postDateAppointment }