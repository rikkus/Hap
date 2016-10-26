namespace Hap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Hap.Models.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Hap.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Hap.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            var april = new DateTime(2016, 4, 3, 2, 1, 0);
            var may = new DateTime(2016, 5, 4, 3, 2, 1);
            var september2015 = new DateTime(2015, 9, 9, 9, 9, 9, 9);

            var aliceHome = new PhoneNumber
            {
                AddedUtc = september2015,
                Type = PhoneNumberType.Home,
                ID = Guid.NewGuid(),
                Number = "0123469234234"
            };

            var aliceMobile = new PhoneNumber
            {
                AddedUtc = september2015,
                Type = PhoneNumberType.Mobile,
                ID = Guid.NewGuid(),
                Number = "0778129812398213",
                IsPrimary = true
            };

            context.PhoneNumbers.AddOrUpdate(pn => pn.Number, new[] { aliceHome, aliceMobile });
            
            var alice = new Contact
            {
                ID = Guid.NewGuid(),
                AddedUtc = september2015,
                Name = "Alice",
                PhoneNumbers = new[] { aliceHome, aliceMobile }
            };

            var bob = new Contact
            {
                ID = Guid.NewGuid(),
                AddedUtc = september2015,
                Name = "Bob"
            };

            var clive = new Contact
            {
                ID = Guid.NewGuid(),
                AddedUtc = september2015,
                Name = "Clive"
            };

            context.Contacts.AddOrUpdate(
                c => c.Name,
                new[] { alice, bob, clive }
                );
            
            context.Spaces.AddOrUpdate(
                s => s.ShortDescription,
                new Space
                {
                    ShortDescription = "Space 1",
                    AddedUtc = april,
                    ID = Guid.NewGuid(),
                    Contacts = new[] { new SpaceContact {
                        ID = Guid.NewGuid(),
                        AddedUtc = april,
                        Contact = alice,
                        IsPrimary = true
                    },
                    new SpaceContact
                    {
                        ID= Guid.NewGuid(),
                        AddedUtc = april,
                        Contact = bob,

                    }
                    }

                },
                new Space
                {
                    ShortDescription = "Space 2",
                    AddedUtc = may,
                    ID = Guid.NewGuid(),
                    Contacts = new []
                    {
                        new SpaceContact
                        {
                            ID = Guid.NewGuid(),
                            AddedUtc = may,
                            Contact = clive,
                            IsPrimary = true
                        }
                    }
                }
                );
        }
    }
}
