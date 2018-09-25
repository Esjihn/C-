using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceBookDLT
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FaceBookDLTConsole();
        }

        static void FaceBookDLTConsole()
        {
            var accessToken = "EAADiGqOkZBcwBACi1rr6UazHCQtZCC5GaThR14ZA5iS69V9wVu8NzKfZBN7kWJjS0FVp3o5UUL0TXTCPmfsOvFMbpy0UMq97zfZBzZBhFhgD9HJM0fTS1g69Elr8tbyMQ43irmW4AXE5cZCtndzKOppDX7komCsOwFAjEeWDrNIvwZDZD";
            var facebookClient = new FaceBookClient();
            var facebookService = new FacebookService(facebookClient);
            var getAccountTask = facebookService.GetAccountAsync(accessToken);

            Task.WaitAll(getAccountTask);
            var account = getAccountTask.Result;
            Console.WriteLine($"{account.ID} {account.Name}");

            var postOnWallTask =
                facebookService.PostOnWallAsync(accessToken, "Currently Testing Automated Integration with Facebook API!");
            Task.WaitAll(postOnWallTask);
        }
    }
}
