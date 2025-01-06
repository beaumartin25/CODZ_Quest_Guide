import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import GamesPage from "../Pages/GamesPage/GamesPage";
import MapsPage from "../Pages/MapsPage/MapsPage";
export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "games", element: <GamesPage /> },
      { path: "maps/:gameId", element: <MapsPage /> },
    ],
  },
]);
