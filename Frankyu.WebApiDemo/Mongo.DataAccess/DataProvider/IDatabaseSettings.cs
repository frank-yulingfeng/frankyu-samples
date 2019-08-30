using System;
using System.Collections.Generic;
using System.Text;

namespace Mongo.DataAccess.DataProvider
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
