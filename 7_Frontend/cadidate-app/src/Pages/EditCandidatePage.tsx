import EditForm from "../Components/EditForm";
import { Paper } from "./CreateCandidatePage";

export default function EditCandidatePage(){
    return(
        <div style={{display:"flex", flexDirection:"row", justifyContent:"center", paddingTop:"30px"}}>
            <Paper color="#FFDF6A" fontColor="#009E95" head="Edit Candidate" info="To edit profile of candidates" />
            <EditForm />
        </div>
    );
}