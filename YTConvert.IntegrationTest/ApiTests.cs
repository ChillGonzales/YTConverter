using System;
using NUnit.Framework;

namespace YTConvert.IntegrationTest
{
    [TestFixture]
    public class ApiTests
    {
        ConvertController _controller;

        public ApiTests()
        {
            _controller = new ConvertController();
        }

        [Test]
        public void TestApiGet()
        {
            var response = _controller.Get();
        }
    }
}
