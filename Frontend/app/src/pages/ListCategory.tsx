import { FC, useEffect, useState } from "react";
import {
  Container,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  IconButton,
  TextField,
  Button,
  Grid2,
  Typography,
  tableCellClasses,
  styled,
} from "@mui/material";

import DeleteIcon from "@mui/icons-material/Delete";
import { Category } from "../types";
import CategoryService from "../services/CategoryService";

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
  "&:last-child td, &:last-child th": {
    border: 0,
  },
}));

const ListCategory: FC = () => {
  const [listCategory, setListCategory] = useState<Category[]>([]);
  const [categoryName, setCategoryName] = useState<string>("");
  const [executingCategoryCreation, setExecutingCategoryCreation] =
    useState<boolean>(false);

  const handleDelete = async (id: number) => {
    const sucess = await CategoryService.deleteCategory(id);
    if (sucess) {
      setListCategory((list) => list.filter((x) => x.id !== id));
    }
  };

  const handleAdd = async () => {
    setExecutingCategoryCreation(true);
    const newCategory = await CategoryService.createCategory(categoryName);
    if (newCategory) {
      setListCategory([...listCategory, newCategory]);
      setCategoryName("");
    }
    setExecutingCategoryCreation(false);
  };

  const executeFetchCategoryList = async () => {
    const newListCategory = await CategoryService.getListCategory();
    setListCategory(newListCategory);
  };

  useEffect(() => {
    executeFetchCategoryList();
  }, []);

  return (
    <Container>
      <Typography variant="h4" marginY="24px">
        Gerenciador de categorias
      </Typography>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <StyledTableCell width="10%">ID</StyledTableCell>
              <StyledTableCell width="80%">Name</StyledTableCell>
              <StyledTableCell width="10%">Ação</StyledTableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {listCategory.map((category) => (
              <StyledTableRow key={category.id}>
                <StyledTableCell width="10%">{category.id}</StyledTableCell>
                <StyledTableCell width="80%">{category.name}</StyledTableCell>
                <StyledTableCell width="10%">
                  <IconButton onClick={() => handleDelete(category.id)}>
                    <DeleteIcon />
                  </IconButton>
                </StyledTableCell>
              </StyledTableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <Grid2 container alignItems="center" spacing="24px">
        <Grid2 size={{ xs: 10 }}>
          <TextField
            label="Nova Categoria"
            variant="outlined"
            fullWidth
            value={categoryName}
            onChange={(e) => setCategoryName(e.target.value.trimStart())}
            margin="normal"
          />
        </Grid2>
        <Grid2 size={{ xs: 2 }}>
          <Button
            fullWidth
            variant="contained"
            color="primary"
            onClick={handleAdd}
            disabled={categoryName.length === 0 || executingCategoryCreation}
          >
            Adicionar
          </Button>
        </Grid2>
      </Grid2>
    </Container>
  );
};

export default ListCategory;
