import { IColumnAppointment } from "./CandidateBoard";
import { Droppable } from 'react-beautiful-dnd';
import { Box, Typography, Paper, IconButton} from '@mui/material';
import CardAppointment from "./CardAppointment";
import { useContext } from "react";
import CandidateBoardContext from "./CandidateBoardContex";
import { IApiDateAppointment } from "../Api/ApiDateAppointment";

function ColumnAppointment({column}:{column:IColumnAppointment}){
    const { candidateLists, dateAppointmentLists } = useContext(CandidateBoardContext)
    const items = candidateLists.filter(data=>data.statusCodeID.toString() === column.columnId)
    const dateItems = dateAppointmentLists.filter(date=>items.some(item=> item.candidateId === date.candidateId))
    return(
        <Droppable key={column.columnId} droppableId={column.columnId}>
            {provide=>(
                <Box ref={provide.innerRef} {...provide.droppableProps}>
                    <div style={{display:"flex", flexDirection:"row", justifyContent:"space-between"}}>
                        <Typography variant="h6" sx={{color:column.fontColor}}>{column.columnName}</Typography>
                        <IconButton><Typography>Filter</Typography></IconButton>
                    </div>
                    <Paper variant="elevation" sx={{height:"70vh", overflow:"auto"}}  >
                        {items.map((data,index)=>(
                            <CardAppointment 
                                index={index} 
                                candidate={data} 
                                key={index} 
                                date={dateItems.find(el=>el.candidateId===data.candidateId)||{}as IApiDateAppointment} />
                        ))}
                        {provide.placeholder}
                    </Paper>
                </Box>
            )}
        </Droppable>
    );
}

export default ColumnAppointment