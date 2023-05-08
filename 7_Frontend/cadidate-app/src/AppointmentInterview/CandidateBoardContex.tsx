import { createContext, ReactElement, useCallback, useState, useEffect } from 'react'
import { ICandidate, getAllCandidate, updateCandidateById } from '../Api/ApiCandidate'

let testData:ICandidate[] = [
   {
    candidateId:1,
    firstName:"string",
    lastName:"string",
    email:"string",
    phoneNumber:"string",
    image:undefined,
    imageName:"string",
    resume:undefined,
    resumeName:"string",
    statusCodeID:1
   },
   {
    candidateId:2,
    firstName:"string",
    lastName:"string",
    email:"string",
    phoneNumber:"string",
    image:undefined,
    imageName:"string",
    resume:undefined,
    resumeName:"string",
    statusCodeID:1
   },
   {
    candidateId:3,
    firstName:"string",
    lastName:"string",
    email:"string",
    phoneNumber:"string",
    image:undefined,
    imageName:"string",
    resume:undefined,
    resumeName:"string",
    statusCodeID:4
   },
   {
    candidateId:4,
    firstName:"string",
    lastName:"string",
    email:"string",
    phoneNumber:"string",
    image:undefined,
    imageName:"string",
    resume:undefined,
    resumeName:"string",
    statusCodeID:3
   },
   {
    candidateId:5,
    firstName:"string",
    lastName:"string",
    email:"string",
    phoneNumber:"string",
    image:undefined,
    imageName:"string",
    resume:undefined,
    resumeName:"string",
    statusCodeID:2
   },
   {
    candidateId:6,
    firstName:"string",
    lastName:"string",
    email:"string",
    phoneNumber:"string",
    image:undefined,
    imageName:"string",
    resume:undefined,
    resumeName:"string",
    statusCodeID:2
   },
   {
    candidateId:7,
    firstName:"string",
    lastName:"string",
    email:"string",
    phoneNumber:"string",
    image:undefined,
    imageName:"string",
    resume:undefined,
    resumeName:"string",
    statusCodeID:2
   },
   {
    candidateId:8,
    firstName:"string",
    lastName:"string",
    email:"string",
    phoneNumber:"string",
    image:undefined,
    imageName:"string",
    resume:undefined,
    resumeName:"string",
    statusCodeID:2
   },
]

export interface ICandidateBoardContext{
    candidateLists:ICandidate[],
    onChangeStatus:(
        candidateId:string,
        destination:string
    )=>void
}

const CandidateBoardContext = createContext<ICandidateBoardContext>({} as ICandidateBoardContext)

export function CandidateBoardContextProvider({children,}:{children:ReactElement}){
    console.log("Provider")
    const [candidates, setCandidate] = useState<ICandidate[]>([] as ICandidate[])

    useEffect(()=>{
        const fetchData = async ()=>{
            console.log("start use effect")
            try{
                let data = await getAllCandidate()
                setCandidate(data)
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
        <CandidateBoardContext.Provider value={{candidateLists:candidates,onChangeStatus}}>
            {children}
        </CandidateBoardContext.Provider>
    );
    
}

export default CandidateBoardContext

