using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview;
using NUnit.Framework;

namespace UT
{
	[TestFixture]
	public class ExampleClassTest
	{
		[Test]
        [TestCase(0, 100)]
        [TestCase(1, 1)]
		[TestCase(5, 5)]
		[TestCase(5, 1)]
        public void testValidateParameters(int from, int to)
		{
		    Assert.Throws<ArgumentException>(() =>
		        {
		            var example = new ExampleClass(0, 100);
		            example.Print();
                }
		    );
		}

	    [Test]
	    public void testPrintSuccess()
	    {
	        var example = new ExampleClass(1, 100);
	        example.Print();
	    }
    }
}
