using System.Text.Json;

namespace PeerSoftware
{

    public class Info
    {
        public string Checksum { get; set; }
        public string FileName { get; set; }
        public string TorrentName { get; set; }
        public int Length { get; set; }
        public string Description { get; set; }
    }

    public class TorrentFile
    {
        public string Announce { get; set; }
        public Info Info { get; set; }
        
    }


    static class TorrentReader
    {
        public static TorrentFile ReadFromJSON(string filename)
        {
            string jsonText = File.ReadAllText(filename);

            TorrentFile ?torrent = JsonSerializer.Deserialize<TorrentFile>(jsonText);

            return torrent;
        }
       /* public TorrentFile ReadFromJSON(string filename)
        {
            string json = File.ReadAllText(@"..\..\..\Storage\storage.json");



            if (string.IsNullOrEmpty(json))
            {
                Console.WriteLine("JSON file is empty.");
                return null;
            }



            TorrentFile torrent = JsonSerializer.Deserialize<TorrentFile>(json);
            return 
        }*/



       /* public void WriteJSON(ref List<Product> products)
        {
            string json = File.ReadAllText(@"..\..\..\Storage\storage.json");
            List<Product> existingProducts = new List<Product>();



            existingProducts.AddRange(products);



            json = JsonSerializer.Serialize(existingProducts);
            File.WriteAllText(@"..\..\..\Storage\storage.json", json);
        }*/
    }
}


