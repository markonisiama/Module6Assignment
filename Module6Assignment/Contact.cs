using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module6Assignment
{
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }  // e.g. "avatar1.png"
    }

    public class ContactGroup : ObservableCollection<Contact>
    {
        public string Key { get; }

        public ContactGroup(string key, IEnumerable<Contact> contacts)
            : base(contacts)
        {
            Key = key;
        }
    }
}
