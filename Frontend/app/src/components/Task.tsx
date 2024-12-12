import { FC, FormEvent } from "react";
import { Category, TodoEdit } from "../types";
import {
  Box,
  Button,
  Card,
  CardContent,
  Checkbox,
  FormControl,
  FormControlLabel,
  InputLabel,
  MenuItem,
  Select,
  styled,
  TextField,
  Typography,
} from "@mui/material";
import { MASK_DATE } from "../util/Consts";

interface TaskProps {
  todo: TodoEdit;
  setTodo: (todo: TodoEdit) => void;
  onSubmit: () => void;
  listCategory: Category[];
}

const Submit = styled(Button)({
  margin: "16px 0 0px",
});

const Task: FC<TaskProps> = ({ todo, setTodo, onSubmit, listCategory }) => {
  const handleSubmit = (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    onSubmit();
  };
  return (
    <Card>
      <CardContent>
        <form onSubmit={handleSubmit}>
          <Box gap="16px" padding="16px">
            {todo.createdAt && todo.updatedAt && (
              <Box display="flex" gap="16px" justifyContent="space-between">
                <Typography variant="h6">{`Data criação: ${todo.createdAt.format(
                  MASK_DATE
                )}`}</Typography>
                <Typography variant="h6">{`Data edição: ${todo.updatedAt.format(
                  MASK_DATE
                )}`}</Typography>
              </Box>
            )}
            <TextField
              variant="outlined"
              margin="normal"
              required
              fullWidth
              id="title"
              label="Titulo"
              name="title"
              value={todo.title}
              onChange={(e) => setTodo({ ...todo, title: e.target.value })}
              autoFocus
            />
            <TextField
              variant="outlined"
              margin="normal"
              required
              fullWidth
              multiline
              id="description"
              label="Descrição"
              name="description"
              value={todo.description}
              onChange={(e) =>
                setTodo({ ...todo, description: e.target.value })
              }
            />
            <FormControl fullWidth margin="normal">
              <InputLabel id="select-category-label">Categoria</InputLabel>
              <Select
                id="select-category"
                labelId="select-category-label"
                value={todo.categoryId ?? ""}
                label="Categoria"
                onChange={(e) => {
                  let newCategoryId: string | null | number = e.target.value;
                  if (typeof newCategoryId === "string") newCategoryId = null;
                  setTodo({
                    ...todo,
                    categoryId: e.target.value as number | null,
                  });
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
            <FormControlLabel
              control={
                <Checkbox
                  checked={todo.isCompleted}
                  onChange={(e) =>
                    setTodo({ ...todo, isCompleted: e.target.checked })
                  }
                  color="primary"
                />
              }
              label="Tarefa completa"
            />
            <Submit
              type="submit"
              fullWidth
              variant="contained"
              color="primary"
              className="login-submit"
            >
              Salvar
            </Submit>
          </Box>
        </form>
      </CardContent>
    </Card>
  );
};

export default Task;
