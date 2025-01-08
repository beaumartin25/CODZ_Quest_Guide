import axios from "axios";
import { QuestGet } from "../Models/Quest";
import { handleError } from "../Helpers/ErrorHandler";

const api = "http://localhost:5170/api/quest/";

export const questGetAPI = async () => {
  try {
    const response = await axios.get<QuestGet[]>(api);
    return response.data; // Directly return the quest data
  } catch (error) {
    handleError(error);
  }
};

export const QuestGetByGameIdAPI = async (mapId: number) => {
  try {
    const response = await axios.get<QuestGet[]>(`${api}map/${mapId}`);
    return response.data; // Directly return the quest data
  } catch (error) {
    handleError(error);
  }
};
