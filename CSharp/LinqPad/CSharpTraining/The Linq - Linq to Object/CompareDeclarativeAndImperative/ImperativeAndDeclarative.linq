<Query Kind="Program" />

void Main()
{
	"Imperative vs Declarative".H1();
	//ImperativeDelegateTypes();
	DeclarativeDelegateTypes();
}

// Imperative
internal static void ImperativeDelegateTypes()
{
	Assembly coreLibrary = typeof(object).Assembly;
	Dictionary<string, List<Type>> delegateTypes = new Dictionary<string, List<Type>>();
	foreach (Type type in coreLibrary.GetExportedTypes())
	{
		if (type.BaseType == typeof(MulticastDelegate))
		{
			if (!delegateTypes.TryGetValue(type.Namespace, out List<Type> namespaceTypes))
			{
				namespaceTypes = delegateTypes[type.Namespace] = new List<Type>();
			}
			namespaceTypes.Add(type);
		}
	}
	List<KeyValuePair<string, List<Type>>> delegateTypesList =
		new List<KeyValuePair<string, List<Type>>>(delegateTypes);
	for (int index = 0; index < delegateTypesList.Count - 1; index++)
	{
		int currentIndex = index;
		KeyValuePair<string, List<Type>> after = delegateTypesList[index + 1];
		while (currentIndex >= 0)
		{
			KeyValuePair<string, List<Type>> before = delegateTypesList[currentIndex];
			int compare = before.Value.Count.CompareTo(after.Value.Count);
			if (compare == 0)
			{
				compare = string.Compare(after.Key, before.Key, StringComparison.Ordinal);
			}
			if (compare >= 0)
			{
				break;
			}
			delegateTypesList[currentIndex + 1] = delegateTypesList[currentIndex];
			currentIndex--;
		}
		delegateTypesList[currentIndex + 1] = after;
	}
	delegateTypesList.Dump();
}

// Declarative
internal static void DeclarativeDelegateTypes()
{
	var coreLibrary = typeof(object).Assembly;
	var delegateTypes = coreLibrary.GetExportedTypes()
		.Where(type => type.BaseType == typeof(MulticastDelegate))
		.GroupBy(type => type.Namespace)
		.OrderByDescending(namespaceTypes => namespaceTypes.Count())
		.ThenBy(namespaceTypes => namespaceTypes.Key);

	delegateTypes.Dump();
}