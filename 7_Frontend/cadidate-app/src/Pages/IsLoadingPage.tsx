import Logo from '../Imgs/mycos-technologies-logo.png';
import { Avatar, Box, Fade } from '@mui/material';

const icon = () =>{
    return(
        <Fade in={true} timeout={1200}>
            <Avatar 
                src={Logo} 
                alt='' 
                sx={{width:300,height:300, margin:"90px"}} 
            />
        </Fade>
    );
}

export default function IsLoadingPage(){
    return(
        <Box component={"div"} display={"flex"} justifyContent={"center"} margin={"auto"}>
            {icon()}
        </Box>
    );
}