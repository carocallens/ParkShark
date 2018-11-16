using ParkShark.Domain.Divisions;
using ParkShark.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.ParkingLots
{
    public class ParkingLotBuilder
    {
        public string ParkingLotID { get; private set; }
        public string Name { get; private set; }
        public int DivisionID { get; private set; }
        public BuildingType BuildingtypeID { get; private set; }
        public int Capacity { get; private set; }
        public int ContactPersonID { get; private set; }
        public Address Address { get; private set; }
        public decimal PricePerHour { get; private set; }

        private  ParkingLotBuilder()
        {
   
        }

        public static ParkingLotBuilder CreateNewParkingLot()
        {
            return new ParkingLotBuilder();
        }

        public ParkingLotBuilder WithName(string name)
        {
            this.Name = name;
            return this;
        }

        public ParkingLotBuilder WithDivision(int division)
        {
            this.DivisionID = division;
            return this;
        }

        public ParkingLotBuilder WithBuildingType(BuildingType buildingType = BuildingType.Abovehground)
        {
            this.BuildingtypeID = buildingType;
            return this;
        }

        public ParkingLotBuilder WithCapacity(int capacity)
        {
            this.Capacity = capacity;
            return this;
        }

        public ParkingLotBuilder WithContactPersonID(int contactPersonID)
        {

            this.ContactPersonID = contactPersonID;
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
