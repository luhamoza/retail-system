namespace RetailInvetorySystem.Models
{
    public class ProductsRepository
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product { ProductId = 1, CategoryId = 1, Name = "Milk", Quantity = 10, Price = 2 },
            new Product { ProductId = 2, CategoryId = 1, Name = "Cheese", Quantity = 20, Price = 3 },
            new Product { ProductId = 3, CategoryId = 2, Name = "Bread", Quantity = 15, Price = 1 },
            new Product { ProductId = 4, CategoryId = 2, Name = "Rolls", Quantity = 25, Price = 2 },
            new Product { ProductId = 5, CategoryId = 3, Name = "Apples", Quantity = 30, Price = 3 },
            new Product { ProductId = 6, CategoryId = 3, Name = "Oranges", Quantity = 35, Price = 1 },
        };

        public static void AddProduct(Product product)
        {
            var maxId = _products.Max(p => p.ProductId);
            product.ProductId = maxId + 1;
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

        public static List<Product> GetProducts()
        {
            return _products;
        }

        public static Product GetProductById(int ProductId)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == ProductId);
            if (product != null)
            {
                return new Product
                {
                    CategoryId = product.CategoryId,
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Quantity = product.Quantity,
                    Price = product.Price,
                };
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

    }
}
