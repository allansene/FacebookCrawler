using System.IO;

namespace Facebook.Crawler
{
    public class GlobalIO
    {
        public void WriteJson(string json, string path)
        {

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(json);
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(json);
            }
        }
    }
}
