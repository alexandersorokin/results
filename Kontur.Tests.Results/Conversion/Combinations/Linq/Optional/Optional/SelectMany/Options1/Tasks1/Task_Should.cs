﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Kontur.Results;
using NUnit.Framework;

namespace Kontur.Tests.Results.Conversion.Combinations.Linq.Optional.Optional.SelectMany.Options1.Tasks1
{
    [TestFixture]
    internal class Task_Should
    {
        private const int TaskTerm = 1000;
        private static readonly Task<int> Task1000 = Task.FromResult(TaskTerm);

        private static readonly IEnumerable<TestCaseData> Cases = SelectCasesGenerator
            .Create(1)
            .ToTestCases(option => option.MapValue(sum => sum + TaskTerm));

        [TestCaseSource(nameof(Cases))]
        public Task<Optional<int>> Option_Task(Optional<int> optional)
        {
            return
                from x in optional
                from y in Task1000
                select Task.FromResult(x + y);
        }

        [TestCaseSource(nameof(Cases))]
        public Task<Optional<int>> TaskOption_Task(Optional<int> optional)
        {
            return
                from x in Task.FromResult(optional)
                from y in Task1000
                select Task.FromResult(x + y);
        }
    }
}