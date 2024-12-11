import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { Box } from "@mui/material";
import { styled } from "@mui/system";
import Router from "./routes/Router";

const Container = styled(Box)({
  display: "flex",
  justifyContent: "center",
  alignItems: "center",
  height: "100vh",
});

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <Container>
      <Router />
    </Container>
  </StrictMode>
);
