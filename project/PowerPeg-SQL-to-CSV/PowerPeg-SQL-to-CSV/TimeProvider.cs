using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV
{
    public interface ITimeProvider
    {
        DateTime GetCurrentTime();
    }

    public class DefaultTimeProvider : ITimeProvider
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }

    public class TestTimeProvider : ITimeProvider
    {
        private DateTime _mockedDateTime;

        public TestTimeProvider(DateTime mockedDateTime)
        {
            _mockedDateTime = mockedDateTime;
        }

        public DateTime GetCurrentTime()
        {
            return _mockedDateTime;
        }
    }
}
