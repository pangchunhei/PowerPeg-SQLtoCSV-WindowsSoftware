using PowerPeg_SQL_to_CSV.Mode;
using System.Reflection;

namespace Unit_Testing
{
    public class MonthMode_CheckNeedRun
    {
        //When do the test update the ** value before run
        [Fact]
        public void Test1()
        {
            List<string> list = new List<string>();
            list.Add("*");

            //Run the private method (Create with current date)
            Type type = typeof(MonthMode);
            //** Set tigger date
            var m = Activator.CreateInstance(type, DayOfWeek.Sunday, 12, list);
            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name == "needRun" && x.IsPrivate)
            .First();

            //** Set trigger date, correct day and time (Update every time - Next month trigeger)
            //Tue 1200
            DateTime dt = new DateTime(2022, 12, 4, 12, 0, 0);

            //Act
            bool res = (bool)method.Invoke(m, new object[] { dt });

            Assert.True(res);
        }

        [Fact]
        public void Test2()
        {
            List<string> list = new List<string>();
            list.Add("*");

            //Run the private method (Create with current date)
            Type type = typeof(MonthMode);
            //Set tigger date
            var m = Activator.CreateInstance(type, DayOfWeek.Tuesday, 12, list);
            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name == "needRun" && x.IsPrivate)
            .First();

            //Set trigger date, correct day and time (Update every time - Next month trigeger)
            //Tue 0000
            DateTime dt = new DateTime(2022, 10, 4, 0, 0, 0);

            //Act
            bool res = (bool)method.Invoke(m, new object[] { dt });

            Assert.False(res);
        }

        [Fact]
        public void Test3()
        {
            List<string> list = new List<string>();
            list.Add("*");

            //Run the private method (Create with current date)
            Type type = typeof(MonthMode);
            //Set tigger date
            var m = Activator.CreateInstance(type, DayOfWeek.Tuesday, 12, list);
            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name == "needRun" && x.IsPrivate)
            .First();
            //Set trigger date, wrong day, correct time (Update every time - Next month trigeger)
            //Thu 1200
            DateTime dt = new DateTime(2022, 10, 1, 12, 0, 0);

            //Act
            bool res = (bool)method.Invoke(m, new object[] { dt });

            Assert.False(res);
        }

        [Fact]
        public void Test4()
        {
            List<string> list = new List<string>();
            list.Add("*");

            //Run the private method (Create with current date)
            Type type = typeof(MonthMode);
            //Set tigger date
            var m = Activator.CreateInstance(type, DayOfWeek.Tuesday, 12, list);
            MethodInfo method = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name == "needRun" && x.IsPrivate)
            .First();

            //Set trigger date, wrong day and time (Update every time - Next month trigeger)
            //Thu 0000
            DateTime dt = new DateTime(2022, 10, 1, 0, 0, 0);

            //Act
            bool res = (bool)method.Invoke(m, new object[] { dt });

            Assert.False(res);
        }
    }
}