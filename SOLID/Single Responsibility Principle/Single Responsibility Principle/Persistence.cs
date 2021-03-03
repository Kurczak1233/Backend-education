using System.IO;

namespace Single_Responsibility_Principle
{
    public class Persistence
    {
        public void SaveToFile(Journal j,string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }
    }
}
