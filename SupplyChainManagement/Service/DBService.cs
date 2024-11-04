using Microsoft.Data.SqlClient;

public class DBService
{
    private readonly IConfiguration _configuration;

    public DBService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<Dictionary<string, object>> ExecuteQuery(string connectionName, string query)
    {
        var result = new List<Dictionary<string, object>>();



        using (SqlConnection connection = new SqlConnection(connectionName))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[reader.GetName(i)] = reader.GetValue(i);
                        }

                        result.Add(row);
                    }
                }
            }
        }

        return result;
    }
}
