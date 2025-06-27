using System.Collections.ObjectModel;

namespace Module6Assignment
{
    public partial class ContactsPage : ContentPage
    {
        public ObservableCollection<ContactGroup> ContactGroups { get; set; }

        public ContactsPage()
        {
            InitializeComponent();
            LoadContacts();
            ContactsCollectionView.ItemsSource = ContactGroups;
        }

        void LoadContacts()
        {
            // 4 images reused to make 15 contacts
            var pics = new[] { "profile1.png", "profile2.png", "profile3.png", "profile4.png" };
            var names = new[]
            {
                "Alice Anderson","Alan Adams","Amber Avery",
                "Bob Brown","Bill Bennett","Barbara Black",
                "Charlie Campbell","Cathy Cooper","Carl Collins",
                "David Davis","Derek Dixon","Debbie Drake",
                "Eve Evans","Emma Edwards","Eli Ellis"
            };
            var emails = names.Select(n => n.ToLower().Replace(" ", ".") + "@example.com").ToArray();
            var phones = Enumerable.Range(101, names.Length).Select(i => $"555-{i:0000}").ToArray();
            var descs = new[]
            {
                "College friend","Neighborhood buddy","Yoga classmate",
                "Work colleague","Band mate","Cousin",
                "Gym buddy","Book club","Coffee friend",
                "Gym instructor","Project partner","Volunteer",
                "Mentor","Cousin","Study group"
            };

            var contacts = new List<Contact>();
            for (int i = 0; i < names.Length; i++)
            {
                contacts.Add(new Contact
                {
                    Name = names[i],
                    Email = emails[i],
                    Phone = phones[i],
                    Description = descs[i],
                    Avatar = pics[i % pics.Length]
                });
            }

            var grouped = contacts
                .OrderBy(c => c.Name)
                .GroupBy(c => c.Name[0].ToString())
                .Select(g => new ContactGroup(g.Key, g))
                .OrderBy(g => g.Key);

            ContactGroups = new ObservableCollection<ContactGroup>(grouped);
        }

        async void ContactsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Contact sel)
            {
                await Navigation.PushAsync(new ContactDetailsPage(sel));
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}