<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\mscorlib.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\WindowsBase.dll</Reference>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
</Query>

void Main()
{
	"Avoid block UI thread".H1();	
	
	var panel = new StackPanel();
	var win = new Window
	{
		Width = 300,
		Height = 200,
		Title = "Block Test",	
		Content = panel,
	};
	
	var btn1 = new Button
	{
		Content = "Run Blocking Operation"
	};
	
	btn1.Click += BtnClicked1;
	
	var btn2 = new Button
	{
		Content = "Using Task Still Block"
	};
	
	btn2.Click += BtnClicked2;
	
	var btn3 = new Button
	{
		Content = "Use Continue With To Avoid Blocking"
	};
	
	btn3.Click += BtnClicked3;	
	
	var btn4 = new Button
	{
		Content = "Use async await To Avoid Blocking"
	};
	
	btn4.Click += BtnClicked4;
	
	var btn5 = new Button
	{
		Content = "Do Not Wait Result"
	};
	
	btn5.Click += BtnClicked5;
	
	panel.Children.Add(btn1);
	panel.Children.Add(btn2);
	panel.Children.Add(btn3);
	panel.Children.Add(btn4);
	panel.Children.Add(btn5);
	
	win.ShowDialog();
}

// Define other methods and classes here
public void BtnClicked1(object source, EventArgs arg)
{
	$"{Tid()}Before do hard work1".H3("blue");
	var ret = HardWork();
	$"{Tid()}After do hard work1, result={ret}".H3("blue");
}

public void BtnClicked2(object source, EventArgs arg)
{
	$"{Tid()}Before do hard work2".H3("blue");
	var retTask = Task.Run(new Func<int>(HardWork));
	var ret = retTask.Result;
	$"{Tid()}After do hard work2, result={ret}".H3("blue");
}

public void BtnClicked3(object source, EventArgs arg)
{
	$"{Tid()}Before do hard work3".H3("blue");
	var retTask = Task.Run(new Func<int>(HardWork));
	retTask.ContinueWith(x => {
		$"{Tid()}After do hard work3, result={x.Result}".H3("blue");
	});	
}

public async void BtnClicked4(object source, EventArgs arg)
{
	$"{Tid()}Before do hard work4".H3("blue");
	var ret = await Task.Run(new Func<int>(HardWork));
	$"{Tid()}After do hard work4, result={ret}".H3("blue");
}

public void BtnClicked5(object source, EventArgs arg)
{
	$"{Tid()}Before do hard work5".H3("blue");
	Task.Run(new Func<int>(HardWork));
	$"{Tid()}After do hard work5".H3("blue");
}
public int HardWork()
{
	Thread.Sleep(3000);
	$"{Tid()}Hard work finished".H4("red");
	return 42;
}

public string Tid()
{
	return $"TID:{Thread.CurrentThread.ManagedThreadId, -20}";
}