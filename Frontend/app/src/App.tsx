import { FC } from "react";
import Login from "./pages/Login";
import { Box, styled } from "@mui/material";

const Container = styled(Box)({
  display: "flex",
  justifyContent: "center",
  alignItems: "center",
  height: "100vh",
});

const App: FC = () => {
  return (
    <Container>
      <Login></Login>
    </Container>
  );
};

export default App;
