import { Draggable } from 'react-beautiful-dnd'
import SettingsIcon from '@mui/icons-material/Settings';
import { Card, CardContent, Avatar, Typography, CardActions, IconButton, Box } from '@mui/material';
import LexendExaRegular from '../fonts/static/LexendExa-Regular.ttf';
import LexendExaThin from '../fonts/static/LexendExa-Thin.ttf';
import { useContext, useState } from 'react'
import DefineDateAppointment from '../Components/DefineDateAppointment';
import { IApiDateAppointment } from '../Api/ApiDateAppointment';
import { IGetCandidate } from '../Pages/CandidateProfilesPage';
import CandidateBoardContext from './CandidateBoardContex';

function CardAppointment({ index, candidate, date }: { index: number; candidate: IGetCandidate, date:IApiDateAppointment }) {
    const [dialog, setDialog] = useState<boolean>(false)
    const { onChangeDate } = useContext(CandidateBoardContext)

    const btnCloseDialog = () => {
        setDialog(false)
        console.log(dialog)
    }
    const btnOpenDialog = () => {
        setDialog(true)
        console.log(dialog)
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
                            src={candidate.pathImage}
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
                                    start: {ShowDate(date.startAppointment) || "--/--/----"}
                                </Typography>
                                <Typography textAlign={"center"}>
                                    end: {ShowDate(date.endAppointment) || "--/--/----"}
                                </Typography>
                            </Box>
                        </Box>
                        <CardActions sx={{ margin: "1px", padding: "0px" }}>
                            <IconButton onClick={() => btnOpenDialog()} ><SettingsIcon /></IconButton>
                            <DefineDateAppointment 
                                open={dialog} 
                                onClose={btnCloseDialog} 
                                candidate={candidate} 
                                date={date} 
                                funcSetDate={onChangeDate} 
                            />
                        </CardActions>
                    </CardContent>
                </Card>
            )}
        </Draggable>
    );
}

export default CardAppointment