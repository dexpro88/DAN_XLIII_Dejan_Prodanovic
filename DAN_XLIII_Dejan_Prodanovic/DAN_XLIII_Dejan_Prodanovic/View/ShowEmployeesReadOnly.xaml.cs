using DAN_XLIII_Dejan_Prodanovic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DAN_XLIII_Dejan_Prodanovic.View
{
    /// <summary>
    /// Interaction logic for ShowEmployeesReadOnly.xaml
    /// </summary>
    public partial class ShowEmployeesReadOnly : Window
    {
        public ShowEmployeesReadOnly()
        {
            InitializeComponent();
            this.DataContext = new ShowEmployeesReadOnlyViewModel(this);
        }

        public ShowEmployeesReadOnly(tblEmployee currentUser)
        {
            InitializeComponent();
            this.DataContext = new ShowEmployeesReadOnlyViewModel(this, currentUser);
        }
    }
}
