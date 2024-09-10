namespace Lesson1;

public sealed class BinaryNumber : INumberSystem
{
   private readonly INumberSystem _numberSystem;

   public BinaryNumber(string value, int precision = 10)
   {
      _numberSystem = new NumberSystem(value, SourceNumberSystem, precision);
      SourceValue = value;
   }

   public const string SourceNumberSystem = "01";
   public string SourceValue { get; }

   public string Convert(string targetNumberSystemChars) =>
      _numberSystem.Convert(targetNumberSystemChars);
}