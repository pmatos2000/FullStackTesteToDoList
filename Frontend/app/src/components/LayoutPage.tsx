import { Box } from "@mui/material";
import { styled } from "@mui/system";
import { FC } from "react";

interface LayoutPageProps {
  children?: React.ReactNode;
}

const StyledBox = styled(Box)({
  boxSizing: "border-box",
  maxWidth: "1460px",
  width: "100%",
  padding: "0 20px",
  margin: "0 auto",
});

const LayoutPage: FC<LayoutPageProps> = ({ children }) => (
  <StyledBox>{children}</StyledBox>
);

export default LayoutPage;
