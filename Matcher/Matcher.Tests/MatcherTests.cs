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
        public void Bind()
        {
            var result = Match.Value(100)
                              .AndReturn<int>()
                              .With(x =>
                              {
                                  x.Bind(v => v + 1);
                              });

            Assert.AreEqual(result, 101);
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
        public void IsOfType()
        {
            var result = Match.Value(new SampleParent())
                              .AndReturn<bool>()
                              .With(x =>
                              {
                                  x.OfType().Is<SampleBase>(b => true);
                              });

            Assert.AreEqual(result, true);
        }

        [Test]
        public void IsOfType2()
        {
            var result = Match.Value(new SampleParent())
                              .AndReturn<bool>()
                              .With(x =>
                              {
                                  x.OfType().IsExactly<SampleBase>(b => true);
                                  x.Default(false);
                              });

            Assert.AreEqual(result, false);
        }

        [Test]
        public void IsOfType3()
        {
            var result = Match.Value(new SampleParent() as SampleBase)
                              .AndReturn<bool>()
                              .With(x =>
                              {
                                  x.OfType().Is<SampleParent>(b => true);
                              });

            Assert.AreEqual(result, true);
        }

        [Test]
        public void IsOfType4()
        {
            var result = Match.Value(new SampleParent() as SampleBase)
                              .AndReturn<bool>()
                              .With(x =>
                              {
                                  x.OfType().IsExactly<SampleParent>(b => true);
                              });

            Assert.AreEqual(result, true);
        }
    }
}
