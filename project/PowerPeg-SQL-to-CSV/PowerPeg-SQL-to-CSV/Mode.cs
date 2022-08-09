using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV
{
    public interface Mode
    {
        public Result toRun();
        
        public void changeModeConfig();
    }
}
