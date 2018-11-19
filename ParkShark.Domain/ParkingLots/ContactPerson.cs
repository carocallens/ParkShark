using ParkShark.Domain.Members;
using System;
using System.Net.Mail;

namespace ParkShark.Domain.ParkingLots
{
    public class ContactPerson
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address Address { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string MobilePhoneNumber { get; private set; }

        private ContactPerson() { }

        private ContactPerson(string firstName, string lastName, Address address, string email, string phoneNumber, string mobilePhoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
            MobilePhoneNumber = mobilePhoneNumber;
        }

        public static ContactPerson CreateNewContactPerson(string firstName, string lastName, Address address, string email, string phoneNumber, string mobilePhoneNumber)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || address == null || !IsMailValid(email))
            {
                return null;
            }

            return new ContactPerson(firstName, lastName, address, email, phoneNumber, mobilePhoneNumber);
        }

        private static bool IsMailValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}