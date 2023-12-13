using Microsoft.Toolkit.Uwp.Notifications;
using PeerSoftware.Utils;
using Windows.ApplicationModel.VoiceCommands;

namespace PeerSoftware.Download
{
    public class ThreadManager
    {
        private List<Thread> threads = new List<Thread>();
        private List<DownloadTcpManager> downloadTcpManagers = new List<DownloadTcpManager>();

        public void CreateThread(Action threadAction)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");
            
            Thread newThread = new Thread(() =>
            {
                threadAction();
            });

            threads.Add(newThread);
        }

        public void StartAllThreads()
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            foreach (var thread in threads)
            {
                thread.Start();
            }
        }

        public void StartThread(int index, int maxParallelDownloads)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            if (index >= 0 && index < threads.Count)
            {
                if (index >= maxParallelDownloads)
                {
                    CustomMessageBoxOK msgBox = new CustomMessageBoxOK();

                    msgBox.SetTitle("Attention");
                    msgBox.SetMessageText($"You can download only {maxParallelDownloads} file at the same time. You can change it from settings.");
                    msgBox.Show();

                    return;
                }
                threads[index].Start();
            }
            else
            {
                Logger.e("Invalid thread index.");
            }
        }

        public void StopThread(int index)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            if (index >= 0 && index <= threads.Count)
            {
                Thread tr = threads[index];
                threads.RemoveAt(index);
                tr.Abort();
            }
        }

        public void StopAllThreads()
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

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
            downloadTcpManagers.RemoveAt(index-1);
        }
        
        public DownloadTcpManager GerDownloadTCPManeger(int index)
        {
            return downloadTcpManagers.ElementAt(index);
        }
    }
}
