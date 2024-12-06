using System.Text;

namespace ToDo.Shared.Extension
{
    public static class StringExtension
    {
        public static string ConvertPascalToSnake(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            var result = new StringBuilder();
            result.Append(char.ToLower(input[0]));

            for (int i = 1; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsUpper(c))
                {
                    result.Append('_');
                    result.Append(char.ToLower(c));
                }
                else
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}
