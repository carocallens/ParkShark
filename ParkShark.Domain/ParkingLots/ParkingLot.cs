using ParkShark.Domain.Divisions;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.ParkingLots
{
    public class ParkingLot
    {
        public string ParkingLotID { get; private set; }
        public string Name { get; private set; }
        public int DivisionID { get; private set; }
        public Division Division { get; private set; }
        public BuildingType BuildingtypeID { get; private set; }
        public int Capacity { get; private set; }
        public int ContactPersonID { get; private set; }
        public ContactPerson ContactPerson { get; private set; } 
        public Address Address { get; private set; }
        public decimal PricePerHour { get; private set; }

        private ParkingLot(string name, int divisionId, BuildingType buildingTypeId, int capacity, int contactPersonId, Address address, decimal pricePerHour)
        {
            ParkingLotID = Guid.NewGuid().ToString();
            Name = name;
            DivisionID = divisionId;
            BuildingtypeID = buildingTypeId;
            Capacity = capacity;
            ContactPersonID = contactPersonId;
            Address = address;
            PricePerHour = pricePerHour;
        }

        public static ParkingLot CreateParkingLot(ParkingLotBuilder builder)
        {
            if(string.IsNullOrWhiteSpace(builder.Name) || 
                builder.Address == null || 
                builder.Capacity <= 0 || 
                builder.ContactPersonID <= 0 || 
                builder.DivisionID <= 0 || 
                builder.PricePerHour <0)
            {
                return null;
            }

            return new ParkingLot(
                builder.Name, 
                builder.DivisionID, 
                builder.BuildingtypeID, 
                builder.Capacity, 
                builder.ContactPersonID, 
                builder.Address, 
                builder.PricePerHour);
        }
    }
}
