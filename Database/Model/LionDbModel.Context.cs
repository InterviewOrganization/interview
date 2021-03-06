﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InterviewDb.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LionDbEntities : DbContext
    {
        public LionDbEntities()
            : base("name=LionDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Accounting> Accountings { get; set; }
        public virtual DbSet<AccountingClearanceType> AccountingClearanceTypes { get; set; }
        public virtual DbSet<AccountingType> AccountingTypes { get; set; }
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<BaseCard> BaseCards { get; set; }
        public virtual DbSet<BaseCardType> BaseCardTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<IGameUserMachineSiteAssignment> IGameUserMachineSiteAssignments { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<MachineSession> MachineSessions { get; set; }
        public virtual DbSet<MachineSessionEndType> MachineSessionEndTypes { get; set; }
        public virtual DbSet<MachineSessionLog> MachineSessionLogs { get; set; }
        public virtual DbSet<MachineSessionLogAction> MachineSessionLogActions { get; set; }
        public virtual DbSet<MachineType> MachineTypes { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationState> OrganizationStates { get; set; }
        public virtual DbSet<OrganizationType> OrganizationTypes { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerRole> PlayerRoles { get; set; }
        public virtual DbSet<Right> Rights { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionLog> SessionLogs { get; set; }
        public virtual DbSet<SessionType> SessionTypes { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<WebSession> WebSessions { get; set; }
    
        public virtual ObjectResult<Nullable<int>> spFetchCommonOrganization(Nullable<int> machineID, Nullable<int> staffBaseCardID, Nullable<int> playerBaseCardID, Nullable<int> organizationID, ObjectParameter commonOrganizationID)
        {
            var machineIDParameter = machineID.HasValue ?
                new ObjectParameter("MachineID", machineID) :
                new ObjectParameter("MachineID", typeof(int));
    
            var staffBaseCardIDParameter = staffBaseCardID.HasValue ?
                new ObjectParameter("StaffBaseCardID", staffBaseCardID) :
                new ObjectParameter("StaffBaseCardID", typeof(int));
    
            var playerBaseCardIDParameter = playerBaseCardID.HasValue ?
                new ObjectParameter("PlayerBaseCardID", playerBaseCardID) :
                new ObjectParameter("PlayerBaseCardID", typeof(int));
    
            var organizationIDParameter = organizationID.HasValue ?
                new ObjectParameter("OrganizationID", organizationID) :
                new ObjectParameter("OrganizationID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spFetchCommonOrganization", machineIDParameter, staffBaseCardIDParameter, playerBaseCardIDParameter, organizationIDParameter, commonOrganizationID);
        }
    
        public virtual ObjectResult<Nullable<int>> spFetchOrganizationForGamesAllowed(Nullable<int> machineID, Nullable<int> baseCardID, Nullable<int> organizationID, ObjectParameter organizationIdForGameAllowed)
        {
            var machineIDParameter = machineID.HasValue ?
                new ObjectParameter("MachineID", machineID) :
                new ObjectParameter("MachineID", typeof(int));
    
            var baseCardIDParameter = baseCardID.HasValue ?
                new ObjectParameter("BaseCardID", baseCardID) :
                new ObjectParameter("BaseCardID", typeof(int));
    
            var organizationIDParameter = organizationID.HasValue ?
                new ObjectParameter("OrganizationID", organizationID) :
                new ObjectParameter("OrganizationID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spFetchOrganizationForGamesAllowed", machineIDParameter, baseCardIDParameter, organizationIDParameter, organizationIdForGameAllowed);
        }
    
        public virtual ObjectResult<Nullable<int>> spFetchOrganizationLimits(Nullable<int> organizationID, ObjectParameter mcmPayInLimit, ObjectParameter payInLimit, ObjectParameter payOutLimit, ObjectParameter lossLimit, ObjectParameter desiredHold, ObjectParameter displayedCoinSymbol, ObjectParameter maxOrganizationLoss, ObjectParameter allowActionGames, ObjectParameter maxGamble, ObjectParameter allowTurbo)
        {
            var organizationIDParameter = organizationID.HasValue ?
                new ObjectParameter("OrganizationID", organizationID) :
                new ObjectParameter("OrganizationID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spFetchOrganizationLimits", organizationIDParameter, mcmPayInLimit, payInLimit, payOutLimit, lossLimit, desiredHold, displayedCoinSymbol, maxOrganizationLoss, allowActionGames, maxGamble, allowTurbo);
        }
    
        public virtual ObjectResult<Nullable<int>> spFetchParentOrganizations(Nullable<int> organizationID)
        {
            var organizationIDParameter = organizationID.HasValue ?
                new ObjectParameter("OrganizationID", organizationID) :
                new ObjectParameter("OrganizationID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spFetchParentOrganizations", organizationIDParameter);
        }
    
        public virtual ObjectResult<spFetchChildOrganizations_Result> spFetchChildOrganizations(Nullable<int> organizationID)
        {
            var organizationIDParameter = organizationID.HasValue ?
                new ObjectParameter("OrganizationID", organizationID) :
                new ObjectParameter("OrganizationID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spFetchChildOrganizations_Result>("spFetchChildOrganizations", organizationIDParameter);
        }
    }
}
