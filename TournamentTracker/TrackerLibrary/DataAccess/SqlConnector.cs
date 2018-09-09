using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        // TODO - Make the CreatePrize() actually save to the database
        // Saves a new prize to the database
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Closes SQL connection down properly after end of curly braces.
            using (IDbConnection connection =
                new System.Data.SqlClient.SqlConnection(GlobalConfig.ConString("Tournaments")))
            {



            }
        }

    }
}
