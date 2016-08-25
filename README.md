# KScript
KScript provides a simple way to create and evaluate compiled expressions:

```
var exp = new Expression("NOW > '2016-1-1' OR ({IsEmployee} = TRUE AND {Department} IN ['Testers', 'Developers'])");

IDictionary<string, object> state = 
    new Dictionary {
        { "IsEmployee", true },
        { "Department", "Call Center" },
        { "StartDate", "2010-5-10" } // Not used
    }

bool result = exp.Evaluate(state}; // false
```

## Tokens
Tokens are defined by a string wrapped in curly braces: `{TokenName}`.  When the expression
is evaluated, token values are supplied based on the keys in the supplied `state` dictionary.
Keys are case-sensitive and tokens that are not supplied via `state` are considered to be `null`.

The values types in the dictionary must be
* `string`,
* `decimal`,
* `bool`, or
* `DateTime`

(Tokens whose values are collections are not supported.)

## NOW
The `NOW` keyword evaluates to the current UTC date/time when the expression is evaluated.

## Strings
Strings can be written with single or double quotes.  Strings containing single quotes must be
wrapped in double quotes and vice versa.

## Numbers
All integer and decimal numbers are supported, but all numbers are handled interally as `decimal` values.
Comparing numbers with strings (eg. `'5' == 5`) will always evaluate to `false`.

## Dates
Dates can be written as ISO 8601 formatted strings and are evaluated internally as `DateTime` objects.
Dates can be compared with `NOW` or with `DateTime` values from the `state`.

## NULL
The `NULL` keyword evaluates to `null`.  Any of the Equal or Not Equal syntax may be used to check for
equality with `NULL` (eg. `{SomeToken} IS NOT NULL` is the same as `{SomeToken} != NULL`).

## Equality
The following equality syntax is supported:

* Equal: '=', '==', 'IS'
* Not Equal: '!=', '<>', 'IS NOT'
* Greater/Less Than (or Equal To): '>', '<', '>=', '<='

(Any expression or boolean value can be negated with the `NOT` keyword.)

## IN Clause
```
{SomeToken} IN ["Some Value", "Another value", ...]
```

The first value as well as each of the values in the list can be
Strings, Dates (including the `NOW` keyword), Numbers, or Tokens.  `IN` can alternatively be
written as `IS IN`.

## BETWEEN Clause
```
{MyNumber} BETWEEN 5 AND 7.9
```

The lower bound is inclusive; the upper bound is exclusive.  The arguments can be either
Numbers, Dates (including the `NOW` keyword), or Tokens whose values are `decimal` or `DateTime`.

## Casing
All keywords are case-insensitive, but the comparison between strings (including Token values) is
case-sensitive.  Token names are also case-sensitive and may contain any character except `{` or `}`.