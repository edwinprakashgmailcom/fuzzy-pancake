using Core;
using Xunit;

namespace UnitTests;

public class MustacheRendererTests
{
    [Fact(DisplayName = "No Interpolation")]
    public void ShouldRenderAsIs()
    {
        // arrange
        var template = "Mustache-free templates should render as-is.";
        var json = "{ }";

        var sut = CreateSut();

        // act
        var output = sut.Render(template, json);

        // assert
        Assert.NotNull(output);
        Assert.Equal("Mustache-free templates should render as-is.", output);
    }

    [Fact(DisplayName = "Basic Interpolation")]
    public void ShouldRenderWithBasicInterpolation()
    {
        // arrange
        var template = "Hello, {{subject}}!";
        var json = "{ \"subject\": \"world\" }";

        var sut = CreateSut();

        // act
        var output = sut.Render(template, json);

        // assert
        Assert.NotNull(output);
        Assert.Equal("Hello, world!", output);
    }

    [Fact(DisplayName = "HTML Escaping")]
    public void ShouldEscapeHTMLCharacters()
    {
        // arrange
        var template = "These characters should be HTML escaped: {{forbidden}}";
        var json = "{ \"forbidden\": \"& \\\" < >\" }";

        var sut = CreateSut();

        // act
        var output = sut.Render(template, json);

        // assert
        Assert.NotNull(output);
        Assert.Equal("These characters should be HTML escaped: &amp; &quot; &lt; &gt;", output);
    }

    [Fact(DisplayName = "Triple Mustache")]
    public void ShouldNotEscapeHTMLCharacters()
    {
        // arrange
        var template = "These characters should NOT be HTML escaped: {{{forbidden}}}";
        var json = "{ \"forbidden\": \"& \\\" < >\" }";

        var sut = CreateSut();

        // act
        var output = sut.Render(template, json);

        // assert
        Assert.NotNull(output);
        Assert.Equal("These characters should NOT be HTML escaped: & \" < >", output);
    }

    [Fact(DisplayName = "Basic Integer Interpolation")]
    public void ShouldRenderIntegers()
    {
        // arrange
        var template = "\"{{kmph}} kilometers per hour!\"";
        var json = "{ \"kmph\": 100 }";

        var sut = CreateSut();

        // act
        var output = sut.Render(template, json);

        // assert
        Assert.NotNull(output);
        Assert.Equal("\"100 kilometers per hour!\"", output);
    }

    [Fact(DisplayName = "Basic Context Missing Interpolation")]
    public void ShouldDefaultToEmptyStrings()
    {
        // arrange
        var template = "I ({{cannot}}) be seen!";
        var json = "{ }";

        var sut = CreateSut();

        // act
        var output = sut.Render(template, json);

        // assert
        Assert.NotNull(output);
        Assert.Equal("I () be seen!", output);
    }

    [Fact(DisplayName = "Complex Json - Basic Interpolation")]
    public void ShouldRenderComplexModels()
    {
        // arrange
        var template = "Hi {{person.name}}!";
        var json = "{ \"person\": { \"name\": \"Joe\" } }";

        var sut = CreateSut();

        // act
        var output = sut.Render(template, json);

        // assert
        Assert.NotNull(output);
        Assert.Equal("Hi Joe!", output);
    }

    [Fact(DisplayName = "Arrays - Basic Interpolation")]
    public void ShouldRenderArrays()
    {
        // arrange
        var template = "{{#list}}{{item}}{{/list}}";
        var json = "{ \"list\": [ { \"item\": 1 }, { \"item\": 2 }, { \"item\": 3 } ] }";

        var sut = CreateSut();

        // act
        var output = sut.Render(template, json);

        // assert
        Assert.NotNull(output);
        Assert.Equal("123", output);
    }

    private RenderView CreateSut()
    {
        return new RenderView(new MustacheRenderer.Renderer());
    }
}
