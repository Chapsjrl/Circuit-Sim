using AutoCADAPI.Lab2;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using CircuitSimulator.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Model
{
    public abstract class Input
    {
        /// <summary>
        /// Accede al directorio de bloques
        /// </summary>
        /// <value>
        /// La ruta al directorio de bloques
        /// </value>
        public String BlockDirectory
        {
            get
            {
                string pth = Assembly.GetAssembly(typeof(Compuerta)).Location;
                pth = Path.GetDirectoryName(pth);
                return Path.Combine(pth, "Blocks");
            }
        }
       
        /// <summary>
        /// El Identificador de la compuerta.
        /// </summary>
        public Handle Id { get { return this.Block.Handle; } }
        /// <summary>
        /// Define las zonas de la aplicación
        /// </summary>
        public Dictionary<String, Point3dCollection> Zones = new Dictionary<string, Point3dCollection>();
        /// <summary>
        /// Define los puntos de contacto de la compuerta
        /// </summary>
        public Dictionary<String, Point3d> ConnectionPoints = new Dictionary<string, Point3d>();
        /// <summary>
        /// El nombre de la compuerta
        /// </summary>
        public readonly String Name;
        /// <summary>
        /// Los valores en la entrada
        /// </summary>
        public readonly Boolean[] Value;
        /// <summary>
        /// La referencia asociada a la compuerta
        /// </summary>
        public BlockReference Block;
        /// <summary>
        /// Define la caja de colisión de la compuerta
        /// </summary>
        public Point3dCollection Box;
        /// <summary>
        /// Establece el valor de la compuerta.
        /// </summary>
        /// <param name="tr">La transacción activa</param>
        /// <param name="doc">Active document</param>
        /// <param name="input">The input.</param>
        public abstract Boolean[] Values { get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase<see cref="Compuerta"/>.
        /// </summary>
        /// <param name="name">El nombre de la compuerta.</param>
        public Input(String name, Boolean valor)
        {
            this.Name = name;
            this.Value = new Boolean[1];
            this.Value[0] = valor;
        }
        /// <summary>
        /// Inserta la compuerta en el punto especificado
        /// </summary>
        /// <param name="instPt">La compuerta a insertar.</param>
        /// <param name="tr">La transacción activa.</param>
        /// <param name="doc">El documento activo.</param>
        public void Insert(Point3d instPt, Transaction tr, Document doc)
        {
            String file = Path.Combine(this.BlockDirectory, String.Format("{0}.dwg", this.Name));
            if (BlockManager.LoadBlock(file, this.Name, doc, tr))
            {
                this.Block = BlockManager.InsertBlock(this.Name, instPt, doc, tr);
                Drawer d = new Drawer(tr);
                d.Entity(this.Block);
                this.Block.UpgradeOpen();
                //BlockManager.SetAttribute(this.Block, "VCC", String.Empty, doc, tr);
                this.InitBox(this.Name);
            }
        }
        /// <summary>
        /// Inicializa la caja de colisión de la compuerta
        /// </summary>
        public void InitBox(String name)
        {
            this.Box = new Point3dCollection(new Point3d[]
            {
                this.Block.GeometricExtents.MinPoint,
                new Point3d(this.Block.GeometricExtents.MaxPoint.X,this.Block.GeometricExtents.MinPoint.Y,0),
                this.Block.GeometricExtents.MaxPoint,
                new Point3d(this.Block.GeometricExtents.MinPoint.X,this.Block.GeometricExtents.MaxPoint.Y,0),
            });
            this.Zones.Add("OUTPUT", this.Box);
            if (name == "VCC")
                this.ConnectionPoints.Add("OUTPUT", this.Box[1]);
            else
                this.ConnectionPoints.Add("OUTPUT", this.Box[2]);
            
        }

        /// <summary>
        /// Dibuja una caja de colisión
        /// </summary>
        public ObjectId DrawBox(Drawer drawer)
        {
            drawer.Geometry(this.Box, true);
            foreach (var zone in this.Zones)
                drawer.Geometry(zone.Value);
            return drawer.Ids.OfType<ObjectId>().FirstOrDefault();
        }
        /// <summary>
        /// Obtiene la zona mediante el contacto de un punto
        /// </summary>
        /// <param name="test_pt">El punto de contacto</param>
        /// <param name="zoneName">El nombre de la zona.</param>
        /// <param name="zone">La zona de contacto.</param>
        public void GetZone(Point3d test_pt, out string zoneName, out Point3dCollection zone)
        {
            zoneName = String.Empty;
            zone = new Point3dCollection();
            foreach (var z in this.Zones)
            {
                if (test_pt.TestPoint(z.Value))
                {
                    zoneName = z.Key;
                    zone = z.Value;
                    break;
                }
            }
        }

        public ObjectIdCollection Search(String zona)
        {
            //Nota deben asegurarse de que las cajas sean actuales.
            //En caso de mover la compuerta no coincidiran a menos que ejecuten la función InitBox
            Point3d connPoint = this.ConnectionPoints.ContainsKey(zona) ? this.ConnectionPoints[zona] : new Point3d();
            ObjectIdCollection res = connPoint.Select();
            //Debemos ignorar esta instancia de la selección
            res.Remove(this.Block.ObjectId);
            return res;
        }


    }
}
