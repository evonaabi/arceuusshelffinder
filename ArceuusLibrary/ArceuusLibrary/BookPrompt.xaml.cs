using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ArceuusLibrary
{
    /// <summary>
    /// Interaction logic for BookPrompt.xaml
    /// </summary>
    public partial class BookPrompt : Window
    {
        string[] bookNames = new string[17] { "Dark manuscript",
                                                "Byrne's coronation speech",
                                                "Eathram & rada extract",
                                                "Hosidius letter",
                                                "Ideology of darkness",
                                                "Killing of a king",
                                                "Rada's census",
                                                "Rada's journey",
                                                "Ricktor's diary(7)",
                                                "Soul journey",
                                                "Transportation incantations",
                                                "Transvergence theory",
                                                "Treachery of royalty",
                                                "Tristessa's tragedy",
                                                "Twill accord",
                                                "Wintertodt parable",
                                                "Varlamore envoy" };

        string[] fileNames = new string[17] { "Dark_manuscript.png",
                                                "Byrne's_coronation_speech.png",
                                                "Eathram_&_rada_extract.png",
                                                "Hosidius_letter.png",
                                                "Ideology_of_darkness.png",
                                                "Killing_of_a_king.png",
                                                "Rada's_census.png",
                                                "Rada's_journey.png",
                                                "Ricktor's_diary_(7).png",
                                                "Soul_journey.png",
                                                "Transportation_incantations.png",
                                                "Transvergence_theory.png",
                                                "Treachery_of_royalty.png",
                                                "Tristessa's_tragedy.png",
                                                "Twill_accord.png",
                                                "Wintertodt_parable.png",
                                                "Varlamore_envoy.png" };

        Book[] books = new Book[17];

        public BookPrompt()
        {
            InitializeComponent();
            InitializeBooks();
        }

        private void InitializeBooks()
        {
            books[0] = book1;
            books[1] = book2;
            books[2] = book3;
            books[3] = book4;
            books[4] = book5;
            books[5] = book6;
            books[6] = book7;
            books[7] = book8;
            books[8] = book9;
            books[9] = book10;
            books[10] = book11;
            books[11] = book12;
            books[12] = book13;
            books[13] = book14;
            books[14] = book15;
            books[15] = book16;
            books[16] = book17;

            int i = 0;
            foreach (Book book in books)
            {
                //Book icon
                BitmapImage logo = new BitmapImage(new Uri("pack://application:,,,/ArceuusLibrary;component/books/" + fileNames[i], UriKind.Absolute));
                book.bookIcon.Source = logo;

                //Name text
                book.bookName.Text = bookNames[i];

                //Number text
                book.bookNumber.Text = i == 0 ? "M" : i.ToString();

                //Click event
                book.MouseDown += Book_MouseDown;

                i++;
            }
        }

        private void Book_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Book book = sender as Book;
            MainWindow.newestBook = Array.IndexOf(books, book);
            this.DialogResult = true;
        }
    }
}
