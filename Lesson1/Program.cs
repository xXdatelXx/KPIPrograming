using Lesson1;

Console.WriteLine("Exercise: 1");
DecimalNumber[] decimals =
[
   new("245.223"),
   new("891.48")
];

foreach (var d in decimals)
{
   Console.WriteLine($"Convert for {d.SourceValue}:");
   Console.WriteLine($"In Binary: {d.Convert(BinaryNumber.SourceNumberSystem)}");
   Console.WriteLine($"In Octal: {d.Convert(OctalNumber.SourceNumberSystem)}");
   Console.WriteLine($"In Hex: {d.Convert(HexNumber.SourceNumberSystem)} \n");
}

Console.WriteLine("Exercise: 2");
BinaryNumber[] binaries =
[
   new("110100011100101"),
   new("11100011110010")
];

foreach (var b in binaries)
{
   Console.WriteLine($"Convert for {b.SourceValue}:");
   Console.WriteLine($"In Decimal: {b.Convert(DecimalNumber.SourceNumberSystem)}");
   Console.WriteLine($"In Hex: {b.Convert(HexNumber.SourceNumberSystem)} \n");
}

Console.WriteLine("Exercise: 3");
HexNumber[] hexes =
[
   new("5F3"),
   new("FEDA")
];

foreach (var h in hexes)
{
   Console.WriteLine($"Convert for {h.SourceValue}:");
   Console.WriteLine($"In Decimal: {h.Convert(DecimalNumber.SourceNumberSystem)}");
   Console.WriteLine($"In Binary: {h.Convert(BinaryNumber.SourceNumberSystem)} \n");
}