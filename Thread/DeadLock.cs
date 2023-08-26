


public class DeadLock
{


	static object lock1 = new object();
	static object lock2 = new object();

	static void AcquireLocks1()
	{
		var threadId = Thread.CurrentThread.ManagedThreadId;

		lock (lock1)
		{
			Console.WriteLine($"Thread {threadId} acquired lock 1.");
			Thread.Sleep(1000);
			Console.WriteLine($"Thread {threadId} attempted to acquire lock 2.");
			lock (lock2)
			{
				Console.WriteLine($"Thread {threadId} acquired lock 2.");
			}
		}
	}

	static void AcquireLocks2()
	{
		var threadId = Thread.CurrentThread.ManagedThreadId;

		lock (lock2)
		{
			Console.WriteLine($"Thread {threadId} acquired lock 2.");
			Thread.Sleep(1000);
			Console.WriteLine($"Thread {threadId} attempted to acquire lock 1.");
			lock (lock1)
			{
				Console.WriteLine($"Thread {threadId} acquired lock 1.");
			}
		}
	}

	public static void Test()
	{
		// Create two new threads that compete for the locks
		var thread1 = new Thread(AcquireLocks1);
		var thread2 = new Thread(AcquireLocks2);

		// Start the threads
		thread1.Start();
		thread2.Start();

		// Wait for the threads to complete
		thread1.Join();
		thread2.Join();

		Console.WriteLine("Finished.");

	}
}