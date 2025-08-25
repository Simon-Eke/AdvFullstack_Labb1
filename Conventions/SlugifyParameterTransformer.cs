using System.Text.RegularExpressions;

namespace AdvFullstack_Labb1.Conventions
{
    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        private static readonly Regex _slugifyRegex = new Regex(
            @"([a-z0-9])([A-Z])",
            RegexOptions.CultureInvariant | RegexOptions.Compiled);
        public string? TransformOutbound(object? value)
        {
            if (value == null) { return null; }

            var input = value.ToString();
            if (string.IsNullOrWhiteSpace(input)) { return null; }

            var result = _slugifyRegex.Replace(input, "$1-$2");

            return result.ToLowerInvariant();
        }
    }
}
