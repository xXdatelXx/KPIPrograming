namespace Lesson1;

public sealed class NumberSystem : INumberSystem
{
   private float _decimalValueRepresent;
   private readonly string _sourceValue;
   private readonly string _sourceNumberSystem;
   private readonly int _precision;

   public NumberSystem(string sourceValue, string sourceNumberSystem, int precision = 10)
   {
      _sourceValue = sourceValue;
      _sourceNumberSystem = sourceNumberSystem;
      _precision = precision;
      RepresentToDecimal();
   }

   public string SourceValue => _sourceValue;

   //Convert decimal to other systems
   public string Convert(string targetNumberSystem)
   {
      if (string.IsNullOrEmpty(targetNumberSystem))
         throw new ArgumentNullException($"{nameof(targetNumberSystem)} is empty");
      if (targetNumberSystem == _sourceNumberSystem)
         throw new InvalidCastException("Source number system is already in the target number system");

      string result = "";
      int wholePart = (int)_decimalValueRepresent;
      decimal fracPart = (decimal)_decimalValueRepresent % 1;
      int systemOrder = targetNumberSystem.Length;

      //Convert whole part
      while (wholePart > 0)
      {
         int remainder = wholePart % systemOrder;
         result += targetNumberSystem[remainder];
         wholePart /= systemOrder;
      }

      result = new string(result.Reverse().ToArray());

      if (fracPart == 0)
         return result;

      //Convert fractional part
      result += ".";

      for (int i = 0; i < _precision && fracPart > 0; i++)
      {
         fracPart *= systemOrder;
         int wholeRemainder = (int)fracPart;
         result += targetNumberSystem[wholeRemainder];
         fracPart -= wholeRemainder;
      }

      return result;
   }

   //Convert other systems to Decimal
   private void RepresentToDecimal()
   {
      if (string.IsNullOrEmpty(_sourceValue))
         throw new NullReferenceException($"{nameof(_sourceValue)} is empty");
      if (_sourceValue.Contains(','))
         throw new FormatException($"{nameof(_sourceValue)} must be separate only by `.`, `,` - is exception");
      //If system already is Decimal
      if (_sourceNumberSystem == "0123456789")
      {
         _decimalValueRepresent = float.Parse(_sourceValue);
         return;
      }

      var valueParts = _sourceValue.Split('.');

      if (valueParts.Length > 2)
         throw new FormatException($"{nameof(_sourceValue)} must contains only one separator");

      //Represent whole part
      string wholePart = valueParts[0];
      foreach (var i in wholePart)
      {
         int digitValue = _sourceNumberSystem.IndexOf(i);
         _decimalValueRepresent = _decimalValueRepresent * _sourceNumberSystem.Length + digitValue;
      }

      //Represent fractional part
      string fractionalPart = valueParts.Length > 1 ? valueParts[1] : string.Empty;
      float fractionMultiplier = 1.0f / _sourceNumberSystem.Length;
      foreach (var i in fractionalPart)
      {
         int digitValue = _sourceNumberSystem.IndexOf(i);
         _decimalValueRepresent += digitValue * fractionMultiplier;
         fractionMultiplier /= _sourceNumberSystem.Length;
      }
   }
}
