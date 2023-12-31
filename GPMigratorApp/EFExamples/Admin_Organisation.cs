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
    
    public partial class Admin_Organisation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin_Organisation()
        {
            this.Admin_Organisation1 = new HashSet<Admin_Organisation>();
            this.Admin_Organisation11 = new HashSet<Admin_Organisation>();
            this.Admin_Patient = new HashSet<Admin_Patient>();
            this.Admin_Patient1 = new HashSet<Admin_Patient>();
            this.Admin_UserInRole = new HashSet<Admin_UserInRole>();
            this.Appointment_Session = new HashSet<Appointment_Session>();
            this.Appointment_Slot = new HashSet<Appointment_Slot>();
            this.CareRecord_Consultation = new HashSet<CareRecord_Consultation>();
            this.CareRecord_Diary = new HashSet<CareRecord_Diary>();
            this.CareRecord_Observation = new HashSet<CareRecord_Observation>();
            this.CareRecord_ObservationReferral = new HashSet<CareRecord_ObservationReferral>();
            this.CareRecord_ObservationReferral1 = new HashSet<CareRecord_ObservationReferral>();
            this.CareRecord_ObservationReferral2 = new HashSet<CareRecord_ObservationReferral>();
            this.CareRecord_Problem = new HashSet<CareRecord_Problem>();
            this.Prescribing_DrugRecord = new HashSet<Prescribing_DrugRecord>();
            this.Prescribing_IssueRecord = new HashSet<Prescribing_IssueRecord>();
        }
    
        public string OrganisationGuid { get; set; }
        public string CDB { get; set; }
        public string OrganisationName { get; set; }
        public string ODSCode { get; set; }
        public string ParentOrganisationGuid { get; set; }
        public string CCGOrganisationGuid { get; set; }
        public string OrganisationType { get; set; }
        public string OpenDate { get; set; }
        public string CloseDate { get; set; }
        public string MainLocationGuid { get; set; }
        public string ProcessingId { get; set; }
    
        public virtual Admin_Location Admin_Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin_Organisation> Admin_Organisation1 { get; set; }
        public virtual Admin_Organisation Admin_Organisation2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin_Organisation> Admin_Organisation11 { get; set; }
        public virtual Admin_Organisation Admin_Organisation3 { get; set; }
        public virtual Admin_OrganisationLocation Admin_OrganisationLocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin_Patient> Admin_Patient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin_Patient> Admin_Patient1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Admin_UserInRole> Admin_UserInRole { get; set; }
        public virtual Agreements_SharingOrganisation Agreements_SharingOrganisation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment_Session> Appointment_Session { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment_Slot> Appointment_Slot { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CareRecord_Consultation> CareRecord_Consultation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CareRecord_Diary> CareRecord_Diary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CareRecord_Observation> CareRecord_Observation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CareRecord_ObservationReferral> CareRecord_ObservationReferral { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CareRecord_ObservationReferral> CareRecord_ObservationReferral1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CareRecord_ObservationReferral> CareRecord_ObservationReferral2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CareRecord_Problem> CareRecord_Problem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescribing_DrugRecord> Prescribing_DrugRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescribing_IssueRecord> Prescribing_IssueRecord { get; set; }
    }
}
