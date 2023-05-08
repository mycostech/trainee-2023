import axios from "axios"

const getAllCommentAndScore = async() =>{
    return await axios.get('').then(response => { return response.data})
} 

export default { getAllCommentAndScore }