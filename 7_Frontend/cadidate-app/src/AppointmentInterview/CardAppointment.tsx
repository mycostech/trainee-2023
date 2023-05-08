import { Draggable } from 'react-beautiful-dnd'
import { ICandidate } from '../Api/ApiCandidate';
import SettingsIcon from '@mui/icons-material/Settings';
import { Card, CardContent, Avatar, Typography, CardActions, IconButton, Box } from '@mui/material';
import Profile from '../Imgs/Profiles.jpg';
import LexendExaRegular from '../fonts/static/LexendExa-Regular.ttf'
import LexendExaThin from '../fonts/static/LexendExa-Thin.ttf'

function CardAppointment({index, candidate}:{index:number; candidate:ICandidate}){
    return(
        <Draggable key={candidate.candidateId.toString()} index={index} draggableId={candidate.candidateId.toString()} >
            {(provided)=>(
                <Card ref={provided.innerRef}
                    {...provided.draggableProps}
                    {...provided.dragHandleProps}
                    sx={{backgroundColor:"#47CCC4", padding:"0px"}}
                    
                >
                    <CardContent sx={{display:"flex", flexDirection:"row", padding:"1px"}}>
                        <Avatar 
                            alt={candidate.candidateId?.toString()} 
                            src={Profile} 
                            sx={{width:60,height:60, margin:"4px"}} 
                        />
                        <Typography 
                            margin={1} 
                            fontSize={20} 
                            fontFamily={LexendExaRegular} 
                            sx={{textShadow:"0px 2px 1px #FFDF6A"}}
                            >
                            {candidate.firstName}1
                        </Typography>
                        <Typography 
                            margin={2} 
                            fontSize={20} 
                            fontFamily={LexendExaThin} 
                            sx={{textShadow:"0px 2px 1px #FFDF6A"}}
                            >
                            {candidate.lastName}2
                        </Typography>
                        <Box>
                            <Typography>{}</Typography>
                        </Box>
                        {/* <Typography>{candidate.statusCodeId}</Typography> */}
                        <CardActions sx={{margin:"4px"}}>
                            <IconButton ><SettingsIcon /></IconButton>
                        </CardActions>
                    </CardContent>
                    
                </Card>
            )}
        </Draggable>
    );
}

export default CardAppointment