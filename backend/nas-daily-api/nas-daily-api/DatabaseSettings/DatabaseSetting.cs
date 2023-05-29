namespace nas_daily_api.DatabaseSettings
{
    public class DatabaseSetting
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? OASCollectionName { get; set; }
        public string? NASCollectionName { get; set; }
        public string? OfficeCollectionName { get; set; }
        public string? SuperiorCollectionName { get; set; }
        public string? ScheduleCollectionName { get; set; }
        public string? LogCollectionName { get; set; }
    }
}
