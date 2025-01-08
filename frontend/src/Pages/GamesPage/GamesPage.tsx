import React, { useEffect, useState } from "react";
import SelectionGrid from "../../Components/SelectionGrid/SelectionGrid";
import { gameGetAPI } from "../../Services/GameService";
import { mapGetByGameIdAPI } from "../../Services/MapService";
import { useNavigate } from "react-router-dom";

interface GameItem {
  id: number;
  name: string;
  imageUrl: string;
}

const GamesPage: React.FC = () => {
  const [games, setGames] = useState<GameItem[]>([]);
  const navigate = useNavigate();

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

  const handleGameClick = async (game: GameItem) => {
    try {
      console.log(`Navigating to ${game.name} page`);
      const maps = await mapGetByGameIdAPI(game.id);
      console.log(maps);
      navigate(`/maps/${game.id}`, {
        state: { maps, gameName: game.name },
      });
    } catch (error) {
      console.error(error);
    }
  };

  return <SelectionGrid items={games} onItemClick={handleGameClick} />;
};

export default GamesPage;
