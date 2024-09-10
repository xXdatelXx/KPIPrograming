namespace Lesson1;

public interface INumberSystem
{
   string SourceValue { get; }
   string Convert(string targetNumberSystemChars);
}