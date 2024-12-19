import { useState } from "react";
import "./App.css";
import GamesPage from "./Pages/GamesPage/GamesPage";

function App() {
  const [count, setCount] = useState(0);

  return (
    <div>
      <GamesPage />
    </div>
  );
}

export default App;
