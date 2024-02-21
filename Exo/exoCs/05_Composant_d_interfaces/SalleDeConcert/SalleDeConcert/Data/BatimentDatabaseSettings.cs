namespace SalleDeConcert.Data
{
    public class BatimentDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string SallesCollectionName { get; set; } = null!;
    }
}
