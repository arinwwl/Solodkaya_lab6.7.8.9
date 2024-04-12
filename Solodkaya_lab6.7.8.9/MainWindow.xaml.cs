﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Solodkaya_lab6._7._8._9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> Listlab1;
        public MainWindow()
        {
            InitializeComponent();
            Listlab1 = new List<int>();
            PopulateList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Listlab1.Add(int.Parse(tbElement.Text));
            Lblist.ItemsSource = null;
            Lblist.ItemsSource = Listlab1;
            tbElement.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int index = Lblist.SelectedIndex;
            Listlab1.RemoveAt(index);
            Lblist.ItemsSource = null;
            Lblist.ItemsSource = Listlab1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<int> numbers = new List<int>();
            foreach (var item in Lblist.Items)
            {
                if (int.TryParse(item.ToString(), out int num))
                {
                    numbers.Add(num);
                }
            }
            if (numbers.Count > 0)
            {
                int min = numbers[0];
                int minIndex = 0;
                for (int i = 1; i < numbers.Count; i++)
                {
                    if (numbers[i] < min)
                    {
                        min = numbers[i];
                        minIndex = i;
                    }
                }

                Result.Text = $"Индекс наименьшего элемента: {minIndex}";
            }
            else
            {
                Result.Text = "Список чисел пуст. Добавьте числа в ListBox.";
            }
        }
        public class Apartment
        {
            public string Street { get; set; }
            public int HouseNumber { get; set; }
            public int ApartmentNumber { get; set; }
        }

        private Stack<Apartment> apartmentStack = new Stack<Apartment>();

        private void AddApartmentButton_Click(object sender, RoutedEventArgs e)
        {
            Apartment newApartment = new Apartment
            {
                Street = "Дерибасовская",
                HouseNumber = 1,
                ApartmentNumber = apartmentStack.Count + 1
            };
            apartmentStack.Push(newApartment);
        }

        private void ShowApartmentsButton_Click(object sender, RoutedEventArgs e)
        {
            ApartmentsListBox.Items.Clear();
            foreach (var apartment in apartmentStack)
            {
                ApartmentsListBox.Items.Add($"Улица: {apartment.Street}, Дом: {apartment.HouseNumber}, Квартира: {apartment.ApartmentNumber}");
            }
        }

        private void CountHousesButton_Click(object sender, RoutedEventArgs e)
        {
            int houseCount = apartmentStack.Where(a => a.Street == "Дерибасовская").Select(a => a.HouseNumber).Distinct().Count();
            MessageBox.Show($"Количество домов на улице Дерибасовская: {houseCount}");
        }

        private void AddApartment_Click(object sender, RoutedEventArgs e)
        {
            int currentHouseNumber = (apartmentStack.Count / 10) + 1;
            currentHouseNumber++;
            MessageBox.Show($"Добавлен новый дом: Дом №{currentHouseNumber}");
            Apartment newApartment = new Apartment
            {
                Street = "Дерибасовская",
                HouseNumber = currentHouseNumber,
                ApartmentNumber = 1
            };

            apartmentStack.Push(newApartment);
        }
        private void AddHouseButton_Click(object sender, RoutedEventArgs e)
        {
            int currentHouseNumber = (apartmentStack.Count / 10) + 1; 
            currentHouseNumber++; 

            MessageBox.Show($"Добавлен новый дом: Дом №{currentHouseNumber}");

            Apartment newApartment = new Apartment
            {
                Street = "Дерибасовская",
                HouseNumber = currentHouseNumber,
                ApartmentNumber = 1
            };

            apartmentStack.Push(newApartment);
        }

        LinkedList<int> linkedList = new LinkedList<int>();
        private void PopulateList()
        {
            for (int i = 1; i <= 10; i++)
            {
                linkedList.AddLast(i);
            }

            foreach (int item in linkedList)
            {
                lbList3.Items.Add(item);
            }
        }

        private void InsertEvenAfterOdd_Click(object sender, RoutedEventArgs e)
        {
            var currentNode = linkedList.First;

            while (currentNode != null)
            {
                if (currentNode.Value % 2 != 0 && currentNode.Next != null)
                {
                    linkedList.AddAfter(currentNode, currentNode.Next.Value);
                    currentNode = currentNode.Next.Next;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }

            lbList3.Items.Clear();
            foreach (int item in linkedList)
            {
                lbList3.Items.Add(item);
            }
        }
    }
}

