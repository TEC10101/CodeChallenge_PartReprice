using PartReprice.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartReprice.Data
{
    public static class ProcessingCommands
    {
        private const string Delimiter = "*!*";

        public static List<PartData> ReadPartDataFromFile(string filePath)
        {
            List<PartData> partDataList = new List<PartData>();

            string currentDirectory = Directory.GetCurrentDirectory();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(new[] { Delimiter }, StringSplitOptions.None);

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

        public static List<Reprices> ReadRepricesFromFile(string filePath)
        {
            List<Reprices> repricesList = new List<Reprices>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(new[] { Delimiter }, StringSplitOptions.None);

                if (parts.Length == 2 && int.TryParse(parts[0], out int partId) && decimal.TryParse(parts[1], out decimal price))
                {
                    Reprices reprices = new Reprices
                    {
                        PartId = partId,
                        Price = price
                    };

                    repricesList.Add(reprices);
                }
            }

            return repricesList;
        }

        public static void RepriceThePartData(List<PartData> partData, List<Reprices> reprices)
        {
            reprices.ForEach(newPrice =>
            {
                PartData partToUpdate = partData.Single(p => p.PartId == newPrice.PartId);
                partToUpdate.Price = newPrice.Price;
            });
        }

        public static void WriteNewPricesToFile(string filePath, List<PartData> newPricesList)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Header
                writer.WriteLine(string.Join(Delimiter, nameof(PartData.PartId), nameof(PartData.PartDesc), nameof(PartData.Price)));

                foreach (PartData reprices in newPricesList)
                {
                    string line = string.Join(Delimiter, reprices.PartId, reprices.PartDesc, reprices.Price);
                    writer.WriteLine(line);
                }
            }
        }
    }
}
