using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Matcher.Cases;
using Matcher.Cases.Pattern;

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
        public static void Default<TValue, TResult>(this IMatchContext<TValue, TResult> context, Func<Option<TResult>> func)
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
        public static void Default<TValue, TResult>(this IMatchContext<TValue, TResult> context, Func<TValue, Option<TResult>> func)
        {
            context.Case(new DefaultBindMatchCase<TValue, TResult>(func));
        }

        #endregion

        #region Value

        /// <summary>
        /// Checks if the matched value equals a given value.
        /// </summary>
        public static void Value<TValue, TResult>(this IMatchContext<TValue, TResult> context, TValue value, Func<Option<TResult>> func)
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
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<Option<TResult>> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[],TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, Option<TResult>> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, Option<TResult>> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, Option<TResult>> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, Option<TResult>> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, Option<TResult>> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, Option<TResult>> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TElem, Option<TResult>> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, Option<TResult>> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, Option<TResult>> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void Array<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, Option<TResult>> func)
        {
            context.Case(new ArrayMatchCase<TElem, TElem[], TResult>(func));
        }

        #endregion

        #region Array with rest

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void ArrayRest<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem[], Option<TResult>> func)
        {
            context.Case(new ArrayRestMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void ArrayRest<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem[], Option<TResult>> func)
        {
            context.Case(new ArrayRestMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void ArrayRest<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem[], Option<TResult>> func)
        {
            context.Case(new ArrayRestMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void ArrayRest<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem[], Option<TResult>> func)
        {
            context.Case(new ArrayRestMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void ArrayRest<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem[], Option<TResult>> func)
        {
            context.Case(new ArrayRestMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void ArrayRest<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem[], Option<TResult>> func)
        {
            context.Case(new ArrayRestMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void ArrayRest<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TElem[], Option<TResult>> func)
        {
            context.Case(new ArrayRestMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void ArrayRest<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem[], Option<TResult>> func)
        {
            context.Case(new ArrayRestMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void ArrayRest<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem[], Option<TResult>> func)
        {
            context.Case(new ArrayRestMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void ArrayRest<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem[], Option<TResult>> func)
        {
            context.Case(new ArrayRestMatchCase<TElem, TElem[], TResult>(func));
        }

        /// <summary>
        /// Destructs an array.
        /// </summary>
        public static void ArrayRest<TElem, TResult>(this IMatchContext<TElem[], TResult> context, Func<TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem, TElem[], Option<TResult>> func)
        {
            context.Case(new ArrayRestMatchCase<TElem, TElem[], TResult>(func));
        }

        #endregion

        #region Tuple

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, TResult>(this IMatchContext<Tuple<T1>, TResult> context, Func<T1, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<Tuple<T1>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, TResult>(this IMatchContext<Tuple<T1, T2>, TResult> context, Func<T1, T2, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<Tuple<T1, T2>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, T3, TResult>(this IMatchContext<Tuple<T1, T2, T3>, TResult> context, Func<T1, T2, T3, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<Tuple<T1, T2, T3>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, T3, T4, TResult>(this IMatchContext<Tuple<T1, T2, T3, T4>, TResult> context, Func<T1, T2, T3, T4, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<Tuple<T1, T2, T3, T4>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, T3, T4, T5, TResult>(this IMatchContext<Tuple<T1, T2, T3, T4, T5>, TResult> context, Func<T1, T2, T3, T4, T5, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<Tuple<T1, T2, T3, T4, T5>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, T3, T4, T5, T6, TResult>(this IMatchContext<Tuple<T1, T2, T3, T4, T5, T6>, TResult> context, Func<T1, T2, T3, T4, T5, T6, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<Tuple<T1, T2, T3, T4, T5, T6>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, T3, T4, T5, T6, T7, TResult>(this IMatchContext<Tuple<T1, T2, T3, T4, T5, T6, T7>, TResult> context, Func<T1, T2, T3, T4, T5, T6, T7, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<Tuple<T1, T2, T3, T4, T5, T6, T7>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, T3, T4, T5, T6, T7, TRest, TResult>(this IMatchContext<Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>, TResult> context, Func<T1, T2, T3, T4, T5, T6, T7, TRest, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>, TResult>(func));
        }

        #endregion

        #region ValueTuple

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, TResult>(this IMatchContext<ValueTuple<T1>, TResult> context, Func<T1, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<ValueTuple<T1>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, TResult>(this IMatchContext<ValueTuple<T1, T2>, TResult> context, Func<T1, T2, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<ValueTuple<T1, T2>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, T3, TResult>(this IMatchContext<ValueTuple<T1, T2, T3>, TResult> context, Func<T1, T2, T3, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<ValueTuple<T1, T2, T3>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, T3, T4, TResult>(this IMatchContext<ValueTuple<T1, T2, T3, T4>, TResult> context, Func<T1, T2, T3, T4, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<ValueTuple<T1, T2, T3, T4>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, T3, T4, T5, TResult>(this IMatchContext<ValueTuple<T1, T2, T3, T4, T5>, TResult> context, Func<T1, T2, T3, T4, T5, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<ValueTuple<T1, T2, T3, T4, T5>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, T3, T4, T5, T6, TResult>(this IMatchContext<ValueTuple<T1, T2, T3, T4, T5, T6>, TResult> context, Func<T1, T2, T3, T4, T5, T6, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<ValueTuple<T1, T2, T3, T4, T5, T6>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, T3, T4, T5, T6, T7, TResult>(this IMatchContext<ValueTuple<T1, T2, T3, T4, T5, T6, T7>, TResult> context, Func<T1, T2, T3, T4, T5, T6, T7, Option<TResult>> func)
        {
            context.Case(new TupleMatchCase<ValueTuple<T1, T2, T3, T4, T5, T6, T7>, TResult>(func));
        }

        /// <summary>
        /// Destructs a tuple.
        /// </summary>
        public static void Tuple<T1, T2, T3, T4, T5, T6, T7, TRest, TResult>(this IMatchContext<ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>, TResult> context, Func<T1, T2, T3, T4, T5, T6, T7, TRest, Option<TResult>> func)
            where TRest: struct
        {
            context.Case(new TupleMatchCase<ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>, TResult>(func));
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

        #region Pattern

        /// <summary>
        /// Matches an arbitrary pattern.
        /// </summary>
        public static PatternMatchCaseBuilder<TValue, TResult> Pattern<TValue, TResult>(this IMatchContext<TValue, TResult> context, Expression<Func<IPatternBuilder, object>> expr)
        {
            return new PatternMatchCaseBuilder<TValue, TResult>(context, expr);
        }

        #endregion

        #region Regex (string)

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, string regex, TResult value)
        {
            context.Regex(regex, () => value);
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, string regex, Func<Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(new Regex(regex), func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, string regex, Func<string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(new Regex(regex), func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, string regex, Func<string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(new Regex(regex), func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, string regex, Func<string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(new Regex(regex), func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, string regex, Func<string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(new Regex(regex), func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, string regex, Func<string, string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(new Regex(regex), func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, string regex, Func<string, string, string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(new Regex(regex), func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, string regex, Func<string, string, string, string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(new Regex(regex), func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, string regex, Func<string, string, string, string, string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(new Regex(regex), func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, string regex, Func<string, string, string, string, string, string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(new Regex(regex), func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, string regex, Func<string, string, string, string, string, string, string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(new Regex(regex), func));
        }

        #endregion

        #region Regex (object)

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, Regex regex, TResult value)
        {
            context.Regex(regex, () => value);
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, Regex regex, Func<Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(regex, func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, Regex regex, Func<string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(regex, func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, Regex regex, Func<string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(regex, func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, Regex regex, Func<string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(regex, func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, Regex regex, Func<string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(regex, func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, Regex regex, Func<string, string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(regex, func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, Regex regex, Func<string, string, string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(regex, func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, Regex regex, Func<string, string, string, string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(regex, func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, Regex regex, Func<string, string, string, string, string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(regex, func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, Regex regex, Func<string, string, string, string, string, string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(regex, func));
        }

        /// <summary>
        /// Matches the value against a regex.
        /// </summary>
        public static void Regex<TResult>(this IMatchContext<string, TResult> context, Regex regex, Func<string, string, string, string, string, string, string, string, string, string, Option<TResult>> func)
        {
            context.Case(new RegexMatchCase<TResult>(regex, func));
        }

        #endregion

        #region Options

        /// <summary>
        /// Matches the optional value.
        /// </summary>
        public static void Option<TElem, TResult>(this IMatchContext<TElem?, TResult> context, Func<TElem, Option<TResult>> func) where TElem : struct
        {
            context.Case(new OptionMatchCase<TElem, TResult>(func));
        }

        #endregion
    }
}
