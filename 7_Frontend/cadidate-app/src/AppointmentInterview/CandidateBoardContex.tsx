import { createContext, ReactElement, useCallback, useState, useEffect } from 'react'
import { getAllCandidate, updateCandidateById } from '../Api/ApiCandidate'
import { IApiDateAppointment, getAllDateAppointment } from '../Api/ApiDateAppointment'
import { IGetCandidate } from '../Pages/CandidateProfilesPage'

const getCandidateAndDateAppointment = ()=>{
    return Promise.all([
        getAllCandidate(),
        getAllDateAppointment(),
    ])
}

export interface ICandidateBoardContext{
    candidateLists:IGetCandidate[],
    dateAppointmentLists:IApiDateAppointment[],
    onChangeStatus:(
        candidateId:string,
        destination:string
    )=>void,
    onChangeDate:(
        dateAppointmentId:number,
        startAppointmentIn:string,
        endAppointmentIn:string,
    )=>void,
}

const CandidateBoardContext = createContext<ICandidateBoardContext>({} as ICandidateBoardContext)

export function CandidateBoardContextProvider({children,}:{children:ReactElement}){
    const [candidates, setCandidate] = useState<IGetCandidate[]>([] as IGetCandidate[])
    const [ dateAppointment, setDateAppointment ] = useState<IApiDateAppointment[]>([] as IApiDateAppointment[])
    useEffect(()=>{
        const fetchData = async ()=>{
            try{
                const [candidatesRes, dateAppointmentsRes ] = await getCandidateAndDateAppointment()
                setCandidate(candidatesRes)
                setDateAppointment(dateAppointmentsRes)
            }catch(err){
                alert("error")
            }
        }
        fetchData();
    },[])

    const onChangeStatus = useCallback((candidateId:string, destinationStatus:string)=>{
        setCandidate((prev)=>{
            return prev.map((m) => {
                if (candidateId === m.candidateId.toString()) {
                    updateCandidateById(parseInt(candidateId),{...m,statusCodeID: parseInt(destinationStatus)})
                    return {
                        ...m, statusCodeID: parseInt(destinationStatus)
                    }
                }
                return m
            })
        })
    },[])

    const onChangeDateAppointment = useCallback((dateAppointmentId:number, startAppointmentIn:string, endAppointmentIn:string)=>{
        setDateAppointment((prev)=>{
            return prev.map((m)=>{ 
                if(dateAppointmentId === m.appointmentID){
                    return{
                        ...m,
                        startAppointment:startAppointmentIn,
                        endAppointment:endAppointmentIn
                    }
                }
                return m;
            })
        })
    },[])

    return(
        <CandidateBoardContext.Provider 
            value={{
                candidateLists:candidates,
                dateAppointmentLists:dateAppointment,
                onChangeStatus,
                onChangeDate:onChangeDateAppointment}}>
            {children}
        </CandidateBoardContext.Provider>
    );
    
}

export default CandidateBoardContext

