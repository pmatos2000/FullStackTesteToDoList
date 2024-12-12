import { FC, useEffect, useState } from "react";
import { Category, TodoItem } from "../types";
import TaskService from "../services/TaskService";
import Loading from "../components/Loading";
import {
  Box,
  Button,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  styled,
  Typography,
} from "@mui/material";
import TaskTable from "../components/TaskTable";
import LayoutPage from "../components/LayoutPage";
import CategoryService from "../services/CategoryService";
import { useNavigate } from "react-router-dom";
import { PathRoter } from "../routes/Router";
import ModalLoading from "../components/ModalLoadign";

const Container = styled(Box)({
  display: "flex",
  gap: "24px",
  flexDirection: "column",
});

const ListTask: FC = () => {
  const [fetchingCategoryList, setFetchingCategoryList] =
    useState<boolean>(true);
  const [fetchingTodoList, setFetchingTodoList] = useState<boolean>(true);
  const [listTodo, setListTodo] = useState<TodoItem[]>([]);
  const [listCategory, setListCategory] = useState<Category[]>([]);
  const [categoryIdSelect, setCategoryIdSelect] = useState<
    number | string | null
  >("");

  const [executingDeleteTodo, setExecutingDeleteTodo] =
    useState<boolean>(false);
  const [executingConfirmationTodo, setExecutingConfirmationTodo] =
    useState<boolean>(false);

  const navigate = useNavigate();

  const fetchDate = fetchingCategoryList || fetchingTodoList;

  const executeFetchTodoList = async (categoryId: number | null) => {
    setFetchingTodoList(true);
    const newListTodo = await TaskService.getListTodo(categoryId);
    setListTodo(newListTodo);
    setFetchingTodoList(false);
  };

  const updateCategoryIdSelect = (
    newCategoryIdSelect: number | string | null
  ) => {
    setCategoryIdSelect(newCategoryIdSelect);
    const categoryId =
      typeof newCategoryIdSelect === "string" ? null : newCategoryIdSelect;
    executeFetchTodoList(categoryId);
  };

  const executeFetchCategoryList = async () => {
    setFetchingCategoryList(true);

    const newListCategory = await CategoryService.getListCategory();
    setListCategory(newListCategory);
    setFetchingCategoryList(false);
  };

  const executeDeleteTodo = async (id: number) => {
    setExecutingDeleteTodo(true);
    const result = await TaskService.deleteTodo(id);
    if (result) {
      setListTodo((list) => list.filter((x) => x.id !== id));
    }
    setExecutingDeleteTodo(false);
  };

  const executeConfirmTodo = async (id: number) => {
    setExecutingConfirmationTodo(true);
    const result = await TaskService.confirmTodo(id);
    if (result) {
      setListTodo((list) =>
        list.map((x) => ({
          ...x,
          isCompleted: x.id === id ? true : x.isCompleted,
        }))
      );
    }
    setExecutingConfirmationTodo(false);
  };

  const executeEditeTodo = (id: number) => {
    const query = new URLSearchParams();
    query.append("id", id.toString());
    const url = `${PathRoter.EDIT_TASK}?${query.toString()}`;
    navigate(url);
  };

  useEffect(() => {
    executeFetchTodoList(null);
    executeFetchCategoryList();
  }, []);

  return (
    <LayoutPage>
      <Container>
        <Box display="flex" justifyContent="space-between" alignItems="center">
          <Typography variant="h4">Gerenciador de Tarefas</Typography>
          <Box display="flex" gap="24px">
            <FormControl margin="dense">
              <InputLabel id="select-category-label">Categoria</InputLabel>
              <Select
                sx={{ width: "240px" }}
                id="select-category"
                labelId="select-category-label"
                value={categoryIdSelect}
                label="Categoria"
                disabled={fetchingTodoList}
                onChange={(e) => {
                  let newCategoryId = e.target.value;
                  updateCategoryIdSelect(newCategoryId);
                }}
              >
                <MenuItem value="">Limpar seleção</MenuItem>
                {listCategory.map((category) => (
                  <MenuItem key={category.id} value={category.id}>
                    {category.name}
                  </MenuItem>
                ))}
              </Select>
            </FormControl>
            <Button
              variant="contained"
              color="primary"
              onClick={() => navigate(PathRoter.CATEGORYS)}
            >
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
        {fetchDate && <Loading text="Buscando tarefas..." />}
        {listTodo.length === 0 && (
          <Typography variant="h5">Nenhuma tarefa encontrada</Typography>
        )}
        {listTodo.length > 0 && (
          <TaskTable
            listTodo={listTodo}
            listCategory={listCategory}
            onClickDelete={executeDeleteTodo}
            onClickConfirm={executeConfirmTodo}
            onClickEdit={executeEditeTodo}
          />
        )}
      </Container>
      <ModalLoading open={executingDeleteTodo} text="Apagando a tarefa..." />
      <ModalLoading
        open={executingConfirmationTodo}
        text="Confirmando a tarefa..."
      />
    </LayoutPage>
  );
};

export default ListTask;
