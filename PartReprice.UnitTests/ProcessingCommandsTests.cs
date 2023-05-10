using PartReprice.Data;
using PartReprice.Data.Models;

namespace PartReprice.UnitTests
{
    [TestClass]
    public class ProcessingCommandsTests
    {
        private const string KnownGoodPartData = @"PartID*!*PartDesc*!*Price
1*!*Super Cool Part*!*1.2
2*!*Another Awesome Part*!*1.3
3*!*Expensive Part*!*999.99";

        private const string KnownGoodRepriceData = @"PartID*!*Price
1*!*1.3
2*!*1.2
3*!*1000";

        /// <summary>
        /// Test Case: Ensure the Part Data is read correctly and the method functions as expected.
        /// </summary>
        [TestMethod]
        public void TestReadPartData_HappyPath()
        {
            var partDataList = PartReprice.Data.ProcessingCommands.ReadPartDataFromFile(@"A:\Projects\CSharp\GlobalShopSolutionsDemo\PartReprice\PartReprice.UnitTests\TestData\PartData.txt");

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
            var repriceList = PartReprice.Data.ProcessingCommands.ReadRepricesFromFile(@"A:\Projects\CSharp\GlobalShopSolutionsDemo\PartReprice\PartReprice.UnitTests\TestData\RepriceData.txt");

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
            var pristinePartData = PartReprice.Data.ProcessingCommands.ReadPartDataFromFile(@"A:\Projects\CSharp\GlobalShopSolutionsDemo\PartReprice\PartReprice.UnitTests\TestData\PartData.txt");
            var partDataList = PartReprice.Data.ProcessingCommands.ReadPartDataFromFile(@"A:\Projects\CSharp\GlobalShopSolutionsDemo\PartReprice\PartReprice.UnitTests\TestData\PartData.txt");
            var repriceList = PartReprice.Data.ProcessingCommands.ReadRepricesFromFile(@"A:\Projects\CSharp\GlobalShopSolutionsDemo\PartReprice\PartReprice.UnitTests\TestData\RepriceData.txt");

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
        public void TestReadPartData_BadData()
        {
            // Use bad data format and pass it into methods.
        }
    }
}