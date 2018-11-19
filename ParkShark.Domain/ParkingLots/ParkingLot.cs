using ParkShark.Domain.Divisions;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.ParkingLots
{
    public class ParkingLot
    {
        public Guid ParkingLotID { get;  set; }
        public string Name { get;  set; }
        public Guid DivisionID { get;  set; }
        public Division Division { get;  set; }
        public BuildingType BuildingType { get;  set; }
        public int Capacity { get;  set; }
        public ContactPerson ContactPerson { get;  set; } 
        public Address Address { get;  set; }
        public decimal PricePerHour { get;  set; }

        private ParkingLot(string name, Guid divisionId, BuildingType buildingType, int capacity, ContactPerson contactPerson, Address address, decimal pricePerHour)
        {
            Name = name;
            DivisionID = divisionId;
            BuildingType = buildingType;
            Capacity = capacity;
            ContactPerson = contactPerson;
            Address = address;
            PricePerHour = pricePerHour;
        }

        public static ParkingLot CreateParkingLot(ParkingLotBuilder builder)
        {
            if (string.IsNullOrWhiteSpace(builder.Name) ||
                builder.Address == null ||
                builder.Capacity <= 0 ||
                builder.ContactPerson == null ||
                builder.PricePerHour < 0)
            {
                return null;
            }

            return new ParkingLot(
                builder.Name,
                builder.DivisionID,
                builder.Buildingtype,
                builder.Capacity,
                builder.ContactPerson,
                builder.Address,
                builder.PricePerHour);
        }
    }
}
