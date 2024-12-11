import { FC, useEffect, useState } from "react";
import { Category, TodoEdit } from "../types";
import { TODO_EDIT_DEFAULT } from "../util/Values";
import Task from "../components/Task";
import LayoutPage from "../components/LayoutPage";
import { Box, Typography } from "@mui/material";
import CategoryService from "../services/CategoryService";

const NewTask: FC = () => {
  const [todo, setTodo] = useState<TodoEdit>(TODO_EDIT_DEFAULT);
  const [listCategory, setListCategory] = useState<Category[]>([]);

  const executeFetchCategoryList = async () => {
    const newListCategory = await CategoryService.getListCategory();
    setListCategory(newListCategory);
  };

  useEffect(() => {
    executeFetchCategoryList();
  }, []);

  const handleSubmit = () => {
    console.log(todo);
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
    </LayoutPage>
  );
};

export default NewTask;
