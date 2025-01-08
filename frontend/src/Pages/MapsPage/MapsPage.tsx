import React from "react";
import { useLocation, useNavigate } from "react-router-dom";
import SelectionGrid from "../../Components/SelectionGrid/SelectionGrid";
import { QuestGetByGameIdAPI } from "../../Services/QuestSerice";
interface MapItem {
  id: number;
  name: string;
  imageUrl: string;
}

const MapsPage: React.FC = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const { maps = [], gameName = "Unknown Game" } =
    (location.state as { maps: MapItem[]; gameName: string }) || {}; // Retrieve state from navigation

  const handleMapClick = async (map: MapItem) => {
    try {
      console.log(`Navigating to map: ${map.name}`);
      const quests = await QuestGetByGameIdAPI(map.id);
      console.log(quests);
      navigate(`/quests/${map.id}`, {
        state: { quests, mapName: map.name },
      });
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div>
      <h1>Maps for {gameName}</h1>
      {maps.length > 0 ? (
        <SelectionGrid items={maps} onItemClick={handleMapClick} />
      ) : (
        <p>No maps available for this game.</p>
      )}
    </div>
  );
};

export default MapsPage;
