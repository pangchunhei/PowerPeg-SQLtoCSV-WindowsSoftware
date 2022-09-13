using PowerPeg_SQL_to_CSV.ProcessTask;

namespace PowerPeg_SQL_to_CSV.Mode
{
    public interface IMode
    {
        /// <summary>
        /// Run the search of the search task according to Mode (Interface)
        /// </summary>
        /// <param name="runDateTime">Provide the current DateTime</param>
        /// <returns>Return an Result object</returns>
        public Result runSearch(DateTime runDateTime);

        /// <summary>
        /// Get the information of the mode settings (Interface)
        /// </summary>
        /// <returns>
        /// Return depends on mode
        /// </returns>
        public string[] getInfo();

    }
}
