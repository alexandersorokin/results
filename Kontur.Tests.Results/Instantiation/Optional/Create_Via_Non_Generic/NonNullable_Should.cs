﻿using System;
using FluentAssertions;
using Kontur.Results;
using NUnit.Framework;

namespace Kontur.Tests.Results.Instantiation.Optional.Create_Via_Non_Generic
{
    [TestFixture(10)]
    [TestFixture("bar")]
    internal class NonNullable_Should<T>
    {
        private readonly T value;

        public NonNullable_Should(T value)
        {
        this.value = value;
        }

        private static TestCaseData Create(Func<T, Optional<T>> optionFactory, bool hasValue)
        {
            return new(optionFactory) { ExpectedResult = hasValue };
        }

        private static readonly TestCaseData[] Cases =
        {
            Create(_ => Kontur.Results.Optional.None<T>(), false),
            Create(Kontur.Results.Optional.Some, true),
        };

        [TestCaseSource(nameof(Cases))]
        public bool HasValue(Func<T, Optional<T>> optionFactory)
        {
            var option = optionFactory(value);

            return option.HasSome;
        }

        [Test]
        public void Store_Value()
        {
            var option = Kontur.Results.Optional.Some(value);

            var result = option.GetValueOrThrow();

            result.Should().Be(value);
        }
    }
}
