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
    
    public partial class scaleCounter
    {
        public long sc_id { get; set; }
        public Nullable<System.DateTime> sc_processingDate { get; set; }
        public System.DateTime sc_date { get; set; }
        public string sc_source { get; set; }
        public decimal sc_counterValue { get; set; }
        public Nullable<int> sc_sourceIndex { get; set; }
        public Nullable<int> art_id { get; set; }
        public Nullable<int> loc_id { get; set; }
        public Nullable<int> dev_id { get; set; }
    
        public virtual article article { get; set; }
        public virtual device device { get; set; }
        public virtual location location { get; set; }
    }
}
