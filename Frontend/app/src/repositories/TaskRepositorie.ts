import axiosInstance from "../config/axiosConfig";
import { IdResponse, TodoCreateRequest, TodoItemResponse } from "../types";
import MessageResponse from "../types/MessageResponse";

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

  deleteTodo(id: number) {
    const url = `task/${id}`;
    return axiosInstance
      .delete<MessageResponse>(url)
      .then((res) => res.data)
      .catch((error: Error) => error);
  }

  confirmTodo(id: number) {
    const query = new URLSearchParams();
    query.append("id", id.toString());
    query.append("isCompleted", "true");
    const url = `task/update-completed?${query.toString()}`;
    return axiosInstance
      .patch<MessageResponse>(url)
      .then((res) => res.data)
      .catch((error: Error) => error);
  }
}

export default new TaskRepositorie();
