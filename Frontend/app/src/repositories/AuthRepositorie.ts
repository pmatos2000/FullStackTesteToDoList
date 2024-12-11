import axiosInstance from "../config/axiosConfig";
import { LoginRequest, LoginResponse } from "../types";

class AuthRepositorie {
  async Login(userName: string, password: string) {
    const loginRequest: LoginRequest = {
      userName,
      password,
    };

    const response = await axiosInstance
      .post<LoginResponse>("/auth/login", loginRequest)
      .then((res) => res.data)
      .catch((_) => new Error("Aconteceu um erro"));

    return response;
  }
}

export default new AuthRepositorie();
