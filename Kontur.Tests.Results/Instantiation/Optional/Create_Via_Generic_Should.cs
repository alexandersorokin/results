﻿using System;
using FluentAssertions;
using Kontur.Results;
using NUnit.Framework;

namespace Kontur.Tests.Results.Instantiation.Optional
{
    [TestFixture(10)]
    [TestFixture("bar")]
    internal class Create_Via_Generic_Should<T>
    {
        private readonly T value;

        public Create_Via_Generic_Should(T value)
        {
            this.value = value;
        }

        private static TestCaseData CreateCase(Func<T, Optional<T>> optionFactory, bool hasSome)
        {
            return new(optionFactory) { ExpectedResult = hasSome };
        }

        private static readonly TestCaseData[] CreateCases =
        {
            CreateCase(_ => Optional<T>.None(), false),
            CreateCase(Optional<T>.Some, true),
        };

        [TestCaseSource(nameof(CreateCases))]
        public bool HasValue(Func<T, Optional<T>> optionFactory)
        {
            var option = optionFactory(value);

            return option.HasSome;
        }

        [Test]
        public void Store_Value()
        {
            var option = Optional<T>.Some(value);

            var result = option.GetValueOrThrow();

            result.Should().Be(value);
        }
    }
}
