using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV
{
    public class InstantMode : Mode
    {
        private String modeName { get; } = "Insatant Mode";

        private DateTime startDateTime { get; }

        private DateTime endDateTime { get; }

        private DateTime triggerDateTime { get; }

        private List<String> selectColumn { get; } = new List<String>();

        public InstantMode(DateTime s, DateTime e, DateTime t, List<String> sC)
        {
            this.startDateTime = s;
            this.endDateTime = e;
            this.triggerDateTime = t;
            this.selectColumn = sC;
        }

        public Result toRun()
        {
            


            throw new NotImplementedException();
        }
    }
}
