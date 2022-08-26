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
        /// Return "Mode Name", "Trigger DateTime", "Start Search Date", "End Search Date", "Selected Column List"
        /// </returns>
        public string[] getInfo();

        /// <summary>
        /// Provide user current setting of Trigger DateTime (Interface)
        /// </summary>
        /// <returns>Return the TriggerDateTime</returns>
        public DateTime getTriggerDateTime();

        /// <summary>
        /// Provide user current setting of selected column (Interface)
        /// </summary>
        /// <returns>Return the selected column name</returns>
        public List<string> getSelectColumn();
    }
}
