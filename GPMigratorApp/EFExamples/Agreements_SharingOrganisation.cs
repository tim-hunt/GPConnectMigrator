//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DotNetGPSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class Agreements_SharingOrganisation
    {
        public string OrganisationGuid { get; set; }
        public string IsActivated { get; set; }
        public string LastModifiedDate { get; set; }
        public string Disabled { get; set; }
        public string Deleted { get; set; }
    
        public virtual Admin_Organisation Admin_Organisation { get; set; }
    }
}