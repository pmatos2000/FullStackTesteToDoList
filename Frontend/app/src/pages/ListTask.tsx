import { FC, useEffect, useState } from "react";
import { TodoItem } from "../types";
import TaskService from "../services/TaskService";
import FetchData from "./FetchData";

const ListTask: FC = () => {
  const [fetchingTodoList, setFetchingTodoList] = useState<boolean>(true);
  const [listTodo, setListTodo] = useState<TodoItem[]>([]);

  console.log(listTodo);

  const executeFetchTodoList = async () => {
    setFetchingTodoList(true);
    const newListTodo = await TaskService.GetListTodo();
    setListTodo(newListTodo);
    setFetchingTodoList(false);
  };

  useEffect(() => {
    executeFetchTodoList();
  }, []);

  return <FetchData text="Buscando tarefas..." />;
};

export default ListTask;
