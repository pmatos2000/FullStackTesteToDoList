import { FC, useEffect, useState } from "react";
import { Category, TodoItem } from "../types";
import TaskService from "../services/TaskService";
import Loading from "../components/Loading";
import { Box, Button, styled, Typography } from "@mui/material";
import TaskTable from "../components/TaskTable";
import LayoutPage from "../components/LayoutPage";
import CategoryService from "../services/CategoryService";
import { useNavigate } from "react-router-dom";
import { PathRoter } from "../routes/Router";

const Container = styled(Box)({
  display: "flex",
  gap: "24px",
  flexDirection: "column",
});

const GetTaskTable = (
  fetchDate: boolean,
  listTodo: TodoItem[],
  listCategory: Category[]
) => {
  if (fetchDate) return <Loading text="Buscando tarefas..." />;
  if (listTodo.length === 0)
    return <Typography variant="h5">Nenhuma tarefa encontrada</Typography>;
  return <TaskTable listTodo={listTodo} listCategory={listCategory} />;
};

const ListTask: FC = () => {
  const [fetchingCategoryList, setFetchingCategoryList] =
    useState<boolean>(true);
  const [fetchingTodoList, setFetchingTodoList] = useState<boolean>(true);
  const [listTodo, setListTodo] = useState<TodoItem[]>([]);
  const [listCategory, setListCategory] = useState<Category[]>([]);

  const navigate = useNavigate();

  const fetchDate = fetchingCategoryList || fetchingTodoList;

  const executeFetchTodoList = async () => {
    setFetchingTodoList(true);
    const newListTodo = await TaskService.getListTodo();
    setListTodo(newListTodo);
    setFetchingTodoList(false);
  };

  const executeFetchCategoryList = async () => {
    setFetchingCategoryList(true);
    const newListCategory = await CategoryService.getListCategory();
    setListCategory(newListCategory);
    setFetchingCategoryList(false);
  };

  useEffect(() => {
    executeFetchTodoList();
    executeFetchCategoryList();
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
            <Button
              variant="contained"
              color="primary"
              onClick={() => navigate(PathRoter.NEW_TASK)}
            >
              Criar tarefa
            </Button>
          </Box>
        </Box>
        {GetTaskTable(fetchDate, listTodo, listCategory)}
      </Container>
    </LayoutPage>
  );
};

export default ListTask;
