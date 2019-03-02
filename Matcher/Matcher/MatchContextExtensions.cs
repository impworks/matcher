using System;
using Matcher.Cases;

namespace Matcher
{
    /// <summary>
    /// Helper methods for defining cases.
    /// </summary>
    public static class MatchContextExtensions
    {
        #region Default

        /// <summary>
        /// Returns a default value.
        /// </summary>
        public static void Default<TValue, TResult>(this IMatchContext<TValue, TResult> context, Func<TResult> func)
        {
            context.Case(new DefaultMatchCase<TValue, TResult>(func));
        }

        /// <summary>
        /// Returns a default value.
        /// </summary>
        public static void Default<TValue, TResult>(this IMatchContext<TValue, TResult> context, TResult result)
        {
            context.Case(new DefaultMatchCase<TValue, TResult>(() => result));
        }


        /// <summary>
        /// Binds the value to a new name.
        /// </summary>
        public static void Default<TValue, TResult>(this IMatchContext<TValue, TResult> context, Func<TValue, TResult> func)
        {
            context.Case(new DefaultBindMatchCase<TValue, TResult>(func));
        }

        #endregion

        #region Value

        /// <summary>
        /// Checks if the matched value equals a given value.
        /// </summary>
        public static void Value<TValue, TResult>(this IMatchContext<TValue, TResult> context, TValue value, Func<TResult> func)
        {
            context.Case(new ValueMatchCase<TValue, TResult>(value, func));
        }

        /// <summary>
        /// Checks if the matched value equals a given value.
        /// </summary>
        public static void Value<TValue, TResult>(this IMatchContext<TValue, TResult> context, TValue value, TResult result)
        {
            context.Case(new ValueMatchCase<TValue, TResult>(value, () => result));
        }

        #endregion

        #region Array

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TResult> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[],TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TResult> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TResult> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TResult> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TResult> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TResult> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TResult> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TElem, TResult> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TResult> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TResult> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TResult> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        #endregion

        #region OfType

        /// <summary>
        /// Sets up a type check.
        /// </summary>
        public static OfTypeMatchCaseBuilder<TValue, TResult> OfType<TValue, TResult>(this IMatchContext<TValue, TResult> context)
        {
            return new OfTypeMatchCaseBuilder<TValue, TResult>(context);
        }

        #endregion
    }
}
