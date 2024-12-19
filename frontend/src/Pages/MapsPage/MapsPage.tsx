import React from 'react'

interface Props = {
    id: number;
    name: string;
    imageUrl: string;
}

const MapsPage: React.FC<Props> = ({ name, imageUrl}: Props): JSX.Element => {
    const mapsTemplate: MapItem[] = [
        { id: 1, name: "Black Ops" },
        { id: 2, name: "Black Ops II"},
        { id: 3, name: "Black Ops III" },
        { id: 4, name: "Black Ops IV" },
        { id: 5, name: "Cold War" },
        { id: 6, name: "Black Ops 6" },
    ];
    const handleGameClick = (map: MapItem) => {
        console.log(`Navigating to ${map.name} page`);
        // Add navigation logic here
      };
  return (
    <SelectionGrid items={mapsTemplate} onItemClick={handleGameClick} />;
  )
}

export default MapsPage