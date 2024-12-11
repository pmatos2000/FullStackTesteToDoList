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
}

export default new CategoryService();
