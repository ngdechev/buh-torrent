using Microsoft.Toolkit.Uwp.Notifications;
using PeerSoftware.Utils;
using Windows.ApplicationModel.VoiceCommands;

namespace PeerSoftware.Download
{
    public class ThreadManager
    {
        

        public Thread CreateThread(Action threadAction)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");
            
            Thread newThread = new Thread(() =>
            {
                threadAction();
            });
            return newThread;
        }

        public void StartAllThreads(List<Thread> threads)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            foreach (var thread in threads)
            {
                thread.Start();
            }
        }

        public void StartThread(int index, int maxParallelDownloads, List<Thread> threads)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            if (index >= 0 && index < threads.Count)
            {
                if (index > maxParallelDownloads)
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

        public void StopThread(int index, ref List<Thread> threads)
        {
            Logger.d($"Class -> {GetType().Name}.cs | Method -> {System.Reflection.MethodBase.GetCurrentMethod().Name}()");

            if (index >= 0 && index <= threads.Count)
            {
                threads.ElementAt(index).Join();
            }
        }

        public void StopAllThreads(List<Thread> threads)
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

        
    }
}
