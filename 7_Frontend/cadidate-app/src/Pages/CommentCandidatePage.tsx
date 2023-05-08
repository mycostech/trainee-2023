import { HeadTitle } from "./CandidateProfilesPage";
import { Avatar, Box, Button, Card, Paper, Rating, TextField, Typography } from '@mui/material';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Cancel';
import { useEffect, useState } from 'react';
import { ICandidate, getCandidateById } from "../Api/ApiCandidate";
import { useParams } from "react-router-dom";

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

    const [ candidate, setCandidate ] = useState<ICandidate>({}as ICandidate)
    const params = useParams()
    useEffect(()=>{
        const fetchData = async()=>{
            try{
                let fData = await getCandidateById(parseInt(params.id as any))
                setCandidate(fData)
            }catch(err){

            }
        }
        fetchData()
    },[])

    const ShowComments = () => {
        return COMMENT.map((data) => {
            return (
                <Card >
                    <Rating readOnly value={data.scores / 2} />
                    <Typography fontSize={18}>{data.comments}</Typography>
                </Card>
            );
        })
    }

    const AverageScores = () => {
        return COMMENT.reduce((result, num) => result + num.scores, 0) / COMMENT.length;
    }
    return (
        <div style={{ display: "flex", flexDirection: "column"}}>
            {HeadTitle("Commentation")}
            <Box sx={{display:"flex", alignItems:"center", margin:"auto"}}>
                <Paper sx={{ display: "flex", flexDirection: "row" }} >
                    <Box component="div" sx={{width:"500px"}} padding={2}>
                        <Box component="div" bgcolor="#FFDF6A" alignSelf={"auto"} margin={"auto"}>
                            <Avatar src={candidate.imageName} alt="" sx={{ width: 150, height: 150, border: 5, borderColor: "#009E95" }} />
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
                    <Box component="form" sx={{width:"500px"}} margin={4}>
                        <Box component="div" display={"flex"} flexDirection="row">
                            <Typography fontSize={20}>Scores:</Typography>
                            <TextField id="outlined-multiline-static" size="small" sx={{width:"50px"}} InputProps={{ inputMode: 'numeric' }} />
                            <Typography fontSize={20}>/10</Typography>
                        </Box>
                        <Box component="div" display={"flex"} flexDirection={"column"}>
                            <Typography fontSize={20}>Comment:</Typography>
                            <TextField multiline rows={13} id="outlined-multiline-static" />
                            <Button startIcon={<SaveIcon />} sx={{ color: "#E26354", backgroundColor: "#FFDF6A" }}>Save</Button>
                            <Button startIcon={<CancelIcon />} sx={{ color: "#FFFFFF", backgroundColor: "#E40000" }} >Cancle</Button>
                        </Box>
                    </Box>
                </Paper>
            </Box>
        </div>
    );
}