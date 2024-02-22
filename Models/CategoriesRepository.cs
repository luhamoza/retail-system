namespace RetailInvetorySystem.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category {CategoryId=1, Description="Dairy", Name="Dairy"},
            new Category {CategoryId=2, Description="Bread", Name="Bread"},
            new Category {CategoryId=3, Description="Fruits", Name="Fruits"},
        };

        public static void AddCategory(Category category)
        {
            var maxId = _categories.Max(x => x.CategoryId);
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Description = category.Description,
                    Name = category.Name,
                };
            }
            else
            {
                return null;
            }
        }
        public static void UpdateCategory(Category category, int categoryId)
        {
            if (categoryId != category.CategoryId)
            {
                return;
            }
            Category? categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int categoryId)
        {
            Category? categoryToDelete = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (categoryToDelete != null)
            {
                _categories.Remove(categoryToDelete);
            }
        }
    }
}
