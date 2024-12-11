interface TodoCreateRequest {
  title: string;
  description: string;
  isCompleted: boolean;
  categoryId: number | null;
}

export default TodoCreateRequest;
