using System.Text;
using System.Text.RegularExpressions;

namespace PseudoLocalizer.Core
{
    /// <summary>
    /// A transform which replaces all characters with underscores.
    /// </summary>
    public static class Underscores
    {
        private static readonly Regex PlaceholderExpr = new Regex(@"{\d+}");

        public static string Transform(string value)
        {
            var output = new StringBuilder(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '{')
                {
                    var match = PlaceholderExpr.Match(value, i);
                    if (match.Success)
                    {
                        output.Append(match.Value);
                        i += match.Length - 1;
                        continue;
                    }
                }

                output.Append("_");
            }

            return output.ToString();
        }
    }
}
