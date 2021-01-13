using ContactWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactWebAPI.DBOperation
{
    public static class ContactDB
    {
        static List<ContactEntity> _contacts = new List<ContactEntity>();
        public static List<ContactEntity> GetAllContact() => _contacts;

        public static ContactEntity GetContactByMobile(string mobileNumber) =>
            _contacts.FirstOrDefault(m => m.MobileNumber.Equals(mobileNumber));
        public static ContactEntity GetContactByEmail(string email) => _contacts.FirstOrDefault(m => m.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        public static void CreateContact(ContactEntity contact) => _contacts.Add(contact);

        public static string UpdateContactByMobile(string mobileNumber, ContactEntity contact)
        {
            var detailIndex = _contacts.FindIndex(x => x.MobileNumber.Equals(mobileNumber));
            if (detailIndex > -1)
            {
                _contacts[detailIndex] = contact;
                return "Contact Updated Successfully";
            }
            else
            {
                return $"Unable to find the detail for Mobile Number:{mobileNumber} to Edit";
            }
        }

        public static string DeleteContactByMobile(string mobileNumber)
        {
            var detailIndex = _contacts.FindIndex(x => x.MobileNumber.Equals(mobileNumber));
            if (detailIndex > -1)
            {
                _contacts.RemoveAt(detailIndex);
                return "Contact Deleted Successfully";
            }
            else
                return $"Unable to find the detail for Mobile Number:{mobileNumber} to Delete";
        }
    }
}
