using System;
using System.IO;
using PowerPeg_SQL_to_CSV;
using PowerPeg_SQL_to_CSV.Mode;
using PowerPeg_SQL_to_CSV.ProcessTask;
using Xunit.Abstractions;


namespace Unit_Testing
{
    public class TestableMonthMode : MonthMode
    {
        public TestableMonthMode(DayOfWeek triggerDay, int triggerTime, List<string> selection)
            : base(triggerDay, triggerTime, selection)
        {
            
        }

        public override Result runSearch()
        {
            // Override implementation for testing

            DateTime runDateTime = TestableMonthMode.TimeProvider.GetCurrentTime();

            if (needRun(runDateTime))
            {
                this.nextRunDateTime = CalculateNextTriggerDate(runDateTime);
                return new Result(runDateTime);
            }
            else
            {
                return null;
            }
        }

        public bool checkingHaveRan()
        {
            if(runSearch() == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class Test_Monthmode_Trigger
    {
        private readonly ITestOutputHelper output;

        public Test_Monthmode_Trigger(ITestOutputHelper output)
        {
            this.output = output;
        }

        //Time 1st time
        [Fact]
        public void Test1_FirstRun()
        {
            DateTime dateTime = new DateTime(2022, 4, 1, 1, 0, 0);
            TestableMonthMode.TimeProvider = new TestTimeProvider(dateTime);

            TestableMonthMode testableMonthMode = new TestableMonthMode(DayOfWeek.Monday, 0, new List<string> { "*" });
            output.WriteLine($"MonthMode Current Time: {TestableMonthMode.TimeProvider.GetCurrentTime()}");
            output.WriteLine($"MonthMode: {testableMonthMode}");

            // Assert
            Assert.True(testableMonthMode.checkingHaveRan());
        }

        //Not Reach Target Time
        [Fact]
        public void Test2_TimeNotReachMinutes()
        {
            // Arrange
            DateTime dateTime = new DateTime(2022, 4, 1, 1, 0, 0);
            TestableMonthMode.TimeProvider = new TestTimeProvider(dateTime);
            output.WriteLine($"Current Time: {TestableMonthMode.TimeProvider.GetCurrentTime()}");

            TestableMonthMode testableMonthMode = new TestableMonthMode(DayOfWeek.Monday, 0, new List<string> { "*" });
            output.WriteLine($"Current Time: {TestableMonthMode.TimeProvider.GetCurrentTime()}");
            output.WriteLine($"MonthMode: {testableMonthMode}");

            dateTime = new DateTime(2022, 4, 1, 0, 0, 0);
            TestableMonthMode.TimeProvider = new TestTimeProvider(dateTime);
            output.WriteLine($"Current Time: {TestableMonthMode.TimeProvider.GetCurrentTime()}");

            // Assert
            Assert.False(testableMonthMode.checkingHaveRan());
        }

        [Fact]
        public void Test2_TimeNotReachDay()
        {
            // Arrange
            DateTime dateTime = new DateTime(2022, 4, 1, 1, 0, 0);
            TestableMonthMode.TimeProvider = new TestTimeProvider(dateTime);

            TestableMonthMode testableMonthMode = new TestableMonthMode(DayOfWeek.Monday, 0, new List<string> { "*" });
            output.WriteLine($"Current Time: {TestableMonthMode.TimeProvider.GetCurrentTime()}");
            output.WriteLine($"MonthMode: {testableMonthMode}");

            dateTime = new DateTime(2022, 3, 28, 0, 10, 0);
            TestableMonthMode.TimeProvider = new TestTimeProvider(dateTime);

            // Assert
            Assert.False(testableMonthMode.checkingHaveRan());
        }

        //Time reached
        [Fact]
        public void Test3_TimeReachMinutes()
        {
            // Arrange
            DateTime dateTime = new DateTime(2022, 4, 1, 1, 1, 0);
            TestableMonthMode.TimeProvider = new TestTimeProvider(dateTime);

            TestableMonthMode testableMonthMode = new TestableMonthMode(DayOfWeek.Monday, 1, new List<string> { "*" });
            output.WriteLine($"Current Time: {TestableMonthMode.TimeProvider.GetCurrentTime()}");
            output.WriteLine($"MonthMode: {testableMonthMode}");

            dateTime = new DateTime(2022, 4, 1, 1, 10, 0);
            TestableMonthMode.TimeProvider = new TestTimeProvider(dateTime);

            // Assert
            Assert.True(testableMonthMode.checkingHaveRan());
        }

        [Fact]
        public void Test3_TimeReachMoreMinutes()
        {
            // Arrange
            DateTime dateTime = new DateTime(2022, 4, 1, 1, 0, 0);
            TestableMonthMode.TimeProvider = new TestTimeProvider(dateTime);

            TestableMonthMode testableMonthMode = new TestableMonthMode(DayOfWeek.Monday, 1, new List<string> { "*" });
            output.WriteLine($"Current Time: {TestableMonthMode.TimeProvider.GetCurrentTime()}");
            output.WriteLine($"MonthMode: {testableMonthMode}");

            dateTime = new DateTime(2022, 4, 1, 1, 11, 0);
            TestableMonthMode.TimeProvider = new TestTimeProvider(dateTime);

            // Assert
            Assert.True(testableMonthMode.checkingHaveRan());
        }

        [Fact]
        public void Test3_TimeReachHour()
        {
            // Arrange
            DateTime dateTime = new DateTime(2022, 4, 1, 1, 0, 0);
            TestableMonthMode.TimeProvider = new TestTimeProvider(dateTime);

            TestableMonthMode testableMonthMode = new TestableMonthMode(DayOfWeek.Monday, 1, new List<string> { "*" });
            output.WriteLine($"Current Time: {TestableMonthMode.TimeProvider.GetCurrentTime()}");
            output.WriteLine($"MonthMode: {testableMonthMode}");

            dateTime = new DateTime(2022, 4, 1, 2, 0, 0);
            TestableMonthMode.TimeProvider = new TestTimeProvider(dateTime);

            // Assert
            Assert.True(testableMonthMode.checkingHaveRan());
        }



        [Fact]
        public void Test4_YrSim()
        {
            DateTime dateTime = new DateTime(2022, 4, 1, 0, 0, 0);
            TestableMonthMode.TimeProvider = new TestTimeProvider(dateTime);

            TestableMonthMode testableMonthMode = new TestableMonthMode(DayOfWeek.Monday, 10, new List<string> { "*" });

            int runtTime_inMin = 356 * 24 * 60 * 60 * 2;

            string full_csvFilePath = "YearSim_Full_RunningRecord.csv";
            // Clear the existing content of the CSV file
            File.WriteAllText(full_csvFilePath, string.Empty);
            File.AppendAllText(full_csvFilePath, testableMonthMode.ToString());
            string str = string.Format($"dateTime, checkingHaveRan{Environment.NewLine}");
            File.AppendAllText(full_csvFilePath, str);

            string true_csvFilePath = "YearSim_True_RunningRecord.csv";
            // Clear the existing content of the CSV file
            File.WriteAllText(true_csvFilePath, string.Empty);
            File.AppendAllText(true_csvFilePath, testableMonthMode.ToString());
            File.AppendAllText(true_csvFilePath, str);

            using (FileStream full_fileStream = new FileStream(full_csvFilePath, FileMode.Append, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter full_streamWriter = new StreamWriter(full_fileStream))
                {
                    using (FileStream true_fileStream = new FileStream(true_csvFilePath, FileMode.Append, FileAccess.Write, FileShare.None))
                    {
                        using (StreamWriter true_streamWriter = new StreamWriter(true_fileStream))
                        {
                            for (int i = 0; i < runtTime_inMin; i++)
                            {
                                bool resBool = testableMonthMode.checkingHaveRan();
                                str = string.Format($"{dateTime}, {resBool}");
                                full_streamWriter.WriteLine(str);

                                if (resBool)
                                {
                                    true_streamWriter.WriteLine(str);
                                }

                                dateTime = dateTime.AddSeconds(1);
                                TestableMonthMode.TimeProvider = new TestTimeProvider(dateTime);
                            }
                        }
                    }
                }
            }
            Assert.True(true);
        }
    }
}
