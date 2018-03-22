using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;


//https://code.msdn.microsoft.com/windowsdesktop/Sorting-a-WPF-ListView-by-5769086f

namespace Homework03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private ListSortDirection _sortDirection;
        private GridViewColumnHeader _sortColumn;
        public MainWindow()
        {
            InitializeComponent();

            uxList.ItemsSource = UserList();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription("Password", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void uxListClick(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = e.OriginalSource as GridViewColumnHeader;
            if (column == null) return;

            if (_sortColumn == column)
            {
                _sortDirection = _sortDirection == ListSortDirection.Ascending ?
                                     ListSortDirection.Descending :
                                     ListSortDirection.Ascending;
            }
            else
            {
                if (_sortColumn != null)
                {
                    _sortColumn.Column.HeaderTemplate = null;
                    _sortColumn.Column.Width = _sortColumn.ActualWidth - 20;
                }

                _sortColumn = column;
                _sortDirection = ListSortDirection.Ascending;
                column.Column.Width = column.ActualWidth + 20;
            }

            string header = string.Empty;

            Binding b = _sortColumn.Column.DisplayMemberBinding as Binding;
            if(b != null)
            {
                header = b.Path.Path;
            }

            ICollectionView resultDataView = CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            resultDataView.SortDescriptions.Clear();
            resultDataView.SortDescriptions.Add(new SortDescription(header, _sortDirection));
        }
        private List<User> UserList()
        {
            List<User> users = new List<User>();

            users.Add(new User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new User { Name = "Lisa", Password = "3LisaPwd" });

            return users;
        }


    }
}
