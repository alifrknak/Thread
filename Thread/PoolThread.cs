
namespace teste;

public class Data
{
	public int id;
	public Data(int _id)
	{
		id = _id;
	}
}
	// ThreadPool
class PoolThread
{
	public int QueueLength;
	public PoolThread()
	{
		QueueLength = 0;
	}
	public void Produce(Data ware)
	{
		ThreadPool.QueueUserWorkItem(new WaitCallback(Consume), ware);
		QueueLength++;
	}
	public void Consume(Object obj)
	{
		Console.WriteLine("Thread {0} consumes {1}",
		Thread.CurrentThread.GetHashCode(), 
		((Data)obj).id); 
		Thread.Sleep(100);
		QueueLength--;
	}

	public static void Test()
	{
		PoolThread poolThread = new PoolThread();

		for (int i = 0; i < 100; i++)
		{
			poolThread.Produce(new Data(i));
		}
		Console.WriteLine("Thread {0}",Thread.CurrentThread.GetHashCode());
		
		while (poolThread.QueueLength != 0)
		{
			Thread.Sleep(1000);
		}
		
		Console.ReadLine();
	}
}