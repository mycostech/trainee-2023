import CreateForm from "../Components/CreateForm.tsx";

export const Paper = (props:any) =>{
    return(
        <div style={{width:"515px", height:"600px", backgroundColor:props.color}}>
            <h1 style={{fontSize:64, padding:"10px", color:props.fontColor, marginBottom:"0px"}}>{props.head}</h1>
            <p style={{fontSize:32, color:"black", margin:"10px"}}>{props.info}</p>
        </div>
    );
}

export default function CreateCandidatePage(){

    return(
        <div style={{display:"flex", flexDirection:"row", justifyContent:"center", paddingTop:"30px"}}>
           <Paper 
                color="#FFDF6A" 
                fontColor="#009E95" 
                head="Create Candidate" 
                info="To create profile of candidates."
            />
           <CreateForm />
        </div>
    );
}