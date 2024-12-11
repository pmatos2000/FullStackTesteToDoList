import { TodoEdit } from "../types";

export const TOKEN_NAME = "token";

export const TODO_EDIT_DEFAULT: TodoEdit = {
  title: "",
  description: "",
  isCompleted: false,
  categoryId: null,
};
