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
    
    public partial class membere
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public membere()
        {
            this.abonners = new HashSet<abonner>();
            this.participers = new HashSet<participer>();
        }
    
        public int id_membere { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public Nullable<System.DateTime> datenaissence { get; set; }
        public string telephone { get; set; }
        public string sexe { get; set; }
        public Nullable<int> idsalle { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<abonner> abonners { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<participer> participers { get; set; }
        public virtual salle salle { get; set; }
    }
}
