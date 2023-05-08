import ButtonGroup from '@mui/material/ButtonGroup';
import Button from "@mui/material/Button";
import { useNavigate } from 'react-router-dom';
import Avatar from '@mui/material/Avatar';
import Logo from '../Imgs/mycos-technologies-logo.png';

export default function NavigationBarComponent(){

    const navigate = useNavigate()

    const btnAppointment = () =>{
        navigate("/Appointment")
        // navigate("/Example")
    }

    const btnEvaluation = () =>{
        navigate("/Evaluation")
    }

    const btnCandidate = () =>{
        navigate("/")
    }

    return(
        <div style={{
                display:"flex",
                flexDirection:"row",
                backgroundColor:"#FFDF6A",
                marginBottom:"20px",
                width:"auto",
                height:"60px",
                // justifyContent:"flex-end",
                borderRadius:"0px 0px 9px 9px",
                boxShadow:"5px 5px 5px 2px #7AA1D9"
            }}>
            <div style={{width:"100px"}}>

            </div>

            <div style={{
                    display:"flex",
                    width:"106px",
                    height:"106px",
                    backgroundColor:"#FFDF6A",
                    justifyContent:"center",
                    borderRadius:"200px",
                    boxShadow:"0px 6px 2px 0px #7AA1D9"
                }}>
                <Avatar src={Logo} 
                        sx={{
                                width:"90px",
                                height:"90px",
                                marginTop:"10px"
                            }}/>
            </div>

            <div style={{width:"790px"}}>
            </div>

            <ButtonGroup 
            variant="text" 
            // aria-aria-label='text button group'
            sx={{
                    color:"black",
                    position:"relative",
                    marginRight:"70px",
                    marginTop:"10px",
                    marginBottom:"10px"
                }}>
                
                <Button onClick={()=>btnAppointment()} sx={{color:"black"}}>Appointment & Interview</Button>
                
                <Button onClick={()=>btnEvaluation()} sx={{color:"black"}}>Evaluation</Button>
                
                <Button onClick={()=>btnCandidate()} sx={{color:"black"}}>Candidate</Button>

            </ButtonGroup>

        </div>
    )
}