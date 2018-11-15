using System;
using System.Collections.Generic;
using System.Text;

namespace ParkShark.Domain.Divisions
{
    public class Division
    {
        public Guid GuidID { get; private set; }
        public string Name { get; private set; }
        public string OriginalName { get; private set; }
        public string Director { get; private set; }

        private Division(string name, string originalName, string director)
        {
            Name = name;
            OriginalName = originalName;
            Director = director;
            GuidID = Guid.NewGuid();
        }

        public static Division CreateNewDivision(string name, string originalName, string director)
        {
            if (director == null || name == null || originalName == null)
            {
                return null;
            }
            return new Division(name, originalName, director);
        }



    }
}
