import { Moment } from "moment";
import TodoItem from "./TodoItem";

type TodoEdit = Omit<TodoItem, "id" | "createdAt" | "updatedAt"> & {
  id?: number;
  createdAt?: Moment;
  updatedAt?: Moment;
};

export default TodoEdit;
