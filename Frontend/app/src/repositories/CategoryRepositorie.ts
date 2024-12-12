import axiosInstance from "../config/axiosConfig";
import { CategoryCreateRequest, CategoryResponse } from "../types";
import MessageResponse from "../types/MessageResponse";

class CategoryRepositorie {
  getListCategory() {
    return axiosInstance
      .get<CategoryResponse[]>("/category/list")
      .then((res) => res.data)
      .catch((error: Error) => error);
  }

  deleteCategory(id: number) {
    const url = `/category/${id}`;

    return axiosInstance
      .delete<MessageResponse>(url)
      .then((res) => res.data)
      .catch((error: Error) => error);
  }

  createCategory(categoryName: string) {
    const req: CategoryCreateRequest = {
      categoryName,
    };

    return axiosInstance
      .post<CategoryResponse>("/category/create", req)
      .then((res) => res.data)
      .catch((error: Error) => error);
  }
}

export default new CategoryRepositorie();
