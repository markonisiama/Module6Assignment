namespace Module6Assignment;

public partial class ContactDetailsPage : ContentPage
{
    public ContactDetailsPage(Contact contact)
    {
        InitializeComponent();
        BindingContext = contact;
    }
}