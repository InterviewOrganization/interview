namespace Interview
{
    using System;

    public class ExampleClass
	{
	    public int From { get; set; }
        public int To { get; set; }

	    public ExampleClass(int from, int to)
	    {
            if(from < 1)
	            throw new ArgumentException("from is greater than 0");

            if(to < from)
                throw new ArgumentException("'to' is greater than 'from'");

	        this.From = from;
	        this.To = to;
	    }

	    private bool IsDivisibleBy(int number, int dividing)
	    {
	        return number % dividing == 0;
	    }

	    public void Print()
	    {
	        for(int number=From; number<=To; number++)
	        {
	            if(IsDivisibleBy(number, 15))
                    Console.WriteLine("FooBar");
                else if(IsDivisibleBy(number, 3))
                    Console.WriteLine("Foo");
                else if(IsDivisibleBy(number, 5))
                    Console.WriteLine("Bar");
	        }
	    }
	}
}
