import { HeadTitle } from "./CandidateProfilesPage";
import FilterAltIcon from '@mui/icons-material/FilterAlt';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import CardEvaluation from "../Evaluation/CardEvaluation";
import { Grid } from "@mui/material";
import { useState, useEffect } from 'react'
import { ICandidate, getAllCandidate } from "../Api/ApiCandidate";

export default function EvaluationPage(){

    const [ candidate, setCandidate ] = useState<ICandidate[]>([]as ICandidate[])
    useEffect(()=>{
        const fetchData =async() => {
            try{
                let data = await getAllCandidate()
                setCandidate(data)
            }catch(err){

            }
        }
        fetchData()
    },[])
    const ShowCandidateEvaluation = () =>{
        return candidate.map((data)=>{
            return(
                <Grid item  key={data.candidateId}>
                    <CardEvaluation firstName={data.firstName} lastName={data.lastName} candidateId={data.candidateId} />
                </Grid>
            )
        })
    }
    return(
        <div style={{display:"flex", flexDirection:"column", justifyContent:"center"}}>
            {HeadTitle("Evaluation")}
            <div style={{ margin:"auto"}}>
                <TextField id="outlined-basic" size="small" variant="outlined" sx={{marginTop:"12px", width:"350px"}} />
                <Button endIcon={<FilterAltIcon />} sx={{color:"black"}} ><p>Filter</p></Button>
            </div>
            <Grid container spacing={2} justifyContent={"flex-start"} margin={"auto"} width={1450}>
                {ShowCandidateEvaluation()}
            </Grid>
            
        </div>
    );
}