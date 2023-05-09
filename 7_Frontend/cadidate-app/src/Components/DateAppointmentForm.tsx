import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { z } from 'zod';

export interface IDateAppointment{
    startDate:string,
    endDate:string,
}

const validationDateAppointment = z.object({
    startDate:z.string(),
    endDate:z.string()
})

function DateAppointmentForm(){
    const form = useForm<IDateAppointment>({
        resolver:zodResolver(validationDateAppointment),
        defaultValues:{
            startDate:"",
            endDate:""
        }
    })
    return form;
}

export default DateAppointmentForm