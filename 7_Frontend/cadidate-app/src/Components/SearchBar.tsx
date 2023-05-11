import { Grid } from "@mui/material";
import { IGetCandidate } from "../Pages/CandidateProfilesPage";
import CardCandidate from "../Candidate/CardCandidate";
import CardEvaluation from "../Evaluation/CardEvaluation";

function SearchBar({
    candidateArray,
    searchText,
    nameComponent,
}:{
    candidateArray:IGetCandidate[],
    searchText:string,
    nameComponent:string,
    })
{
    if(searchText !== ""){
        return candidateArray
        .filter((item)=>item.firstName.toLowerCase().includes(searchText.toLowerCase())|| 
        item.lastName.toLowerCase().includes(searchText.toLowerCase()) ||
        item.email.toLowerCase().includes(searchText.toLowerCase()) || 
        item.phoneNumber.toLowerCase().includes(searchText.toLowerCase())).map((item)=>{
            return(
                <Grid item key={item.candidateId}>
                    {(nameComponent === "CardCandidate")? <CardCandidate candidate={item} />: <CardEvaluation candidate={item} />}
                </Grid>
            );
        })
    }else{
        return candidateArray.map((item)=>{
            return(
                <Grid item key={item.candidateId}>
                    {(nameComponent === "CardCandidate")? <CardCandidate candidate={item} />: <CardEvaluation candidate={item} />}
                </Grid>
            );
        })
    }
}

export default SearchBar;