namespace PeerSoftware.Download
{
    public class ThreadManager
    {
        private List<Thread> threads = new List<Thread>();

        public void CreateThread(Action threadAction)
        {
            Thread newThread = new Thread(() =>
            {
                threadAction();
            });

            threads.Add(newThread);
        }

        public void StartAllThreads()
        {
            foreach (var thread in threads)
            {
                thread.Start();
            }
        }

        public void StartThread(int index)
        {
            if (index >= 0 && index < threads.Count)
            {
                threads[index].Start();
            }
            else
            {
                Console.WriteLine("Invalid thread index.");
            }
        }

        public void StopThread(int index)
        {
            if (index >= 0 && index < threads.Count && threads[index].IsAlive)
            {
                threads[index].Abort();
            }
        }

        public void StopAllThreads()
        {
            foreach (var thread in threads)
            {
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }

            threads.Clear();
        }
    }
}
