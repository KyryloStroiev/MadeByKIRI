using Microsoft.Data.SqlClient;

namespace MadeByKIRI.Models;

public static class Setting
{
    public static string ConnectionString => new SqlConnectionStringBuilder
    {
        DataSource = "localhost",
        InitialCatalog = "ShopKiri",
        IntegratedSecurity = true,
        TrustServerCertificate = true
    }.ConnectionString;
    public static JsonSerializerOptions SerializerOptions = new()
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    };
}

