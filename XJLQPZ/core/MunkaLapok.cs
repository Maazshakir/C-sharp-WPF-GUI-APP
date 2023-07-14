using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XJLQPZ.core
{
    internal class MunkaLapok
    {
        public int anyagKöltseg { get; }
        public int munkadíj { get; }
        public int munkakSzama { get; }
        public int munkaIdo{get;}

        public MunkaLapok(int anyagKöltseg, int munkadíj,int munkakSzama,int munkaIdo)
        {
            this.anyagKöltseg = anyagKöltseg;
            this.munkadíj = munkadíj;
            this.munkakSzama = munkakSzama;
            this.munkaIdo = munkaIdo;
        }
    }
}
