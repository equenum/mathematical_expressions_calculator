# mathematical_expressions_calculator
A simple mathematical expression calculator.It takes simple expressions and solves them with respect to the priority of operations.

This application has the following architecture:

- Presentation layer: Console Application (C#, .NET Core);
- Business layer: Class Library (C#, .NET Core);
- Data layer: Txt-file.


There are some additional project details (architecture, technologies/patterns used, etc.):
- Logging (Serilog, sinks: debug, text-file);
- Dependency injection (Autofac);
- Reverse polish notation conversion algorithm (using stack);
- Postfix notation expression evaluation algorithm (using stack);
- Repository pattern;
- Observer pattern;
- Txt-file input/output;
- Unit-tests (MSTest).


# Demo (expression input):

![Screenshot](ExpressionDemo.jpg)

# Demo (txt-file input):

![Screenshot](FileDemo1.jpg)
Txt-file path input

![Screenshot](FileDemo2.jpg)
Input file

![Screenshot](FileDemo3.jpg)
Output file
