import axiosInstance from "../config/axiosConfig";
import { IdResponse, TodoCreateRequest, TodoItemResponse } from "../types";

class TaskRepositorie {
  getListTodo() {
    const url = "task/list";
    return axiosInstance
      .get<TodoItemResponse[]>(url)
      .then((res) => res.data)
      .catch((error: Error) => error);
  }

  createTodo(req: TodoCreateRequest) {
    return axiosInstance
      .post<IdResponse>("task/create", req)
      .then((res) => res.data)
      .catch((error: Error) => error);
  }
}

export default new TaskRepositorie();
