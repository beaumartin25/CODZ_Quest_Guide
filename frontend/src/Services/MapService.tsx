import axios from "axios";
import { MapGet } from "../Models/Map";
import { handleError } from "../Helpers/ErrorHandler";

const api = "http://localhost:5170/api/map/";


export const mapGetAPI = async () => {
  try {
    const response = await axios.get<MapGet[]>(api);
    return response.data; // Directly return the map data
  } catch (error) {
    handleError(error);
  }
};

export const mapGetByGameIdAPI = async (gameId: number) => {
  try {
    const response = await axios.get<MapGet[]>(`${api}game/${gameId}`);
    return response.data; // Directly return the game data
  } catch (error) {
    handleError(error);
  }
};