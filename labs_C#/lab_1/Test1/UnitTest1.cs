using System.Reflection.Emit;

namespace Test1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double a = 3;
            double b = 4;
            double p = lab_1.Program.Perimetr(a, b);
            double c = lab_1.Program.Hypotenuse(a, b);
            Assert.AreEqual(12, p);
            Assert.AreEqual(5, c);
        }
    }
}