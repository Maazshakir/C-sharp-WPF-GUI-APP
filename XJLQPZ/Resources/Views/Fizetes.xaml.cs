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
using XJLQPZ.core;

namespace XJLQPZ.Resources
{
    /// <summary>
    /// Interaction logic for Fizetes.xaml
    /// </summary>
    public partial class Fizetes : Window
    {
        public Fizetes()
        {
            InitializeComponent();
            UpdateText();
        }

        private void UpdateText() {
            munkalapokSzama.Text = $"{Log.munkaLapok.Count} db";
            anyagKoltseg.Text = $"{anyagKoltsegKalkulator()} FT";
            munkaDíj.Text = $"{munkaDijKalkulator()} FT";
            munkakSzama.Text = $"{munkakSzamaKalkulator()} db";
            Öszzes.Text = $"{anyagKoltsegKalkulator() + munkaDijKalkulator()} FT";
            osszMunkaIdo.Text = MunkaIdoKalkulator();
   
        }

        private int anyagKoltsegKalkulator() {
            int anyagkoltseg = 0;
            for (int i = 0; i < Log.munkaLapok.Count; i++) {
                anyagkoltseg = anyagkoltseg + Log.munkaLapok[i].anyagKöltseg;
            }
            return anyagkoltseg;
        }

        private int munkakSzamaKalkulator() {
            int munkakSzama = 0;
            for (int i = 0; i < Log.munkaLapok.Count; i++)
            {
                munkakSzama = munkakSzama + Log.munkaLapok[i].munkakSzama;
            }
            return munkakSzama;
        }

        private int munkaDijKalkulator()
        {
            int munkadij = 0;
            for (int i = 0; i < Log.munkaLapok.Count; i++)
            {
                munkadij = munkadij + Log.munkaLapok[i].munkadíj;
            }
            return munkadij;
        }

        private String MunkaIdoKalkulator() {
            int Munkaido = 0;
            for (int i = 0; i < Log.munkaLapok.Count; i++)
            {
                Munkaido = Munkaido + Log.munkaLapok[i].munkaIdo;
            }


            return $"{Munkaido / 60} óra {Munkaido%60} perc";
        }

        private void close(object sender, EventArgs e)
        {
            MessageBox.Show("Payment Sucessfull, Thanks for shopping with us!");
            Log.munkaLapok.Clear();
            
        }
    }
}
