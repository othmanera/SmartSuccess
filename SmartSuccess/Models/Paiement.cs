//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartSuccess.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paiement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paiement()
        {
            this.Matieres = new HashSet<Matiere>();
        }
    
        public int ID_Paiement { get; set; }
        public Nullable<System.DateTime> Date_Paiement { get; set; }
        public Nullable<decimal> Prix { get; set; }
        public string Etat { get; set; }
        public Nullable<int> ID_Etudiant { get; set; }
    
        public virtual Etudiant Etudiant { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matiere> Matieres { get; set; }
    }
}
