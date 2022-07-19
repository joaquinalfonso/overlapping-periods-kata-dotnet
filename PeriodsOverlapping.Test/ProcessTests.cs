using System;
using System.Collections.Generic;
using Periods;
using PeriodsSum.Model;
using Xunit;

namespace PeriodsSum.Tests {
    public class ProcessTests {
        [Fact]
        public void Test1() {
            var periodsSum = new PeriodsManager();

            var input = new List<Period>();
            input.Add(new Period("A", new TimeSpan(3, 30, 0), new TimeSpan(8, 30, 0)));
            input.Add(new Period("B", new TimeSpan(6, 15, 0), new TimeSpan(9, 45, 0)));

            var expected = new List<Period>();
            expected.Add(new Period("A", new TimeSpan(3, 30, 0), new TimeSpan(6, 14, 0)));
            expected.Add(new Period("AB", new TimeSpan(6, 15, 0), new TimeSpan(8, 29, 0)));
            expected.Add(new Period("B", new TimeSpan(8, 30, 0), new TimeSpan(9, 45, 0)));

            var output = periodsSum.ProcessInputs(input);

            Assert.Equal<Period>(expected, output);
        }

        [Fact]
        public void Test2() {
            var periodsSum = new PeriodsManager();

            var input = new List<Period>();
            input.Add(new Period("A", new TimeSpan(1, 0, 0), new TimeSpan(4, 0, 0)));
            input.Add(new Period("B", new TimeSpan(2, 0, 0), new TimeSpan(5, 0, 0)));
            input.Add(new Period("C", new TimeSpan(3, 0, 0), new TimeSpan(6, 0, 0)));
            input.Add(new Period("D", new TimeSpan(8, 0, 0), new TimeSpan(9, 0, 0)));

            var expected = new List<Period>();
            expected.Add(new Period("A", new TimeSpan(1, 0, 0), new TimeSpan(1, 59, 0)));
            expected.Add(new Period("AB", new TimeSpan(2, 0, 0), new TimeSpan(2, 59, 0)));
            expected.Add(new Period("ABC", new TimeSpan(3, 0, 0), new TimeSpan(3, 59, 0)));
            expected.Add(new Period("BC", new TimeSpan(4, 0, 0), new TimeSpan(4, 59, 0)));
            expected.Add(new Period("C", new TimeSpan(5, 0, 0), new TimeSpan(6, 0, 0)));
            expected.Add(new Period("D", new TimeSpan(8, 0, 0), new TimeSpan(9, 0, 0)));

            var output = periodsSum.ProcessInputs(input);

            Assert.Equal<Period>(expected, output);
        }

        [Fact]
        public void Test3() {
            var periodsSum = new PeriodsManager();

            var input = new List<Period>();
            input.Add(new Period("A", new TimeSpan(3, 30, 0), new TimeSpan(8, 30, 0)));
            input.Add(new Period("B", new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0)));

            var expected = new List<Period>();
            expected.Add(new Period("A", new TimeSpan(3, 30, 0), new TimeSpan(8, 30, 0)));
            expected.Add(new Period("B", new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0)));

            var output = periodsSum.ProcessInputs(input);

            Assert.Equal<Period>(expected, output);
        }

        [Fact]
        public void Test4() {
            var periodsSum = new PeriodsManager();

            var input = new List<Period>();
            input.Add(new Period("A", new TimeSpan(1, 0, 0), new TimeSpan(3, 0, 0)));
            input.Add(new Period("B", new TimeSpan(2, 0, 0), new TimeSpan(4, 0, 0)));
            input.Add(new Period("C", new TimeSpan(3, 0, 0), new TimeSpan(5, 0, 0)));

            var expected = new List<Period>();
            expected.Add(new Period("A", new TimeSpan(1, 0, 0), new TimeSpan(1, 59, 0)));
            expected.Add(new Period("AB", new TimeSpan(2, 0, 0), new TimeSpan(2, 59, 0)));
            expected.Add(new Period("BC", new TimeSpan(3, 0, 0), new TimeSpan(3, 59, 0)));
            expected.Add(new Period("C", new TimeSpan(4, 0, 0), new TimeSpan(5, 0, 0)));

            var output = periodsSum.ProcessInputs(input);

            Assert.Equal<Period>(expected, output);
        }

        [Fact]
        public void Test5() {
            var periodsSum = new PeriodsManager();

            var input = new List<Period>();
            input.Add(new Period("A", new TimeSpan(3, 30, 0), new TimeSpan(8, 30, 0)));
            input.Add(new Period("B", new TimeSpan(3, 30, 0), new TimeSpan(8, 30, 0)));

            var expected = new List<Period>();
            expected.Add(new Period("AB", new TimeSpan(3, 30, 0), new TimeSpan(8, 30, 0)));

            var output = periodsSum.ProcessInputs(input);

            Assert.Equal<Period>(expected, output);
        }

        [Fact]
        public void Test6() {
            var periodsSum = new PeriodsManager();

            var input = new List<Period>();
            input.Add(new Period("A", new TimeSpan(3, 00, 0), new TimeSpan(8, 00, 0)));
            input.Add(new Period("B", new TimeSpan(6, 00, 0), new TimeSpan(9, 00, 0)));

            var expected = new List<Period>();
            expected.Add(new Period("A", new TimeSpan(3, 0, 0), new TimeSpan(5, 59, 0)));
            expected.Add(new Period("AB", new TimeSpan(6, 0, 0), new TimeSpan(7, 59, 0)));
            expected.Add(new Period("B", new TimeSpan(8, 0, 0), new TimeSpan(9, 00, 0)));

            var output = periodsSum.ProcessInputs(input);

            Assert.Equal<Period>(expected, output);
        }

    }
}
