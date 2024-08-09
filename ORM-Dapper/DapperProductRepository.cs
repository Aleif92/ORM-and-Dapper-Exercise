using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperProductRepository: IProductRepository

{

    private readonly IDbConnection _connection;
    

    public void CreateProduct(string name, double price, int categoryID)
    {
        _connection.Execute("INSERT INTO products (Name, Price, CategoryID) Values (@name, @price, @categoryID);",
            new {name = name, price = price, categoryID = categoryID});
    }

    public void UpdateProductName(int productID, string updateName)
    {
        _connection.Execute("UPDATE products SET  Name = @updateName WHERE ProductID = @productID;");
    }

    public void DeleteProduct(int productID)
    {
        _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID",
            new { productID = productID });

        _connection.Execute("DELETE FROM sales WHERE ProductID = @productID",
            new { productID = productID });
        _connection.Execute("DELETE FROM products WHERE ProductID = @productID",
            new { productID = productID });

    }

    public DapperProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Product> GetAllProducts()
    {
       return _connection.Query<Product>("SELECT * FROM PRODUCTS;");
        
    }
}