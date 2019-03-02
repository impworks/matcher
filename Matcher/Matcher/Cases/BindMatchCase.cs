﻿using System;

namespace Matcher.Cases
{
    /// <summary>
    /// Binds the value to a new name.
    /// </summary>
    public class BindMatchCase<TValue, TResult> : IMatchCase<TValue, TResult>
    {
        public BindMatchCase(Func<TValue, TResult> factory)
        {
            _factory = factory;
        }

        private readonly Func<TValue, TResult> _factory;

        public Option<TResult> Match(TValue value)
        {
            return new Option<TResult>(_factory(value));
        }
    }
}
