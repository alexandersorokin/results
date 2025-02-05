﻿namespace Kontur.Results.SourceGenerator.Code
{
    internal class ClassNamesPass : ClassNamesFactory
    {
        internal ClassNamesPass(string methodName, string parameterTypes)
        : base(methodName, parameterTypes)
        {
        }

        internal string Pass => Create(nameof(Pass));
    }
}
