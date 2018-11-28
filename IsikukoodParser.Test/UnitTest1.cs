using System;
using Xunit;
using IsikukoodiParser;

namespace IsikukoodiParser.Test
{
    public class Test
    {
        [Fact]
        public void Should_beValidIsikukood()
        {
            var parser = new IsikukoodiParser("39302020249");
            var parser2 = new IsikukoodiParser("08173628367");
            var parser3 = new IsikukoodiParser("3930202024");
            var parser4 = new IsikukoodiParser("393020202eb");
            var parser5 = new IsikukoodiParser("99302020249");

            bool parsedIk = parser.evaluateIk();
            bool parsedIk2 = parser2.evaluateIk();
            bool parsedIk3 = parser3.evaluateIk();
            bool parsedIk4 = parser4.evaluateIk();
            bool parsedIk5 = parser5.evaluateIk();

            Assert.True(parsedIk);
            Assert.False(parsedIk2);
            Assert.False(parsedIk3);
            Assert.False(parsedIk4);
            Assert.False(parsedIk5);
        }

        [Fact]
        public void Should_EvaluateGender()
        {
            var parser = new IsikukoodiParser("39302020249");
            var parser2 = new IsikukoodiParser("49302020249");
            var parser3 = new IsikukoodiParser("09302020249");
            var parser4 = new IsikukoodiParser("99302020249");
            var parser5 = new IsikukoodiParser("19302020249");
            var parser6 = new IsikukoodiParser("59302020249");
            var parser7 = new IsikukoodiParser("79302020249");
            var parser8 = new IsikukoodiParser("29302020249");
            var parser9 = new IsikukoodiParser("69302020249");
            var parser10 = new IsikukoodiParser("89302020249");

            string parsedIk = parser.evaluateGender();
            string parsedIk2 = parser2.evaluateGender();
            string parsedIk3 = parser3.evaluateGender();
            string parsedIk4 = parser4.evaluateGender();
            string parsedIk5 = parser5.evaluateGender();
            string parsedIk6 = parser6.evaluateGender();
            string parsedIk7 = parser7.evaluateGender();
            string parsedIk8 = parser8.evaluateGender();
            string parsedIk9 = parser9.evaluateGender();
            string parsedIk10 = parser10.evaluateGender();

            Assert.Equal("Male", parsedIk);
            Assert.Equal("Female", parsedIk2);
            Assert.Null(parsedIk3);
            Assert.Null(parsedIk4);
            Assert.Equal("Male", parsedIk5);
            Assert.Equal("Male", parsedIk6);
            Assert.Equal("Male", parsedIk7);
            Assert.Equal("Female", parsedIk8);
            Assert.Equal("Female", parsedIk9);
            Assert.Equal("Female", parsedIk10);
        }

        [Fact]
        public void Should_EvaluateBirthday()
        {
            var parser = new IsikukoodiParser("39302020249");
            var parser2 = new IsikukoodiParser("39399020249");
            var parser3 = new IsikukoodiParser("39302990249");
            var parser4 = new IsikukoodiParser("39300020249");

            string parsedIk = parser.evaluateBirthday();
            string parsedIk2 = parser2.evaluateBirthday();
            string parsedIk3 = parser3.evaluateBirthday();
            string parsedIk4 = parser4.evaluateBirthday();

            Assert.Equal("02.02.93", parsedIk);
            Assert.Null(parsedIk2);
            Assert.Null(parsedIk3);
            Assert.Null(parsedIk4);
        }
    }
}
