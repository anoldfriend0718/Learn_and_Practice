<Query Kind="Program" />

void Main()
{
	"OrderBy".H1();

	var data = new List<Record>
	{
		new Record{Name = "A", Area = 10, UpdDate = new DateTime(2018, 1, 1)},
		new Record{Name = "A", Area = 10, UpdDate = new DateTime(2018, 1, 2)},
		new Record{Name = "A", Area = 10, UpdDate = new DateTime(2018, 1, 3)},
		new Record{Name = "A", Area = 9, UpdDate = new DateTime(2018, 1, 4)},
		new Record{Name = "B", Area = 6, UpdDate = new DateTime(2018, 1, 5)},
	};

	data.OrderBy(record => record.Name)
		.ThenBy(record => record.Area)
		.ThenByDescending(record => record.UpdDate)
		.Dump("Ordered by function");

	(from record in data
	 orderby record.Name, record.Area, record.UpdDate descending
	 select record)
	.Dump("Ordered by expression");
}

public class Record
{
	public string Name { get; set; }

	public int Area { get; set; }

	public DateTime UpdDate { get; set; }
}
