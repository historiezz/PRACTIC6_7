//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace practic6_7
{
    using System;
    using System.Collections.Generic;
    
    public partial class vistavki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vistavki()
        {
            this.hall = new HashSet<hall>();
        }
    
        public int id { get; set; }
        public string kind { get; set; }
        public System.DateTime date_event { get; set; }
        public Nullable<int> id_artist { get; set; }
    
        public virtual artist artist { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hall> hall { get; set; }
    }
}
