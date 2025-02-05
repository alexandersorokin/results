﻿namespace Kontur.Results
{
    public sealed class ResultSucceedException<TValue> : ResultSucceedException
    {
        internal ResultSucceedException(TValue value, string message)
            : base(message)
        {
            Value = value;
        }

        public TValue Value { get; }
    }
}
