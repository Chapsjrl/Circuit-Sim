using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcadAPP = Autodesk.AutoCAD.ApplicationServices.Application;

namespace CircuitSimulator.UI
{
    public partial class FuentesUI : UserControl
    {
        public String PulsoName;
        public String FuenteName;

        public FuentesUI()
        {
            InitializeComponent();
            //Scroll vertical y horizontal automaticos según el tamaño
            AutoScrollMinSize = new Size(0, 1);
            AutoScroll = true;
        }

        private void Pulso_Click(object sender, EventArgs e)
        {
            PulsoName = (sender as Button).Name;
            var doc = AcadAPP.DocumentManager.MdiActiveDocument;
            //switch{ }
            doc.SendStringToExecute("Pulso" + PulsoName + " ", true, false, false);
        }

        private void VCC_Click(object sender, EventArgs e)
        {
            FuenteName = (sender as Button).Name;
            var doc = AcadAPP.DocumentManager.MdiActiveDocument;
            //switch{ }
            doc.SendStringToExecute("Dibuja" + FuenteName + " ", true, false, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var doc = AcadAPP.DocumentManager.MdiActiveDocument;
            //switch{ }
            doc.SendStringToExecute("DibujaSalida ", true, false, false);
        }
    }
}
