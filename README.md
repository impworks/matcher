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

### Upcoming features

* Tuple destructuring
* Regex matching
* Array with "rest"
* IEnumerable destructuring
* When guards

### Known limitations

* No nested structures :(
