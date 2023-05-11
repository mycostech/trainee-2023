import Button from '@mui/material/Button';
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Cancel';
import TextField from '@mui/material/TextField';
import { IApiCandidate, postCandidate } from '../Api/ApiCandidate';
import { useNavigate } from 'react-router-dom';
import Swal from 'sweetalert2';
import CandidateForm, { ICandidateForm } from './CandidateForm';
import { SubmitErrorHandler, SubmitHandler } from 'react-hook-form';


export const TagInput = (fnc: Function, word: string, tagName: string) => {
    return (
        <>
            <p style={{ color: "black", margin: "2px" }}>{word}</p>
            <TextField {...fnc(tagName)} size='small' sx={{ width: 365 }} />
        </>
    )
}

export const TagUpload = (word: string, tag: string, fnc: Function, mx:string) => {
    return (
        <div style={{ display: "flex", flexDirection: "row" }}>
            <p style={{ color: "black", margin: "2px" }}>{word}</p>
            <Button
                sx={{ backgroundColor: "#47CCC4", color: "white", margin:mx}}
                variant='contained'
                component="label"
            >
                Upload
                <input type="file" {...fnc(tag)} hidden />
            </Button>
        </div>
    );
}

export default function CreateForm() {
    const { handleSubmit, register, formState: { isSubmitting } } = CandidateForm()
    const formData = new FormData()

    const navigate = useNavigate()

    const SendFormCandidate: SubmitHandler<ICandidateForm> = async (values) => {
        // let newCandidate: IApiCandidate = {
        //     candidateId: 0,
        //     firstName: values.firstName,
        //     lastName: values.lastName,
        //     email: values.email,
        //     phoneNumber: values.phone,
        //     image: values.image[0], // null
        //     imageName: values.image[0].name,
        //     resume: values.resume[0], // null
        //     resumeName: values.resume[0].name,
        //     statusCodeID: 1
        // }
        // console.log(newCandidate.image)
        formData.append('candidateId','0')
        formData.append('imageFile',values.image[0])
        formData.append('imageName',values.image[0].name)
        formData.append('firstName',values.firstName)
        formData.append('lastName',values.lastName)
        formData.append('phoneNumber',values.phone)
        formData.append('email',values.email)
        formData.append('resumeFile',values.resume[0])
        formData.append('resumeName',values.resume[0].name)
        formData.append('statusCodeId','1')
        console.log(formData)
        let resp: any = await postCandidate(formData)
        if (resp.status === 201) {
            Swal.fire({
                position: "center",
                icon: "success",
                title: "Candidate has been create.",
                showConfirmButton: false,
                timer: 1500
            }).then(()=>{
                navigate("/")
            })
            
        }
    }

    const onSubmitError: SubmitErrorHandler<ICandidateForm> = (error) => {
        console.log(error)
    }
    const CancelAction = () => {
        navigate('/')
    }

    return (
        <form action="" onSubmit={handleSubmit(SendFormCandidate, onSubmitError)} >
            <div style={{ display: "flex", width: "515px", height: "600px", backgroundColor: "white", flexDirection: "column" }}>
                <h1 style={{ fontSize: 64, color: "black", margin: "0px", textAlign: "center" }}>CREATE</h1>
                <div style={{ margin: "auto", marginTop: "20px", marginBottom: "20px" }}>
                    {TagInput(register, "First Name:", "firstName")}
                    {TagInput(register, "Last Name:", "lastName")}
                    {TagInput(register, "Email:", "email")}
                    {TagInput(register, "Phone Number:", "phone")}
                </div>
                <div style={{ marginTop: "0px", marginBottom: "50px", marginLeft: "75px" }}>
                    {TagUpload("Upload Image: ", "image", register,"0px")}
                    {TagUpload("Upload Resume: ", "resume", register,"0px")}
                </div>
                <div style={{ display: "flex", flexDirection: "column", gap: "8px", padding: "0px", marginLeft: "12px", marginRight: "12px" }}>
                    <Button
                        startIcon={<SaveIcon />}
                        sx={{ color: "#DE5151", backgroundColor: "#FFDF6A" }}
                        type='submit'
                        disabled={isSubmitting}
                    >Create</Button>
                    <Button
                        startIcon={<CancelIcon />}
                        sx={{ color: "#FFFFFF", backgroundColor: "#E40000" }}
                        onClick={() => CancelAction()}
                    >Cancel</Button>
                </div>
            </div>
        </form>
    );
}