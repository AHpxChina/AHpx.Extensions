using System;
using System.Runtime.Serialization;
using AHpx.Extensions.StringExtensions;
using Xunit;

namespace AHpx.Extensions.UnitTest
{
    public class StringFilterShould
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void BeFalseIfNullOrEmpty(string s)
        {
            Assert.False(s.IsNotNullOrEmpty());
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void BeTrueIfNullOrEmpty(string s)
        {
            Assert.True(s.IsNullOrEmpty());
        }

        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        public void ThrowCustomExceptionIfNullOrEmpty(string s)
        {
            var exception = new MyException("This is a custom exception");
            Assert.Throws<MyException>(() =>
            {
                s.IsNotNullOrEmptyThrow(exception);
            });
        }
        
        [Serializable]
        public class MyException : Exception
        {
            //
            // For guidelines regarding the creation of new exception types, see
            //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
            // and
            //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
            //

            public MyException()
            {
            }

            public MyException(string message) : base(message)
            {
            }

            public MyException(string message, Exception inner) : base(message, inner)
            {
            }

            protected MyException(
                SerializationInfo info,
                StreamingContext context) : base(info, context)
            {
            }
        }
    }
}