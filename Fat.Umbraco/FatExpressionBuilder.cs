using System;
using System.CodeDom;
using System.Configuration;
using System.Web.UI;
using System.Web.Compilation;

namespace Fat.Umbraco
{
    [ExpressionPrefix("fat")]
    public class FatExpressionBuilder : ExpressionBuilder
    {
        private readonly static object ConfigLock = new object();
        private static volatile FatConfigSection _config;

        public static object GetEvalData(string expression, Type target, string entry)
        {
            if (_config == null)
            {
                lock (ConfigLock)
                    if (_config == null)
                        _config = (FatConfigSection)ConfigurationManager.GetSection("fatConfig");
            }

            try
            {
                return _config.Get(expression);
            }
            catch (Exception)
            {
                return "fat expression builder cannot find expression";
            }
        }

        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
        {
            var expression = new CodeExpression[3];

            expression[0] = new CodePrimitiveExpression(entry.Expression.Trim());
            expression[1] = new CodeTypeOfExpression(typeof(string));
            expression[2] = new CodePrimitiveExpression(entry.Name);

            return new CodeCastExpression(typeof(string),
                                          new CodeMethodInvokeExpression(
                                              new CodeTypeReferenceExpression(GetType()), "GetEvalData",
                                              expression));
        }

        public override bool SupportsEvaluate { get { return true; } }
    }
}