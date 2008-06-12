using System.Text;

namespace DevDefined.Winforms.Framework
{
    public static class Text
    {
        public static string Join(string[] fragments, int startIndex, string joiner)
        {
            var builder = new StringBuilder();

            for (int i = startIndex; i < fragments.Length; i++)
            {
                string fragment = fragments[i];
                if (builder.Length > 0) builder.Append(joiner);
                builder.Append(fragment);
            }

            return builder.ToString();
        }
    }
}