using System.Text.RegularExpressions;

namespace HW;

class Program
{
    static async Task Main(string[] args)
    {
      
        using var client = new HttpClient();
        string result_inedx = await client.GetStringAsync("https://www.tabnak.ir/");
        File.WriteAllText("index.html", result_inedx);
        
        string pattern1 = @"(?:src)\s*=\s*[""'](?<url>https?://[^""']+)[""']";
        await photos(pattern1, "firstPagePhotos");

        async Task photos(string pattern, string foldername)
        {
            Directory.CreateDirectory(foldername);
            foreach (Match match in Regex.Matches(result_inedx, pattern, RegexOptions.IgnoreCase))
            {
                string url2 = match.Groups["url"].Value;
                string filename = Path.GetFileName(url2);
                string fullpath = Path.Combine(foldername, filename);
                try
                {
                    Console.WriteLine($"Downloading: {url2}");
                    byte[] bytes = await client.GetByteArrayAsync(url2);
                    await File.WriteAllBytesAsync(fullpath, bytes);
                    Console.WriteLine($"Saved to: {fullpath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to download {url2}: {ex.Message}");
                }
            }
        }
       
        string pattern2 = @"(?:href)\s*=\s*[""'](?<url>https?://[^""']+)[""']";
        int count = 0;

        
        foreach (Match match in Regex.Matches(result_inedx, pattern2, RegexOptions.IgnoreCase))
        {
            string url2 = match.Groups["url"].Value;
            try
                {
                    count++;
               
                    await photos(pattern2, "subPagesPhotos");


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to download {url2}: {ex.Message}");
                }
        }
    }
}
