<Query Kind="Program" />

void Main()
{
	"Use reference type and struct as parameter".H1();
	"===== reference type =====".H2();
	var param = new List<string>();
	ChangeParamContent(param);
	param.Dump("change reference type content:");
	
	param = new List<string>();
	ChangeParamReferenceNotWork(param);
	param.Dump("change reference not work:");
	
	param = new List<string>();
	ChangeParamReference(ref param);
	param.Dump("change reference worked:");
	
	
	"===== value type =====".H2();
	Point parameter = new Point(1,1);
	ChangeParamContentValueTypeNotWork(parameter);
	parameter.Dump("change value type content not work:");
	
	parameter = new Point(1,1);
	ChangeParamContentValueTypeWork(ref parameter);
	parameter.Dump("change value type content worked:");
	
	parameter = new Point(1,1);
	ChangeParamRefNotWork(parameter);
	parameter.Dump("change value type ref not work:");	

	parameter = new Point(1,1);
	ChangeParamRefWorked(ref parameter);
	parameter.Dump("change value type ref worked:");	
}

public void ChangeParamContent(List<string> list)
{
	list.Add("content changed");
}

public void ChangeParamReferenceNotWork(List<string> list)
{
	list = new List<String>{"change reference"};
}

public void ChangeParamReference(ref List<string> list)
{
	list = new List<String>{"change reference"};
}

public void ChangeParamRefWorked(ref Point point)
{
	point = new Point(2,2);
}

public void ChangeParamRefNotWork(Point point)
{
	point = new Point(2,2);
}

public void ChangeParamContentValueTypeWork(ref Point point)
{
	point.X = 2;
	point.Y = 2;
}

public void ChangeParamContentValueTypeNotWork(Point point)
{
	point.X = 2;
	point.Y = 2;
}

public struct Point
{
	public int X{get;set;}
	public int Y{get;set;}
	public Point(int x, int y)
	{
		X = x;
		Y = y;
	}
}