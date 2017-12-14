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
    public partial class CompuertasUI : UserControl
    {
        public String CompuertaName;

        public CompuertasUI()
        {
            InitializeComponent();
            //Scroll vertical y horizontal automaticos según el tamaño
            AutoScrollMinSize = new Size(0, 1);
            AutoScroll = true;

        }

        private void Compuerta_Click(object sender, EventArgs e)
        {
            CompuertaName = (sender as Button).Name;
            var doc = AcadAPP.DocumentManager.MdiActiveDocument;
            //switch{ }
            doc.SendStringToExecute("Insert" + CompuertaName + " ", true, false, false);
        }
    }
}
