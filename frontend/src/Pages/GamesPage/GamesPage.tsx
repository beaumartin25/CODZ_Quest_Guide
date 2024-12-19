import React, { useEffect, useState } from "react";
import SelectionGrid from "../../Components/SelectionGrid/SelectionGrid";
import { gameGetAPI } from "../../Services/GameService";

interface GameItem {
  id: number;
  name: string;
  imageUrl: string;
}

const GamesPage: React.FC = () => {
  const [games, setGames] = useState<GameItem[]>([]);

  useEffect(() => {
    const fetchGames = async () => {
      try {
        const gamesData = await gameGetAPI();
        setGames(gamesData);
      } catch (error) {
        console.error(error);
      }
    };
    fetchGames();
  }, []);

  const handleGameClick = (game: GameItem) => {
    console.log(`Navigating to ${game.name} page`);
    // Add navigation logic here
  };

  return <SelectionGrid items={games} onItemClick={handleGameClick} />;
};

export default GamesPage;
