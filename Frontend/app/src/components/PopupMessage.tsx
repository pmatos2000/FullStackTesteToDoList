import { Snackbar, IconButton } from "@mui/material";
import { FC } from "react";
import CloseIcon from "@mui/icons-material/Close";

interface PopupMessageProps {
  error: string | null;
  onCLose?: () => void;
}

const PopupMessage: FC<PopupMessageProps> = ({ error, onCLose }) => {
  return (
    <Snackbar
      open={Boolean(error)}
      autoHideDuration={6000}
      onClose={onCLose}
      message={error ?? ""}
      action={
        <IconButton
          size="small"
          aria-label="close"
          color="inherit"
          onClick={onCLose}
        >
          <CloseIcon fontSize="small" />
        </IconButton>
      }
    />
  );
};

export default PopupMessage;
