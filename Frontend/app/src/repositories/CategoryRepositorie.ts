import axiosInstance from "../config/axiosConfig";
import { CategoryResponse } from "../types";

class CategoryRepositorie {
  getListCategory() {
    return axiosInstance
      .get<CategoryResponse[]>("/category/list")
      .then((res) => res.data)
      .catch((error: Error) => error);
  }
}

export default new CategoryRepositorie();
