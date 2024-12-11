import TodoCreateRequest from "./TodoCreateRequest";

interface TodoUpdateRequest extends TodoCreateRequest {
  id: number;
}

export default TodoUpdateRequest;
