using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerPeg_SQL_to_CSV.Mode;
using PowerPeg_SQL_to_CSV.ProcessTask;
using System.Reflection;

namespace Unit_Testing
{
    public class MonthMode_CheckNeedRun
    {
        [Fact]
        public void Test1()
        {
            List<string> list = new List<string>();
            list.Add("*");
            
            MonthMode m = new MonthMode(DayOfWeek.Tuesday, 12, list);

            //Set trigger date, correct day and time (Next month trigeger)
            //Tue 1200
            DateTime dt = new DateTime(2022, 10, 4, 12, 0, 0);

            Result res = m.runSearch(dt);
            MethodInfo methodInfo = typeof(MonthMode).GetMethod("needRun", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { "God" };

            object result = methodInfo.Invoke(sut, parameters);

            Assert.NotNull(res);
        }

        [Fact]
        public void Test2()
        {

            List<string> list = new List<string>();
            list.Add("*");

            MonthMode m = new MonthMode(DayOfWeek.Tuesday, 12, list);

            //Set trigger date, correct day, wrong time
            //Tue 0000
            DateTime dt = new DateTime(2022, 10, 4, 0, 0, 0);
            Result res = m.runSearch(dt);

            Assert.Null(res);
        }

        [Fact]
        public void Test3()
        {

            List<string> list = new List<string>();
            list.Add("*");

            MonthMode m = new MonthMode(DayOfWeek.Tuesday, 12, list);

            //Set trigger date, wrong day, correct time
            //Thu 1200
            DateTime dt = new DateTime(2022, 10, 1, 12, 0, 0);
            Result res = m.runSearch(dt);

            Assert.Null(res);
        }

        [Fact]
        public void Test4()
        {
            //Set create date
            

            List<string> list = new List<string>();
            list.Add("*");

            MonthMode m = new MonthMode(DayOfWeek.Tuesday, 12, list);

            //Set trigger date, wrong day, wrong time
            //Thu 0000
            DateTime dt = new DateTime(2022, 10, 1, 0, 0, 0);
            Result res = m.runSearch(dt);

            Assert.Null(res);
        }
    }
}