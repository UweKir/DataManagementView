﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class KTBDataManagerEntities : DbContext
    {
        public KTBDataManagerEntities()
            : base("name=KTBDataManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<article> article { get; set; }
        public virtual DbSet<consumerCounter> consumerCounter { get; set; }
        public virtual DbSet<consumption> consumption { get; set; }
        public virtual DbSet<device> device { get; set; }
        public virtual DbSet<location> location { get; set; }
        public virtual DbSet<production> production { get; set; }
        public virtual DbSet<scaleCounter> scaleCounter { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<unit> unit { get; set; }
        public virtual DbSet<usage> usage { get; set; }
        public virtual DbSet<version> version { get; set; }
        public virtual DbSet<view_dailyProduction> view_dailyProduction { get; set; }
        public virtual DbSet<view_dailyUsage> view_dailyUsage { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_GetConsumerCounterDifference_Result> sp_GetConsumerCounterDifference(Nullable<System.DateTime> dATE_BEGIN, Nullable<System.DateTime> dATE_END, string lOCATION_NAME, string dEVICE_NAME, string cONSUMPTION_TYPE, string uNIT_NAME)
        {
            var dATE_BEGINParameter = dATE_BEGIN.HasValue ?
                new ObjectParameter("DATE_BEGIN", dATE_BEGIN) :
                new ObjectParameter("DATE_BEGIN", typeof(System.DateTime));
    
            var dATE_ENDParameter = dATE_END.HasValue ?
                new ObjectParameter("DATE_END", dATE_END) :
                new ObjectParameter("DATE_END", typeof(System.DateTime));
    
            var lOCATION_NAMEParameter = lOCATION_NAME != null ?
                new ObjectParameter("LOCATION_NAME", lOCATION_NAME) :
                new ObjectParameter("LOCATION_NAME", typeof(string));
    
            var dEVICE_NAMEParameter = dEVICE_NAME != null ?
                new ObjectParameter("DEVICE_NAME", dEVICE_NAME) :
                new ObjectParameter("DEVICE_NAME", typeof(string));
    
            var cONSUMPTION_TYPEParameter = cONSUMPTION_TYPE != null ?
                new ObjectParameter("CONSUMPTION_TYPE", cONSUMPTION_TYPE) :
                new ObjectParameter("CONSUMPTION_TYPE", typeof(string));
    
            var uNIT_NAMEParameter = uNIT_NAME != null ?
                new ObjectParameter("UNIT_NAME", uNIT_NAME) :
                new ObjectParameter("UNIT_NAME", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetConsumerCounterDifference_Result>("sp_GetConsumerCounterDifference", dATE_BEGINParameter, dATE_ENDParameter, lOCATION_NAMEParameter, dEVICE_NAMEParameter, cONSUMPTION_TYPEParameter, uNIT_NAMEParameter);
        }
    
        public virtual ObjectResult<sp_GetScaleCounterDifference_Result> sp_GetScaleCounterDifference(Nullable<System.DateTime> dATE_BEGIN, Nullable<System.DateTime> dATE_END, string lOCATION_NAME, string dEVICE_NAME, string aRTICLE_NAME, string uNIT_NAME)
        {
            var dATE_BEGINParameter = dATE_BEGIN.HasValue ?
                new ObjectParameter("DATE_BEGIN", dATE_BEGIN) :
                new ObjectParameter("DATE_BEGIN", typeof(System.DateTime));
    
            var dATE_ENDParameter = dATE_END.HasValue ?
                new ObjectParameter("DATE_END", dATE_END) :
                new ObjectParameter("DATE_END", typeof(System.DateTime));
    
            var lOCATION_NAMEParameter = lOCATION_NAME != null ?
                new ObjectParameter("LOCATION_NAME", lOCATION_NAME) :
                new ObjectParameter("LOCATION_NAME", typeof(string));
    
            var dEVICE_NAMEParameter = dEVICE_NAME != null ?
                new ObjectParameter("DEVICE_NAME", dEVICE_NAME) :
                new ObjectParameter("DEVICE_NAME", typeof(string));
    
            var aRTICLE_NAMEParameter = aRTICLE_NAME != null ?
                new ObjectParameter("ARTICLE_NAME", aRTICLE_NAME) :
                new ObjectParameter("ARTICLE_NAME", typeof(string));
    
            var uNIT_NAMEParameter = uNIT_NAME != null ?
                new ObjectParameter("UNIT_NAME", uNIT_NAME) :
                new ObjectParameter("UNIT_NAME", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetScaleCounterDifference_Result>("sp_GetScaleCounterDifference", dATE_BEGINParameter, dATE_ENDParameter, lOCATION_NAMEParameter, dEVICE_NAMEParameter, aRTICLE_NAMEParameter, uNIT_NAMEParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<spAddConsumerCounter_Result> spAddConsumerCounter(Nullable<System.DateTime> pROCESSING_DATE, Nullable<System.DateTime> dATE, Nullable<decimal> cOUNTER_VALUE, string lOCATION_NAME, string uNIT_NAME, string cONSUMPTION_TYPE_NAME, string dEVICE_NAME, string sOURCE, Nullable<int> sOURCE_INDEX)
        {
            var pROCESSING_DATEParameter = pROCESSING_DATE.HasValue ?
                new ObjectParameter("PROCESSING_DATE", pROCESSING_DATE) :
                new ObjectParameter("PROCESSING_DATE", typeof(System.DateTime));
    
            var dATEParameter = dATE.HasValue ?
                new ObjectParameter("DATE", dATE) :
                new ObjectParameter("DATE", typeof(System.DateTime));
    
            var cOUNTER_VALUEParameter = cOUNTER_VALUE.HasValue ?
                new ObjectParameter("COUNTER_VALUE", cOUNTER_VALUE) :
                new ObjectParameter("COUNTER_VALUE", typeof(decimal));
    
            var lOCATION_NAMEParameter = lOCATION_NAME != null ?
                new ObjectParameter("LOCATION_NAME", lOCATION_NAME) :
                new ObjectParameter("LOCATION_NAME", typeof(string));
    
            var uNIT_NAMEParameter = uNIT_NAME != null ?
                new ObjectParameter("UNIT_NAME", uNIT_NAME) :
                new ObjectParameter("UNIT_NAME", typeof(string));
    
            var cONSUMPTION_TYPE_NAMEParameter = cONSUMPTION_TYPE_NAME != null ?
                new ObjectParameter("CONSUMPTION_TYPE_NAME", cONSUMPTION_TYPE_NAME) :
                new ObjectParameter("CONSUMPTION_TYPE_NAME", typeof(string));
    
            var dEVICE_NAMEParameter = dEVICE_NAME != null ?
                new ObjectParameter("DEVICE_NAME", dEVICE_NAME) :
                new ObjectParameter("DEVICE_NAME", typeof(string));
    
            var sOURCEParameter = sOURCE != null ?
                new ObjectParameter("SOURCE", sOURCE) :
                new ObjectParameter("SOURCE", typeof(string));
    
            var sOURCE_INDEXParameter = sOURCE_INDEX.HasValue ?
                new ObjectParameter("SOURCE_INDEX", sOURCE_INDEX) :
                new ObjectParameter("SOURCE_INDEX", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spAddConsumerCounter_Result>("spAddConsumerCounter", pROCESSING_DATEParameter, dATEParameter, cOUNTER_VALUEParameter, lOCATION_NAMEParameter, uNIT_NAMEParameter, cONSUMPTION_TYPE_NAMEParameter, dEVICE_NAMEParameter, sOURCEParameter, sOURCE_INDEXParameter);
        }
    
        public virtual ObjectResult<spAddScaleCounter_Result> spAddScaleCounter(Nullable<System.DateTime> pROCESSING_DATE, Nullable<System.DateTime> dATE, Nullable<decimal> cOUNTER_VALUE, string lOCATION_NAME, string uNIT_NAME, string aRTICLE_NAME, string dEVICE_NAME, string sOURCE, Nullable<int> sOURCE_INDEX)
        {
            var pROCESSING_DATEParameter = pROCESSING_DATE.HasValue ?
                new ObjectParameter("PROCESSING_DATE", pROCESSING_DATE) :
                new ObjectParameter("PROCESSING_DATE", typeof(System.DateTime));
    
            var dATEParameter = dATE.HasValue ?
                new ObjectParameter("DATE", dATE) :
                new ObjectParameter("DATE", typeof(System.DateTime));
    
            var cOUNTER_VALUEParameter = cOUNTER_VALUE.HasValue ?
                new ObjectParameter("COUNTER_VALUE", cOUNTER_VALUE) :
                new ObjectParameter("COUNTER_VALUE", typeof(decimal));
    
            var lOCATION_NAMEParameter = lOCATION_NAME != null ?
                new ObjectParameter("LOCATION_NAME", lOCATION_NAME) :
                new ObjectParameter("LOCATION_NAME", typeof(string));
    
            var uNIT_NAMEParameter = uNIT_NAME != null ?
                new ObjectParameter("UNIT_NAME", uNIT_NAME) :
                new ObjectParameter("UNIT_NAME", typeof(string));
    
            var aRTICLE_NAMEParameter = aRTICLE_NAME != null ?
                new ObjectParameter("ARTICLE_NAME", aRTICLE_NAME) :
                new ObjectParameter("ARTICLE_NAME", typeof(string));
    
            var dEVICE_NAMEParameter = dEVICE_NAME != null ?
                new ObjectParameter("DEVICE_NAME", dEVICE_NAME) :
                new ObjectParameter("DEVICE_NAME", typeof(string));
    
            var sOURCEParameter = sOURCE != null ?
                new ObjectParameter("SOURCE", sOURCE) :
                new ObjectParameter("SOURCE", typeof(string));
    
            var sOURCE_INDEXParameter = sOURCE_INDEX.HasValue ?
                new ObjectParameter("SOURCE_INDEX", sOURCE_INDEX) :
                new ObjectParameter("SOURCE_INDEX", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spAddScaleCounter_Result>("spAddScaleCounter", pROCESSING_DATEParameter, dATEParameter, cOUNTER_VALUEParameter, lOCATION_NAMEParameter, uNIT_NAMEParameter, aRTICLE_NAMEParameter, dEVICE_NAMEParameter, sOURCEParameter, sOURCE_INDEXParameter);
        }
    
        public virtual ObjectResult<spGetSingleConsumerCounter_Result> spGetSingleConsumerCounter(Nullable<System.DateTime> dATE, string cONSUMPTION_TYPE_NAME, string uNIT_NAME, string dEVICE_NAME, string lOCATION_NAME)
        {
            var dATEParameter = dATE.HasValue ?
                new ObjectParameter("DATE", dATE) :
                new ObjectParameter("DATE", typeof(System.DateTime));
    
            var cONSUMPTION_TYPE_NAMEParameter = cONSUMPTION_TYPE_NAME != null ?
                new ObjectParameter("CONSUMPTION_TYPE_NAME", cONSUMPTION_TYPE_NAME) :
                new ObjectParameter("CONSUMPTION_TYPE_NAME", typeof(string));
    
            var uNIT_NAMEParameter = uNIT_NAME != null ?
                new ObjectParameter("UNIT_NAME", uNIT_NAME) :
                new ObjectParameter("UNIT_NAME", typeof(string));
    
            var dEVICE_NAMEParameter = dEVICE_NAME != null ?
                new ObjectParameter("DEVICE_NAME", dEVICE_NAME) :
                new ObjectParameter("DEVICE_NAME", typeof(string));
    
            var lOCATION_NAMEParameter = lOCATION_NAME != null ?
                new ObjectParameter("LOCATION_NAME", lOCATION_NAME) :
                new ObjectParameter("LOCATION_NAME", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetSingleConsumerCounter_Result>("spGetSingleConsumerCounter", dATEParameter, cONSUMPTION_TYPE_NAMEParameter, uNIT_NAMEParameter, dEVICE_NAMEParameter, lOCATION_NAMEParameter);
        }
    
        public virtual ObjectResult<spGetSingleScaleCounter_Result> spGetSingleScaleCounter(Nullable<System.DateTime> dATE, string aRTICLE_NAME, string uNIT_NAME, string dEVICE_NAME, string lOCATION_NAME)
        {
            var dATEParameter = dATE.HasValue ?
                new ObjectParameter("DATE", dATE) :
                new ObjectParameter("DATE", typeof(System.DateTime));
    
            var aRTICLE_NAMEParameter = aRTICLE_NAME != null ?
                new ObjectParameter("ARTICLE_NAME", aRTICLE_NAME) :
                new ObjectParameter("ARTICLE_NAME", typeof(string));
    
            var uNIT_NAMEParameter = uNIT_NAME != null ?
                new ObjectParameter("UNIT_NAME", uNIT_NAME) :
                new ObjectParameter("UNIT_NAME", typeof(string));
    
            var dEVICE_NAMEParameter = dEVICE_NAME != null ?
                new ObjectParameter("DEVICE_NAME", dEVICE_NAME) :
                new ObjectParameter("DEVICE_NAME", typeof(string));
    
            var lOCATION_NAMEParameter = lOCATION_NAME != null ?
                new ObjectParameter("LOCATION_NAME", lOCATION_NAME) :
                new ObjectParameter("LOCATION_NAME", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetSingleScaleCounter_Result>("spGetSingleScaleCounter", dATEParameter, aRTICLE_NAMEParameter, uNIT_NAMEParameter, dEVICE_NAMEParameter, lOCATION_NAMEParameter);
        }
    
        public virtual int spResetDatabase()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spResetDatabase");
        }
    
        public virtual ObjectResult<spSetAliveToLocation_Result> spSetAliveToLocation(string lOCATION_NAME)
        {
            var lOCATION_NAMEParameter = lOCATION_NAME != null ?
                new ObjectParameter("LOCATION_NAME", lOCATION_NAME) :
                new ObjectParameter("LOCATION_NAME", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spSetAliveToLocation_Result>("spSetAliveToLocation", lOCATION_NAMEParameter);
        }
    }
}
