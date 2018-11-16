using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkShark.Domain.Divisions
{
    public class Division
    {
        public string GuidID { get; private set; }
        public string Name { get; private set; }
        public string OriginalName { get; private set; }
        public string Director { get; private set; }
        public string ParentDivisionGuidID { get; set; }
        public Division ParentDivision { get; set; }
        public List<Division> SubdivisionsList { get; set; } = new List<Division>();

        private Division()
        {
        }

        private Division(string name, string originalName, string director)
        {
            Name = name;
            OriginalName = originalName;
            Director = director;
            GuidID = Guid.NewGuid().ToString();
        }

        public static Division CreateNewDivision(string name, string originalName, string director)
        {
            if (string.IsNullOrWhiteSpace(director) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(originalName))
            {
                return null;
            }
            return new Division(name, originalName, director);
        }



    }
}
