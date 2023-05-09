import axios from "axios"

export interface IApiCommentAndScore {
    commentScoreId: number,
    candidateId: number,
    comments: string,
    scores: number
}

const getAllCommentAndScore = async () => {
    return await axios.get('http://localhost:5190/CommentAndScore').then(response => { return response.data })
}

const getAllCommentAndScoreByCandidateId = async (id: number) => {
    return await axios.get(`http://localhost:5190/CommentAndScore/Candidate/${id}`).then(response => response.data)
}

const putCommentsAndScores = async(data:IApiCommentAndScore) =>{
    return await axios.put('http://localhost:5190/CommentAndScore',data).then(response=>response.status)
}

export { getAllCommentAndScore, getAllCommentAndScoreByCandidateId, putCommentsAndScores }