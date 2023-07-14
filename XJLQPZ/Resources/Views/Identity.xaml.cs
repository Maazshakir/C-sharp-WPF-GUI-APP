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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XJLQPZ.Resources
{
    /// <summary>
    /// Interaction logic for Identity.xaml
    /// </summary>
    public partial class Identity : Window
    {
        public Identity()
        {
            InitializeComponent();
            updateDate();
        }

        private void updateDate() { 
            Date.Text = DateTime.Now.ToShortDateString();
        }
    }
}
