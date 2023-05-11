import { HeadTitle, IGetCandidate } from "./CandidateProfilesPage";
import FilterAltIcon from '@mui/icons-material/FilterAlt';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import CardEvaluation from "../Evaluation/CardEvaluation";
import { Grid } from "@mui/material";
import { useState, useEffect } from 'react'
import {  getAllCandidate } from "../Api/ApiCandidate";
import SearchBar from "../Components/SearchBar";

export default function EvaluationPage(){

    const [ candidate, setCandidate ] = useState<IGetCandidate[]>([]as IGetCandidate[])
    const [ searchBar, setSearchBar ] = useState<string>("")
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
                    <CardEvaluation candidate={data} />
                </Grid>
            )
        })
    }
    return(
        <div style={{display:"flex", flexDirection:"column", justifyContent:"center"}}>
            {HeadTitle("Evaluation")}
            <div style={{ margin:"auto"}}>
                <TextField 
                    id="outlined-basic" size="small" variant="outlined" sx={{marginTop:"12px", width:"350px"}} onChange={(event)=>setSearchBar(event.target.value)} />
                <Button endIcon={<FilterAltIcon />} sx={{color:"black"}} ><p>Filter</p></Button>
            </div>
            <Grid container spacing={2} justifyContent={"flex-start"} margin={"auto"} width={1450}>
                {SearchBar({candidateArray:candidate, searchText:searchBar, nameComponent:'CardEvaluation'})}
            </Grid>
        </div>
    );
}