import axiosInstance from "../config/axiosConfig";
import { TodoItemResponse } from "../types";

class TaskRepositorie {
  async GetListTodo() {
    const url = "task/list";
    return axiosInstance
      .get<TodoItemResponse[]>(url)
      .then((res) => res.data)
      .catch((error: Error) => error);
  }
}

export default new TaskRepositorie();
