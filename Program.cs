using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherStreamOperations
{
    class Program
    {
        const string fileName = @"C:\FileTwo.txt";
        public static void WriteDefaultValues()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                writer.Write(1.250F);
                writer.Write("This is a random text message");
                writer.Write(10);
                writer.Write(true);
            }
        }

        public static void DisplayValues()
        {
            float aspectRatio;
            string tempDirectory;
            int autoSaveTime;
            bool showStatusBar;

            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    aspectRatio = reader.ReadSingle();
                    tempDirectory = reader.ReadString();
                    autoSaveTime = reader.ReadInt32();
                    showStatusBar = reader.ReadBoolean();
                }

                Console.WriteLine("Aspect ratio set to: " + aspectRatio);
                Console.WriteLine("Temp directory is: " + tempDirectory);
                Console.WriteLine("Auto save time set to: " + autoSaveTime);
                Console.WriteLine("Show status bar: " + showStatusBar);
            }
        }
        static void Main()
        {
            WriteDefaultValues();
            DisplayValues();
        }
    }
}
