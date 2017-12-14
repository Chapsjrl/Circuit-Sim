using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using AutoCADAPI.Lab2;

namespace CircuitSimulator.Model
{
    public class Vcc : Input
    {
        public Vcc() : base("VCC", true)
        {
        }

        public override Boolean[] Values
        {
            get
            {
                return this.Value;
            }
        }
    }
}
