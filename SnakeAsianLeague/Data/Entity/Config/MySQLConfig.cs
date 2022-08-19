namespace SnakeAsianLeague.Data.Entity.Config
{
    public class MySQLConfig
    {
        public static readonly string Section = "MySQL";

        public string IP { get; set; }
        public uint Port { get; set; }
        public string DatabaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool DoMigrationOnlyThenExit { get; set; }
    }
}
