import { FC, useEffect, useState } from "react";
import { Category, TodoEdit } from "../types";
import { TODO_EDIT_DEFAULT } from "../util/Values";
import Task from "../components/Task";
import LayoutPage from "../components/LayoutPage";
import { Box, Typography } from "@mui/material";
import CategoryService from "../services/CategoryService";
import ModalLoading from "../components/ModalLoadign";
import TaskService from "../services/TaskService";
import { PathRoter } from "../routes/Router";
import { useNavigate, useSearchParams } from "react-router-dom";
import Loading from "../components/Loading";

const EditTask: FC = () => {
  const [todo, setTodo] = useState<TodoEdit>(TODO_EDIT_DEFAULT);
  const [listCategory, setListCategory] = useState<Category[]>([]);
  const [executingTaskCreation, setExecutingTaskCreation] =
    useState<boolean>(false);
  const [executingFetchTodo, setExecutingFetchTodo] = useState<boolean>(true);

  const [searchParams] = useSearchParams();

  const navigate = useNavigate();

  const executeFetchCategoryList = async () => {
    const newListCategory = await CategoryService.getListCategory();
    setListCategory(newListCategory);
  };

  const executeFetchTodo = async () => {
    setExecutingFetchTodo(true);
    const idTodo = searchParams.get("id");
    if (idTodo == null) {
      navigate(PathRoter.TASKS);
      return;
    }
    const id = parseInt(idTodo);

    const newTodo = await TaskService.getTodo(id);
    if (newTodo === null) {
      navigate(PathRoter.TASKS);
    } else {
      setTodo(newTodo);
    }
    setExecutingFetchTodo(false);
  };

  useEffect(() => {
    executeFetchCategoryList();
    executeFetchTodo();
  }, []);

  const handleSubmit = async () => {
    setExecutingTaskCreation(true);
    const result = await TaskService.createTodo(todo);
    if (result instanceof Error) {
      console.error(result.message);
    } else {
      navigate(PathRoter.TASKS);
    }
    setExecutingTaskCreation(false);
  };

  return (
    <LayoutPage>
      <Box display="flex" gap="16px" padding="16px" flexDirection="column">
        <Typography variant="h4">Editando tarefa</Typography>
        {executingFetchTodo && (
          <Loading text="Buscando informaçõas da tarefa..." />
        )}
        {!executingFetchTodo && (
          <Task
            todo={todo}
            setTodo={setTodo}
            onSubmit={handleSubmit}
            listCategory={listCategory}
          />
        )}
      </Box>
      <ModalLoading open={executingTaskCreation} text="Salvando a tarefa" />
    </LayoutPage>
  );
};

export default EditTask;
