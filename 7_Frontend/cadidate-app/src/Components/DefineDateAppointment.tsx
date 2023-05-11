import { Modal, Button, Avatar, Card, CardContent, Typography, CardActions, Box, TextField } from '@mui/material';
import CancelIcon from '@mui/icons-material/Cancel';
import SaveIcon from '@mui/icons-material/Save';
import DateAppointmentForm, { IDateAppointment } from './DateAppointmentForm';
import { SubmitHandler, SubmitErrorHandler } from 'react-hook-form';
import { IApiDateAppointment, postDateAppointment, updateDateAppointmentById } from '../Api/ApiDateAppointment';
import Swal from 'sweetalert2';

export default function DefineDateAppointment(props:any){

    const { handleSubmit, register } = DateAppointmentForm()

    const SendFormDateAppointment:SubmitHandler<IDateAppointment> = async(values) =>{
        const formData:IApiDateAppointment = {
            appointmentID: props.date.appointmentID || 0,
            candidateId:props.candidate.candidateId,
            startAppointment: values.startDate,
            endAppointment: values.endDate
        }
        props.onClose()
        if(props.date.startAppointment == undefined || props.date.endAppointment == undefined){
            const status = await postDateAppointment(formData)
        }else{
            const status = await updateDateAppointmentById(props.date.appointmentID,formData);
        }
        props.funcSetDate(props.date.appointmentID, values.startDate, values.endDate)
        Swal.fire({
            position:"center",
            icon:"success",
            title:"Add Date appointment successfull."
        }).then((result)=>{
            if(result.isConfirmed){
                window.location.reload()
            }
        })
    }

    const onFormDateAppointmentError:SubmitErrorHandler<IDateAppointment> = (error) =>{
        console.log(error)
    }
    return(
        <Modal open={props.open} onClose={props.onClose} sx={{display:"flex", justifyContent:"center", alignItems:"center", margin:"auto"}}>
            <Card sx={{width:"auto", height:"600px"}}>
                <Avatar src={props.candidate.pathImage} alt='' sx={{width:100, height:100, alignContent:"center", margin:"auto"}} />
                <CardContent sx={{margin:"auto"}}>
                    <Typography textAlign={"center"} fontSize={32}>PROFILE</Typography>
                    <Typography fontSize={20}>Fisrt Name: {props.candidate.firstName}</Typography>
                    <Typography fontSize={20}>Last Name: {props.candidate.lastName}</Typography>
                    <Typography fontSize={20}>Email: {props.candidate.email}</Typography>
                    <Typography fontSize={20}>Phone Number: {props.candidate.phone}</Typography>
                </CardContent>
                <CardActions sx={{alignItems:"center"}}>
                    <form onSubmit={handleSubmit(SendFormDateAppointment,onFormDateAppointmentError)}>   
                        <Typography>Start Date:</Typography>
                        <TextField type='datetime-local' {...register("startDate")} />
                        <Typography>End Date:</Typography>
                        <TextField type='datetime-local' {...register("endDate")} />
                        <Box >
                            <Button startIcon={<SaveIcon />} type='submit'>Save</Button>
                            <Button startIcon={<CancelIcon />} onClick={()=>props.onClose()} >Cancel</Button>
                        </Box>
                    </form>
                </CardActions>
             </Card>
        </Modal>
    );
}