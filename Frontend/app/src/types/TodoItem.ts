import { Moment } from "moment";

interface TodoItem {
  id: number;
  title: string;
  description: string;
  isCompleted: boolean;
  createdAt: Moment;
  updatedAt: Moment;
  categoryId: number | null;
}

export default TodoItem;
