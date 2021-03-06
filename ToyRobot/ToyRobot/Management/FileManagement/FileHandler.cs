﻿using System.IO;

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
                input += line + "|"; 
            }

            file.Close();

            return input;
        }   
    }
}
