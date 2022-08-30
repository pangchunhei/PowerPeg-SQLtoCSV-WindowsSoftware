using System.Data;

namespace PowerPeg_SQL_to_CSV.ProcessTask
{
    public class Result
    {
        private DateTime generationTime;
        private DataTable result;

        /// <summary>
        /// Create a result object
        /// </summary>
        /// <param name="genTime">Result generation time</param>
        /// <param name="dt">DataTable of the result</param>
        public Result(DateTime genTime)
        {
            generationTime = genTime;
            result = new DataTable();
        }

        public void updateDataTable(DataTable newDataTable)
        {
            this.result = newDataTable;
        }

        /// <summary>
        /// Get the generation time
        /// </summary>
        /// <returns>Return of DataTime</returns>
        public DateTime getGenerationTime()
        {
            return generationTime;
        }

        /// <summary>
        /// Get the Result of the DataTable
        /// </summary>
        /// <returns>Return of DataTable</returns>
        public DataTable getResultTable()
        {
            return result;
        }
    }
}