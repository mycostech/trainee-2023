import axios from "axios"

export interface IApiDateAppointment{
    appointmentID:number,
    candidateId:number,
    startAppointment:string,
    endAppointment:string,
}

const getAllDateAppointment = async() =>{
    return await axios.get('http://localhost:5190/DateAppointment').then(response=>response.data)
}

const postDateAppointment = async(dateAppointment:IApiDateAppointment) =>{
    return await axios.put('http://localhost:5190/DateAppointment',dateAppointment).then(response=>response.status)
}

const getDateAppointmentByCandidateById = async(id:number) =>{
    return await axios.get(`http://localhost:5190/DateAppointment/Candidate/${id}`).then(response=>response.data)
}

const updateDateAppointmentById = async(id:number, data:IApiDateAppointment) =>{
    return await axios.put(`http://localhost:5190/DateAppointment/${id}`,data).then(response=>response.status)
}

export { getAllDateAppointment, postDateAppointment, getDateAppointmentByCandidateById, updateDateAppointmentById }