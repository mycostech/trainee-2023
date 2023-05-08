import { zodResolver } from '@hookform/resolvers/zod'
import { useForm } from 'react-hook-form'
import { z } from 'zod'

export interface ICandidateForm{
    firstName:string,
    lastName:string,
    email:string,
    phone:string,
    image:FileList,
    resume:FileList,
}

const validationCandidate = z.object({
    firstName:z.string().min(1,{message:"First name is require"}),
    lastName:z.string().min(1,{message:"Last name is require"}),
    email:z.string().min(1,{message:"Email is require"}).email({message:""}),
    phone:z.string().min(1,{message:"Phone number is require"}).max(10,{message:"Phone number is valid"}),
    image:z.instanceof(FileList),
    resume:z.instanceof(FileList),
})


function CandidateForm(){
    const form = useForm<ICandidateForm>({
        resolver: zodResolver(validationCandidate),
        defaultValues:{
            firstName:"",
            lastName:"",
            email:"",
            phone:"",
            image:undefined,
            resume:undefined,
        }
    })
    return form;
}

export default CandidateForm