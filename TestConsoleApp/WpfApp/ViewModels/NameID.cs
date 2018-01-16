namespace WpfApp.ViewModels
{
    public class NameID
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
