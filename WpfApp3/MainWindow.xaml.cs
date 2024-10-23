using System.Collections.Generic;
using System.Windows;

namespace MushroomApp
{
    public partial class MainWindow : Window
    {
        private List<Mushroom> mushrooms;

        public MainWindow()
        {
            InitializeComponent();
            InitializeMushrooms();
            DisplayMushrooms();
        }

        private void InitializeMushrooms()
        {
            mushrooms = new List<Mushroom>
            {
               
            };
        }

        private void DisplayMushrooms()
        {
            listBoxMushrooms.ItemsSource = null; // Сбрасываем источник
            listBoxMushrooms.ItemsSource = mushrooms; // Устанавливаем обновленный источник
        }

        private void listBoxMushrooms_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (listBoxMushrooms.SelectedItem is Mushroom selectedMushroom)
            {
                textBoxId.Text = selectedMushroom.Id.ToString();
                textBoxName.Text = selectedMushroom.Name;
                textBoxColor.Text = selectedMushroom.Color;
                checkBoxIsEdible.IsChecked = selectedMushroom.IsEdible;
                textBoxWeight.Text = selectedMushroom.Weight.ToString();
                textBoxHeight.Text = selectedMushroom.Height.ToString();
                textBoxCapRadius.Text = selectedMushroom.CapRadius.ToString();
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxMushrooms.SelectedItem is Mushroom selectedMushroom)
            {
                selectedMushroom.Name = textBoxName.Text;
                selectedMushroom.Color = textBoxColor.Text;
                selectedMushroom.IsEdible = checkBoxIsEdible.IsChecked ?? false;
                selectedMushroom.Weight = double.TryParse(textBoxWeight.Text, out var weight) ? weight : 0;
                selectedMushroom.Height = double.TryParse(textBoxHeight.Text, out var height) ? height : 0;
                selectedMushroom.CapRadius = double.TryParse(textBoxCapRadius.Text, out var radius) ? radius : 0;
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var newMushroom = new Mushroom
            {
                Id = mushrooms.Count + 1, // Простой способ генерации ID
                Name = textBoxNewName.Text,
                Color = textBoxNewColor.Text,
                IsEdible = checkBoxNewIsEdible.IsChecked ?? false,
                Weight = double.TryParse(textBoxNewWeight.Text, out var weight) ? weight : 0,
                Height = double.TryParse(textBoxNewHeight.Text, out var height) ? height : 0,
                CapRadius = double.TryParse(textBoxNewCapRadius.Text, out var radius) ? radius : 0
            };

            mushrooms.Add(newMushroom);
            DisplayMushrooms();

            // Очистка полей ввода
            textBoxNewName.Clear();
            textBoxNewColor.Clear();
            checkBoxNewIsEdible.IsChecked = false;
            textBoxNewWeight.Clear();
            textBoxNewHeight.Clear();
            textBoxNewCapRadius.Clear();
        }
    }
}
