import {
  Avatar,
  Box,
  Button,
  Card,
  CardContent,
  styled,
  TextField,
  Typography,
} from "@mui/material";
import { FC, FormEvent, useState } from "react";

import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import AuthService from "../services/AuthService";
import PopupMessage from "../components/PopupMessage";
import { TOKEN_NAME } from "../util/Values";
import { useNavigate } from "react-router-dom";
import { PathRoter } from "../routes/Router";
import LayoutPageCenter from "../components/LayoutPageCenter";

const LoginCard = styled(Card)({
  minWidth: "275px",
  maxWidth: "275px",
  padding: "24px",
});

const LoginAvatar = styled(Avatar)({
  margin: "8px auto",
  backgroundColor: "#f50057",
});

const LoginForm = styled("form")({
  width: "100%",
  marginTop: "8px",
});

const StyledButton = styled(Button)({
  margin: "24px 0 16px",
});

const Login: FC = () => {
  const [nameUser, setNameUser] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [loggingIn, setLoggingIn] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();

  const login = async () => {
    setLoggingIn(true);
    const response = await AuthService.login(nameUser, password);
    if (response instanceof Error) {
      console.log(response.message);
      setError(response.message);
    } else {
      localStorage.setItem(TOKEN_NAME, response.jwtToken);
      navigate(PathRoter.TASKS);
    }
    setLoggingIn(false);
  };

  const handleSubmit = (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    login();
  };

  return (
    <LayoutPageCenter>
      <LoginCard>
        <CardContent>
          <Box textAlign="center">
            <LoginAvatar>
              <LockOutlinedIcon />
            </LoginAvatar>
            <Typography component="h1" variant="h5">
              Login
            </Typography>
          </Box>
          <LoginForm onSubmit={handleSubmit}>
            <TextField
              variant="outlined"
              margin="normal"
              required
              fullWidth
              id="userName"
              label="Nome usuário"
              name="userName"
              value={nameUser}
              onChange={(e) => setNameUser(e.target.value.trim())}
              autoFocus
            />
            <TextField
              variant="outlined"
              margin="normal"
              required
              fullWidth
              name="password"
              label="Senha"
              type="password"
              id="password"
              autoComplete="current-password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
            <StyledButton
              type="submit"
              fullWidth
              variant="contained"
              color="primary"
              className="login-submit"
              disabled={nameUser.length < 3 || password.length < 8 || loggingIn}
            >
              Entrar
            </StyledButton>
            <Button
              fullWidth
              variant="outlined"
              onClick={() => navigate(PathRoter.REGISTER_USER)}
            >
              Registrar
            </Button>
          </LoginForm>
        </CardContent>
        <PopupMessage error={error} onCLose={() => setError(null)} />
      </LoginCard>
    </LayoutPageCenter>
  );
};

export default Login;
