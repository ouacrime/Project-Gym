//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Management_Gym
{
    using System;
    using System.Collections.Generic;
    
    public partial class salle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public salle()
        {
            this.memberes = new HashSet<membere>();
            this.offrirs = new HashSet<offrir>();
        }
    
        public int id_salle { get; set; }
        public string email { get; set; }
        public string nom { get; set; }
        public string nom_salle { get; set; }
        public string motpasse { get; set; }
        public string Type { get; set; }
        public string Idadmin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<membere> memberes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<offrir> offrirs { get; set; }
    }
}