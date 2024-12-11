import axios, { InternalAxiosRequestConfig } from "axios";

const baseURL = "https://localhost:44391/api";

if (!baseURL) {
  throw new Error(
    "A variável de ambiente 'REACT_APP_API_BASE_URL' não está definida."
  );
}

const axiosInstance = axios.create({
  baseURL: baseURL,
});

// Interceptador de requisição para adicionar o token Bearer
axiosInstance.interceptors.request.use(
  (config: InternalAxiosRequestConfig): InternalAxiosRequestConfig => {
    const token = localStorage.getItem("token");
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default axiosInstance;
