import axios from "axios";
import { GameGet } from "../Models/Game";
import { handleError } from "../Helpers/ErrorHandler";

const api = "http://localhost:5170/api/game/";

export const gameGetAPI = async () => {
  try {
    const response = await axios.get<GameGet[]>(api);
    return response.data; // Directly return the game data
  } catch (error) {
    handleError(error);
  }
};
