import { FC, useEffect, useState } from "react";
import { TodoItem } from "../types";
import TaskService from "../services/TaskService";
import Loading from "../components/Loading";
import { Typography } from "@mui/material";
import TaskTable from "../components/TaskTable";

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

  if (fetchingTodoList) return <Loading text="Buscando tarefas..." />;

  if (listTodo.length === 0)
    return <Typography variant="h5">Nenhuma tarefa encontrada</Typography>;

  return <TaskTable listTodo={listTodo} />;
};

export default ListTask;
