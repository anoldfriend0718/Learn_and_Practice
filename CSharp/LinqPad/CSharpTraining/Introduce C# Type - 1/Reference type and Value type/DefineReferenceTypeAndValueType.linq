<Query Kind="Program" />

void Main()
{
	"Differnce of reference type and value type".H1();
	
	"===== reference type test =====".H2();
	TestRef();
	
	"===== value type test =====".H2();
	TestValue();
	
	"===== unintentional fail =====".H2();
	UnintentionalFailTest();
	
	"===== watch gc performance =====".H2();
	GcWorkTest();
}

public void GcWorkTest()
{
	GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
	
	var gcCountsBefore = Enumerable.Range(0, 3).Select(i => GC.CollectionCount(i)).ToList();
	
	// hard work
	
	for(int i = 0; i < 100000000; i++)
	{
		var point = new PointRef(1,1);	
	}
	
	var gcCountsAfter = Enumerable.Range(0, 3).Select(i => GC.CollectionCount(i)).ToList();
	
	var result = gcCountsBefore.Zip(gcCountsAfter, (x,y) => y - x);
	result.Select( (x,i) => new {Gen=i, Count=x}).Dump();
}


public void UnintentionalFailTest()
{
	var pointList = Enumerable.Range(1,3).Select(x => new PointValue(x,x)).ToList();
	pointList.Dump("original list");
	
	// offset the list
	for(int i = 0, n = pointList.Count; i < n; i++)
	{
		var point = pointList[i];
		point.X = point.X + 1;
		point.Y = point.Y + 1;
	}
	
	pointList.Dump("after offset update list:");
}

public void TestRef()
{
	var point1 = new PointRef(1,1);
	var point2 = point1;
	point2.Dump("Point2");
	point1.X = 2;
	point1.Dump("Point1");
	point2.Dump("Point2");
}

public void TestValue()
{
	var point1 = new PointValue(1,1);
	var point2 = point1;
	point2.Dump("Point2");
	point1.X = 2;
	point1.Dump("Point1");
	point2.Dump("Point2");
}

// types
public class PointRef
{
	public int X {get;set;}
	
	public int Y {get;set;}		
	
	public PointRef(int x, int y)
	{
		X = x;
		Y = y;
	}
}

public struct PointValue
{
	public int X {get;set;}
	
	public int Y {get;set;}		
	
	public PointValue(int x, int y)
	{
		X = x;
		Y = y;
	}
}