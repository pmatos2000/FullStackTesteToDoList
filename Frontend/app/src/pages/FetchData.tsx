import { Box, keyframes, styled, Typography } from "@mui/material";
import { FC } from "react";

interface FetchDataProps {
  text: string;
}

const spin = keyframes`
  from {
    transform: rotate(0deg);
  }
  to {
    transform: rotate(360deg);
  }
`;

const LoadingAnimation = styled("div")({
  border: "4px solid rgba(0, 0, 0, 0.1)",
  borderLeftColor: "#22a6b3",
  borderRadius: "50%",
  width: "40px",
  height: "40px",
  animation: `${spin} 1s linear infinite`,
});

const FetchData: FC<FetchDataProps> = ({ text }) => {
  return (
    <Box display="flex" flexDirection="column" alignItems="center">
      <LoadingAnimation />
      <Typography>{text}</Typography>
    </Box>
  );
};

export default FetchData;
