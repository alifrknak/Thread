



// System.Threading.Timer 
public class Timers
{
	public static void Test()
	{

		var product = new Product
		{
			Id = 1,
			Name="Keyboard"
		};

		System.Threading.Timer timer = new Timer(TimerLog, product, 0, 1000);

		Console.ReadLine();

        timer.Change(0, 100);
        Console.WriteLine("Period has been changed .");

		Console.ReadLine();

	}
	public static void TimerLog(object product)
	{
		string msg = "A product has been added by the user.";

		Console.WriteLine($"{DateTime.Now} - {msg} - product name : {((Product)product).Name}");
        Console.WriteLine($"Thread id : {Thread.CurrentThread.ManagedThreadId}");
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}