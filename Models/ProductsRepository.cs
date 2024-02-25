
namespace RetailInvetorySystem.Models
{
    public class ProductsRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product { ProductId = 1, CategoryId = 1, Name = "Milk", Quantity = 10, Price = 2.99 },
            new Product { ProductId = 2, CategoryId = 1, Name = "Cheese", Quantity = 20, Price = 3.99 },
            new Product { ProductId = 3, CategoryId = 2, Name = "Bread", Quantity = 15, Price = 1.99 },
            new Product { ProductId = 4, CategoryId = 2, Name = "Rolls", Quantity = 25, Price = 2.99 },
            new Product { ProductId = 5, CategoryId = 3, Name = "Apples", Quantity = 30, Price = 3.99 },
            new Product { ProductId = 6, CategoryId = 3, Name = "Oranges", Quantity = 35, Price = 1.99 },
        };

        public static void AddProduct(Product product)
        {
            if (product != null && product.ProductId > 0)
            {
                var maxId = _products.Max(p => p.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }
            if (product == null)
            {
                _products = new List<Product>();
            }
            _products.Add(product);
        }

        public static void DeleteProduct(int ProductId)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == ProductId);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public static List<Product> GetProducts(bool loadCategory = false)
        {
            if (!loadCategory)
            {
                return _products;
            }
            else
            {
                if (_products != null && _products.Count > 0)
                {
                    _products.ForEach(p =>
                    {
                        if (p.CategoryId.HasValue)
                        {
                            p.Category = CategoriesRepository.GetCategoryById(p.CategoryId.Value);
                        }
                    }
                    );
                }
                return _products ?? new List<Product>();
            }

        }

        public static Product GetProductById(int ProductId, bool loadCategory = false)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == ProductId);
            if (product != null)
            {
                var prod = new Product
                {
                    CategoryId = product.CategoryId,
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Price = product.Price,
                };
                if (loadCategory && prod.CategoryId.HasValue)
                {
                    prod.Category = CategoriesRepository.GetCategoryById(prod.CategoryId.Value);
                }
                return prod;
            }
            return null;
        }

        public static void UpdateProduct(int productId, Product product)
        {
            if (productId != product.ProductId)
            {
                return;
            }

            var existingProduct = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.Name = product.Name;
                existingProduct.Quantity = product.Quantity;
                existingProduct.Price = product.Price;
            }
        }

        public static List<Product> GetProductsByCategory(int categoryId)
        {
            var products = _products.Where(p => p.CategoryId == categoryId);
            if (products != null)
            {
                return products.ToList();
            }
            else
            {
                return new List<Product>();
            }

        }
    }
}
