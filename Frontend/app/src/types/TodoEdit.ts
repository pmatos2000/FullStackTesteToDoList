import { Moment } from "moment";
import TodoItem from "./TodoItem";

type TodoEdit = Omit<TodoItem, "id" | "createAt" | "updatedAt"> & {
  id?: number;
  createAt?: Moment;
  updatedAt?: Moment;
};

export default TodoEdit;
