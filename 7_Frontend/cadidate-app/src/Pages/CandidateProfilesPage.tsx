import Grid from '@mui/material/Grid';
import Button from '@mui/material/Button';
import TextInput from '@mui/material/TextField';

import CardCadidate from '../Candidate/CardCandidate';
import FilterAltIcon from '@mui/icons-material/FilterAlt';
import InputAdorenment from '@mui/material/InputAdornment';
import SearchIcon from '@mui/icons-material/Search';
import { useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { getAllCandidate } from '../Api/ApiCandidate';
import IsLoadingPage from './IsLoadingPage';
import SearchBar from '../Components/SearchBar';


export const HeadTitle = (word: string) => {
    return (
        <h1 className='font-LexendExa'
            style={{
                margin: "auto",
                fontSize: "64",
                color: "#09B4A9",
                padding: "10px",
                fontWeight: "bold"
            }}>
            {word}
        </h1>
    );
}

export interface IGetCandidate {
    candidateId: number,
    email: string,
    firstName: string,
    lastName: string,
    pathImage: string,
    pathResume: string,
    phoneNumber: string,
    statusCodeID: number
}

export default function CandidateProfilesPage() {

    const [ fetchCandidate, setFetchCandidate] = useState<IGetCandidate[]>([] as IGetCandidate[])
    const [ isLoading, setIsLoading] = useState<boolean>(false)
    const [ search, setSearch ] = useState<string>("")
    // const [ searchResult, setSearchResult ] = useState<IGetCandidate[]>([])
    useEffect(() => {
        const fData = async () => {
            try {
                setIsLoading(true)
                const fData = await getAllCandidate()
                setFetchCandidate(fData)
            } catch (err) {

            } finally {
                setIsLoading(false)
            }
        }
        fData();
    }, [])

    const navigate = useNavigate()

    const btnAddCandidate = () => {
        navigate("/CreateCandidate")
    }

    // const ShowAllCandidates = () => {
    //     return fetchCandidate.map((item) => {
    //         return (
    //             <Grid item key={item.candidateId}>
    //                 <CardCadidate
    //                     candidate={item}
    //                 />
    //             </Grid>
    //         );
    //     })
    // }

    // const ShowResultCandidate = () =>{
    //     return fetchCandidate
    //     .filter((item)=>
    //     item.firstName.toLowerCase().includes(search.toLowerCase()) || 
    //     item.lastName.toLowerCase().includes(search.toLowerCase()) ||
    //     item.email.toLowerCase().includes(search.toLowerCase()))
    //     .map((item)=>{
    //         return(
    //             <Grid item key={item.candidateId}>
    //                 <CardCadidate
    //                     candidate={item}
    //                 />
    //             </Grid>
    //         );
    //     })
    // }

    // const ShowCandidates = () =>{
    //     if(search !== ""){
    //         return ShowResultCandidate()
    //     }else{
    //         return ShowAllCandidates()
    //     }
    // }

    const btnGetCandidate = async () => {
        try {
            let response: any = await getAllCandidate()
            setFetchCandidate(response)
            console.log(fetchCandidate)
        } catch (err) {

        }
    }

    if (isLoading) {
        return <IsLoadingPage />
    } else {

        return (

            <div className="Board" style={{ display: "flex", flexDirection: "column" }}>

                {HeadTitle("Candidate Profiles")}

                <div className="SearchFillter"
                    style={{
                        display: "flex",
                        flexDirection: "row",
                        justifyContent: "flex-end",
                        marginRight: "180px"
                    }}>
                    <TextInput id="outlined-basic" variant="outlined" size="small" InputProps={{
                        endAdornment: (
                            <InputAdorenment position='end'>
                                <SearchIcon />
                            </InputAdorenment>
                        )
                    }}
                        sx={{
                            margin: "0",
                            width: 342,
                            padding: "0",
                            justifyContent: "center"
                        }}
                        onChange={(event)=>setSearch(event.target.value)}
                    />

                    <Button endIcon={<FilterAltIcon />} sx={{ marginRight: "120px", color: "black" }} onClick={() => btnGetCandidate()} ><p>Filter</p></Button>
                    <Button variant="contained"
                        sx={{
                            width: 200,
                            height: 60,
                            color: "#DE5151",
                            backgroundColor: "#FFDF6A"
                        }}
                        onClick={() => btnAddCandidate()}
                    >
                        Add Candidate
                    </Button>
                </div>

                <div className="Table">
                    <Grid container spacing={1}
                        sx={{
                            justifyContent: "flex-start",
                            padding: "20px",
                            paddingLeft: "153px"
                        }}>
                        {/* {SearchBar({fetch})} */}
                        {/* <SearchBar candidateArray={fetchCandidate} searchText={search} nameComponent={'CardCandidate'}  /> */}
                        {SearchBar({candidateArray:fetchCandidate, searchText:search, nameComponent:'CardCandidate'})}
                    </Grid>
                </div>
            </div>

        );
    }
}