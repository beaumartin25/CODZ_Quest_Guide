import React from "react";
import { Card, CardContent, Grid2, Typography } from "@mui/material";

interface GameItem {
  id: number;
  name: string;
  imageUrl: string;
}

interface SelectionGridProps {
  items: GameItem[];
  onItemClick: (item: GameItem) => void;
}

const SelectionGrid: React.FC<SelectionGridProps> = ({
  items,
  onItemClick,
}) => {
  return (
    <Grid2 container spacing={2} justifyContent="center">
      {items.map((item) => (
        <Grid2
          item
          xs={12}
          sm={6}
          md={4}
          key={item.id}
          justifyContent="center"
          alignItems="center"
        >
          <Card
            onClick={() => onItemClick(item)}
            sx={{
              width: 350,
              bgcolor: "black",
              display: "flex",
              flexDirection: "column",
              padding: 2,
              ":hover": { bgcolor: "gray" },
            }}
          >
            <CardContent sx={{ flexGrow: 1 }}>
              <Typography variant="h5" color="white" component="div">
                {item.name}
              </Typography>
            </CardContent>
          </Card>
        </Grid2>
      ))}
    </Grid2>
  );
};

export default SelectionGrid;
