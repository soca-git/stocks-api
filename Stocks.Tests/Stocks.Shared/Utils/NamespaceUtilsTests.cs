using Stocks.Shared.Utils;
using System;
using Xunit;

namespace Stocks.Tests.Stocks.Shared.Utils
{
    public class EnumUtilsTests
    {
        private readonly string _validEnumStringValue = "EUR";
        private readonly string _invalidEnumStringValue = "EURO";
        private readonly MockEnum _validEnumValue = MockEnum.EUR;
        private readonly MockEnum _defaultEnumValue = MockEnum.USD;

        private enum MockEnum
        {
            EUR,
            USD
        }

        [Fact]
        public void ToEnumOrDefault_Returns_Enum_When_Value_Matches()
        {
            var enumValue = _validEnumStringValue.ToEnumOrDefault(_defaultEnumValue);

            Assert.IsType<MockEnum>(enumValue);
            Assert.Equal(_validEnumValue, enumValue);
        }

        [Fact]
        public void ToEnumOrDefault_Returns_Default_Enum_When_Value_Does_Not_Match()
        {
            var enumValue = _invalidEnumStringValue.ToEnumOrDefault(_defaultEnumValue);

            Assert.IsType<MockEnum>(enumValue);
            Assert.Equal(_defaultEnumValue, enumValue);
        }

        [Fact]
        public void ToEnum_Returns_Enum_When_Value_Matches()
        {
            var enumValue = _validEnumStringValue.ToEnum<MockEnum>();

            Assert.IsType<MockEnum>(enumValue);
            Assert.Equal(_validEnumValue, enumValue);
        }

        [Fact]
        public void ToEnum_Throws_Exception_When_Value_Does_Not_Match()
        {
            Assert.Throws<Exception>(() => _invalidEnumStringValue.ToEnum<MockEnum>());
        }
    }
}
