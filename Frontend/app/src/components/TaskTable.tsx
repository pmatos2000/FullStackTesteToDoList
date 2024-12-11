import { FC } from "react";
import { TodoItem } from "../types";
import {
  IconButton,
  Paper,
  styled,
  Table,
  TableBody,
  TableCell,
  tableCellClasses,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import { MASK_DATE } from "../util/Consts";
import { CheckCircle, Delete, Edit } from "@mui/icons-material";

interface TaskTableProps {
  listTodo: TodoItem[];
}

const StyledTableCell = styled(TableCell)(({ theme }) => ({
  [`&.${tableCellClasses.head}`]: {
    backgroundColor: "blue",
    color: theme.palette.common.white,
  },
  [`&.${tableCellClasses.body}`]: {
    fontSize: 14,
  },
}));

const StyledTableRow = styled(TableRow)(({ theme }) => ({
  "&:nth-of-type(odd)": {
    backgroundColor: theme.palette.action.hover,
  },
  // hide last border
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}));

const StyledPaper = styled(Paper)({
  maxWidth: "1280px",
});

const TaskTable: FC<TaskTableProps> = ({ listTodo }) => {
  return (
    <TableContainer component={StyledPaper}>
      <Table aria-label="Task Table">
        <TableHead>
          <TableRow>
            <StyledTableCell width="5%">ID</StyledTableCell>
            <StyledTableCell width="30%">Titulo</StyledTableCell>
            <StyledTableCell align="center" width="25%">
              Categoria
            </StyledTableCell>
            <StyledTableCell align="center" width="5%">
              Completo
            </StyledTableCell>
            <StyledTableCell align="center" width="20%">
              Data criação
            </StyledTableCell>
            <StyledTableCell align="center" width="15%">
              Ações
            </StyledTableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {listTodo.map((todo) => (
            <StyledTableRow key={todo.id}>
              <StyledTableCell width="5%" component="th" scope="row">
                {todo.id}
              </StyledTableCell>
              <StyledTableCell width="30%">{todo.title}</StyledTableCell>
              <StyledTableCell align="center" width="25%">
                {todo.categoryId}
              </StyledTableCell>
              <StyledTableCell align="center" width="5%">
                {todo.isCompleted ? "Sim" : "Não"}
              </StyledTableCell>
              <StyledTableCell align="center" width="20%">
                {todo.createAt.format(MASK_DATE)}
              </StyledTableCell>
              <StyledTableCell align="center" width="15%">
                <IconButton>
                  <CheckCircle />
                </IconButton>
                <IconButton>
                  <Edit />
                </IconButton>
                <IconButton>
                  <Delete />
                </IconButton>
              </StyledTableCell>
            </StyledTableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default TaskTable;
