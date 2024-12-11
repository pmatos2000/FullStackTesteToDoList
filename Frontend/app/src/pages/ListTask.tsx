import { FC, useEffect, useState } from "react";
import { TodoItem } from "../types";
import TaskService from "../services/TaskService";
import Loading from "../components/Loading";

const ListTask: FC = () => {
  const [fetchingTodoList, setFetchingTodoList] = useState<boolean>(true);
  const [listTodo, setListTodo] = useState<TodoItem[]>([]);

  const executeFetchTodoList = async () => {
    setFetchingTodoList(true);
    const newListTodo = await TaskService.GetListTodo();
    setListTodo(newListTodo);
    setFetchingTodoList(false);
  };

  useEffect(() => {
    executeFetchTodoList();
  }, []);

  if (fetchingTodoList) {
    return <Loading text="Buscando tarefas..." />;
  } else if (listTodo.length) {
    return "Tabela";
  }
  return "Nenhuma tarefa encontrada";
};

export default ListTask;
