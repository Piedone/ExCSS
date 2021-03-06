using System.Collections.Generic;
using System.Text;

namespace ExCSS.Model
{
    /// <summary>
    /// Defines a complet set of CSS rules
    /// </summary>
    public class RuleSet : IDeclarationContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleSet"/> class.
        /// </summary>
        public RuleSet()
        {
            Selectors = new List<Selector>();
            Declarations = new List<Declaration>();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var builder = new StringBuilder();
            BuildElementString(builder);

            return builder.ToString();
        }

        internal void BuildElementString(StringBuilder builder)
        {
            var first = true;

            foreach (var selector in Selectors)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    builder.Append(", ");
                }

                //builder.Append(selector.ToString());
                selector.BuildElementString(builder);
            }

            builder.Append(" {\r\n");

            foreach (var declaration in Declarations)
            {
                //builder.AppendFormat("\t{0};\r\n", declaration);
                builder.Append("\t");
                declaration.BuildElementString(builder);
                builder.Append(";");
                builder.AppendLine();
            }

            builder.Append("}");
           // return builder.ToString();
        }

        /// <summary>
        /// Gets the selectors.
        /// </summary>
        public List<Selector> Selectors { get; private set; }
        /// <summary>
        /// Gets the declarations.
        /// </summary>
        public List<Declaration> Declarations { get; private set; }
    }
}