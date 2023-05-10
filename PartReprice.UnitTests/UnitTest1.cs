namespace PartReprice.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string testInputData = @"PartID*!*PartDesc*!*Price
1*!*Super Cool Part*!*1.2
2*!*Another Awesome Part*!*1.3
3*!*Expensive Part*!*999.99";

            string testRepriceData = @"PartID*!*Price
1*!*1.3
2*!*1.2
3*!*1000";


        }
    }
}