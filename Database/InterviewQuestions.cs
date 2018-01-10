using System;
using System.Collections.Generic;
using InterviewDb.Model;

namespace InterviewDb
{
	public class InterviewQuestions
	{
		private readonly DbFactory myDbFactory = new DbFactory();

		public List<DateTime> EntityFrameworkOne()
		{
			//Retrieve all "SessionStart"'s of a player with Alias "assessment" that logged in on any machine (or an empty list if none found)
			using (var context = myDbFactory.Create())
			{
				return null;
			}
		}

		public List<Machine> EntityFrameworkTwo()
		{
			//Retrieve all machines containing "Hk" in the MachineName that a player with Alias "aplayer" ever logged in at (or an empty list if none found)
			using (var context = myDbFactory.Create())
			{
				return null;	
			}
		}

		public List<DateTime> EntityFrameworkThree()
		{
			//Retrieve all machines on which a player with alias "b2d1" has a SessionLog entry with a LogTimestamp that happened on the 9th of June 2017, with GameID = 1 (or an empty list if none found)
			using (var context = myDbFactory.Create())
			{
				return null;	
			}
		}
	}
}
