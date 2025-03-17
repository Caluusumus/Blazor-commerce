using Dapper;
using MySqlConnector;
using Blazor_E_commerce.Models;

namespace Blazor_E_commerce.Services;

public class CategoryDataAccess : ICategoryDataAccess
{
    private string Conn;

    public CategoryDataAccess(IConfiguration configuration)
    {
        Conn = configuration.GetConnectionString("DefaultConnection")
            ?? throw new Exception("No Database Found");
    }

    public IEnumerable<Category> GetCategories()
    {
        using var connection = new MySqlConnection(Conn);

        const string query = """
                SELECT categoryId, title, description, status
                FROM Categories;
            """;

        return connection.Query<Category>(query);
    }

    public Category? GetCategory(int id)
    {
        using var connection = new MySqlConnection(Conn);

        const string query = """
            SELECT categoryId, Title
            FROM Categories
            WHERE categoryId = @id;
            """;

        return connection.QueryFirstOrDefault<Category>(query, new { id = id });
    }

    public void AddCategory(Category category)
    {
        using var connection = new MySqlConnection(Conn);

        const string query = """
            INSERT INTO Categories(title)
            VALUE (@title);
            """;

        connection.Execute(query, category);
    }

    public void DeleteCategory(int id)
    {
        using var connection = new MySqlConnection(Conn);

        const string query = """
            DELETE FROM Categories
            WHERE categoryId = @id
            """;

        connection.Execute(query, new { id = id });
    }

    public void UpdateCategory(Category category)
    {
        using var connection = new MySqlConnection(Conn);

        const string query = """
            UPDATE Categories
            SET title = @title
            WHERE categoryId = @categoryId;
            """;

        connection.Execute(query, category);
    }
}

