using System;
using System.Collections.Generic;
using System.Text;
using TesouroDiretoAPI.Common;
using Xunit;

namespace TesouroDiretoAPI.Tests
{
    public class StringExtensionTest
    {
        [Fact]
        public void ParseToDecimal()
        {
            Assert.True("R$ 3.890,87".ParseToDecimal() > 0);
        }

        [Fact]
        public void ParseToDecimalIncorrect()
        {
            Assert.False("KKASK".ParseToDecimal() > 0);
        }

        [Fact]
        public void IsEmpty()
        {
            Assert.True("".IsNullOrEmpty());
        }

        [Fact]
        public void IsNull()
        {
            string test = null;

            Assert.True(test.IsNullOrEmpty());
        }

        [Fact]
        public void IsNotNullAndNotEmpty()
        {
            Assert.False("OLA".IsNullOrEmpty());
        }
    }
}
