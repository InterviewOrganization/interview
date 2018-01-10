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
		public void TestMethod1()
		{
			var sut = new ExampleClass();

			var actual = sut.Foo();

			Assert.AreEqual("bar", actual);
		}
	}
}
