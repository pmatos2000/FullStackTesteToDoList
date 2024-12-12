import CategoryRepositorie from "../repositories/CategoryRepositorie";
import { Category } from "../types";

class CategoryService {
  async getListCategory(): Promise<Category[]> {
    const listCategory = await CategoryRepositorie.getListCategory();
    if (listCategory instanceof Error) {
      console.error(listCategory.message);
      return [];
    }
    return listCategory;
  }

  async deleteCategory(id: number): Promise<boolean> {
    const response = await CategoryRepositorie.deleteCategory(id);
    if (response instanceof Error) {
      console.error(response);
      return false;
    }
    return true;
  }
}

export default new CategoryService();
