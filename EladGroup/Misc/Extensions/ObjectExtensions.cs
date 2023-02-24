using System.Reflection;
using System.Text;

namespace EladGroup.Misc.Extensions
{
    public static class ObjectExtensions
    {
        private static int _indentationLevel;

        public static string ToStringExtension(this object obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int i = 0;
            StringIndentation.NewLine(stringBuilder, _indentationLevel);
            stringBuilder.Append("{");
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                if (property.GetType().GetProperties().Length > 0)
                {
                    _indentationLevel++;
                    StringIndentation.NewLine(stringBuilder,
                        _indentationLevel);
                }

                stringBuilder.Append(property.Name);
                stringBuilder.Append(": ");
                if (property.GetIndexParameters().Length > 0)
                {
                    stringBuilder.Append("Indexed Property cannot be used");
                }
                else
                {
                    stringBuilder.Append(property.GetValue(obj, null));
                }

                i++;

                // if (i < i_Obj.GetType().GetProperties().Length)
                // {
                //     stringBuilder.Append(", ");
                // }

                _indentationLevel--;
            }

            StringIndentation.NewLine(stringBuilder, _indentationLevel);
            stringBuilder.Append("}");

            return stringBuilder.ToString();
        }
    }
}
