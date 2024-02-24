using Newtonsoft.Json;
using Statistics;
using System.IO;
namespace Statistics
{
    [TestClass]
    public class StatisticsTests
    {
        public static int[] source = new int[] { 1, 2, 3, 4, 5 };

        [TestMethod]
        public void TestMaximum()
        {
            Assert.AreEqual(5, Statistics.Maximum(source));
        }

        [TestMethod]
        public void TestMinimum()
        {
            Assert.AreEqual(1, Statistics.Minimum(source));
        }

        [TestMethod]
        public void TestMean()
        {
            Assert.AreEqual(3, Statistics.Mean(source));
        }

        [TestMethod]
        public void TestMedian()
        {
            Assert.AreEqual(3, Statistics.Median(source));
        }

        [TestMethod]
        public void TestMode()
        {
            int[] FörväntatModes = { 1, 2, 3, 4, 5 };
            int[] realModes = Statistics.Mode(source);

            Assert.AreEqual(FörväntatModes.Length, realModes.Length);


            for (int i = 0; i < FörväntatModes.Length; i++)
            {
                Assert.AreEqual(FörväntatModes[i], realModes[i]);
            }
        }

        [TestMethod]
        public void TestRange()
        {
            Assert.AreEqual(4, Statistics.Range(source));
        }

        [TestMethod]
        public void TestStandardDeviation()
        {
            Assert.AreEqual(1.4, Statistics.StandardDeviation(source), 0.1);
        }
    }
}