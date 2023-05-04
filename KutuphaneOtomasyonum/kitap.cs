using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonum
{
    public class kitap
    {
        public int kitapID { get; set; }
        public string Kitapİsmi { get; set; }
        public string Yazari { get; set; }
        public int SayfaSayisi { get; set; }
        public string YayinEvi { get; set; }
        public int BasimYili { get; set; }
        public loginStatus status { get; set; }



    }
}
