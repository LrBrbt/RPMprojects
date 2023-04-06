using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9практическая
{
    struct Computer
    {
        public string ComputerName;
        public string ProcessorType;
        public int MemorySize;
        public int HDDSize;
        public string VideoCard;

        public Computer(string comtuterName, string processorType, int memorySize, int hardDiskDriveSize, string videoCard)
        {
            ComputerName = comtuterName;
            ProcessorType = processorType;
            MemorySize = memorySize;
            HDDSize = hardDiskDriveSize;
            VideoCard = videoCard;
        }
        public override string ToString()
        {
            return $"{ComputerName}";
        }
    }
}
