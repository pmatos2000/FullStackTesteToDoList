import axios, { InternalAxiosRequestConfig } from "axios";
import { StatusCodes } from "http-status-codes";
import { Mensages } from "../Util/Consts";

const baseURL = "https://localhost:44391/api";

if (!baseURL) {
  throw new Error(
    "A variável de ambiente 'REACT_APP_API_BASE_URL' não está definida."
  );
}

const axiosInstance = axios.create({
  baseURL: baseURL,
});

axiosInstance.interceptors.request.use(
  (config: InternalAxiosRequestConfig): InternalAxiosRequestConfig => {
    const token = localStorage.getItem("token");
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(new Error(error));
  }
);

axiosInstance.interceptors.response.use(
  (response) => response,
  (error) => {
    if (axios.isAxiosError(error)) {
      if (error.response?.status === StatusCodes.UNAUTHORIZED) {
        if (error.response?.data?.message)
          return Promise.reject(new Error(error.response?.data?.message));
        return Promise.reject(new Error(Mensages.ERROR_UNAUTHORIZED));
      }
      if (error.response?.status === StatusCodes.NOT_FOUND) {
        Promise.reject(new Error(Mensages.ERROR_NOT_FOUND));
      }
    }
    return Promise.reject(new Error(Mensages.ERROR_UNKNOWN));
  }
);

export default axiosInstance;
