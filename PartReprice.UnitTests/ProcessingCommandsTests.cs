using PartReprice.Data;

namespace PartReprice.UnitTests
{
    [TestClass]
    public class ProcessingCommandsTests
    {
        private const string FileNamePartData = "PartData.txt";
        private const string FileNameRepriceData = "RepriceData.txt";
        private string filePathPartData = "";
        private string filePathRepriceData = "";

        private const string KnownGoodPartData = @"PartID*!*PartDesc*!*Price
1*!*Super Cool Part*!*1.2
2*!*Another Awesome Part*!*1.3
3*!*Expensive Part*!*999.99";

        private const string KnownGoodRepriceData = @"PartID*!*Price
1*!*1.3
2*!*1.2
3*!*1000";

        [TestInitialize]
        public void TestInitialize()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            this.filePathPartData = Path.Combine(currentDirectory, FileNamePartData);
            this.filePathRepriceData = Path.Combine(currentDirectory, FileNameRepriceData);

            // Create the test data files.
            File.WriteAllText(filePathPartData, KnownGoodPartData);
            File.WriteAllText(filePathRepriceData, KnownGoodRepriceData);
        }

        /// <summary>
        /// Test Case: Ensure the Part Data is read correctly and the method functions as expected.
        /// </summary>
        [TestMethod]
        public void TestReadPartData_HappyPath()
        {
            var partDataList = ProcessingCommands.ReadPartDataFromFile(this.filePathPartData);

            if (partDataList == null)
            {
                Assert.Fail("Test data not setup correctly");
            }

            Assert.IsTrue(partDataList.Count > 0, "Data file not read correctly");
        }

        /// <summary>
        /// Test Case: Ensure the Reprice data is read correctly and the method functions as expected.
        /// </summary>
        [TestMethod]
        public void TestReadRepriceData_HappyPath()
        {
            var repriceList = ProcessingCommands.ReadRepricesFromFile(this.filePathRepriceData);

            if (repriceList == null)
            {
                Assert.Fail("Test data not setup correctly");
            }

            Assert.IsTrue(repriceList.Count > 0, "Data file not read correctly");
        }

        /// <summary>
        /// Test Case: Ensure that the data is read correctly and that the price is changed.
        /// </summary>
        [TestMethod]
        public void TestRepriceThePartData_HappyPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePathPartData = Path.Combine(currentDirectory, FileNamePartData);
            string fileameRepriceData = Path.Combine(currentDirectory, FileNameRepriceData);

            var pristinePartData = ProcessingCommands.ReadPartDataFromFile(filePathPartData);
            var partDataList = ProcessingCommands.ReadPartDataFromFile(filePathPartData);
            var repriceList = ProcessingCommands.ReadRepricesFromFile(fileameRepriceData);

            if (pristinePartData == null || partDataList == null || repriceList == null)
            {
                Assert.Fail("Test data not setup correctly");
            }

            ProcessingCommands.RepriceThePartData(partDataList, repriceList);

            pristinePartData.ToArray();
            partDataList.ToArray();

            for (int i = 0; i < pristinePartData.Count; i++)
            {
                Assert.AreNotEqual(pristinePartData[i].Price, partDataList[i].Price, "The price was not changed.");
                Assert.AreEqual(pristinePartData[i].PartDesc, partDataList[i].PartDesc, "For some reason the description changed.");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestReadPartData_BadData()
        {
            // Use bad data format and pass it into methods.
        }
    }
}