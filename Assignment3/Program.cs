using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();
var connectionString = configuration.GetConnectionString("Kanban");

var cmdText = @"
    SELECT
        *
    FROM
        Tasks
";

using var connection = new SqlConnection(connectionString);
using var command = new SqlCommand(cmdText, connection);

connection.Open();

var reader = command.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine(reader["Title"]);
}

