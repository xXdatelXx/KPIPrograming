namespace Lesson1;

public sealed class OctalNumber : INumberSystem
{
   private readonly INumberSystem _numberSystem;

   public OctalNumber(string value, int precision = 10)
   {
      _numberSystem = new NumberSystem(value, SourceNumberSystem, precision);
      SourceValue = value;
   }

   public const string SourceNumberSystem = "01234567";
   public string SourceValue { get; }

   public string Convert(string targetNumberSystemChars) =>
      _numberSystem.Convert(targetNumberSystemChars);
}