using Dapper;
using MySqlConnector;
using Blazor_E_commerce.Models;

namespace Blazor_E_commerce.Services;

public class ItemDataAccess : IItemDataAccess
{
    private string Conn;

    public ItemDataAccess(IConfiguration configuration)
    {
        Conn = configuration.GetConnectionString("DefaultConnection")
            ?? throw new Exception("Database Not Found");
    }

    public IEnumerable<Item> GetItems()
    {
        using var connection = new MySqlConnection(Conn);

        const string query = """
                SELECT ItemId, Name, Description, CategoryId, totalPrice, priceEach
                FROM Items;
            """;

        return connection.Query<Item>(query);
    }

    public Item? GetItem(int id)
    {
        using var connection = new MySqlConnection(Conn);

        const string query = """
            SELECT ItemId, Name, Description, CategoryId, totalPrice, priceEach
            FROM Items
            WHERE ItemId = @id;
            """;

        return connection.QueryFirstOrDefault<Item?>(query, new { id = id });
    }

    public void AddItem(Item item)
    {
        using var connection = new MySqlConnection(Conn);

        const string query = """
            INSERT INTO Items(Name, Description, CategoryId, totalPrice, priceEach)
            VALUE (@Name, @Description, @CategoryId, @totalPrice, @priceEach);
            """;

        connection.Execute(query, item);
    }

    public void DeleteItem(int id)
    {
        using var connection = new MySqlConnection(Conn);

        const string query = """
            DELETE FROM Items
            WHERE ItemId = @id
            """;

        connection.Execute(query, new { id = id });
    }

    public void UpdateItem(Item item)
    {
        using var connection = new MySqlConnection(Conn);

        const string query = """
            UPDATE Items
            SET 
            Name = @Name,
            Description = @Description,
            CategoryId = @CategoryId,
            totalPrice = @totalPrice,
            priceEach = @priceEach,
            WHERE ItemId = @Id;
            """;

        connection.Execute(query, item);
    }
}

