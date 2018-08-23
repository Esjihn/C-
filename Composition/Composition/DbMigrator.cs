namespace Composition
{
    public class DbMigrator
    {
        readonly Logger _logger;

        public DbMigrator(Logger logger)
        {
            _logger = logger;
        }

        public void Migrate()
        {
            _logger.Log("We are migrating blah blah blah...");
        }
    }
}