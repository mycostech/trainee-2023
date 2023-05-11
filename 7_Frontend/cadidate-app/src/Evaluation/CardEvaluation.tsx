import { Avatar, Button, Card, CardActions, CardContent, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom'
import ArrowForwardIosSharpIcon from '@mui/icons-material/ArrowForwardIosSharp';
import { IGetCandidate } from '../Pages/CandidateProfilesPage';

export default function CardEvaluation({candidate}:{candidate:IGetCandidate}){

    const { candidateId, firstName, lastName, pathImage, pathResume, email, phoneNumber } = candidate
    const navigate = useNavigate()
    const btnCommentCandidate = (candidateId:number)=>{
        navigate(`/Evaluation/${candidateId}`)
    }
    return(
        <Card sx={{width:250, backgroundColor:"#FFDF6A", borderRadius:"38px"}}>
            <CardContent sx={{display:"flex", justifyContent:"center", padding:"0px"}}>
                <Avatar src={pathImage} alt='' sx={{width:50, height:50, border:3, borderColor:"#3DADA6", margin:"5px"}} />
                <CardContent sx={{backgroundColor:"#47CCC4", width:"160px", padding:"0px", margin:"5px" } }>
                    <Typography textAlign={"start"} marginLeft={2}>{firstName}</Typography>
                    <Typography textAlign={"end"} marginRight={2}>{lastName}</Typography>
                </CardContent>                
            </CardContent>
            <CardActions sx={{justifyContent:"flex-end", padding:"0px"}}>
                <Button 
                    variant='text' 
                    sx={{color:"#DE5151"}}
                    onClick={()=>btnCommentCandidate(candidateId)}
                    >    
                    Comment<ArrowForwardIosSharpIcon />
                </Button>
            </CardActions>
        </Card>
    );
}