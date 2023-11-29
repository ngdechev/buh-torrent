using TorrentTracker;

TrackerServer trackerServer = new TrackerServer();
Console.CancelKeyPress += delegate (object? sender, ConsoleCancelEventArgs e) {
    e.Cancel = true;
    trackerServer.Stop();
    Environment.Exit(0);
};
trackerServer.Start(12345, 56789); 
