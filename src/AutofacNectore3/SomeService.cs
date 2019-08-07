using System;
using System.Threading.Tasks;

namespace AutofacNectore3
{
    public class SomeService : ISomeService
    {
        public Task DoSomethingAsync()
            => Task.Delay(TimeSpan.FromMilliseconds(100));
    }
}