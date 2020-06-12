<Query Kind="Program" />

void Main()
{
	"Alias of primitive type".H1();
	var primitiveTypeDic = new Dictionary<Type,string>
	{
		{typeof(sbyte), "sbyte"},
		{typeof(byte), "byte"},
		{typeof(short), "short"},
		{typeof(ushort), "ushort"},
		{typeof(int), "int"},
		{typeof(uint), "uint"},
		{typeof(long), "long"},
		{typeof(ulong), "ulong"},
		{typeof(char), "char"},
		{typeof(float), "float"},
		{typeof(double), "double"},
		{typeof(bool), "bool"},
		{typeof(decimal), "decimal"},
		{typeof(string), "string"},
		{typeof(object), "object"},
		{typeof(void), "void"}
	};

	var primitiveTypes = new List<Type>
	{
		typeof(sbyte),
		typeof(byte),
		typeof(short),
		typeof(ushort),
		typeof(int),
		typeof(uint),
		typeof(long),
		typeof(ulong),
		typeof(char),
		typeof(float),
		typeof(double),
		typeof(bool),
		typeof(decimal),
		typeof(string),
		typeof(object),
		typeof(void),
	};
	
	var fclTypes = new List<Type>
	{
		typeof(SByte),
		typeof(Byte),
		typeof(Int16),
		typeof(UInt16),
		typeof(Int32),
		typeof(UInt32),
		typeof(Int64),
		typeof(UInt64),
		typeof(Char),
		typeof(Single),
		typeof(Double),
		typeof(Boolean),
		typeof(Decimal),
		typeof(String),
		typeof(Object),
		typeof(void),
	};
	
	primitiveTypes.Zip(fclTypes, (x,y)=> new 
	{
		PrimitiveName = primitiveTypeDic[x],
		FCLName = y.Name,
		Equality = x == y ? "Y" : "N"
	}).Dump();
}

// Define other methods and classes here