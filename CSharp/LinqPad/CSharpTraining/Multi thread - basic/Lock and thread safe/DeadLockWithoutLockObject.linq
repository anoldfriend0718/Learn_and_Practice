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
	"Dead lock without lock object".H1();
	
	"you shouldn’t mix synchronous and asynchronous code without carefully considering the consequences.".Info();

	var panel = new StackPanel();
	var win = new Window
	{
		Width = 300,
		Height = 200,
		Title = "DeadLock Test",
		Content = panel,
	};

	var btn1 = new Button
	{
		Content = "Dead lock!!!"
	};

	btn1.Click += BtnClicked1;

	var btn2 = new Button
	{
		Content = "No dead lock...use await"
	};

	btn2.Click += BtnClicked2;

	var btn3 = new Button
	{
		Content = "No dead lock...use ConfigureAwait"
	};

	btn3.Click += BtnClicked3;

	panel.Children.Add(btn1);
	panel.Children.Add(btn2);
	panel.Children.Add(btn3);

	win.ShowDialog();
}

public void BtnClicked1(object source, EventArgs arg)
{
	$"{Tid()}Before do hard work1".H3("blue");
	var ret = HardWorkAsync().Result;
	$"{Tid()}After do hard work1, result={ret}".H3("blue");
}

public async void BtnClicked2(object source, EventArgs arg)
{
	$"{Tid()}Before do hard work2".H3("blue");
	var ret = await HardWorkAsync();
	$"{Tid()}After do hard work2, result={ret}".H3("blue");
}

public void BtnClicked3(object source, EventArgs arg)
{
	$"{Tid()}Before do hard work3".H3("blue");
	var ret = HardWork2Async().Result;
	$"{Tid()}After do hard work3, result={ret}".H3("blue");
}


public async Task<int> HardWorkAsync()
{
	$"{Tid()}Hard work started.".H4("red");
	await Task.Delay(1000);
	return 42;
}

public async Task<int> HardWork2Async()
{
	$"{Tid()}Hard work started.".H4("red");
	await Task.Delay(1000).ConfigureAwait(false);
	return 42;
}

public string Tid()
{
	return $"TID:{Thread.CurrentThread.ManagedThreadId,-20}";
}