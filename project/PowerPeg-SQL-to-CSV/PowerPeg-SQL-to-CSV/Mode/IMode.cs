using PowerPeg_SQL_to_CSV.ProcessTask;

namespace PowerPeg_SQL_to_CSV.Mode
{
    public interface IMode
    {
        public Result runSearch();

        /// <summary>
        /// Get the information of the mode settings
        /// </summary>
        /// <returns>
        /// Return "Mode Name", "Trigger DateTime", "Start Search Date", "End Search Date", "Selected Column List"
        /// </returns>
        public string[] getInfo();

        public DateTime getTriggerDateTime();

        public List<string> getSelectColumn();
    }
}
