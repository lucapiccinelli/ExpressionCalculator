using System;
using System.Collections.Generic;
using System.IO;

namespace Expressions
{
    public class WithFileFixture: IDisposable
    {
        public string Filename { get; } = $"expressions{new Random().Next()}.txt";
        public string FirstExpression { get; } = "5+2*4";
        public string SecondExpression { get; } = "12-2";

        public WithFileFixture()
        {
            var lines = new List<string>
            {
                FirstExpression,
                SecondExpression
            };
            File.WriteAllLines(Filename, lines);
        }

        public void Dispose()
        {
            File.Delete(Filename);
        }
    }
}