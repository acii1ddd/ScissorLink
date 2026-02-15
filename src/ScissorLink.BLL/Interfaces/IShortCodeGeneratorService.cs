namespace ScissorLink.BLL.Interfaces;

public interface IShortCodeGeneratorService
{
    public string Generate(int length = 6);
}