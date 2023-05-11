import { HeadTitle, IGetCandidate } from "./CandidateProfilesPage";
import { Avatar, Box, Button, Card, Paper, Rating, TextField, Typography } from '@mui/material';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Cancel';
import { useEffect, useState } from 'react';
import {  getCandidateById } from "../Api/ApiCandidate";
import { useNavigate, useParams } from "react-router-dom";
import CommentForm, { ICommentForm } from "../Components/CommentForm";
import { SubmitErrorHandler, SubmitHandler } from "react-hook-form";
import { IApiCommentAndScore, getAllCommentAndScoreByCandidateId, putCommentsAndScores } from "../Api/ApiCommentAndScore";




export default function CommentCandidate() {
    const { handleSubmit, register, formState: { isSubmitting } } = CommentForm()
    const [candidate, setCandidate] = useState<IGetCandidate>({} as IGetCandidate)
    const [commentScores, setCommentScores] = useState<IApiCommentAndScore[]>()
    const params = useParams()
    const navigate = useNavigate()
    useEffect(() => {
        const fetchData = async () => {
            try {
                const fData = await getCandidateById(parseInt(params.id as any))
                setCandidate(fData)
                const fComment = await getAllCommentAndScoreByCandidateId(parseInt(params.id as any));
                setCommentScores(fComment)
            } catch (err) {

            }
        }
        fetchData()
    }, [])

    const ShowComments = () => {
        if (!commentScores) {
            return;
        } else {
            return commentScores.map((data) => {
                return (
                    <Card key={data.commentScoreId} sx={{ padding: "3px", margin:"2px" }}>
                        <Box component={"div"} sx={{margin:"5px"}}>
                            <Rating readOnly value={data.scores / 2} />
                            <Typography fontSize={18} overflow={"hidden"}>{data.comments}</Typography>
                        </Box>
                    </Card>
                );
            })
        }
    }

    const AverageScores = () => {
        if (commentScores === undefined || commentScores.length === 0) {
            return 0;
        } else {
            return (commentScores.reduce((result, num) => result + num.scores, 0) / commentScores.length).toFixed(1);
        }
    }

    const SendFormComment: SubmitHandler<ICommentForm> = async (values) => {
        const formDate: IApiCommentAndScore = {
            commentScoreId: 0,
            candidateId: candidate.candidateId,
            comments: values.comments,
            scores: parseInt(values.scores)
        };
        const status = await putCommentsAndScores(formDate);
        console.log(status)
        setCommentScores(prev => [...prev!, formDate])
        if (status == 200) {
            window.location.reload()
        }
    }

    const btnCancel =() =>{
        navigate("/Evaluation")
    }

    const onErrorComment: SubmitErrorHandler<ICommentForm> = (error) => {
        console.log(error)
    }
    return (
        <div style={{ display: "flex", flexDirection: "column" }}>
            {HeadTitle("Commentation")}
            <Box sx={{ display: "flex", alignItems: "center", margin: "auto" }}>
                <Paper sx={{ display: "flex", flexDirection: "row" }} >
                    <Box component="div" sx={{ width: "500px" }} padding={2}>
                        <Box component="div" bgcolor="#FFDF6A">
                            <Avatar src={candidate.pathImage} alt=""
                                sx={{ width: 150, height: 150, border: 5, borderColor: "#009E95", margin:"auto" }} />
                            <Typography textAlign={"center"}>First Name: {candidate.firstName}</Typography>
                            <Typography textAlign={"center"}>Last Name: {candidate.lastName}</Typography>
                            <Typography textAlign={"center"}>Email: {candidate.email}</Typography>
                            <Typography textAlign={"center"}>Phone: {candidate.phoneNumber}</Typography>
                        </Box>
                        <Box component="div">
                            <Typography>Scores: {AverageScores()} / 10</Typography>
                            <Paper variant="elevation" sx={{ height: "30vh", overflow: "auto", marginBottom: "10px", backgroundColor: "gray" }}>
                                {ShowComments()}
                            </Paper>
                        </Box>
                    </Box>
                    <Box component="form" 
                        sx={{ width: "500px" }} 
                        margin={4} 
                        onSubmit={handleSubmit(SendFormComment, onErrorComment)} 
                        key={candidate.candidateId} >
                        <Box component="div" display={"flex"} flexDirection="row">
                            <Typography fontSize={20}>Scores:</Typography>
                            <TextField id="outlined-multiline-static" size="small" sx={{ width: "50px" }} type="number" {...register("scores")} />
                            <Typography fontSize={20}>/10</Typography>
                        </Box>
                        <Box component="div" display={"flex"} flexDirection={"column"}>
                            <Typography fontSize={20}>Comment:</Typography>
                            <TextField multiline rows={13} id="outlined-multiline-static" {...register("comments")} />
                            <Button 
                                startIcon={<SaveIcon />} 
                                sx={{ color: "#E26354", backgroundColor: "#FFDF6A" }} 
                                type="submit" 
                                disabled={isSubmitting}
                            >
                                Save
                            </Button>
                            <Button 
                                startIcon={<CancelIcon />} 
                                sx={{ color: "#FFFFFF", backgroundColor: "#E40000" }} 
                                onClick={()=>btnCancel()}
                            >
                                Cancle
                            </Button>
                        </Box>
                    </Box>
                </Paper>
            </Box>
        </div>
    );
}
