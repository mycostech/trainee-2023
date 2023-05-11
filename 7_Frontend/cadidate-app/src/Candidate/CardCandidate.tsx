import EditIcon from '@mui/icons-material/Edit';
import Card from '@mui/material/Card'
import EmailIcon from '@mui/icons-material/Email';
import PhoneIcon from '@mui/icons-material/Phone';
import DeleteIcon from '@mui/icons-material/Delete';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import Swal from 'sweetalert2';
import { deleteCandidateById } from '../Api/ApiCandidate';
import { useNavigate } from 'react-router-dom'
import { Box } from '@mui/material';
import { IGetCandidate } from '../Pages/CandidateProfilesPage';

const AvatarStyle = { width:60, height:60, margin:"10px", strokeWidth:"3px" }
const CardCandidateStyle = {backgroundColor:"#FFDF6A", width:280,height:130,display:'flex', borderRadius:"38px"}
const LexendaExaRegularStyle = {fontSize:20, margin:"0%", padding:"0%", alignItems:'flex-start' }
const LastNameStyle = { fontSize:20, margin:"0%", padding:"0%", marginLeft:"70px"}
const IConLargeStyle = {width:24, height:24}
const IConSmallStyle = {width:20, height:20, color:"black"}
// const HeadContainStyle = {}

// export default function CardCadidate({candidateId,imagePath,firstName,lastName,email,phone,resumePath}:ICardCandidate){
export default function CardCandidate({candidate}:{candidate:IGetCandidate}){
    const navigate = useNavigate()
    const btnDeleteCandidate = () =>{
        Swal.fire({
            title:"Are you want delete?",
            text:"You won't be able to revert this!",
            icon:"warning",
            showCancelButton:true,
            confirmButtonText:"Yes",
        }).then((result)=>{
            if(result.isConfirmed){
                deleteCandidateById(candidate.candidateId)
                window.location.reload()
            }
        })
        
    }

    const btnEditCanidate = () =>{
        navigate("/EditCandidate/" + candidate.candidateId.toString())
    }

    const btnDownloadResume = () =>{
        if(candidate.pathResume !== ""){
            window.open(candidate.pathResume)
        }else{
            Swal.fire({
                icon:"error",
                position:"center",
                title:"Not have resume file.",
                timer:1500
            })
        }
    }

    const ShowButtonDownload = () =>{
        if(candidate.pathResume !== ""){
            return <Button onClick={()=>btnDownloadResume()}>Resume</Button>
        }else{
            return;
        }
    }
    return(
        <>
            <Card sx={CardCandidateStyle}>
                <Box component={"div"}  >
                    <Avatar alt="" src={candidate.pathImage} sx={AvatarStyle} />
                    {ShowButtonDownload()}
                </Box>
                <div className="CandidateInfo" style={{display:"flex", flexDirection:"column", padding:"2px"}}>
                    <div style={{
                                display:'flex',
                                width:"200px",
                                justifyContent:"flex-end",
                                backgroundColor:"#47CCC4"
                            }}>
                                <Button startIcon={<EditIcon sx={{padding:"0px"}} />} sx={IConSmallStyle} onClick={()=>btnEditCanidate()} />
                                <Button startIcon={<DeleteIcon />} sx={IConSmallStyle} onClick={()=>btnDeleteCandidate()} />
                                <div style={{paddingRight:"30px"}}></div>
                    </div>
                    <div className="GroupName" style={{backgroundColor:"#47CCC4", margin:"0", padding:"3px", width:"192px"}}>
                        <div className='HeadContain' style={{display:'flex', flexDirection:'row', margin:'auto'}}>

                            <h1 style={LexendaExaRegularStyle}>{candidate.firstName}</h1>
                        </div>
                        <h1 style={LastNameStyle}>{candidate.lastName}</h1>
                    </div>

                    <div className='GroupEmail' style={{display:'flex', gap:"12px"}}>
                        <EmailIcon sx={IConLargeStyle} />
                        <p style={{margin:'0'}}>{candidate.email}</p>
                    </div>

                    <div className='GroupPhone' style={{display:'flex', gap:"12px"}}>
                        <PhoneIcon sx={IConLargeStyle} />
                        <p style={{margin:'0'}}>{candidate.phoneNumber}</p>
                    </div>
                </div>
            </Card>
        </>
    );
}