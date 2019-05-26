<Query Kind="Program" />

void Main()
{
	var mc=new MyClass();
	"Before Update Data".H2("blue");
	mc.MyData.Dump();
	"After Update Data".H2("blue");
	mc.UpdateData();
	mc.MyData.Dump();	
}

public class MyClass
{	
   private List<double> data;
   public MyClass()
   {
   		data=new List<double>();
   }
   public List<double> MyData
   {
   		get
		{
			return data;
		}
   }
   
   public void UpdateData()
   {
   		var temp=new List<double>(){1,2};
		data=temp;
   }

}

// Define other methods and classes here
