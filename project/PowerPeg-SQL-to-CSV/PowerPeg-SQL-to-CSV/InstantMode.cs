using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV
{
    public class InstantMode : Mode
    {
        private String modeName { get; set; }

        private DateTime startDateTime { get; set; }

        private DateTime endDateTime { get; set; }

        private DateTime triggerDateTime { get; set; }

        private List<String> selectColumn { get; set; }

        public void changeModeConfig()
        {
            throw new NotImplementedException();
        }

        public Result toRun()
        {
            throw new NotImplementedException();
        }
    }
}
