﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Kontur.Results;
using NUnit.Framework;

namespace Kontur.Tests.Results.Conversion.Combinations.Linq.Optional.OptionalOptional.SelectMany.Options1.Tasks2
{
    internal class Task_Should<TFixtureCase> : LinqTestBase<TFixtureCase>
        where TFixtureCase : IFixtureCase, new()
    {
        private const int TaskTerm1 = 1000;
        private const int TaskTerm2 = 10000;
        private static readonly Task<int> Task1000 = Task.FromResult(TaskTerm1);
        private static readonly Task<int> Task10000 = Task.FromResult(TaskTerm2);

        private static readonly IEnumerable<TestCaseData> Cases = CreateSelectCases(1, sum => sum + TaskTerm1 + TaskTerm2);

        private static Task<Optional<int>> SelectResult(int value)
        {
            return Task.FromResult(GetOption(value));
        }

        [TestCaseSource(nameof(Cases))]
        public Task<Optional<int>> Option_Task_Task(Optional<int> optional)
        {
            return
                from x in optional
                from y in Task1000
                from z in Task10000
                select SelectResult(x + y + z);
        }

        [TestCaseSource(nameof(Cases))]
        public Task<Optional<int>> TaskOption_Task_Task(Optional<int> optional)
        {
            return
                from x in Task.FromResult(optional)
                from y in Task1000
                from z in Task10000
                select SelectResult(x + y + z);
        }
    }
}