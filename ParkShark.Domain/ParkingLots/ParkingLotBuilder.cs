using ParkShark.Domain.Members;
using System;

namespace ParkShark.Domain.ParkingLots
{
    public class ParkingLotBuilder
    {
        public string Name { get; private set; }
        public Guid DivisionID { get; private set; }
        public BuildingType Buildingtype { get; private set; }
        public int Capacity { get; private set; }
        public Address Address { get; private set; }
        public decimal PricePerHour { get; private set; }
        public ContactPerson ContactPerson { get; private set; }

        public static ParkingLotBuilder CreateNewParkingLot()
        {
            return new ParkingLotBuilder();
        }

        public ParkingLotBuilder WithName(string name)
        {
            this.Name = name;
            return this;
        }

        public ParkingLotBuilder WithDivision(Guid division)
        {
            this.DivisionID = division;
            return this;
        }

        public ParkingLotBuilder WithBuildingType(BuildingType buildingType = BuildingType.AboveGround)
        {
            this.Buildingtype = buildingType;
            return this;
        }

        public ParkingLotBuilder WithCapacity(int capacity)
        {
            this.Capacity = capacity;
            return this;
        }

        public ParkingLotBuilder WithContactPerson(ContactPerson contactPerson)
        {
            this.ContactPerson = contactPerson;
            return this;
        }

        public ParkingLotBuilder WithAddress(Address address)
        {
            this.Address = address;
            return this;
        }

        public ParkingLotBuilder WithPricePerHour(decimal pricePerHour)
        {
            this.PricePerHour = pricePerHour;
            return this;
        }

        public ParkingLot Build()
        {
            return ParkingLot.CreateParkingLot(this);
        }

    }
}
