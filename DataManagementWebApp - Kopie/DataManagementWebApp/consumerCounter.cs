//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataManagementWebApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class consumerCounter
    {
        public long cc_id { get; set; }
        public Nullable<System.DateTime> cc_processingDate { get; set; }
        public System.DateTime cc_date { get; set; }
        public string cc_source { get; set; }
        public decimal cc_counterValue { get; set; }
        public Nullable<int> cc_sourceIndex { get; set; }
        public Nullable<int> con_id { get; set; }
        public Nullable<int> loc_id { get; set; }
        public Nullable<int> dev_id { get; set; }
    
        public virtual consumption consumption { get; set; }
        public virtual device device { get; set; }
        public virtual location location { get; set; }
    }
}
