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
using XJLQPZ.core;

namespace XJLQPZ.Resources.Views
{
    /// <summary>
    /// Interaction logic for Munkalap.xaml
    /// </summary>
    public partial class Munkalap : Window
    {
        List<Work> workList = new();
        List<TextBlock> mDijtextblocks = new();
        private int osszMunkadij = 0;
        private int osszAnyagkKoltseg = 0;
        List<int> Logindexes = new();
        int munkakSzama = 0;
        int OsszMunkaIdo = 0;
        public Munkalap(String filename)
        {
            InitializeComponent();
            fillData(filename);
        }

        public void fillData(String filename,bool editFile = false,int fileIndex=-1)
        {

            Loader<Work> loader = new();
            workList = loader.LoadFile(filename, Parser.Parse);
            int i = 0;
            foreach (Work work in workList)
            {
                addToGUI(work.Mnev, $"{work.anyagKoltseg} FT", work.getIdo(), $"{work.getmunkaDij()} FT", i);
                addCheckBox(i);
                i++;
            }
        }

        private void addNameToGUI(String name, int index)
        {
            TextBlock DynamictextBlock1 = new();
            DynamictextBlock1.Name = $"DynamictextBlock1{index}";
            stringGUIFormat(DynamictextBlock1);
            DynamictextBlock1.Text = name;
            M_nev.Children.Add(DynamictextBlock1);
        }

        private void addKoltsegToGUI(String koltseg, int index)
        {
            TextBlock DynamictextBlock2 = new();
            DynamictextBlock2.Name = $"DynamictextBlock2{index}";
            numberGUIFormat(DynamictextBlock2);
            DynamictextBlock2.Text = koltseg;
            Anyagkoltseg.Children.Add(DynamictextBlock2);
        }

        private void addMidoToGUI(String Mido, int index)
        {
            TextBlock DynamictextBlock3 = new();
            numberGUIFormat(DynamictextBlock3);
            DynamictextBlock3.Name = $"DynamictextBlock3{index}";
            DynamictextBlock3.Text = Mido;
            MunkaIdo.Children.Add(DynamictextBlock3);
        }

        private void addMdijToGUI(String Mdij)
        {

            TextBlock DynamictextBlock4 = new();
            numberGUIFormat(DynamictextBlock4);
            DynamictextBlock4.Text = Mdij;
            DynamictextBlock4.Visibility = Visibility.Hidden;
            mDijtextblocks.Add(DynamictextBlock4);
            Munkadij.Children.Add(DynamictextBlock4);
        }

        private void showMunkadij(int Index)
        {
            mDijtextblocks[Index].Visibility = Visibility.Visible;
        }

        private void hideMunkaDij(int Index)
        {
            mDijtextblocks[Index].Visibility = Visibility.Hidden;
        }

        private void addCheckBox(int index)
        {
            CheckBox checkbox = new CheckBox();
            checkBox.Name = $"checkbox{index}";
            checkBoxGUIFormat(checkbox);
            checkBox.Children.Insert(0, checkbox);
            
            checkbox.Checked += checkbox_Checked;
            checkbox.Unchecked += checkBox_Unchecked;

            
        }

        void checkbox_Checked(object sender, EventArgs e)
        {
            osszMunkadij = osszMunkadij + workList[checkBox.Children.IndexOf((CheckBox)sender)].getmunkaDij();
            osszAnyagkKoltseg = osszAnyagkKoltseg + workList[checkBox.Children.IndexOf((CheckBox)sender)].anyagKoltseg;

            showMunkadij(checkBox.Children.IndexOf((CheckBox)sender));
            Logindexes.Add(checkBox.Children.IndexOf((CheckBox)sender));
            munkakSzama += 1;
            OsszMunkaIdo += workList[checkBox.Children.IndexOf((CheckBox)sender)].idoPerc + workList[checkBox.Children.IndexOf((CheckBox)sender)].idoOra * 60;

            OsszMunkadij.Text = $"{osszMunkadij} FT";
            OsszAnyagKoltseg.Text = $"{osszAnyagkKoltseg} FT";

        }

        void checkBox_Unchecked(object sender, EventArgs e)
        {
            osszMunkadij = osszMunkadij - workList[checkBox.Children.IndexOf((CheckBox)sender)].getmunkaDij();
            osszAnyagkKoltseg = osszAnyagkKoltseg - workList[checkBox.Children.IndexOf((CheckBox)sender)].anyagKoltseg;

            hideMunkaDij(checkBox.Children.IndexOf((CheckBox)sender));
            Logindexes.Remove(checkBox.Children.IndexOf((CheckBox)sender));
            munkakSzama -= 1;
            OsszMunkaIdo -= workList[checkBox.Children.IndexOf((CheckBox)sender)].idoPerc + workList[checkBox.Children.IndexOf((CheckBox)sender)].idoOra * 60;

            OsszAnyagKoltseg.Text = $"{osszAnyagkKoltseg} FT";
            OsszMunkadij.Text = $"{osszMunkadij} FT";
        }

        private void addToGUI(String name, String a_koltseg, String m_ido, String m_dij, int index)
        {
            addNameToGUI(name, index);
            addKoltsegToGUI(a_koltseg, index);
            addMidoToGUI(m_ido, index);
            addMdijToGUI(m_dij);
        }

        private void numberGUIFormat(TextBlock block)
        {
            block.HorizontalAlignment = HorizontalAlignment.Center;
            block.VerticalAlignment = VerticalAlignment.Center;
            block.FontSize = 16;
        }

        private void checkBoxGUIFormat(CheckBox checkBox)
        {
            checkBox.Margin = new Thickness(0, 2.6, 0, 2.6);
            checkBox.Height = 16;
            checkBox.Width = 16;

        }

        private void stringGUIFormat(TextBlock block)
        {
            block.HorizontalAlignment = HorizontalAlignment.Left;
            block.VerticalAlignment = VerticalAlignment.Center;
            block.FontSize = 16;
        }


        private void ClearGuiData()
        {
            M_nev.Children.Clear();
            Anyagkoltseg.Children.Clear();
            MunkaIdo.Children.Clear();
            checkBox.Children.Clear();
            Munkadij.Children.Clear();
            osszMunkadij = 0;
            osszAnyagkKoltseg = 0;
            OsszAnyagKoltseg.Text = $"{osszAnyagkKoltseg} FT";
            OsszMunkadij.Text = $"{osszMunkadij} FT";
        }

        private void submitClicked(object sender, RoutedEventArgs e)
        {
            if (osszAnyagkKoltseg > 0 || osszMunkadij > 0) {
                MessageBoxResult result = MessageBox.Show("Rögziti a Munkalapot?", "Rögzités", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes )
                {
                    Log.munkaLapok.Add(new MunkaLapok(Int32.Parse(OsszAnyagKoltseg.Text.Trim('F', 'T')),
                        Int32.Parse(OsszMunkadij.Text.Trim('F', 'T')),munkakSzama,OsszMunkaIdo));
                    ClearGuiData();
                    
                    Close();
                }
            }
            else {
                MessageBox.Show("Please Select atleast one work");
                Logindexes.Clear();
            }

        }
    }
}
