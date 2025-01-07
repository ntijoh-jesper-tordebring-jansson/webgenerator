using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace webgenerator
{
    class Seeder
    {
        public static void SeedDatabase()
        {
            Console.WriteLine("Seeding markdown database...");

            try
            {
                using var connection = new SqliteConnection("Data Source=./db/markdown.db");
                connection.Open();
                Console.WriteLine("Connected to the SQLite database!");

                // Create table MarkdownRules
                var createTableCmd = @"
                    CREATE TABLE IF NOT EXISTS MarkdownRules (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        MarkdownCommand TEXT NOT NULL,
                        HtmlOpenTag TEXT NOT NULL,
                        HtmlCloseTag TEXT NOT NULL
                    );
                ";
                using var createTable = new SqliteCommand(createTableCmd, connection);
                createTable.ExecuteNonQuery();
                Console.WriteLine("Table MarkdownRules created");

                // Clear table MarkdownRules
                var clearTableCmd = "DELETE FROM MarkdownRules;";
                using var clearTable = new SqliteCommand(clearTableCmd, connection);
                clearTable.ExecuteNonQuery();
                Console.WriteLine("Table cleared!");

                // Seed with markdown rules
                var seedData = new[]
                {
                    ("#", "<h1>", "</h1>"),
                    ("##", "<h2>", "</h2>"),
                    ("###", "<h3>", "</h3>"),
                    ("*", "<em>", "</em>"),
                    ("**", "<strong>", "</strong>"),
                    ("-", "<li>", "</li>")
                };

                foreach (var (command, openTag, closeTag) in seedData)
                {
                    var insertCmd = @"
                        INSERT INTO MarkdownRules (MarkdownCommand, HtmlOpenTag, HtmlCloseTag)
                        VALUES (@command, @openTag, @closeTag);
                    ";
                    using var insert = new SqliteCommand(insertCmd, connection);
                    insert.Parameters.AddWithValue("@command", command);
                    insert.Parameters.AddWithValue("@openTag", openTag);
                    insert.Parameters.AddWithValue("@closeTag", closeTag);
                    insert.ExecuteNonQuery();
                }

                Console.WriteLine("Seeding completed successfully!");




            } catch (SqliteException ex) { 
                Console.WriteLine($"SQLite Error: {ex.Message}");
            }
        }
    }
}
