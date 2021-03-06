﻿using System;

namespace Matcher.Cases
{
    /// <summary>
    /// Checks if the value if of a specified type.
    /// </summary>
    public class OfTypeMatchCase<TNewType, TValue, TResult>: IMatchCase<TValue, TResult>
    {
        public OfTypeMatchCase(bool strict, Func<TNewType, Option<TResult>> factory)
        {
            _strict = strict;
            _factory = factory;
        }

        private readonly bool _strict;
        private readonly Func<TNewType, Option<TResult>> _factory;

        public Option<TResult> Match(TValue value)
        {
            var isMatch = _strict
                ? value.GetType() == typeof(TNewType)
                : value is TNewType;

            if (isMatch)
                return _factory((TNewType) (object) value);

            return Option.None<TResult>();
        }
    }
}
