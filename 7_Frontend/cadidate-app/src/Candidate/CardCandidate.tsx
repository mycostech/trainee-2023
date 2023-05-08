import EditIcon from '@mui/icons-material/Edit';
import CardCandidate from '@mui/material/Card'
import EmailIcon from '@mui/icons-material/Email';
import PhoneIcon from '@mui/icons-material/Phone';
import DeleteIcon from '@mui/icons-material/Delete';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import Swal from 'sweetalert2';
import { deleteCandidateById } from '../Api/ApiCandidate';
import { useNavigate } from 'react-router-dom'

const AvatarStyle = { width:60, height:60, margin:"10px", strokeWidth:"3px" }
const CardCandidateStyle = {backgroundColor:"#FFDF6A", width:280,height:130,display:'flex', borderRadius:"38px"}
const LexendaExaRegularStyle = {fontSize:20, margin:"0%", padding:"0%", alignItems:'flex-start' }
const LastNameStyle = { fontSize:20, margin:"0%", padding:"0%", marginLeft:"70px"}
const IConLargeStyle = {width:24, height:24}
const IConSmallStyle = {width:20, height:20, color:"black"}
// const HeadContainStyle = {}

interface ICardCandidate{
    candidateId:number,
    imagePath?:string,
    firstName:string,
    lastName:string,
    email?: string,
    phone?: string,
}

export default function CardCadidate({candidateId,imagePath,firstName,lastName,email,phone}:ICardCandidate){

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
                deleteCandidateById(candidateId)
                window.location.reload()
            }
        })
        
    }

    const btnEditCanidate = () =>{
        navigate("/EditCandidate/" + candidateId.toString())
    }
    return(
        <>
            <CardCandidate sx={CardCandidateStyle}>
                <Avatar alt="" src={imagePath} sx={AvatarStyle} ></Avatar>

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

                            <h1 style={LexendaExaRegularStyle}>{firstName}</h1>
                        </div>
                        <h1 style={LastNameStyle}>{lastName}</h1>
                    </div>

                    <div className='GroupEmail' style={{display:'flex', gap:"12px"}}>
                        <EmailIcon sx={IConLargeStyle} />
                        <p style={{margin:'0'}}>{email}</p>
                    </div>

                    <div className='GroupPhone' style={{display:'flex', gap:"12px"}}>
                        <PhoneIcon sx={IConLargeStyle} />
                        <p style={{margin:'0'}}>{phone}</p>
                    </div>

                </div>
            </CardCandidate>
        </>
    );
}