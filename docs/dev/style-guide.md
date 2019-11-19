# Style Guide for devICT Public Meetings Back

## Overview

Most of the style rules can be easily enforced by loading [the editorconfig](../../src/.editorconfig). Those that cannot are labeled as such. More information about each setting can be found [on the editorconfig website](https://editorconfig.org) or [in the Microsoft Visual Studio documentation](https://docs.microsoft.com/en-us/visualstudio/ide/editorconfig-code-style-settings-reference).

## Table of Contents

- [Naming Conventions](#naming-conventions)
  + [Namespaces, Classes, Structs, & Enums](#namespaces-classes-structs--enums)
  + [Interfaces](#interfaces)
  + [Members](#members)
    * [Methods, Events, & Delegates](#methods-events--delegates)
    * [Properties & Fields](#properties--fields)
    * [Parameters](#parameters)
  + [Constants](#constants)
  + [Type Parameters](#type-parameters)
- [Formatting Conventions](#formatting-conventions)
  + [Using Directives](#using-directives)
  + [Curly Braces](#curly-braces)
  + [Object Initializers & Anonymous Types](#object-initializers--anonymous-types)
  + [Indentation](#indentation)
    * [Switch Statements](#switch-statements)
    * [Labels](#labels)
    * [Blocks](#blocks)
  + [Multi-line Functions](#multi-line-functions)
  + [Spacing](#spacing)
- [Language Conventions](#language-conventions)
  + [this Qualifiers](#this-qualifiers)
  + [Language Keywords](#language-keywords)
  + [Modifiers](#modifiers)
  + [Parentheses](#parentheses)
  + [One Liners](#one-liners)
  + [Explicit Types](#explicit-types)
  + [Expression Bodies](#expression-bodies)

## Naming Conventions

The base namespace for the solution is `DevIct.PublicMeetings.Back`. The Api project resides in the `DevIct.PublicMeetings.Back.Api` namespace, while the Data project resides in the `DevIct.PublicMeetings.Back.Data` namespace.

### Namespaces, Classes, Structs, & Enums

All namespaces, classes, structs, and enums should have names that are PascalCase.

### Interfaces

All interfaces should have names that are PascalCase and prefixed with 'I'.

### Members

The naming scheme for members (methods, events, delegates, properties, and fields) depends on the type of member and their accessibility level. For members that are local to a function, use camelCase.

#### Methods, Events, & Delegates

All methods, events, & delegates, except for local ones, should have names that are PascalCase.

#### Properties & Fields

The naming scheme for properties and fields depends on their level of accessibility. For properties and fields that *are visible to unrelated classes* (`public`, `internal`, or `protected internal`), use PascalCase. For those that *are only visible to related classes* (`private`, `protected`, or `private protected`), use camelCase with an underscore prefix.

**BAD**

```csharp
public class Thing
{
    public string _message;
    protected DateTime TimeStamp;
}
```

**GOOD**

```csharp
public class Thing
{
    public string Messgae;
    protected DateTime _timestamp;
}
```

#### Parameters

As parameters are essentially just fields that are local to a function, they should use camelCase.

### Constants

Constants should have names that are ALL\_CAPS\_WITH\_UNDERSCORE\_SEPARATING\_WORDS

### Type Parameters

Type parameters should have names that are PascalCase and prefixed with 'T'.

## Formatting Conventions

### Using Directives

Using directives should be at the top of the file, sorted in alphabetical order (except that System using directives should come first), with an empty line following the final using directive. *This is only partially enforced by the editorconfig*

### Curly Braces

Each Curly brace should get its own line unless the open and closing braces are on the same line in a single line expression.

### Newlines

Object initializers and anonymous types should have new lines for each expression.

### Indentation

An indent should be four (4) spaces.

#### Switch Statements

The case labels in a switch statement should be indented. The case contents should be indented *unless they are a block*.

#### Labels

Use of labels is discouraged as they can easily lead to code that is hard to follow. However, if they are used, they should be flush left, with no spaces before them.

#### Blocks

The braces that start and stop blocks should not be indented. The contents of the block should all be indented.

### Multi-line Functions

Functions whose definitions need to be wrapped because the name and parameter list would surpass the maximum line length, as well as calls to functions that need to be wrapped for the same reason, are multi-line functions. Each parameter or argument should have its own line, and the whole set of parameters or arguments should be indented one level. The opening parenthesis should be on the same line as the function name, and the closing parenthesis should be on the same line as the final parameter or argument. *This is not enforced by the editorconfig*.

### Spacing

In general, extra spaces between symbols should be avoided. The exceptions are:

* Include a space after control flow keywords
* Include a space before and after the colon (:) in inheritance clauses
* Include a space before and after binary operators
* Include a space after commas and semi-colons

## Language Conventions

*This section only includes the rules that could benefit from further explanation or cannot be enforced by the editorconfig. For the full list of language conventions, see the editorconfig*

### this Qualifiers

In general, this qualifiers are redundant and should not be used. However, if there is a case that seems ambiguous, they should be used for clarity.

### Modifiers

For consistency and explicitness, include all accessibility modifiers that apply even if they are the default modifiers. The preferred modifier order is defined in the editorconfig.

### Parentheses

Use parentheses for clarity when using multiple operators even when they are not required.

**BAD**

```csharp
x = y * 8 + z / 3;
```

**GOOD**

```csharp
x = (y * 8) + (z / 3);
```

### One Liners

Use one-liners for expressions where they make the code clear (ie. autoproperties, conditional expressions, compound assignment). **DO NOT** chain conditional expressions since they can easily become difficult to decipher. *This second rule is not enforced by the editorconfig. In fact, the editorconfig may suggest chaining these expressions. Please avoid it*.

### Explicit Types

Only use `var` when the type is apparent. Use explicit types for everything else.

### Expression Bodies

Always use block bodies or methods, constructors, and operators. For properties, indexers, accessors, lambdas, and local functions, use expression bodies if they fit on a single line, otherwise use block bodies.
