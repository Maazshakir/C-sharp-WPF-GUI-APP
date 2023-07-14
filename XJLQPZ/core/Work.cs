using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace XJLQPZ.core
{
    internal class Work
    {
        public String Mnev { get; }
        public int anyagKoltseg { get; }
        public int osszIdoperc; /// <summary>
        /// we get the total minutes to calculate minutes and hours separately
        /// </summary>
        public int idoOra { get { return osszIdoperc / 60; } }
        public int idoPerc { get { return osszIdoperc % 60; } }
        private int munkaDij;
        public Work(String Mnev, int osszIdoperc, int anyagkoltseg)
        {
            this.Mnev = Mnev;
            this.osszIdoperc = osszIdoperc;
            this.anyagKoltseg = anyagkoltseg;
        }

        public String getIdo() {
            return $"{idoOra} ó {idoPerc} perc";
        }

        public int getmunkaDij()
        {
            munkaDij = idoOra * 15000;
            if (idoPerc >= 0)
            {
                munkaDij = munkaDij + idoPerc*(15000/60);
            }
            return munkaDij;
        }
    }
}
