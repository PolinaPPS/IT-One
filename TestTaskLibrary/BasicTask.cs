using System.Text.RegularExpressions;

namespace TestTaskLibrary;

public static class BasicTask
{
    /// <summary>
    /// Инкрементирует числа в переданной строке на заданное значение.
    /// </summary>
    /// <param name="textIn">Строка, содержащая числа для инкрементации.</param>
    /// <param name="increment">Значение, на которое необходимо увеличить каждое число.</param>
    /// <returns>
    /// Строку с инкрементированными числами.
    /// Если результат инкрементации превышает количество разрядов оригинального числа, 
    /// результат обрезается до этого количества разрядов.
    /// </returns>
    public static string IncrementNumber(string textIn, int increment)
    {
        if (increment < 0)
        {
            throw new ArgumentException("increment must be greater than or equal to zero");
        }

        if (increment == 0)
        {
            return textIn;
        }
        
        const string pattern = @"\d+";

        return Regex.Replace(textIn, pattern, match =>
        {
            var number = int.Parse(match.Value);
            number = (number + increment);
            var newNumber = number.ToString();
            if (newNumber.Length > match.Value.Length)
            {
                int excessDigits = newNumber.Length - match.Value.Length;
                newNumber = newNumber.Substring(excessDigits);
            }
            return newNumber.PadLeft(match.Groups[2].Value.Length, '0');
        });
    }
}