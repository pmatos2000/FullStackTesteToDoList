import TaskRepositorie from "../repositories/TaskRepositorie";
import { TodoCreateRequest, TodoEdit, TodoItem } from "../types";
import moment from "moment";

class TaskService {
  async getListTodo(): Promise<TodoItem[]> {
    const response = await TaskRepositorie.getListTodo();
    if (response instanceof Error) {
      console.log(response.message);
      return [];
    }
    return response.map((x) => ({
      id: x.id,
      title: x.title,
      description: x.description,
      isCompleted: x.isCompleted,
      createAt: moment(x.createAt),
      updatedAt: moment(x.updatedAt),
      categoryId: x.categoryId,
    }));
  }

  async createTodo(todo: TodoEdit): Promise<number | Error> {
    const req: TodoCreateRequest = {
      title: todo.title,
      description: todo.description,
      isCompleted: todo.isCompleted,
      categoryId: todo.categoryId,
    };
    const response = await TaskRepositorie.createTodo(req);
    if (response instanceof Error) return response;
    return response.id;
  }

  async deleteTodo(id: number): Promise<boolean> {
    const responde = await TaskRepositorie.deleteTodo(id);
    if (responde instanceof Error) {
      console.error(responde);
      return false;
    }
    return true;
  }
}

export default new TaskService();
