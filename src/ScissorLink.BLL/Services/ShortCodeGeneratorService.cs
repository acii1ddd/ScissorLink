using System.Security.Cryptography;
using System.Text;
using ScissorLink.BLL.Interfaces;

namespace ScissorLink.BLL.Services;

public class ShortCodeGeneratorService : IShortCodeGeneratorService
{
    private static long _counter;
    
    private static readonly string Salt = Guid.NewGuid().ToString("N");
    public string Generate(int length = 7)
    {
        var value = Interlocked.Increment(ref _counter);

        var input = $"{Salt}:{value}";
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        
        return ConvertToBase64(hash, length);
    }

    private static string ConvertToBase64(byte[] hash, int length)
    {
        return Convert.ToBase64String(hash)
            .Replace('+', '-')
            .Replace('/', '_')
            .TrimEnd('=')[..length];
    }
}