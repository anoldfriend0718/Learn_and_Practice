<Query Kind="Program" />

void Main()
{
	"Attribute".H1();
	var value = AttributeHelper.GetPropertyAttributeValue<MyClass,string,MyBeanAttribute,string>
	(b => b.Name, att => att.Value);
	
	value.Dump();
}

// Get attribute value via provided type, attribute type, property path, attribute path
public static class AttributeHelper
{
    public static TValue GetPropertyAttributeValue<T, TOut, TAttribute, TValue>(
        Expression<Func<T, TOut>> propertyExpression, 
        Func<TAttribute, TValue> valueSelector) 
        where TAttribute : Attribute
    {
        var expression = (MemberExpression) propertyExpression.Body;
        var propertyInfo = (PropertyInfo) expression.Member;
        var att = propertyInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
        return att != null ? valueSelector(att) : default(TValue);
    }
}
	
// Define class and use attribute	
public class MyClass 
{
	[MyBean(Value="test")]
    public String Name {get;set;}
}

// Define attribute
[AttributeUsage(AttributeTargets.Property,Inherited=false)]
public class MyBeanAttribute : Attribute
{
	public String Value{get;set;}
}