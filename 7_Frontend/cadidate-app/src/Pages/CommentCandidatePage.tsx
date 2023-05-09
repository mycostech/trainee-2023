import { HeadTitle } from "./CandidateProfilesPage";
import { Avatar, Box, Button, Card, Paper, Rating, TextField, Typography } from '@mui/material';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Cancel';
import { useEffect, useState } from 'react';
import { ICandidate, getCandidateById } from "../Api/ApiCandidate";
import { useParams } from "react-router-dom";
import CommentForm, { ICommentForm } from "../Components/CommentForm";
import { SubmitErrorHandler, SubmitHandler } from "react-hook-form";
import { IApiCommentAndScore, getAllCommentAndScoreByCandidateId, putCommentsAndScores } from "../Api/ApiCommentAndScore";


const COMMENT = [
    {
        scores: 5,
        comments: "Golden Hour",
    },
    {
        scores: 6,
        comments: "Good Luck",
    },
    {
        scores: 4,
        comments: "Dancing",
    },
    {
        scores: 5,
        comments: "So, Amazing",
    },
]

export default function CommentCandidate() {
    const { handleSubmit, register, formState: { isSubmitting } } = CommentForm()
    const [candidate, setCandidate] = useState<ICandidate>({} as ICandidate)
    const [commentScores, setCommentScores] = useState<IApiCommentAndScore[]>()
    const params = useParams()
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
                    <Card key={data.commentScoreId} sx={{ padding: "3px" }}>
                        <Box component={"div"} sx={{margin:"5px"}}>
                            <Rating readOnly value={data.scores / 2} />
                            <Typography fontSize={18}>{data.comments}</Typography>
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
            return (commentScores.reduce((result, num) => result + num.scores, 0) / commentScores.length).toFixed(2);
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

    const onErrorComment: SubmitErrorHandler<ICommentForm> = (error) => {
        console.log(error)
    }
    return (
        <div style={{ display: "flex", flexDirection: "column" }}>
            {HeadTitle("Commentation")}
            <Box sx={{ display: "flex", alignItems: "center", margin: "auto" }}>
                <Paper sx={{ display: "flex", flexDirection: "row" }} >
                    <Box component="div" sx={{ width: "500px" }} padding={2}>
                        <Box component="div" bgcolor="#FFDF6A" margin={"auto"}>
                            <Avatar src={candidate.imageName} alt=""
                                sx={{ width: 150, height: 150, border: 5, borderColor: "#009E95" }} />
                            <Typography>First Name: {candidate.firstName}</Typography>
                            <Typography>Last Name: {candidate.lastName}</Typography>
                            <Typography>Email: {candidate.email}</Typography>
                            <Typography>Phone: {candidate.phoneNumber}</Typography>
                        </Box>
                        <Box component="div">
                            <Typography>Scores: {AverageScores()} / 10</Typography>
                            <Paper variant="elevation" sx={{ height: "30vh", overflow: "auto", marginBottom: "10px", backgroundColor: "gray" }}>
                                {ShowComments()}
                            </Paper>
                        </Box>
                    </Box>
                    <Box component="form" sx={{ width: "500px" }} margin={4} onSubmit={handleSubmit(SendFormComment, onErrorComment)}>
                        <Box component="div" display={"flex"} flexDirection="row">
                            <Typography fontSize={20}>Scores:</Typography>
                            <TextField id="outlined-multiline-static" size="small" sx={{ width: "50px" }} type="number" {...register("scores")} />
                            <Typography fontSize={20}>/10</Typography>
                        </Box>
                        <Box component="div" display={"flex"} flexDirection={"column"}>
                            <Typography fontSize={20}>Comment:</Typography>
                            <TextField multiline rows={13} id="outlined-multiline-static" {...register("comments")} />
                            <Button startIcon={<SaveIcon />} sx={{ color: "#E26354", backgroundColor: "#FFDF6A" }} type="submit" disabled={isSubmitting}>Save</Button>
                            <Button startIcon={<CancelIcon />} sx={{ color: "#FFFFFF", backgroundColor: "#E40000" }} >Cancle</Button>
                        </Box>
                    </Box>
                </Paper>
            </Box>
        </div>
    );
}
