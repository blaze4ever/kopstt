namespace Kopstt.Core.DBStructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    interface IDatabaseOperations
    {
        string query();
        void runQuery();
    }
}
