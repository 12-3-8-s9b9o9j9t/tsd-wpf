using HomeLibrary;
using System;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace tsd_wpf
{
    public partial class AddBook : Window, INotifyPropertyChanged, IDataErrorInfo
    {
        public AddBook()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private string bookTitle;

        public string BookTitle
        {
            get { return bookTitle; }
            set 
            { 
                bookTitle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BookTitle"));
            }
        }

        private string bookAuthor;

        public string BookAuthor
        {
            get { return bookAuthor; }
            set
            {
                bookAuthor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BookAuthor"));
            }
        }

        private string bookYear;

        public string BookYear
        {
            get { return bookYear; }
            set
            {
                bookYear = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BookYear"));
            }
        }


        public bool BookIsRead { get; set; }

        private BookFormat? bookFormat;

        public BookFormat? BookFormat
        {
            get { return bookFormat; }
            set { bookFormat = value; }
        }

        private string validationMessage;


        public Book? NewBook { get; set; }

        public string Error
        {
            get { return "Error"; }
        }

        public string this[string columnName]
        {
            get { return Validate(columnName); }
        }

        private string Validate(string propertyName)
        {
            validationMessage = string.Empty;

            switch (propertyName)
            {
                case "BookTitle":
                    if (this.BookTitle.Equals(string.Empty))
                    {
                        validationMessage = Error;
                    }
                    break;
                case "BookAuthor":
                    if (this.BookAuthor.Equals(string.Empty))
                    {
                        validationMessage = Error;
                    }
                    break;
                case "BookYear":
                    try 
                    {
                        int y = int.Parse(BookYear);
                        if (y == 0)
                        {
                            validationMessage = Error;
                        }
                    }
                    catch (FormatException)
                    {
                        validationMessage = Error;
                    }
                    break;
                case "BookFormat":
                    if (this.BookFormat == null)
                    {
                        validationMessage = Error;
                    }
                    break;
            }

            return validationMessage;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void bt_Ok_Click(object sender, RoutedEventArgs e)
        {
            if (validationMessage.Equals("Error"))
            {
                MessageBox.Show("Some fields are incorrectly filled","Incorrect Data",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            else
            {
                DialogResult = true;
                NewBook = new Book() { Author = BookAuthor, Title = BookTitle, Year = int.Parse(BookYear), IsRead = BookIsRead, Format = (BookFormat)BookFormat };
                Close();
            }
        }

        private void bt_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
