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
      .catch((error: Error) => error);

    return response;
  }
}

export default new AuthRepositorie();
