using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV
{
    public class Task
    {
        public String outputLocation { get; set; }

        public Mode operationMode { get; set; }

        public Result outputString { get; set; }

        public Result toRun()
        {
            operationMode.toRun();
        }

        public void changeModeConfig()
        {
            operationMode.changeModeConfig();
        }
    }
}
