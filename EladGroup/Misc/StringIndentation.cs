using System;
using System.Text;

namespace EladGroup.Misc
{
    public static class StringIndentation
    {
        public static void NewLine(StringBuilder stringBuilder,
            int indentationLevel)
        {
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Create(indentationLevel));
        }

        public static string Create(int indentationLevel)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i <= indentationLevel; i++)
            {
                builder.Append("    ");
            }

            return builder.ToString();
        }
    }
}
