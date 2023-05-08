import { IColumnAppointment } from "./CandidateBoard";
import { Droppable } from 'react-beautiful-dnd';
import { Box, Typography, Paper, IconButton} from '@mui/material';
import CardAppointment from "./CardAppointment";
import { useContext } from "react";
import CandidateBoardContext from "./CandidateBoardContex";

function ColumnAppointment({column}:{column:IColumnAppointment}){
    const { candidateLists } = useContext(CandidateBoardContext)
    const items = candidateLists.filter(data=>data.statusCodeID.toString() === column.columnId)
    return(
        <Droppable key={column.columnId} droppableId={column.columnId}>
            {provide=>(
                <Box ref={provide.innerRef} {...provide.droppableProps} marginRight={3}>
                    <div style={{display:"flex", flexDirection:"row", justifyContent:"space-between"}}>
                        <Typography variant="h6" sx={{color:column.fontColor}}>{column.columnName}</Typography>
                        <IconButton><Typography>Filter</Typography></IconButton>
                    </div>
                    <Paper variant="elevation" sx={{height:"70vh", overflow:"auto"}}  >
                        {items.sort((prev,after)=>prev.candidateId> after.candidateId? 1:-1).map((data,index)=>(
                            <CardAppointment index={index} candidate={data} key={index} />
                        ))}
                        {provide.placeholder}
                    </Paper>
                </Box>
            )}
        </Droppable>
    );
}

export default ColumnAppointment