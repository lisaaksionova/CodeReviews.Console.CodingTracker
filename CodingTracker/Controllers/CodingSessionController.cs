using CodingTracker.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CodingTracker.Controllers;

public class CodingSessionController
{
    private readonly string _connectionString = "Data Source=CodingTracker.db";
    
    public void Create(CodingSession codingSession)
    {
        var insertSql = """
                        INSERT INTO codingSession (startTime, endTime, duration)
                        VALUES (@startTime, @endTime, @duration);
                        """;
        using var connection = new SqliteConnection(_connectionString);
        
        connection.Execute(insertSql, codingSession);
    }

    public void Update(CodingSession codingSession)
    {
        var updateSql = """
                        UPDATE codingSession
                        SET startTime = @startTime, endTime = @endTime, duration = @duration;
                        """;
        using var connection = new SqliteConnection(_connectionString);
        
        connection.Execute(updateSql, codingSession);
    }

    public void Delete(int id)
    {
        var deleteSql = """
                        DELETE FROM codingSession
                        WHERE id = @id;
                        """;
        using var connection = new SqliteConnection(_connectionString);
        connection.Execute(deleteSql, id);
    }

    public List<CodingSession> Read()
    {
        var selectSql = """
                        SELECT * from codingSession;
                        """;

        using var connection = new SqliteConnection(_connectionString);
        var result = connection.Query<CodingSession>(selectSql).ToList();
        return result;
    }
}