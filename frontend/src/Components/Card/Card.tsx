import { Box, Typography } from "@mui/material";
import React, { SyntheticEvent } from "react";

type Props = {
  gameName: string;
};

const Card: React.FC<Props> = ({ gameName }: Props): JSX.Element => {
  return (
    <div className="card">
      <Box>
        <Typography sx={{':hover': {bgcolor: "darkblue"}}}>{gameName}</Typography>
      </Box>
    </div>
  );
};

export default Card;
