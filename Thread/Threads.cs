

namespace teste;

class Threads
{

	private static readonly object _lock = new object();
	private static int _counter = 0;

	public static void Test()
	{
		var thread1 = new Thread(IncreaseCounter);
		var thread2 = new Thread(DecreaseCounter);

		thread1.Start();
		thread2.Start();

		thread2.Join();
		thread1.Join();

		Console.WriteLine("Counter = {0}", _counter);
	}


	// The lock structure prevents the race condition.
	public static void IncreaseCounter()
	{
		lock (_lock)
		{
			for (int i = 0; i < 1000; i++)
			{
				_counter++;
			}
		}
	}

	public static void DecreaseCounter()
	{

		lock (_lock)
		{
			for (int i = 0; i < 1000; i++)
			{
				_counter--;
			}
		}
	}
}

