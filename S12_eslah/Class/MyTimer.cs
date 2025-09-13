using System;
using System.Diagnostics;

namespace CoreConceptsDemo
{
    public class CodeTimer : IDisposable
    {
        private readonly string _operationName;
        private readonly Stopwatch _stopwatch;

        public CodeTimer(string operationName)
        {
            _operationName = operationName;
            _stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            _stopwatch.Stop();
            Console.WriteLine($"'{_operationName}' finished in: {_stopwatch.ElapsedMilliseconds} ms");
        }
    }
}