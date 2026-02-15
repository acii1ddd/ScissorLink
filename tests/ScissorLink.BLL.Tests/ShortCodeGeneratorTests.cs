using ScissorLink.BLL.Services;

namespace ScissorLink.BLL.Tests;

public class ShortCodeGeneratorTests
{
    [Fact]
    public void Generator_ShouldGenerateUniqueCodes()
    {
        var generator = new ShortCodeGeneratorService();
        var codes = new HashSet<string>();
    
        for (var i = 0; i < 2200000; i++) // 2.2 млн url
        {
            var code = generator.Generate();
            Assert.True(codes.Add(code), $"Duplicate code: {code}");
        }
    }

    [Fact]
    public void Generator_ShouldBeUnpredictable()
    {
        var generator1 = new ShortCodeGeneratorService();
        var generator2 = new ShortCodeGeneratorService();
    
        var code1 = generator1.Generate();
        var code2 = generator2.Generate();
    
        Assert.NotEqual(code1, code2);
    }
}