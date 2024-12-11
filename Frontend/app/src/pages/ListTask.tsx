import { FC, useEffect, useState } from "react";
import { TodoItem } from "../types";
import TaskService from "../services/TaskService";
import Loading from "../components/Loading";
import { Box, Button, styled, Typography } from "@mui/material";
import TaskTable from "../components/TaskTable";
import LayoutPage from "../components/LayoutPage";

const Container = styled(Box)({
  display: "flex",
  gap: "24px",
  flexDirection: "column",
});

const GetTaskTable = (fetchingTodoList: boolean, listTodo: TodoItem[]) => {
  if (fetchingTodoList) return <Loading text="Buscando tarefas..." />;
  if (listTodo.length === 0)
    return <Typography variant="h5">Nenhuma tarefa encontrada</Typography>;
  return <TaskTable listTodo={listTodo} />;
};

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

  return (
    <LayoutPage>
      <Container>
        <Box display="flex" justifyContent="space-between">
          <Typography variant="h4">Gerenciador de Tarefas</Typography>
          <Box display="flex" gap="24px">
            <Button variant="contained" color="primary">
              Criar categoria
            </Button>
            <Button variant="contained" color="primary">
              Criar tarefa
            </Button>
          </Box>
        </Box>
        {GetTaskTable(fetchingTodoList, listTodo)}
      </Container>
    </LayoutPage>
  );
};

export default ListTask;
