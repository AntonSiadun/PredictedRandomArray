# Predicted random array

A light library, that helps to a developer generate arrays of generic types with defined chance of the appearance. 

## Using

To get new array with defined chances create new factory, where first param is a length of the array and then paste list of tuples, where first element - value of the object, second - a chance of appearance.

```csharp
  var arrayFactory = new ArrayFactory<int>(9, (1, 33), (2, 33), (3, 33));
  var anArray = arrayFactory.Generate();
```

Remember, that a sum of percents must be between 99 and 100.
