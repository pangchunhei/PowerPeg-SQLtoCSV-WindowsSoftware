using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV
{
    public interface Mode
    {
        public Result runSearch();

        /// <summary>
        /// Get the information of the mode settings
        /// </summary>
        /// <returns>
        /// Return "Mode Name", "Trigger DateTime", "Start Search Date", "End Search Date", "Selected Column List"
        /// </returns>
        public string[] getInfo();
        
    }
}
