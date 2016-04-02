using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Management.FileManagement
{
    public class FileHandler : IFileHandler
    {
        public string ReadFile(string fileLocation)
        {
            string line = string.Empty;
            string input = string.Empty;

            if (!File.Exists(fileLocation))
                throw new FileNotFoundException();

            var file = new StreamReader(fileLocation);
            while((line = file.ReadLine()) != null)
            {
                input = line + ","; 
            }

            file.Close();

            return input;
        }   
    }
}
