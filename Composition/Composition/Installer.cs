namespace Composition
{
    public class Installer
    {
        readonly Logger _logger;

        public Installer(Logger logger)
        {
            _logger = logger;
        }

        public void Install()
        {
            _logger.Log("We are installing the application");
        }
    }
}