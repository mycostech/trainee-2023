import './App.css'
import { Route, Routes } from 'react-router-dom'
import CandidateProfilesPage from './Pages/CandidateProfilesPage'
import NavigationBarComponent from './Components/NavigationBarComponent';
import AppointmentInterviewPage from './Pages/AppointmentInterviewPage';
import CreateCandidatePage from './Pages/CreateCandidatePage';
import EvaluationPage from './Pages/EvaluationPage';
import EditCandidatePage from './Pages/EditCandidatePage';
import CommentCandidate from './Pages/CommentCandidatePage';

function App() {
  
  return (
    <>
      <NavigationBarComponent />
      {/* <Routes>
        <Route path='/' element={<><p>Hello world</p></>} />
        <Route path='/candidate' element={<><p>Komg</p></>} />
        <Route path='' ></Route>
      </Routes> */}
      {/* <Button variant="contained">Contained</Button>
      <br></br>
      <input type="text" name="" id="" onChange={(event:React.ChangeEvent<HTMLInputElement>)=>setFirstName(event.target.value)} />
      <CardComponent FirstName={firstName} LastName='Muangrod' Email='Parinya@gmail.com' PhoneNumber='0263159847' Child={<button>Child</button>}></CardComponent> */}
      <Routes>
        <Route path='/*' element={<CandidateProfilesPage />} />
        <Route path='/Appointment' element={<AppointmentInterviewPage />} />
        <Route path='/CreateCandidate' element={<CreateCandidatePage />} />
        <Route path='/Evaluation' element={<EvaluationPage />} />
        <Route path='/EditCandidate'>
          <Route path=':id' element={<EditCandidatePage />} />
        </Route>
        <Route path='/Evaluation'>
          <Route path=':id' element={<CommentCandidate />} />
        </Route>
      </Routes>
      {/* <CandidateProfilesPage /> */}
    </>
  )
}

export default App
