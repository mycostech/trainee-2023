import { createContext, ReactElement, useCallback, useState, useEffect } from 'react'
import { ICandidate, getAllCandidate, updateCandidateById } from '../Api/ApiCandidate'
import { IApiDateAppointment, getAllDateAppointment } from '../Api/ApiDateAppointment'

const getCandidateAndDateAppointment = ()=>{
    return Promise.all([
        getAllCandidate(),
        getAllDateAppointment(),
    ])
}

export interface ICandidateBoardContext{
    candidateLists:ICandidate[],
    dateAppointmentLists:IApiDateAppointment[],
    onChangeStatus:(
        candidateId:string,
        destination:string
    )=>void
}

const CandidateBoardContext = createContext<ICandidateBoardContext>({} as ICandidateBoardContext)

export function CandidateBoardContextProvider({children,}:{children:ReactElement}){
    const [candidates, setCandidate] = useState<ICandidate[]>([] as ICandidate[])
    const [ dateAppointment,setDateAppointment ] = useState<IApiDateAppointment[]>([] as IApiDateAppointment[])
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
    return(
        <CandidateBoardContext.Provider value={{candidateLists:candidates,dateAppointmentLists:dateAppointment,onChangeStatus}}>
            {children}
        </CandidateBoardContext.Provider>
    );
    
}

export default CandidateBoardContext

