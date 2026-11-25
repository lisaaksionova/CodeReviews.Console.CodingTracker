using Microsoft.Data.Sqlite;

namespace CodingTracker.Database;

public class DatabaseInitialization
{
    private readonly string _connectionString;

    public DatabaseInitialization(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void CreateDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var createCodingSessionsTableSql = """
                                           CREATE TABLE IF NOT EXISTS codingSessions (
                                               id INTEGER PRIMARY KEY,
                                               startTime TEXT NOT NULL,
                                               endTime TEXT NOT NULL,
                                               duration REAL
                                           );
                                           """;
        using var command = new SqliteCommand(createCodingSessionsTableSql, connection);
        command.ExecuteNonQuery();
    }
}