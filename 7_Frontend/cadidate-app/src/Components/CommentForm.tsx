import { z } from 'zod'
import { useForm } from 'react-hook-form'
import { zodResolver } from '@hookform/resolvers/zod'

export interface ICommentForm{
    scores:string,
    comments:string,
}

const validationComment = z.object({
    scores:z.string(),
    comments: z.string()
})

function CommentForm(){
    const form = useForm<ICommentForm>({
        resolver:zodResolver(validationComment),
        defaultValues:{
            scores:"",
            comments:""
        }
    })
    return form;
}

export default CommentForm