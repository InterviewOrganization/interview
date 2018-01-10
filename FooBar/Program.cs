using System;
using InterviewDb;

namespace Interview
{
	public class Program
	{
		public static void Main()
		{
			FirstTask();

			SecondTask();
		}

		private static void FirstTask()
		{
			//Write a program that prints the integers from 1 to 100.
			//But for multiples of three print "Foo\n" instead of the number, and for the multiples of five print "Bar\n" instead of the number. 
			//For numbers which are multiples of both three and five print "FooBar\n" instead of the number


			//Write a Unit Test / Tests for your just written program 
		}

		private static void SecondTask()
		{
			var entityQuestions = new InterviewQuestions();
			
			entityQuestions.EntityFrameworkOne();
			entityQuestions .EntityFrameworkTwo();
			entityQuestions .EntityFrameworkThree();
		}
	}
}
