import axios from "axios"

export interface ICandidate{
    candidateId:number,
    firstName?:string,
    lastName?:string,
    email?:string,
    phoneNumber?:string,
    image?:File,
    imageName:string,
    resume?:File,
    resumeName:string,
    statusCodeID:number
}

export interface ICandidateStatus{
    candidateId:number,
    firstName:string,
    lastName:string,
    email:string,
    phone:string,
    statusDescription:string,
}

const getAllCandidate = async() =>{
    return await axios.get('http://localhost:5190/Candidates').then(response=>{ return response.data})
}

const postCandidate = async(candidate:any) =>{ 
    const config = {
        headers: { "Content-Type": "multipart/form-data" },
    }
    return await axios.post('http://localhost:5190/Candidates',candidate,config).then(response=>response)
}

const getCandidateById = async(id:number) =>{
    return await axios.get(`http://localhost:5190/Candidates/${id}`).then(response=>{return response.data})
}

const getCandidateStatus = async() =>{
    return await axios.get('http://localhost:5190/Candidates/Detail')
}

const getCandidateStatusById = async(id:number) =>{
    return await axios.get(`http://localhost:5190/Candidates/Detail/${id}`).then(response =>{return response.data})
}

const deleteCandidateById = async(candidateId:number) =>{
    await axios.delete(`http://localhost:5190/Candidates/${candidateId}`)
}

const updateCandidateById = async(id:number, candidate:any) =>{
    return axios.put(`http://localhost:5190/Candidates/${id}`,candidate).then(response=>response.status)
}

// const updateStatusCandidateById = async(id:number, statusCode:number) =>{
//     return axios.put(`http://localhost:5190/Candidates/ChangeStatusCode/${id}`,{statusCode:statusCode}).then(response=>response.statusText)
// }

export { getAllCandidate, postCandidate, getCandidateStatus, deleteCandidateById, getCandidateStatusById, getCandidateById, updateCandidateById }