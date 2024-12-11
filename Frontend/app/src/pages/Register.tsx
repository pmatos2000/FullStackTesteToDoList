import React, { useState } from "react";
import {
  Box,
  Button,
  TextField,
  Typography,
  styled,
  Card,
} from "@mui/material";
import LayoutPageCenter from "../components/LayoutPageCenter";
import AuthService from "../services/AuthService";
import PopupMessage from "../components/PopupMessage";
import { PathRoter } from "../routes/Router";
import { useNavigate } from "react-router-dom";

const FormContainer = styled(Box)({
  display: "flex",
  flexDirection: "row",
  gap: "24px",
});

const FormBox = styled(Box)({
  display: "flex",
  flexDirection: "column",
  gap: "16px",
  maxWidth: "400px",
  padding: "16px",
});

const ValidationBox = styled(Box)(({ theme }) => ({
  display: "flex",
  flexDirection: "column",
  gap: "8px",
  padding: "16px",
  backgroundColor: theme.palette.primary.dark,
  width: "-webkit-fill-available",
  "@-moz-document url-prefix()": { width: "-moz-available" },
}));

const Register: React.FC = () => {
  const [userName, setUserName] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [registering, setRegistering] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  const navigate = useNavigate();

  const passwordMinLength = password.length >= 8;
  const passwordMaxLength = password.length <= 16;
  const passwordHasUpperCase = /[A-Z]/.test(password);
  const passwordHasLowerCase = /[a-z]/.test(password);
  const passwordHasNumber = /\d/.test(password);
  const passwordSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(password);

  const passwordValid =
    passwordMinLength &&
    passwordMaxLength &&
    passwordHasUpperCase &&
    passwordHasLowerCase &&
    passwordHasNumber &&
    passwordSpecialChar;

  const register = async () => {
    setRegistering(true);
    const response = await AuthService.register(userName, password);
    if (response instanceof Error) {
      console.log(response.message);
      setError(response.message);
    } else {
      navigate(PathRoter.LOGIN);
    }
    setRegistering(false);
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    setRegistering(true);
    register();
    setRegistering(false);
  };

  return (
    <LayoutPageCenter>
      <Card sx={{ maxWidth: "760px" }}>
        <FormContainer>
          <FormBox>
            <Typography variant="h4" component="h1" gutterBottom>
              Registro
            </Typography>
            <form onSubmit={handleSubmit}>
              <TextField
                label="Nome de Usuário"
                value={userName}
                onChange={(e) => setUserName(e.target.value)}
                fullWidth
                margin="normal"
                required
              />
              <TextField
                label="Senha"
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                fullWidth
                margin="normal"
                required
              />
              <Box mt={2}>
                <Button
                  type="submit"
                  variant="contained"
                  color="primary"
                  fullWidth
                  disabled={!passwordValid || registering}
                >
                  Registrar
                </Button>
              </Box>
            </form>
          </FormBox>
          <ValidationBox>
            <Typography variant="h6">Critérios da Senha:</Typography>
            <Typography color={passwordMinLength ? "green" : "red"}>
              - Mínimo de 8 caracteres
            </Typography>
            <Typography color={passwordMaxLength ? "green" : "red"}>
              - Máximo de 16 caracteres
            </Typography>
            <Typography color={passwordHasUpperCase ? "green" : "red"}>
              - Pelo menos uma letra maiúscula
            </Typography>
            <Typography color={passwordHasLowerCase ? "green" : "red"}>
              - Pelo menos uma letra minúscula
            </Typography>
            <Typography color={passwordSpecialChar ? "green" : "red"}>
              - Pelo menos uma letra minúscula
            </Typography>
            <Typography color={passwordHasNumber ? "green" : "red"}>
              - Pelo menos uma número
            </Typography>
          </ValidationBox>
        </FormContainer>
      </Card>
      <PopupMessage error={error} onCLose={() => setError(null)} />
    </LayoutPageCenter>
  );
};

export default Register;
