using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
			    var sessions = from player in context.Db.Players
			                   join session in context.Db.Sessions on player.BaseCardID equals session.BaseCardID
			                   join machineSession in context.Db.MachineSessions on session.MachineSessionID equals machineSession.MachineSessionID
			                   where player.Alias == "assessment"
                               select machineSession.SessionStart;

			    // can get duplicate start time of session of player but you dont want to get unique start times of session
                return sessions.ToList();

			}
		}

		public List<Machine> EntityFrameworkTwo()
		{
			//Retrieve all machines containing "Hk" in the MachineName that a player with Alias "aplayer" ever logged in at (or an empty list if none found)
			using (var context = myDbFactory.Create())
			{
			    var machines = from machine in context.Db.Machines
			                   join machineSession in context.Db.MachineSessions on machine.MachineID equals machineSession.MachineID
			                   join session in context.Db.Sessions on machineSession.MachineSessionID equals session.MachineSessionID
			                   join player in context.Db.Players on session.BaseCardID equals player.BaseCardID
			                   where player.Alias == "aplayer" && machine.MachineName.Contains("Hk")
			                   select machine;

			    // can get duplicate machines but you dont want to get unique machines
                return machines.ToList();
			}
		}

        
		public List<Machine> EntityFrameworkThree()
		{
			//Retrieve all machines on which a player with alias "b2d1" has a SessionLog entry with a LogTimestamp that happened on the 9th of June 2017, with GameID = 1 (or an empty list if none found)
			using (var context = myDbFactory.Create())
			{
			    DateTime filterData = DateTime.Parse("2017-06-09");

				var machines = from machine in context.Db.Machines
				               join machineSession in context.Db.MachineSessions on machine.MachineID equals machineSession.MachineID
				               join session in context.Db.Sessions on machineSession.MachineSessionID equals session.MachineSessionID
                               join sessionLog in context.Db.SessionLogs on new {SessionId=session.SessionID, MachineId=(int?)machine.MachineID }
                                                                        equals new { SessionId = sessionLog.SessionID, MachineId = sessionLog.MachineID }
                               join player in context.Db.Players on session.BaseCardID equals player.BaseCardID
				               where player.Alias == "b2d1" && DbFunctions.TruncateTime(sessionLog.LogTimeStamp) == filterData && sessionLog.GameID == 1 
				               select machine;

			    // can get duplicate machines but you dont want to get unique machines
                return machines.ToList();
            }
		}
	}
}
