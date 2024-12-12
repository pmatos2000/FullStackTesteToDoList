import axiosInstance from "../config/axiosConfig";
import {
  IdResponse,
  TodoCreateRequest,
  TodoItemResponse,
  TodoUpdateRequest,
} from "../types";
import MessageResponse from "../types/MessageResponse";

class TaskRepositorie {
  getListTodo(categoryId: number | null) {
    let url = "task/list";
    if (categoryId) {
      const query = new URLSearchParams();
      query.append("categoryId", categoryId.toString());
      url = `${url}?${query.toString()}`;
    }
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

  getTodo(id: number) {
    const url = `task/${id}`;
    return axiosInstance
      .get<TodoItemResponse>(url)
      .then((res) => res.data)
      .catch((error: Error) => error);
  }

  updateTodo(req: TodoUpdateRequest) {
    return axiosInstance
      .put<TodoItemResponse>("task/update", req)
      .then((res) => res.data)
      .catch((error: Error) => error);
  }
}

export default new TaskRepositorie();
