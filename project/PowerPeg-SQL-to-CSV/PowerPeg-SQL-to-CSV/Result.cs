using System.Data;

namespace PowerPeg_SQL_to_CSV
{
    public class Result
    {
        private DateTime generationTime;
        private DataTable result;

        public Result(DateTime genTime, DataTable dt)
        {
            this.generationTime = genTime;
            this.result = dt;
        }

        public DateTime getGenerationTime()
        {
            return this.generationTime;
        }

        public DataTable getResultTable()
        {
            return this.result;
        }
    }
}