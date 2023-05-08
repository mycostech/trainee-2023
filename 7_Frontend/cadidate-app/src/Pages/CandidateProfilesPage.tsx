import Grid from '@mui/material/Grid';
import Button from '@mui/material/Button';
import TextInput from '@mui/material/TextField';
import Profile from '../Imgs/Profiles.jpg'
import CardCadidate from '../Candidate/CardCandidate';
import FilterAltIcon from '@mui/icons-material/FilterAlt';
import InputAdorenment from '@mui/material/InputAdornment';
import SearchIcon from '@mui/icons-material/Search';
import { useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { ICandidate, getAllCandidate } from '../Api/ApiCandidate';


export const HeadTitle = (word:string)=>{
    return(
        <h1 className='font-LexendExa' 
                    style={{
                            margin:"auto",
                            fontSize:"64", 
                            color:"#09B4A9", 
                            padding:"10px", 
                            fontWeight:"bold"
                        }}>
                    {word}
                </h1>
    );
}

export const LISTS = [{firstName:"Parinya", lastName:"Muangrod", imagePath:{Profile}, email:"Parinya@gmail.com", phone:"0263159874", candidateId:1},
    {firstName:"Parinya", lastName:"Muangrod", imagePath:{Profile}, email:"Parinya@gmail.com", phoneNumber:"026 315 9874", candidateId:2},
    {firstName:"Parinya", lastName:"Muangrod", imagePath:{Profile}, email:"Parinya@gmail.com", phoneNumber:"026 315 9874", candidateId:3},
    {firstName:"Parinya", lastName:"Muangrod", imagePath:{Profile}, email:"Parinya@gmail.com", phoneNumber:"026 315 9874", candidateId:4},
    {firstName:"Parinya", lastName:"Muangrod", imagePath:{Profile}, email:"Parinya@gmail.com", phoneNumber:"026 315 9874", candidateId:5},
    {firstName:"Parinya", lastName:"Muangrod", imagePath:{Profile}, email:"Parinya@gmail.com", phoneNumber:"026 315 9874", candidateId:6},
    {firstName:"Parinya", lastName:"Muangrod", imagePath:{Profile}, email:"Parinya@gmail.com", phoneNumber:"026 315 9874", candidateId:7}]

export default function CandidateProfilesPage(){

    const [ fetchCandidate, setFetchCandidate ] = useState<ICandidate[]>([]as ICandidate[])
    useEffect(()=>{
        const fData =  async()=>{
            try{
                let fData = await getAllCandidate()
                console.log(fData)
                setFetchCandidate(fData)
            }catch(err){

            }
        }
        fData();
    },[])

    const navigate = useNavigate()

    const btnAddCandidate = () =>{
        navigate("/CreateCandidate")
    }

    const ShowCandidates = ()=>{
        return fetchCandidate.map((item)=>{
            return(
                <Grid item key={item.candidateId}>
                    <CardCadidate 
                        candidateId={item.candidateId}
                        firstName={item.firstName!} 
                        lastName={item.lastName!}
                        imagePath={Profile}
                        email={item.email}
                        phone={item.phoneNumber}
                    />
                    {/* <DeletePopup open={isOpen} onClose={handleClose} /> */}
                </Grid>
            );
        })
    }

    const btnGetCandidate = async () =>{
        try{
            let response:any = await getAllCandidate()
            setFetchCandidate(response)
            console.log(fetchCandidate)
        }catch (err){

        }
    }

    return(
        
            <div className="Board" style={{display:"flex", flexDirection:"column"}}>

                {HeadTitle("Candidate Profiles")}

                <div className="SearchFillter" 
                    style={{
                            display:"flex",
                            flexDirection:"row",
                            justifyContent:"flex-end",
                            marginRight:"180px"
                        }}>
                    <TextInput id="outlined-basic" variant="outlined" size="small" InputProps={{
                        endAdornment:(
                            <InputAdorenment position='end'>
                                <SearchIcon />
                            </InputAdorenment>
                        )
                    }}
                    sx={{
                            margin:"0",
                            width:342,
                            padding:"0",
                            justifyContent:"center"
                        }}
                    />

                    <Button endIcon={<FilterAltIcon />} sx={{marginRight:"120px", color:"black"}} onClick={()=>btnGetCandidate()} ><p>Filter</p></Button>
                    <Button variant="contained" 
                            sx={{
                                    width:200,
                                    height:60,
                                    color:"#DE5151",
                                    backgroundColor:"#FFDF6A"
                                }}
                            onClick={()=>btnAddCandidate()}    
                                >
                            Add Candidate
                    </Button>
                </div>

                <div className="Table">
                <Grid container spacing={1} 
                        sx={{
                                justifyContent:"flex-start",
                                padding:"20px",
                                paddingLeft:"153px"
                            }}>
                    {ShowCandidates()}
                </Grid>

                </div>
            </div>  
        
    );
}