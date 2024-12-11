interface TodoItemResponse {
  id: number;
  title: string;
  description: string;
  isCompleted: boolean;
  createdAt: string;
  updatedAt: string;
  categoryId: number | null;
}

export default TodoItemResponse;
