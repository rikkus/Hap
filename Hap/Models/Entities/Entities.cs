using System;
using System.Collections.Generic;

namespace Hap.Models.Entities
{
    public class Space
    {
        public Guid ID { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }

        public virtual decimal? PricePerHourPoundsSterling { get; set; }

        public virtual int? MaxCapacityPersons { get; set; }

        public virtual int? AreaMetresSquared { get; set; }

        public string WebLink { get; set; }

        public virtual ICollection<SpaceContact> Contacts { get; set; }
        public virtual ICollection<Photograph> Photographs { get; set; }
        public virtual ICollection<CalendarEntry> Entries { get; set; }


        public DateTime AddedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public DateTime? DeletedUtc { get; set; }
    }

    public class Photograph
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public byte[] Jpeg { get; set; }

        public virtual Space Space { get; set; }

        public DateTime AddedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public DateTime? DeletedUtc { get; set; }
    }

    public class SpaceContact
    {
        public Guid ID { get; set; }

        public virtual Space Space { get; set; }
        public virtual Contact Contact { get; set; }

        public bool IsPrimary { get; set; }

        public DateTime AddedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public DateTime? DeletedUtc { get; set; }
    }


    public class Contact
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public string Street { get; set; }
        public string PostCode { get; set; }
        public string LoginEmail { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public DateTime AddedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public DateTime? DeletedUtc { get; set; }
    }

    public enum PhoneNumberType
    {
        Home,
        Work,
        Mobile,
        Custom
    }

    public class PhoneNumber
    {
        public Guid ID { get; set; }

        public string Number { get; set; }

        public PhoneNumberType Type { get; set; }
        public string CustomType { get; set; }
        public bool IsPrimary { get; set; }

        public DateTime AddedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public DateTime? DeletedUtc { get; set; }
    }

    public enum CalendarEntryType
    {
        Free,
        Busy,
        Hired,
        NotHireable
    }

    public class CalendarEntry
    {
        public Guid ID { get; set; }

        public CalendarEntryType Type { get; set; }
        public DateTime StartUtc { get; set; }
        public DateTime EndUtc { get; set; }
        
        public virtual Contact Hirer { get; set; }

        public DateTime AddedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }
        public DateTime? DeletedUtc { get; set; }
    }
}