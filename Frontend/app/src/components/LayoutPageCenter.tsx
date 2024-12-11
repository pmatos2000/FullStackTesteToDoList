import { Box } from "@mui/material";
import { styled } from "@mui/system";
import { FC } from "react";
import LayoutPage from "./LayoutPage";

interface LayoutPageCenterProps {
  children?: React.ReactNode;
}

const Container = styled(Box)({
  display: "flex",
  justifyContent: "center",
  alignItems: "center",
  height: "100vh",
});

const LayoutPageCenter: FC<LayoutPageCenterProps> = ({ children }) => (
  <LayoutPage>
    <Container>{children}</Container>
  </LayoutPage>
);

export default LayoutPageCenter;
