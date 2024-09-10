namespace Lesson1;

public sealed class DecimalNumber : INumberSystem
{
   private readonly INumberSystem _numberSystem;

   public DecimalNumber(string value, int precision = 10)
   {
      _numberSystem = new NumberSystem(value, SourceNumberSystem, precision);
      SourceValue = value;
   }

   public const string SourceNumberSystem = "0123456789";
   public string SourceValue { get; }

   public string Convert(string targetNumberSystemChars) =>
      _numberSystem.Convert(targetNumberSystemChars);
}