using System.ComponentModel;

namespace MushroomApp
{
    public class Mushroom : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string color;
        private bool isEdible;
        private double weight;
        private double height;
        private double capRadius;

        public int Id
        {
            get => id;
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Color
        {
            get => color;
            set { color = value; OnPropertyChanged(nameof(Color)); }
        }

        public bool IsEdible
        {
            get => isEdible;
            set { isEdible = value; OnPropertyChanged(nameof(IsEdible)); }
        }

        public double Weight
        {
            get => weight;
            set { weight = value; OnPropertyChanged(nameof(Weight)); }
        }

        public double Height
        {
            get => height;
            set { height = value; OnPropertyChanged(nameof(Height)); }
        }

        public double CapRadius
        {
            get => capRadius;
            set { capRadius = value; OnPropertyChanged(nameof(CapRadius)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
