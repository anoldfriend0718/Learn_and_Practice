<Query Kind="Program" />

void Main()
{
	"Select parameter and return value of method".H1();
	@"first ensure the behavior and extensibility of your method 
	then consider the type of the parameter and return value.".Info();
	
	@"also consider what level data you need to pass or 
	what level operation you need to perform.".Info();
}

// good : we can pass List<T> or IEnumerabel<T> or string
public void ManipulateItems1<T>(IEnumerable<T> items){}

// not good : we can only pass List<T>
public void ManipulateItems2<T>(List<T> items){}

// good we can use Stream or FileStream to get return value
public FileStream OpenFile1(){return null;}

// not good we can only use Stream to get return value
public Stream OpenFile2(){return null;}