﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Kontur.Results;
using NUnit.Framework;

namespace Kontur.Tests.Results.Conversion.Combinations.Linq.Optional.Optional.SelectMany.Options2.Tasks1
{
    [TestFixture]
    internal class Value_Should
    {
        private const int TaskTerm = 1000;
        private static readonly Task<int> Task1000 = Task.FromResult(TaskTerm);

        private static readonly IEnumerable<TestCaseData> Cases = SelectCasesGenerator
            .Create(2)
            .ToTestCases(option => option.MapValue(sum => sum + TaskTerm));

        [TestCaseSource(nameof(Cases))]
        public Task<Optional<int>> Option_Option_Task(
            Optional<int> option1,
            Optional<int> option2)
        {
            return
                from x in option1
                from y in option2
                from z in Task1000
                select x + y + z;
        }

        [TestCaseSource(nameof(Cases))]
        public Task<Optional<int>> TaskOption_Option_Task(
            Optional<int> option1,
            Optional<int> option2)
        {
            return
                from x in Task.FromResult(option1)
                from y in option2
                from z in Task1000
                select x + y + z;
        }

        [TestCaseSource(nameof(Cases))]
        public Task<Optional<int>> Option_TaskOption_Task(
            Optional<int> option1,
            Optional<int> option2)
        {
            return
                from x in option1
                from y in Task.FromResult(option2)
                from z in Task1000
                select x + y + z;
        }

        [TestCaseSource(nameof(Cases))]
        public Task<Optional<int>> TaskOption_TaskOption_Task(
            Optional<int> option1,
            Optional<int> option2)
        {
            return
                from x in Task.FromResult(option1)
                from y in Task.FromResult(option2)
                from z in Task1000
                select x + y + z;
        }

        [TestCaseSource(nameof(Cases))]
        public Task<Optional<int>> Option_Task_Option(Optional<int> option1, Optional<int> option2)
        {
            return
                from x in option1
                from y in Task1000
                from z in option2
                select x + y + z;
        }

        [TestCaseSource(nameof(Cases))]
        public Task<Optional<int>> TaskOption_Task_Option(Optional<int> option1, Optional<int> option2)
        {
            return
                from x in Task.FromResult(option1)
                from y in Task1000
                from z in option2
                select x + y + z;
        }

        [TestCaseSource(nameof(Cases))]
        public Task<Optional<int>> Option_Task_TaskOption(Optional<int> option1, Optional<int> option2)
        {
            return
                from x in option1
                from y in Task1000
                from z in Task.FromResult(option2)
                select x + y + z;
        }

        [TestCaseSource(nameof(Cases))]
        public Task<Optional<int>> TaskOption_Task_TaskOption(Optional<int> option1, Optional<int> option2)
        {
            return
                from x in Task.FromResult(option1)
                from y in Task1000
                from z in Task.FromResult(option2)
                select x + y + z;
        }
    }
}