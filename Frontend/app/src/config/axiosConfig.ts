import axios, { InternalAxiosRequestConfig } from "axios";
import { StatusCodes } from "http-status-codes";
import { Mensages } from "../util/Consts";
import { TOKEN_NAME } from "../util/Values";
import globalRouter from "../routes/globalRouter";
import { PathRoter } from "../routes/Router";

const baseURL = "https://localhost:44391/api";

const axiosInstance = axios.create({
  baseURL: baseURL,
});

axiosInstance.interceptors.request.use(
  (config: InternalAxiosRequestConfig): InternalAxiosRequestConfig => {
    const token = localStorage.getItem(TOKEN_NAME);
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
        const token = localStorage.getItem(TOKEN_NAME);
        if (token) {
          localStorage.removeItem(TOKEN_NAME);
          if (globalRouter.navigate) globalRouter.navigate(PathRoter.LOGIN);
        }
        if (error.response?.data?.message)
          return Promise.reject(new Error(error.response?.data?.message));
        return Promise.reject(new Error(Mensages.ERROR_UNAUTHORIZED));
      }
      if (error.response?.status === StatusCodes.CONFLICT) {
        return Promise.reject(new Error(error.response?.data?.message));
      }
      if (error.response?.status === StatusCodes.NOT_FOUND) {
        Promise.reject(new Error(Mensages.ERROR_NOT_FOUND));
      }
    }
    console.error(error);
    if (globalRouter.navigate) globalRouter.navigate(PathRoter.LOGIN);
    return Promise.reject(new Error(Mensages.ERROR_UNKNOWN));
  }
);

export default axiosInstance;
