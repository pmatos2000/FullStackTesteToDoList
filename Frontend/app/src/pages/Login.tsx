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

const LoginSubmit = styled(Button)({
  margin: "24px 0 16px",
});

const Login: FC = () => {
  const [nameUser, setNameUser] = useState<string>("");
  const [password, setPassword] = useState<string>("");

  const handleSubmit = (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    console.log(event.currentTarget.elements);
  };

  return (
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
          <LoginSubmit
            type="submit"
            fullWidth
            variant="contained"
            color="primary"
            className="login-submit"
            disabled={nameUser.length < 3 || password.length < 8}
          >
            Entrar
          </LoginSubmit>
        </LoginForm>
      </CardContent>
    </LoginCard>
  );
};

export default Login;
