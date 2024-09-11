using System.Text.RegularExpressions;

namespace TestTaskLibrary;

public static class DifficultTask
{
    /// <summary>
    /// Инкрементирует числа в строке и изменяет букву перед числом в зависимости от инкремента.
    /// </summary>
    /// <param name="textIn">Строка, содержащая числа и буквы перед ними для инкрементации.</param>
    /// <param name="increment">Значение, на которое необходимо увеличить каждое число.</param>
    /// <returns>
    /// Строку с инкрементированными числами и измененными буквами.
    /// Если инкремент приводит к увеличению разрядности числа, соответствующая буква инкрементируется.
    /// </returns>
    public static string Increment(string textIn, int increment)
    {
        if (increment < 0)
        {
            throw new ArgumentException("increment must be greater than or equal to zero");
        }

        if (increment == 0)
        {
            return textIn;
        }
        
        const string pattern = @"(\D)(\d+)";
        
        return Regex.Replace(textIn, pattern, match =>
        {
            char previousChar = match.Groups[1].Value[0];
            var number = int.Parse(match.Groups[2].Value);
            int newNumber = number + increment;
            var newNumberStr = newNumber.ToString();
           
            if (newNumberStr.Length > match.Groups[2].Value.Length)
            {
                int excessDigits = newNumber / (int)Math.Pow(10, match.Groups[2].Value.Length);
                char newChar = (char)(previousChar + excessDigits);
                newNumberStr = newChar + newNumberStr.Substring(1);
            }
            else
            {
                newNumberStr = previousChar + newNumberStr;
            }
            
            return newNumberStr;
        });
    }
}