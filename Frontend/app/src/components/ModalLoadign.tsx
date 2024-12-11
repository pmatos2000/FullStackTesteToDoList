import { Box, Modal } from "@mui/material";
import { FC } from "react";
import Loading from "./Loading";

interface ModalLoadingProps {
  text: string;
  open?: boolean;
}

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: 400,
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
};

const ModalLoading: FC<ModalLoadingProps> = ({ text, open = true }) => {
  return (
    <Modal
      aria-labelledby="loading-modal-title"
      aria-describedby="loading-modal-description"
      open={open}
    >
      <Box sx={style}>
        <Loading text={text} />
      </Box>
    </Modal>
  );
};

export default ModalLoading;
