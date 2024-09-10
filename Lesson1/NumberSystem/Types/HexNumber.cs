namespace Lesson1;

public readonly struct HexNumber : INumberSystem
{
   private readonly INumberSystem _numberSystem;

   public HexNumber(string value, int precision = 10)
   {
      _numberSystem = new NumberSystem(value, SourceNumberSystem, precision);
      SourceValue = value;
   }

   public const string SourceNumberSystem = "0123456789ABCDEF";
   public string SourceValue { get; }

   public string Convert(string targetNumberSystemChars) =>
      _numberSystem.Convert(targetNumberSystemChars);
}