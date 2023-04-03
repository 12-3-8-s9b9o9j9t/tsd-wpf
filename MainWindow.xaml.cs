using HomeLibrary;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace tsd_wpf
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
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
    }
}
