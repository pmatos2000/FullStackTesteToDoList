import { Box, styled } from "@mui/material";
import { FC } from "react";
import { useNavigate } from "react-router-dom";
import globalRouter from "./routes/globalRouter";

interface AppProps {
  children?: React.ReactNode;
}

const Container = styled(Box)({
  display: "flex",
  justifyContent: "center",
  alignItems: "center",
  height: "100vh",
});

const App: FC<AppProps> = ({ children }) => {
  const navigate = useNavigate();
  globalRouter.navigate = navigate;

  return <Container>{children}</Container>;
};

export default App;
