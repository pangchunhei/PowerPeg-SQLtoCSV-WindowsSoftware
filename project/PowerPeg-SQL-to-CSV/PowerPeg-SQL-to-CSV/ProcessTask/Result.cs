using System.Data;

namespace PowerPeg_SQL_to_CSV.ProcessTask
{
    public class Result
    {
        private DateTime generationTime;
        private DataTable result;

        public Result(DateTime genTime, DataTable dt)
        {
            generationTime = genTime;
            result = dt;
        }

        public DateTime getGenerationTime()
        {
            return generationTime;
        }

        public DataTable getResultTable()
        {
            return result;
        }
    }
}