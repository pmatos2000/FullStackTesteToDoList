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
import { useNavigate } from "react-router-dom";

const NewTask: FC = () => {
  const [todo, setTodo] = useState<TodoEdit>(TODO_EDIT_DEFAULT);
  const [listCategory, setListCategory] = useState<Category[]>([]);
  const [executingTaskCreation, setExecutingTaskCreation] =
    useState<boolean>(false);

  const navigate = useNavigate();

  const executeFetchCategoryList = async () => {
    const newListCategory = await CategoryService.getListCategory();
    setListCategory(newListCategory);
  };

  useEffect(() => {
    executeFetchCategoryList();
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
        <Typography variant="h4">Criar nova tarefa</Typography>
        <Task
          todo={todo}
          setTodo={setTodo}
          onSubmit={handleSubmit}
          listCategory={listCategory}
        />
      </Box>
      <ModalLoading open={executingTaskCreation} text="Salvando a tarefa" />
    </LayoutPage>
  );
};

export default NewTask;
