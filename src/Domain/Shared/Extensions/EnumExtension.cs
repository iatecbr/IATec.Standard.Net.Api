using System.Linq.Expressions;

namespace Domain.Shared.Extensions;

public static class EnumExtension
{
    public static string ToPropertyIdName<T>(Expression<Func<T, object>> propertyExpression)
    {
        return propertyExpression.Body switch
        {
            MemberExpression member => member.Member.Name.Replace("Enum", "Id"),
            UnaryExpression { Operand: MemberExpression memberExpression } =>
                memberExpression.Member.Name.Replace("Enum", "Id"),
            _ => throw new ArgumentException("The expression does not refer to a property.")
        };
    }
}