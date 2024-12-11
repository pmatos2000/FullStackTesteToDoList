interface TodoItemResponse {
  id: number;
  title: string;
  description: string;
  isCompleted: boolean;
  createAt: string;
  updatedAt: string;
  categoryId: number | null;
}

export default TodoItemResponse;
