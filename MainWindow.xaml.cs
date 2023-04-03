using HomeLibrary;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace tsd_wpf
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Darkness = 255;
        }

        private ObservableCollection<Book> books = new(MyBookCollection.GetMyCollection());

        public ObservableCollection<Book> Books
        {
            get { return books; }
            set { books = value; }
        }

        private Book selectedBook;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set {
                selectedBook = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedBook"));
            }
        }

        private int darkness;

        public int Darkness
        {
            get { return darkness; }
            set {
                if (value < 0)
                {
                    darkness = 0;
                }
                else if (value > 255)
                {
                    darkness = 255;
                }
                else
                {
                    darkness = value;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Darkness"));
                UpdateColor();
            }
        }


        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            AddBook a = new AddBook();
            a.ShowDialog();
            if (a.DialogResult == true)
            {
                Books.Add(a.NewBook);
            }
        }

        private void btDel_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBook != null)
            {
                var res = MessageBox.Show("Are you sure you want to delete this book?", "Delete book", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    Books.Remove(SelectedBook);
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete", "Delete book", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void UpdateColor()
        {
            firstRow.Background = new SolidColorBrush(Color.FromArgb(255, 255, (byte)Darkness, 255));
        }

        private void tb_Dark_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tb_Dark.Text == string.Empty)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Darkness"));
            }
        }
    }
}
