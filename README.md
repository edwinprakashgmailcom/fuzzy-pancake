### Trimmed down {{mustache}} templates in .NET

This demo uses Stubble which is an implementation of the [Mustache](https://mustache.github.io/) template system in C# (but is usable from any .NET language).

For a language-agnostic overview of mustache's template syntax, see the `mustache(5)` [manpage](https://mustache.github.io/mustache.5.html).

This implementation provides no methods of finding your templates, no complicated logic for getting values from your objects or special types, no non-spec tags for rendering or logic and only the necessaries to make it a simple and fast parser and renderer.  Just provide a template string and a json object string and you get out a rendered view of the template as a string.