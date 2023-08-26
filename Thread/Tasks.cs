

namespace teste;

class Tasks
{

	public static int _data;
	public static object _lock = new object();

	// The lock structere prevent the race condition.
	public static void Test()
	{
		var t1 = new Task(WithLock);
		var t2 = new Task(WithLock);

		t1.Start();
		t2.Start();

		Task.WaitAll(t1, t2);

		Console.WriteLine(_data);
	}

	//The result may be unexpected due to the race condition.
	public static void Test2()
	{
		var t1 = new Task(WithoutLock);
		var t2 = new Task(WithoutLock);

		t1.Start();
		t2.Start();

		Task.WaitAll(t1, t2);

		Console.WriteLine(_data);
	}


	static void WithoutLock()
	{
		for (int i = 0; i < 1000; i++)
		{
			_data++;
		}
	}


	static void WithLock()
	{
		lock (_lock)
		{
			for (int i = 0; i < 1000; i++)
			{

				_data++;
			}
		}
	}
}
