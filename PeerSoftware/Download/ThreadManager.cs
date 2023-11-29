using Windows.ApplicationModel.VoiceCommands;

namespace PeerSoftware.Download
{
    public class ThreadManager
    {
        private List<Thread> threads = new List<Thread>();
        private List<DownloadTcpManager> downloadTcpManagers = new List<DownloadTcpManager>();

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
                threads.RemoveAt(index);
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

        public void AddDownloadTCPManeger(DownloadTcpManager downloadTcpManager)
        {
            downloadTcpManagers.Add(downloadTcpManager);
        }

        public void RemoveDownloadTCPManeger(int index)
        {
            downloadTcpManagers.RemoveAt(index);
        }
        
        public DownloadTcpManager GerDownloadTCPManeger(int index)
        {
            return downloadTcpManagers.ElementAt(index);
        }
    }
}
