import { Draggable } from 'react-beautiful-dnd'
import { ICandidate } from '../Api/ApiCandidate';
import SettingsIcon from '@mui/icons-material/Settings';
import { Card, CardContent, Avatar, Typography, CardActions, IconButton, Box } from '@mui/material';
import Profile from '../Imgs/Profiles.jpg';
import LexendExaRegular from '../fonts/static/LexendExa-Regular.ttf';
import LexendExaThin from '../fonts/static/LexendExa-Thin.ttf';
import { useState } from 'react'
import DefineDateAppointment from '../Components/DefineDateAppointment';

function CardAppointment({ index, candidate }: { index: number; candidate: ICandidate }) {
    const [dialog, setDialog] = useState<boolean>(false)

    const btnCloseDialog = () => {
        setDialog(false)
    }
    const btnOpenDialog = () => {
        setDialog(true)
    }
    const ShowDate = (value: string) => {
        if (value !== undefined) {
            const arrayDate = value.split("T")
            return arrayDate[0] + " " + arrayDate[1];
        } else {
            return;
        }
    }

    return (
        <Draggable key={candidate.candidateId.toString()} index={index} draggableId={candidate.candidateId.toString()} >
            {(provided) => (
                <Card ref={provided.innerRef}
                    {...provided.draggableProps}
                    {...provided.dragHandleProps}
                    sx={{ backgroundColor: "#47CCC4", margin: "6px" }}

                >
                    <CardContent sx={{ display: "flex", flexDirection: "row", padding: "1px" }}>
                        <Avatar
                            alt={candidate.candidateId?.toString()}
                            src={Profile}
                            sx={{ width: 60, height: 60, margin: "4px" }}
                        />
                        <Box component={"div"} style={{ display: "flex", flexDirection: "column" }}>
                            <Box component={"div"} style={{ display: "flex", flexDirection: "row" }}>
                                <Typography
                                    margin={1}
                                    fontSize={16}
                                    width={72}
                                    fontFamily={LexendExaRegular}
                                    sx={{ textShadow: "0px 2px 1px #FFDF6A", overflow: "clip" }}
                                >
                                    {candidate.firstName}
                                </Typography>
                                <Typography
                                    margin={1}
                                    fontSize={16}
                                    width={72}
                                    fontFamily={LexendExaThin}
                                    sx={{ textShadow: "0px 2px 1px #FFDF6A", overflow: "clip" }}
                                >
                                    {candidate.lastName}
                                </Typography>
                            </Box>
                            <Box component={"div"} bgcolor={"yellow"}>
                                <Typography textAlign={"center"} >
                                    start: {ShowDate(undefined!) || "--/--/----"}
                                </Typography>
                                <Typography textAlign={"center"}>
                                    end: {ShowDate(undefined!) || "--/--/----"}
                                </Typography>
                            </Box>
                        </Box>
                        <CardActions sx={{ margin: "1px", padding: "0px" }}>
                            <IconButton onClick={() => btnOpenDialog()} ><SettingsIcon /></IconButton>
                            <DefineDateAppointment 
                                open={dialog} 
                                onClose={btnCloseDialog} 
                                candidate={candidate} 
                                date={undefined!} 
                                funcSetDate={undefined!} 
                            />
                        </CardActions>
                    </CardContent>
                </Card>
            )}
        </Draggable>
    );
}

export default CardAppointment