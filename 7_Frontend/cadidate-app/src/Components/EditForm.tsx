import { SubmitErrorHandler, SubmitHandler } from "react-hook-form";
import CandidateForm, { ICandidateForm } from "./CandidateForm";
import { Avatar, Box, Button, Paper, Typography } from "@mui/material";
import { TagInput, TagUpload } from "./CreateForm";
import SaveIcon from '@mui/icons-material/Save';
import CancelIcon from '@mui/icons-material/Cancel';
import { useNavigate, useParams } from 'react-router-dom'
import { useEffect, useState } from 'react'
import { getCandidateById } from "../Api/ApiCandidate";
import IsLoadingPage from "../Pages/IsLoadingPage";
import { IGetCandidate } from "../Pages/CandidateProfilesPage";

export default function EditForm() {
    const { handleSubmit, register, formState: { isSubmitting } } = CandidateForm()
    const navigate = useNavigate()
    const params = useParams()
    const [ candidate, setCandidate ] = useState<IGetCandidate>()
    const [ isLoading, setIsLoading ] = useState<boolean>(false)
    useEffect(()=>{
        const fData = async() =>{
            try{
                setIsLoading(true)
                let data = await getCandidateById(parseInt(params.id!))
                setCandidate(data)
            }catch(err){

            }finally{
                setIsLoading(false)
            }
        }
        fData()
    },[])

    const btnCancle = ()=>{
        navigate("/")
    }
    const SendUpdateForm: SubmitHandler<ICandidateForm> = async (values) => {

    }

    const onSubmitError: SubmitErrorHandler<ICandidateForm> = async () => {

    }

    if(isLoading){
        return(
            <IsLoadingPage />
        );
    }else{
    return (
        <form action="" onSubmit={handleSubmit(SendUpdateForm, onSubmitError)} >
            <Box sx={{display:"flex", alignItems:"center", margin:"auto"}}>
                <Paper sx={{padding:"2px"}}>
                    <Box component={"div"} alignItems={"center"} >
                        <Typography fontSize={64} textAlign={"center"} color={"black"}>EDIT</Typography>
                        <Avatar src={candidate?.pathImage} alt='' sx={{width:80,height:80, margin:"auto"}} />
                        {TagUpload("", "image", register, "auto")}
                        {TagInput(register, "First Name: ", "firstName")}
                        {TagInput(register, "Last Name: ", "lastName")}
                        {TagInput(register, "Email: ", "email")}
                        {TagInput(register, "Phone Number: ", "phone")}
                        {TagUpload("Upload Resume:", "resume", register, "0px")}
                    </Box>
                    <Box component={"div"} display={"flex"} flexDirection={"column"} >
                        <Button 
                            startIcon={<SaveIcon />} 
                            sx={{ color: "#E26354", backgroundColor: "#FFDF6A", margin:"2px" }}
                            disabled={isSubmitting}
                            >
                                Save
                        </Button>
                        <Button 
                            startIcon={<CancelIcon />} 
                            sx={{ color: "white", backgroundColor: "#E40000", margin:"2px" }}
                            onClick={()=>btnCancle()}
                            >
                                Cancel
                        </Button>
                    </Box>
                </Paper>
            </Box>

        </form>
    );
    }
}