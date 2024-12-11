import axiosInstance from "../config/axiosConfig";
import { LoginRequest, LoginResponse } from "../types";
import MessageResponse from "../types/MessageResponse";

class AuthRepositorie {
  login(userName: string, password: string) {
    const loginRequest: LoginRequest = {
      userName,
      password,
    };
    return axiosInstance
      .post<LoginResponse>("/auth/login", loginRequest)
      .then((res) => res.data)
      .catch((error: Error) => error);
  }

  register(userName: string, password: string) {
    const loginRequest: LoginRequest = {
      userName,
      password,
    };
    return axiosInstance
      .post<MessageResponse>("/auth/register", loginRequest)
      .then((res) => res.data)
      .catch((error: Error) => error);
  }
}

export default new AuthRepositorie();
