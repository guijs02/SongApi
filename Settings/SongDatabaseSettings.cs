namespace Song.Api.Settings
{
    public class SongDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string SongCollectionName { get; set; } = null!;
    }
}
