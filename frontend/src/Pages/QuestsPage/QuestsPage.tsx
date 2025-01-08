import React from "react";
import { useLocation } from "react-router-dom";

interface QuestItem {
  id: number;
  name: string;
  description: string;
}

const QuestsPage: React.FC = () => {
  const location = useLocation();
  const { quests = [], mapName = "Unknown Map" } =
    (location.state as { quests: QuestItem[]; mapName: string }) || {}; // Retrieve state from navigation

  return (
    <div>
      <h1>Quests for {mapName}</h1>
      <p>{quests.map((quest) => quest.name).join(", ")}</p>
    </div>
  );
};

export default QuestsPage;
