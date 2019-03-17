using System;

namespace Matcher.Cases
{
    /// <summary>
    /// Matches an optional value.
    /// </summary>
    public class OptionMatchCase<TElem, TResult>: IMatchCase<TElem?, TResult>
        where TElem: struct
    {
        public OptionMatchCase(Func<TElem, Option<TResult>> func)
        {
            _func = func;
        }

        private readonly Func<TElem, Option<TResult>> _func;

        public Option<TResult> Match(TElem? value)
        {
            if (value == null)
                return Option.None<TResult>();

            return _func(value.Value);
        }
    }
}
