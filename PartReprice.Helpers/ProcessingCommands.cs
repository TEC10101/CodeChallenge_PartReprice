using PartReprice.Helpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartReprice.Helpers
{
    internal static class ProcessingCommands
    {
        public static List<PartData> ReadPartDataFromFile(string filePath)
        {
            List<PartData> partDataList = new List<PartData>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(new[] { "*!*" }, StringSplitOptions.None);

                if (parts.Length == 3 && int.TryParse(parts[0], out int partId) && decimal.TryParse(parts[2], out decimal price))
                {
                    PartData partData = new PartData
                    {
                        PartId = partId,
                        PartDesc = parts[1],
                        Price = price
                    };

                    partDataList.Add(partData);
                }
            }

            return partDataList;
        }

    }
}
