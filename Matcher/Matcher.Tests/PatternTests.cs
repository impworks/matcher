using System;
using Matcher.Cases.Pattern;
using NUnit.Framework;

namespace Matcher.Tests
{
    [TestFixture]
    public class PatternTests
    {
        [Test]
        public void Constant()
        {
            var m = Match.Value(1)
                         .AndReturn<string>()
                         .With(ctx => ctx.Pattern(p => 1).Map("test"));

            Assert.AreEqual(m, "test");
        }

        [Test]
        public void Array()
        {
            var m = Match.Value(new [] { 1, 2 })
                         .AndReturn<string>()
                         .With(ctx => ctx.Pattern(p => p.Array(1, 2)).Map("test"));

            Assert.AreEqual(m, "test");
        }

        [Test]
        public void Array2()
        {
            var m = Match.Value(new[] { 1, 2, 3 })
                         .AndReturn<string>()
                         .With(ctx =>
                         {
                             ctx.Pattern(p => p.Array(1, 2)).Map("test");
                             ctx.Default("foo");
                         });

            Assert.AreEqual(m, "foo");
        }

        [Test]
        public void ValueTuple2()
        {
            var m = Match.Value((1, 2))
                         .AndReturn<string>()
                         .With(ctx => ctx.Pattern(p => p.Tuple(1, 2)).Map("test"));

            Assert.AreEqual(m, "test");
        }

        [Test]
        public void CommonTuple2()
        {
            var m = Match.Value(Tuple.Create(1, 2))
                         .AndReturn<string>()
                         .With(ctx => ctx.Pattern(p => p.Tuple(1, 2)).Map("test"));

            Assert.AreEqual(m, "test");
        }

        [Test]
        public void Var1()
        {
            var m = Match.Value(Tuple.Create(1, 2))
                         .AndReturn<string>()
                         .With(ctx =>
                         {
                             ctx.Pattern(p => p.Tuple(p.Var("a"), p.Var("b")))
                                .Map<int, int>((b, a) => $"{a} and {b}");
                         });

            Assert.AreEqual(m, "1 and 2");
        }
        
        [Test]
        public void Var2()
        {
            var m = Match.Value(Tuple.Create(1, true, new []  { 1, 2, 3 }))
                         .AndReturn<string>()
                         .With(ctx =>
                         {
                             ctx.Pattern(p => p.Tuple(1, p.Var("b"), p.Array(1, p.Var("a"), p.Any())))
                                .Map<int, bool>((a, b) => $"{a} and {b}");
                         });

            Assert.AreEqual(m, "2 and True");
        }

        [Test]
        public void OfType()
        {
            var m = Match.Value(1)
                         .AndReturn<string>()
                         .With(ctx =>
                         {
                             ctx.Pattern(p => p.Var("a").OfType<int>())
                                .Map<int>(a => $"is {a}");
                         });

            Assert.AreEqual(m, "is 1");
        }

        [Test]
        public void OfType2()
        {
            var m = Match.Value(1)
                         .AndReturn<string>()
                         .With(ctx =>
                         {
                             ctx.Pattern(p => p.Var("a").OfType<bool>())
                                .Map<int>(a => $"is {a}");
                             ctx.Default("fail");
                         });

            Assert.AreEqual(m, "fail");
        }
    }
}
