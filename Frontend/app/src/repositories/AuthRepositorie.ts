import axiosInstance from "../config/axiosConfig";
import { LoginRequest, LoginResponse } from "../types";

class AuthRepositorie {
  Login(userName: string, password: string) {
    const loginRequest: LoginRequest = {
      userName,
      password,
    };
    return axiosInstance
      .post<LoginResponse>("/auth/login", loginRequest)
      .then((res) => res.data)
      .catch((error: Error) => error);
  }
}

export default new AuthRepositorie();
