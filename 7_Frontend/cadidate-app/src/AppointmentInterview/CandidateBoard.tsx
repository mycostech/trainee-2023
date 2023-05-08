
import Grid from '@mui/material/Grid';
import { DragDropContext,  DropResult, ResponderProvided } from 'react-beautiful-dnd';
import ColumnAppointment from "../AppointmentInterview/ColumnAppointment";
import { useContext } from "react";
import CandidateBoardContext from "./CandidateBoardContex";

export interface IColumnAppointment{
    columnId:string,
    columnName:string,
    fontColor:string,
}


function CandidateBoard() {

    const { onChangeStatus } = useContext(CandidateBoardContext)

    const onDragEnd = (result:DropResult, provide:ResponderProvided) =>{
        if(!result.destination) return;

        const { destination, source, draggableId } = result

        if(source.droppableId !== destination.droppableId){
            //change status id
            onChangeStatus(draggableId, destination.droppableId)
        }else if(source.droppableId === destination.droppableId){
            return
        }
    }
    return (
        // <div style={{ display: "flex", flexDirection: "column" }}>
            <div className="Table" style={{ marginTop: "10px" }}>
                <DragDropContext onDragEnd={onDragEnd}>
                    <Grid container spacing={2}>
                        <Grid item xs={3} sx={{ backgroundColor: "white", marginBottom:"auto" }}>
                            <ColumnAppointment column={{ columnId: "1", columnName: "Applies", fontColor: "black" }} />
                        </Grid>
                        <Grid item xs={3} sx={{ backgroundColor: "white", marginBottom: "auto" }}>
                            <ColumnAppointment column={{ columnId: "2", columnName: "Interviews", fontColor: "#00C1CD" }} />
                        </Grid>
                        <Grid item xs={3} sx={{ backgroundColor: "white", marginBottom: "auto" }}>
                            <ColumnAppointment column={{ columnId: "3", columnName: "Passes", fontColor: "#2BC23A" }} />
                        </Grid>
                        <Grid item xs={3} sx={{ backgroundColor: "white", marginBottom: "auto" }}>
                            <ColumnAppointment column={{ columnId: "4", columnName: "Rejects", fontColor: "#FF0000" }} />
                        </Grid>
                    </Grid>
                </DragDropContext>
            </div>
        // </div>
    );
}

export default CandidateBoard