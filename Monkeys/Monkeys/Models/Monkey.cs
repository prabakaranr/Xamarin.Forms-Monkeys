using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Monkeys.Models
{
    public class Monkey : INotifyPropertyChanged
    {
        private string name;
        private string location;
        private string details;
        private string image;
        private bool isLoaded;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Location
        {
            get => location; set
            {
                location = value;
                OnPropertyChanged();
            }
        }
        public string Details
        {
            get => details; set
            {
                details = value;
                OnPropertyChanged();
            }
        }

        //URL for our monkey image!
        public string Image
        {
            get => image; set
            {
                image = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoaded { get => isLoaded; set { isLoaded = value; OnPropertyChanged(); } }

        public string NameSort => Name[0].ToString();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Load(string location, string details, string image)
        {
            IsLoaded = true;

            Location = location;
            Details = details;
            Image = image;
        }
    }
}