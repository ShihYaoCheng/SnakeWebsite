namespace SnakeAsianLeague.Data.Entity.View
{
    public class Title
    {
        public string? MainTitle { get; set; }
        public string? SubTitle { get; set; }

        public Title(string main, string sub)
        {
            MainTitle = main;
            SubTitle = sub;
        }
    }
}
