namespace TestProject
{

    public class Tests
    {
        private Calculator _calculator;
        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Test1()
        {
            int result = _calculator.Add(2, 3);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void Subtract()
        {
            int result = _calculator.Subtract(5, 3);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Multiply()
        {
            int result = _calculator.Multiply(4, 5);
            Assert.AreEqual(20, result);
        }

        [Test]
        public void Divide()
        {
            int result = _calculator.Multiply(15, 5);
            Assert.AreEqual(5, result);
            //Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }
    }
}