using System;
using NUnit.Framework;

namespace Matcher.Tests
{
    [TestFixture]
    public class ValueTests
    {
        [Test]
        [TestCase(1, true)]
        [TestCase(2, false)]
        public void Value(int value, bool expected)
        {
            var result = Match.Value(value)
                              .AndReturn<bool>()
                              .With(x =>
                              {
                                  x.Value(1, true);
                                  x.Value(2, false);
                              });

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Default()
        {
            var result = Match.Value(100)
                              .AndReturn<bool>()
                              .With(x =>
                              {
                                  x.Value(1, true);
                                  x.Default(false);
                              });

            Assert.AreEqual(result, false);
        }

        [Test]
        public void DefaultBind()
        {
            var result = Match.Value(100)
                              .AndReturn<int>()
                              .With(x =>
                              {
                                  x.Default(v => v + 1);
                              });

            Assert.AreEqual(result, 101);
        }

        [Test]
        public void NoMatch()
        {
            Assert.Throws<MatchFailedException>(() =>
            {
                Match.Value(100)
                     .AndReturn<bool>()
                     .With(x => { x.Value(1, true); });
            });
        }

        [Test]
        public void ArrayEmpty()
        {
            var result = Match.Value(new int[0])
                              .AndReturn<int>()
                              .With(x =>
                              {
                                  x.Array(() => 0);
                              });

            Assert.AreEqual(result, 0);
        }

        [Test]
        public void ArrayOne()
        {
            var result = Match.Value(new [] { 1 })
                              .AndReturn<int>()
                              .With(x =>
                              {
                                  x.Array(() => 0);
                                  x.Array(a => a);
                              });

            Assert.AreEqual(result, 1);
        }

        [Test]
        public void ArrayMultiple()
        {
            var result = Match.Value(new[] { 1, 2, 3 })
                              .AndReturn<int>()
                              .With(x =>
                              {
                                  x.Array(() => 0);
                                  x.Array(a => a);
                                  x.Array((a, b, c) => a + b + c);
                              });

            Assert.AreEqual(result, 6);
        }

        [Test]
        public void ArrayRest()
        {
            var result = Match.Value(new[] {1, 2, 3})
                              .AndReturn<string>()
                              .With(x => { x.ArrayRest((a, rest) => $"{a} and {rest.Length} more"); });

            Assert.AreEqual(result, "1 and 2 more");
        }

        [Test]
        public void ArrayRestEmpty()
        {
            var result = Match.Value(new [] { 1, 2 })
                              .AndReturn<string>()
                              .With(x => { x.ArrayRest((a, b, rest) => $"{a}, {b}, and {rest.Length} more"); });

            Assert.AreEqual(result, "1, 2, and 0 more");
        }

        [Test]
        public void ArrayRestFewer()
        {
            var result = Match.Value(new[] { 1 })
                              .AndReturn<string>()
                              .With(x =>
                              {
                                  x.ArrayRest((a, b, rest) => $"{a}, {b}, and {rest.Length} more");
                                  x.Default(a => $"only {a.Length} item");
                              });

            Assert.AreEqual(result, "only 1 item");
        }

        [Test]
        public void ClassicTuple()
        {
            var result = Match.Value(Tuple.Create(1))
                              .AndReturn<int>()
                              .With(x => { x.Tuple(a => a + 1); });

            Assert.AreEqual(result, 2);
        }

        [Test]
        public void ClassicTuple2()
        {
            var result = Match.Value(Tuple.Create(1, "test"))
                              .AndReturn<int>()
                              .With(x => { x.Tuple((a, b) => a + b.Length); });

            Assert.AreEqual(result, 5);
        }

        [Test]
        public void VTuple()
        {
            var result = Match.Value(ValueTuple.Create(1))
                              .AndReturn<int>()
                              .With(x => { x.Tuple(a => a + 1); });

            Assert.AreEqual(result, 2);
        }

        [Test]
        public void VTuple2()
        {
            var result = Match.Value(ValueTuple.Create(1, "test"))
                              .AndReturn<int>()
                              .With(x => { x.Tuple((a, b) => a + b.Length); });

            Assert.AreEqual(result, 5);
        }

        [Test]
        public void IsOfType()
        {
            var result = Match.Value(new SampleChild())
                              .AndReturn<bool>()
                              .With(x =>
                              {
                                  x.OfType().Is<SampleParent>(b => true);
                              });

            Assert.AreEqual(result, true);
        }

        [Test]
        public void IsOfType2()
        {
            var result = Match.Value(new SampleChild())
                              .AndReturn<bool>()
                              .With(x =>
                              {
                                  x.OfType().IsExactly<SampleParent>(b => true);
                                  x.Default(false);
                              });

            Assert.AreEqual(result, false);
        }

        [Test]
        public void IsOfType3()
        {
            var result = Match.Value(new SampleChild() as SampleParent)
                              .AndReturn<bool>()
                              .With(x =>
                              {
                                  x.OfType().Is<SampleChild>(b => true);
                              });

            Assert.AreEqual(result, true);
        }

        [Test]
        public void IsOfType4()
        {
            var result = Match.Value(new SampleChild() as SampleParent)
                              .AndReturn<bool>()
                              .With(x =>
                              {
                                  x.OfType().IsExactly<SampleChild>(b => true);
                              });

            Assert.AreEqual(result, true);
        }

        [Test]
        public void Regex1()
        {
            var result = Match.Value("hello world")
                              .AndReturn<bool>()
                              .With(x => x.Regex("[a-z]{5}", true));

            Assert.AreEqual(result, true);
        }
        
        [Test]
        public void Regex2()
        {
            var result = Match.Value("hello world")
                              .AndReturn<bool>()
                              .With(x =>
                              {
                                  x.Regex("[0-9]{5}", true);
                                  x.Default(false);
                              });

            Assert.AreEqual(result, false);
        }

        [Test]
        public void Regex3()
        {
            var result = Match.Value("hello world")
                              .AndReturn<int>()
                              .With(x => x.Regex("[a-z]{5}", v => v.Length));

            Assert.AreEqual(result, 5);
        }
        
        [Test]
        public void Regex4()
        {
            var result = Match.Value("hello world")
                              .AndReturn<string>()
                              .With(x => x.Regex("([a-z]+)\\s([a-z]+)", (_, a, b) => $"{b} and {a}"));

            Assert.AreEqual(result, "world and hello");
        }
    }
}
