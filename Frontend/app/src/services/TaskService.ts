import TaskRepositorie from "../repositories/TaskRepositorie";
import { TodoItem } from "../types";
import moment from "moment";

class TaskService {
  async GetListTodo(): Promise<TodoItem[]> {
    const response = await TaskRepositorie.GetListTodo();
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
}

export default new TaskService();
