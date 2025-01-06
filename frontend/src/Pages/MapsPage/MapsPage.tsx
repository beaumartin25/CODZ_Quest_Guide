import React from "react";
import { useLocation } from "react-router-dom";
import SelectionGrid from "../../Components/SelectionGrid/SelectionGrid";
interface MapItem {
  id: number;
  name: string;
  imageUrl: string;
}

const MapsPage: React.FC = () => {
  const location = useLocation();
  const { maps = [], gameName = "Unknown Game" } =
    (location.state as { maps: MapItem[]; gameName: string }) || {}; // Retrieve state from navigation

  const handleMapClick = (map: MapItem) => {
    console.log(`Navigating to map: ${map.name}`);
    // Add navigation logic here if needed
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
