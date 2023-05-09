import { Box, Modal } from "@mui/material"
import { CandidateBoardContextProvider } from "../AppointmentInterview/CandidateBoardContex";
import CandidateBoard from "../AppointmentInterview/CandidateBoard";
import { HeadTitle } from "./CandidateProfilesPage";

export default function AppointmentInterviewPage(){

    return(
        <CandidateBoardContextProvider >
            <div style={{display:"flex", flexDirection:"column"}}>
                {HeadTitle("Appointments & Interviews")}
                <Box sx={{ alignItems:"center", marginLeft:"60px", marginRight:"60px"}}>
                    <CandidateBoard />
                </Box>
            </div>
        </CandidateBoardContextProvider>
        
    );
}