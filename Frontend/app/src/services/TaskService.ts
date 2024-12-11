import TaskRepositorie from "../repositories/TaskRepositorie";
import {
  TodoCreateRequest,
  TodoEdit,
  TodoItem,
  TodoItemResponse,
} from "../types";
import moment from "moment";

class TaskService {
  #converteTodoItemRespondeToTodoItem(res: TodoItemResponse): TodoItem {
    return {
      id: res.id,
      title: res.title,
      description: res.description,
      isCompleted: res.isCompleted,
      createAt: moment(res.createAt),
      updatedAt: moment(res.updatedAt),
      categoryId: res.categoryId,
    };
  }

  async getListTodo(): Promise<TodoItem[]> {
    const response = await TaskRepositorie.getListTodo();
    if (response instanceof Error) {
      console.log(response.message);
      return [];
    }
    return response.map((x) => this.#converteTodoItemRespondeToTodoItem(x));
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
    const response = await TaskRepositorie.deleteTodo(id);
    if (response instanceof Error) {
      console.error(response.message);
      return false;
    }
    return true;
  }
  async confirmTodo(id: number): Promise<boolean> {
    const response = await TaskRepositorie.confirmTodo(id);
    if (response instanceof Error) {
      console.error(response.message);
      return false;
    }
    return true;
  }

  async getTodo(id: number): Promise<TodoItem | null> {
    const response = await TaskRepositorie.getTodo(id);
    if (response instanceof Error) {
      console.error(response.message);
      return null;
    }
    return this.#converteTodoItemRespondeToTodoItem(response);
  }
}

export default new TaskService();
