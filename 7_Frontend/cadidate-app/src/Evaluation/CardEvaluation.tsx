import { Avatar, Button, Card, CardActions, CardContent, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom'
import ArrowForwardIosSharpIcon from '@mui/icons-material/ArrowForwardIosSharp';
import Profile from '../Imgs/Profiles.jpg';

export default function CardEvaluation(props:any){

    const navigate = useNavigate()
    const btnCommentCandidate = (candidateId:number)=>{
        navigate(`/Evaluation/${candidateId}`)
    }
    return(
        <Card sx={{width:280, backgroundColor:"#FFDF6A", borderRadius:"38px"}}>
            <CardContent sx={{display:"flex", justifyContent:"center", padding:"0px"}}>
                <Avatar src={Profile} alt='' sx={{width:70, height:70, border:3, borderColor:"#3DADA6", margin:"5px"}} />
                <CardContent sx={{backgroundColor:"#47CCC4", width:150, padding:"0px", margin:"5px" } }>
                    <Typography textAlign={"start"}>{props.firstName}</Typography>
                    <Typography textAlign={"end"}>{props.lastName}</Typography>
                </CardContent>                
            </CardContent>
            <CardActions sx={{justifyContent:"flex-end"}}>
                <Button 
                    variant='text' 
                    sx={{color:"#DE5151"}}
                    onClick={()=>btnCommentCandidate(props.candidateId)}
                    >    
                    Comment<ArrowForwardIosSharpIcon />
                </Button>
            </CardActions>
        </Card>
    );
}