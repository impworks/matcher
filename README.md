# Matcher

A proof-of-concept library for strongly-typed pattern matching in C#.

### Basic syntax

```csharp
var result = Match.Value(3)
                  .AndReturn<string>()
                  .With(ctx =>
                  {
                      ctx.Value(1, "one");
                      ctx.Value(2, "two");
                      ctx.Value(3, "three");
                      ctx.Default(x => $"just {x}");
                  });
```

### Supported stuff

Array destructuring (up to 10 elements):

```csharp
Match.Value(new [] { 1, 2, 3 })
     .AndReturn<string>()
     .With(ctx =>
     {
         ctx.Array(() => "empty array");
         ctx.Array(a => $"just {a}");
         ctx.Array((a, b) => $"{a} and {b}");
         ctx.Array((a, b, c) => $"{a}, {b}, and {c}");
         ctx.Default(x => $"array with {x.Length} values");
     });
```

Array with a last argument as "rest":

```csharp
Match.Value(new [] { 1, 2, 3 })
     .AndReturn<string>()
     .With(ctx =>
     {
         ctx.ArrayRest((a, rest) => $"{a} and {rest.Length} more"); // 1 and 2 more
     });
```

Tuple deconstructing (supports `ValueTuple` as well):

```csharp
Match.Value(Tuple.Create(1, 2, 3))
     .AndReturn<string>()
     .With(ctx =>
     {
         ctx.Tuple((a, b, c) => a + b + c); // equals 6
     });
```

Nullable value unpacking:

```csharp
Match.Value((int?)10)
     .AndReturn<string>()
     .With(ctx =>
     {
         ctx.Option(i => $"Value is {i}"); // value is 10
     });
```

Type checking:

```csharp
Match.Value(new Child())
     .AndReturn<bool>()
     .With(ctx =>
     {
         ctx.OfType().Is<Child>(x => true);         // true
         ctx.OfType().Is<Parent>(x => true);        // true
         ctx.OfType().IsExactly<Child>(x => true);  // true
         ctx.OfType().IsExactly<Parent>(x => true); // false
     });
```

Arbitrary nested patterns:

```csharp
Match.Value(Tuple.Create(1, true, new[] { 1, 2, 3 }))
     .AndReturn<string>()
     .With(ctx =>
     {
         ctx.Pattern(p =>
                p.Tuple(
                    1,
                    p.Var("b").OfType<bool>(),
                    p.Array(
                        1,
                        p.Var("a"),
                        p.Any()
                    )
                )
            )
            .Map<int, bool>((a, b) => $"{a} and {b}"); // 2 and True
     });
```

Regex matches:

```csharp
Match.Value("code is 123")
     .AndReturn<int>()
     .With(ctx =>
     {
         ctx.Regex("[0-9]+", v => int.Parse(v)); // 123
     });
```

When guards (similarly supported for all other constructs):

```csharp
Match.Value(new [] { 1, 2, 3 })
     .AndReturn<string>()
     .With(ctx =>
     {
         ctx.Array((a, b, c) => Option.When(a > b && b > c, "decreasing"));
         ctx.Array((a, b, c) => Option.When(c > b && b > a, "increasing")); // this
     });
```

### Upcoming features

* IEnumerable destructuring

### Known limitations

* Arbitrary patterns do not allow static type checking and require explicit type annotations
