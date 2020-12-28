using Promos.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Controls;

namespace Promos
{
    class Penawaran
    {
        /// <summary>
        /// Interaction logic for Penawaran.xaml
        /// </summary>

        public partial class Penawaran : Window
        {
            Promos.Controller.PenawaranController controller;
            OnPenawaranChangedListener listener;
            private object listPenawaran;

            public Penawaran()
            {
                InitializeComponent();

                controller = new Promos.Controller.PenawaranController();
                listPenawaran.ItemsSource = controller.getItems();

                generateContentPenawaran();

            }

            public void SetOnItemSelectedListener(OnPenawaranChangedListener listener)
            {
                this.listener = listener;
            }

            private void generateContentPenawaran()
            {
                Item drink1 = new Item("Ice tea", 8000);
                Item drink2 = new Item("Ice lemon tea", 5000);
                Item drink3 = new Item("Ice lemon", 7000);
                Item food4 = new Item("Mie Ayam", 10000);
                Item food5 = new Item("Gado-gado", 14000);
                Item food6 = new Item("Sate", 15000);

                controller.addItem(drink1);
                controller.addItem(drink2);
                controller.addItem(drink3);
                controller.addItem(food4);
                controller.addItem(food5);
                controller.addItem(food6);

                listPenawaran.Items.Refresh();
            }

            private void ListPenawaran_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                ListBox listbox = sender as ListBox;
                Item item = listbox.SelectedItem as Item;
                Debug.WriteLine(item.title);

                this.listener.onPenawaranSelected(item);
            }
        }

        public interface OnPenawaranChangedListener
        {
            void onPenawaranSelected(Item item);
        }

        internal void SetOnItemSelectedListener(MainWindow.MainWindow mainWindow)
        {
            throw new NotImplementedException();
        }

        internal void Show()
        {
            throw new NotImplementedException();
        }
    }
}
