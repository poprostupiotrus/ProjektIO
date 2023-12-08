using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaProjektIO
{
    internal class CustomButton:Button
    {
        public CustomButton()
        {
            BackColor = Color.LightGray;
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Arial", 16);
            FlatAppearance.BorderSize = 0;
        }
    }
}
