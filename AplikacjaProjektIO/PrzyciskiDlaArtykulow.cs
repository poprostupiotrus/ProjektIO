using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaProjektIO
{
    internal class PrzyciskiDlaArtykulow:CustomButton
    {
        public PrzyciskiDlaArtykulow()
        {
            Height = 50;
            Dock = DockStyle.Bottom;
            Visible = false;
        }
    }
}
