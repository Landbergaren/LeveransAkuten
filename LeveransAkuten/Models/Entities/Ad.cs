using System;

namespace LeveransAkuten.Models.Entities
{
    public partial class Ad
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Arequired { get; set; }
        public bool Brequired { get; set; }
        public bool Crequired { get; set; }
        public bool Drequired { get; set; }
        public bool Cerequired { get; set; }
        public int? DriverId { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
