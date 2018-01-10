using System;
using System.Configuration;
using System.Data.Entity;
using InterviewDb.Model;
using NLog;

namespace InterviewDb
{
	public class DbFactory
	{
		private static readonly Logger Log = LogManager.GetCurrentClassLogger();

		#region private classes and enums
		enum Mode
		{
			Normal,
			Transaction
		}
		#endregion

		public const string DB_FROM_CONFIG_FILE = "LionDbEntities";

		private Mode myMode = Mode.Normal;
		private LionDbContainerWithTransaction myCachedDbInConnection;

		public bool IsInTransactionMode
		{
			get { return myMode == Mode.Transaction; }
		}

		public virtual ILionDbContainer Create()
		{
			try
			{
				if (myMode == Mode.Normal)
					return new LionDbContainer(CreateRaw());

				return new NoDisposeContainer(myCachedDbInConnection.Db);
			}
			catch (Exception ex)
			{
				Log.Error("Cannot find an entry in the config file for what database to take!", ex);
				throw;
			}
		}

		/// <summary>
		/// create a raw EF connection; 
		/// using this will always create a new instance instead of reusing one, so know what you are doing before calling this
		/// </summary>
		/// <returns></returns>
		public LionDbEntities CreateRaw()
		{
			string connectionString = ConfigurationManager.AppSettings[DB_FROM_CONFIG_FILE];
			if (connectionString == null)
				connectionString = ConfigurationManager.ConnectionStrings[DB_FROM_CONFIG_FILE].ConnectionString;	//take it from the EF settings
			return new LionDbEntities(connectionString);
		}

		public virtual ILionDbContainer CreateWithTransaction()
		{
			if (myMode == Mode.Transaction)
				return new NoDisposeTransactionContainer(myCachedDbInConnection);
			return InnerCreateWithTransaction();
		}

		/// <summary>
		/// sets the factory to transaction mode in which it remains until the returned object is disposed
		/// </summary>
		/// <returns></returns>
		internal LionDbContainerWithTransaction SetToTransactionMode()
		{
			if (myMode == Mode.Transaction)
				throw new Exception("Already in transaction mode!");

			try
			{
				myMode = Mode.Transaction;
				myCachedDbInConnection = InnerCreateWithTransaction();
				return myCachedDbInConnection;
			}
			catch (Exception)
			{
				myMode = Mode.Normal;
				throw;
			}
		}

		private LionDbContainerWithTransaction InnerCreateWithTransaction()
		{
			return new LionDbContainerWithTransaction(this);
		}

		/// <summary>
		/// should only be called by a LionDbTransaction instance.
		/// disposes the cached database and transaction and setting the Factory back to normal/classic mode of all the time creating new instances when "Create" is called
		/// </summary>
		internal void ResetTransactionMode()
		{
			myCachedDbInConnection = null;	//we dont dispose, because this only gets called by the LionDbInTransaction.Dispose() method which already disposes the DB connection
			myMode = Mode.Normal;
		}
	}

	public class NoDisposeContainer : ILionDbContainer
	{
		public NoDisposeContainer(LionDbEntities db)
		{
			Db = db;
		}

		public LionDbEntities Db { get; private set; }

		public void Dispose()
		{
			
		}
		
		public void SaveAndPossiblyCommit()
		{
			Db.SaveChanges();
		}
	}

	public class LionDbContainer : ILionDbContainer
	{
		private readonly LionDbEntities myDb;

		public LionDbEntities Db
		{
			get { return myDb; }
		}

		public LionDbContainer(LionDbEntities db)
		{
			myDb = db;
		}

		public void Dispose()
		{
			myDb.Dispose();
		}

		public void SaveAndPossiblyCommit()
		{
			myDb.SaveChanges();
		}
	}

	internal class LionDbContainerWithTransaction : ILionDbContainer
	{
		private readonly DbFactory myFactory;
		private readonly LionDbEntities myDb;
		private readonly DbContextTransaction myTransaction;

		public LionDbContainerWithTransaction(DbFactory factory)
		{
			try
			{
				myFactory = factory;
				myDb = factory.CreateRaw();
				myTransaction = myDb.Database.BeginTransaction();
			}
			catch (Exception)
			{
				Dispose();
				throw;
			}
		}

		public LionDbEntities Db
		{
			get { return myDb; }
		}

		public void SaveAndPossiblyCommit()
		{
			myDb.SaveChanges();
			myTransaction.Commit();
		}

		public void Dispose()
		{
			if (myTransaction != null)
				myTransaction.Dispose();
			if (myDb != null)
				myDb.Dispose();

			myFactory.ResetTransactionMode();
		}
	}

	public interface ILionDbContainer : IDisposable
	{
		LionDbEntities Db { get; }
		/// <summary>
		/// the transaction will be commited immediatly if no higher transaction scope was specified.
		/// a "higher" transaction scope can be set by calling DbFactory.SetToTransactionMode()
		/// In case a higher level has called DbFactory.SetToTransactionMode(), 
		/// then this higher place then needs to commit the transaction
		/// </summary>
		void SaveAndPossiblyCommit();
	}


	internal class NoDisposeTransactionContainer : ILionDbContainer
	{
		private static readonly Logger Log = LogManager.GetCurrentClassLogger();

		private readonly LionDbContainerWithTransaction myContainerWithTransaction;

		public NoDisposeTransactionContainer(LionDbContainerWithTransaction containerWithTransaction)
		{
			myContainerWithTransaction = containerWithTransaction;
		}

		public void Dispose()
		{
			
		}

		public LionDbEntities Db { get { return myContainerWithTransaction.Db; } }
		
		public void SaveAndPossiblyCommit()
		{
			myContainerWithTransaction.Db.SaveChanges();
			Log.Trace("No commit done as the container is in a higher scope");
		}
	}


}
