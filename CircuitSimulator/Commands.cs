using AutoCADAPI.Lab2;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using CircuitSimulator.Controller;
using Autodesk.AutoCAD.Runtime;
using CircuitSimulator.Model;
using Autodesk.AutoCAD.Geometry;
using CircuitSimulator.UI;

namespace CircuitSimulator
{
    public class Commands
    {
        PaletteSet compuertasSet;
        public static CompuertasUI myControlCompuertas;
        public static FuentesUI myControlFuentes;

        [CommandMethod("InitUI")]
        public void TestUI()
        {
            //inicializa la interfaz
            compuertasSet = new PaletteSet("Compuertas");
            myControlCompuertas = new CompuertasUI();
            myControlFuentes = new FuentesUI();
            compuertasSet.Add("Galería", myControlCompuertas);
            compuertasSet.Dock = DockSides.Left;
            compuertasSet.Add("Entradas", myControlFuentes);
            compuertasSet.Visible = true;
        }

        [CommandMethod("TestDictionary")]
        public void Dictionary()
        {
            ObjectId obj;
            if (Selector.Entity("Selecciona una entidad", out obj))
            {
                TransactionWrapper tr = new TransactionWrapper();
                tr.Run(DictionaryTask, obj);
            }
        }

        private object DictionaryTask(Document doc, Transaction tr, object[] input)
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            Entity ent = ((ObjectId)input[0]).GetObject(OpenMode.ForRead) as Entity;
            DictionaryManager man = new DictionaryManager();
            //Abrimos el diccionario
            var extD = man.GetExtensionD(tr, doc, ent);
            man.SetData(extD, tr, "Prueba", "Chaps", DateTime.Now.ToShortDateString());
            var data = man.GetData(extD, tr, "Prueba");
            ed.WriteMessage("Nombre: {0}, Fecha de Registro: {1}", data[0], data[1]);
            return null;
        }

        /// <summary>
        /// Las compuertas insertadas en el plano
        /// </summary>
        public static Dictionary<Handle, Compuerta> Compuertas;
        public static Dictionary<Handle, Input> Entradas;
        /// <summary>
        /// Define un comando que prueba la inserción de la compuerta AND
        /// </summary>
        [CommandMethod("InsertAND")]
        public void InsertAND()
        {
            if (Compuertas == null)
                Compuertas = new Dictionary<Handle, Compuerta>();
            Point3d pt;
            if (Selector.Point("Selecciona el punto de inserción de la compuerta", out pt))
            {
                TransactionWrapper tr = new TransactionWrapper();
                var cmp = tr.Run(InsertCompuertaTask, new AND(2), pt) as Compuerta;
                Compuertas.Add(cmp.Id, cmp);
            }
        }
        /// <summary>
        /// Define un comando que prueba la inserción de la compuerta OR
        /// </summary>
        [CommandMethod("InsertOR")]
        public void InsertOR()
        {
            if (Compuertas == null)
                Compuertas = new Dictionary<Handle, Compuerta>();
            Point3d pt;
            if (Selector.Point("Selecciona el punto de inserción de la compuerta", out pt))
            {
                TransactionWrapper tr = new TransactionWrapper();
                var cmp = tr.Run(InsertCompuertaTask, new OR(2), pt) as Compuerta;
                Compuertas.Add(cmp.Id, cmp);
            }
        }
        /// <summary>
        /// Define un comando que prueba la inserción de la compuerta NAND
        /// </summary>
        [CommandMethod("InsertNAND")]
        public void InsertNAND()
        {
            if (Compuertas == null)
                Compuertas = new Dictionary<Handle, Compuerta>();
            Point3d pt;
            if (Selector.Point("Selecciona el punto de inserción de la compuerta", out pt))
            {
                TransactionWrapper tr = new TransactionWrapper();
                var cmp = tr.Run(InsertCompuertaTask, new NAND(2), pt) as Compuerta;
                Compuertas.Add(cmp.Id, cmp);
            }
        }
        /// <summary>
        /// Define un comando que prueba la inserción de la compuerta NOR
        /// </summary>
        [CommandMethod("InsertNOR")]
        public void InsertNOR()
        {
            if (Compuertas == null)
                Compuertas = new Dictionary<Handle, Compuerta>();
            Point3d pt;
            if (Selector.Point("Selecciona el punto de inserción de la compuerta", out pt))
            {
                TransactionWrapper tr = new TransactionWrapper();
                var cmp = tr.Run(InsertCompuertaTask, new NOR(2), pt) as Compuerta;
                Compuertas.Add(cmp.Id, cmp);
            }
        }
        /// <summary>
        /// Define un comando que prueba la inserción de la compuerta XOR
        /// </summary>
        [CommandMethod("InsertXOR")]
        public void InsertXOR()
        {
            if (Compuertas == null)
                Compuertas = new Dictionary<Handle, Compuerta>();
            Point3d pt;
            if (Selector.Point("Selecciona el punto de inserción de la compuerta", out pt))
            {
                TransactionWrapper tr = new TransactionWrapper();
                var cmp = tr.Run(InsertCompuertaTask, new XOR(2), pt) as Compuerta;
                Compuertas.Add(cmp.Id, cmp);
            }
        }
        /// <summary>
        /// Define un comando que prueba la inserción de la compuerta XNOR
        /// </summary>
        [CommandMethod("InsertXNOR")]
        public void InsertXNOR()
        {
            if (Compuertas == null)
                Compuertas = new Dictionary<Handle, Compuerta>();
            Point3d pt;
            if (Selector.Point("Selecciona el punto de inserción de la compuerta", out pt))
            {
                TransactionWrapper tr = new TransactionWrapper();
                var cmp = tr.Run(InsertCompuertaTask, new XNOR(2), pt) as Compuerta;
                Compuertas.Add(cmp.Id, cmp);
            }
        }
        /// <summary>
        /// Define un comando que prueba la inserción de la compuerta NOT
        /// </summary>
        [CommandMethod("InsertNOT")]
        public void InsertNOT()
        {
            if (Compuertas == null)
                Compuertas = new Dictionary<Handle, Compuerta>();
            Point3d pt;
            if (Selector.Point("Selecciona el punto de inserción de la compuerta", out pt))
            {
                TransactionWrapper tr = new TransactionWrapper();
                var cmp = tr.Run(InsertCompuertaTask, new NOT(), pt) as Compuerta;
                Compuertas.Add(cmp.Id, cmp);
            }
        }
        /// <summary>
        /// Define un comando para la inserción de un pulso de tamaño 1 y valor true (Vcc)
        /// </summary>
        [CommandMethod("DibujaVcc")]
        public void InsertVcc()
        {
            if (Entradas == null)
                Entradas = new Dictionary<Handle, Input>();
            Point3d insPt;
            if (Selector.Point("Selecciona el punto de inserción de Vcc", out insPt))
            {
                TransactionWrapper tr = new TransactionWrapper();
                var inp = tr.Run(InsertEntradaTask, new Vcc(), insPt) as Input;
                Entradas.Add(inp.Id, inp);
            }
        }
        /// <summary>
        /// Define un comando para la inserción de un pulso de tamaño 1 y valor false (Gnd)
        /// </summary>
        [CommandMethod("DibujaGnd")]
        public void InsertGnd()
        {
            if (Entradas == null)
                Entradas = new Dictionary<Handle, Input>();
            Point3d insPt;
            if (Selector.Point("Selecciona el punto de inserción de GND", out insPt))
            {
                TransactionWrapper tr = new TransactionWrapper();
                var inp = tr.Run(InsertEntradaTask, new Gnd(), insPt) as Input;
                Entradas.Add(inp.Id, inp);
            }
        }

        [CommandMethod("DibujaSalida")]
        public void InsertSalida()
        {
            if (Compuertas == null)
                Compuertas = new Dictionary<Handle, Compuerta>();
            Point3d insPt;
            if (Selector.Point("Selecciona el punto de inserción de la salida", out insPt))
            {
                TransactionWrapper tr = new TransactionWrapper();
                var cmp = tr.Run(InsertCompuertaTask, new Output(), insPt) as Compuerta;
                Compuertas.Add(cmp.Id, cmp);
            }
        }

        /// <summary>
        /// Define la transacción que inserta un bloque de Vcc o Gnd
        /// </summary>
        /// <param name="doc">El documento activo.</param>
        /// <param name="tr">La transacción activa.</param>
        /// <param name="input">La entrada de la transacción.</param>
        /// <returns>La compuerta insertada</returns>
        private object InsertEntradaTask(Document doc, Transaction tr, object[] input)
        {
            Input cmp = (Input)input[0];
            Point3d pt = (Point3d)input[1];
            DictionaryManager dMan = new DictionaryManager();
            cmp.Insert(pt, tr, doc);

            //En este objeto pueden guardar información de los elementos insertados
            var dicCompuerta = dMan.GetExtensionD(tr, doc, cmp.Block);
            dMan.SetData(dicCompuerta, tr, "Tipo", "Entrada");
            return cmp;
        }

        /// <summary>
        /// Define la transacción que inserta una compuerta
        /// </summary>
        /// <param name="doc">El documento activo.</param>
        /// <param name="tr">La transacción activa.</param>
        /// <param name="input">La entrada de la transacción.</param>
        /// <returns>La compuerta insertada</returns>
        private object InsertCompuertaTask(Document doc, Transaction tr, object[] input)
        {
            Compuerta cmp = (Compuerta)input[0];
            Point3d pt = (Point3d)input[1];
            DictionaryManager dMan = new DictionaryManager();
            cmp.Insert(pt, tr, doc);

            //En este objeto pueden guardar información de los elementos insertados
            var dicCompuerta = dMan.GetExtensionD(tr, doc, cmp.Block);
            if(cmp.Name == "OUTPUT")
                dMan.SetData(dicCompuerta, tr, "Tipo", "Salida");
            else
                dMan.SetData(dicCompuerta, tr, "Tipo", "Compuerta");
            return cmp;
        }
        /// <summary>
        /// Realiza el calculo de una compuerta
        /// </summary>
        [CommandMethod("TestCompuerta")]
        public void TestCompuerta()
        {
            ObjectId p1Id, p2Id, cmpId;
            Point3d pt1, pt2;
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            if (Selector.Entity("\nSelecciona un pulso", typeof(Polyline), out p1Id) &&
                Selector.Entity("\nSelecciona la entrada de conexión", out cmpId, out pt1) &&
                Selector.Entity("\nSelecciona un pulso", typeof(Polyline), out p2Id) &&
                Selector.Entity("\nSelecciona la entrada de conexión", out cmpId, out pt2))
            {
                TransactionWrapper tr = new TransactionWrapper();
                Compuerta cmp = Compuertas.Values.FirstOrDefault(x => x.Block.Id == cmpId);
                if (cmp != null)
                    tr.Run(TestCompuertaTask, cmp, p1Id, p2Id, pt1, pt2);
                else
                    ed.WriteMessage("No es Compuerta");
            }
        }

        private object TestCompuertaTask(Document doc, Transaction tr, object[] input)
        {
            Compuerta cmp = (Compuerta)input[0];
            cmp.InitBox(cmp.Name);
            Polyline p1 = ((ObjectId)input[1]).GetObject(OpenMode.ForRead) as Polyline;
            Polyline p2 = ((ObjectId)input[2]).GetObject(OpenMode.ForRead) as Polyline;
            Point3d pt1 = (Point3d)input[3];
            Point3d pt2 = (Point3d)input[4];
            String zoneA, zoneB;
            //No nos interesa en este ejemplo las coordenadas
            Point3dCollection zone;
            cmp.GetZone(pt1, out zoneA, out zone);
            cmp.GetZone(pt2, out zoneB, out zone);
            InputValue inA = new InputValue() { Name = zoneA, Value = Pulso.GetValues(p1) },
                       inB = new InputValue() { Name = zoneB, Value = Pulso.GetValues(p2) };
            Boolean[] result = cmp.Solve(inA, inB);
            Drawer d = new Drawer(tr);
            Point3d pt;
            if (Selector.Point("Selecciona el punto de inserción de la salida", out pt))
            {
                Pulso p = new Pulso(pt, result);
                p.Draw(d);
                Line lA = new Line(p1.EndPoint, cmp.ConnectionPoints[inA.Name]),
                    lB = new Line(p2.EndPoint, cmp.ConnectionPoints[inB.Name]),
                    lO = new Line(pt, cmp.ConnectionPoints["OUTPUT"]);
                d.Entities(lA, lB, lO);
                cmp.SetData(tr, doc, inA.Value.LastOrDefault(), inB.Value.LastOrDefault());
            }
            return null;
        }


        [CommandMethod("PulsoRandom")]
        public void DPulso()
        {
            Point3d insPt;
            Random r = new Random((int)DateTime.Now.Ticks);
            Boolean[] data = new Boolean[]
            {
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true
            };
            int pulsoSize;
            if (Selector.Point("Selecciona el punto de inserción del pulso", out insPt) &&
                Selector.Integer("El tamaño del pulso", out pulsoSize, 4))
            {
                Boolean[] input = new Boolean[pulsoSize];
                for (int i = 0; i < input.Length; i++)
                    input[i] = data[r.Next(data.Length - 1)];
                Pulso p = new Pulso(insPt, input);
                TransactionWrapper tr = new TransactionWrapper();
                tr.Run(DPulsoTask, new Object[] { p });
            }

        }

        [CommandMethod("PulsoFalseStart")]
        public void PulsoFStart()
        {
            Point3d insPt;
            Boolean[] data = new Boolean[]
            {
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true,
                false, true, false, true, false, true, false, true
            };
            int pulsoSize;
            if (Selector.Point("Selecciona el punto de inserción del pulso", out insPt) &&
                Selector.Integer("El tamaño del pulso", out pulsoSize, 4))
            {
                Boolean[] input = new Boolean[pulsoSize];
                for (int i = 0; i < input.Length; i++)
                    input[i] = data[i];
                Pulso p = new Pulso(insPt, input);
                TransactionWrapper tr = new TransactionWrapper();
                tr.Run(DPulsoTask, new Object[] { p });
            }

        }


        [CommandMethod("PulsoTrueStart")]
        public void PulsoTStart()
        {
            Point3d insPt;
            Boolean[] data = new Boolean[]
            {
                true, false, true, false, true, false, true, false,
                true, false, true, false, true, false, true, false,
                true, false, true, false, true, false, true, false,
                true, false, true, false, true, false, true, false,
                true, false, true, false, true, false, true, false,
                true, false, true, false, true, false, true, false,
                true, false, true, false, true, false, true, false,
                true, false, true, false, true, false, true, false,
                true, false, true, false, true, false, true, false,
                true, false, true, false, true, false, true, false,
                true, false, true, false, true, false, true, false,
                true, false, true, false, true, false, true, false,
                false, true, false, true, false, true, false, true
            };
            int pulsoSize;
            if (Selector.Point("Selecciona el punto de inserción del pulso", out insPt) &&
                Selector.Integer("El tamaño del pulso", out pulsoSize, 4))
            {
                Boolean[] input = new Boolean[pulsoSize];
                for (int i = 0; i < input.Length; i++)
                    input[i] = data[i];
                Pulso p = new Pulso(insPt, input);
                TransactionWrapper tr = new TransactionWrapper();
                tr.Run(DPulsoTask, new Object[] { p });
            }

        }

        private object DPulsoTask(Document doc, Transaction tr, object[] input)
        {
            Drawer d = new Drawer(tr);
            var data = (input[0] as Pulso).Draw(d);
            
            //Despues de dibujar el pulso abrimos la polilína
            Entity ent = data.GetObject(OpenMode.ForWrite) as Entity;
            DictionaryManager dMan = new DictionaryManager();
            var pulsoDictionary = dMan.GetExtensionD(tr, doc, ent);
            dMan.SetData(pulsoDictionary, tr, "Tipo", "Pulso");
            return ent.Id;
        }

        [CommandMethod("LoadCompuertas")]
        public void CargarCompuertas()
        {
            TransactionWrapper trW = new TransactionWrapper();
            Object acadObj = Application.AcadApplication;
            acadObj.GetType().InvokeMember("ZoomExtents", System.Reflection.BindingFlags.InvokeMethod, null, acadObj, null);
            
            trW.TransactionTask = (Document doc, Transaction tr, object[] input) =>
            {
                Compuertas = new Dictionary<Handle, Compuerta>();
                BlockTable blockTable = doc.Database.BlockTableId.GetObject(OpenMode.ForRead) as BlockTable;
                BlockTableRecord modelSpace = blockTable[BlockTableRecord.ModelSpace].GetObject(OpenMode.ForRead)
                                        as BlockTableRecord;
                DBObject obj;
                BlockReference block;
                String[] appBlocks = new String[] { "OR", "AND", "NOR", "NAND", "XOR", "XNOR", "NOT", "VCC", "GND" };
                foreach (var objId in modelSpace)
                {
                    obj = objId.GetObject(OpenMode.ForRead);
                    if (obj is BlockReference && appBlocks.Contains(((obj as BlockReference).Name)))
                    {
                        block = (obj as BlockReference);
                        switch (block.Name) {
                            case "OR":
                                Compuertas.Add(obj.Handle, new OR(2) { Block = block });
                            break;
                            case "AND":
                                Compuertas.Add(obj.Handle, new AND(2) { Block = block });
                                break;
                            case "NOR":
                                Compuertas.Add(obj.Handle, new NOR(2) { Block = block });
                                break;
                            case "NAND":
                                Compuertas.Add(obj.Handle, new NAND(2) { Block = block });
                                break;
                            case "XOR":
                                Compuertas.Add(obj.Handle, new XOR(2) { Block = block });
                                break;
                            case "XNOR":
                                Compuertas.Add(obj.Handle, new XNOR(2) { Block = block });
                                break;
                            case "NOT":
                                Compuertas.Add(obj.Handle, new NOT() { Block = block });
                                break;
                            case "GND":
                                Entradas.Add(obj.Handle, new Gnd() { Block = block });
                                break;
                            case "VCC":
                                Entradas.Add(obj.Handle, new Vcc() { Block = block });
                                break;
                            case "OUTPUT":
                                Compuertas.Add(obj.Handle, new Output() { Block = block });
                                break;
                        }
                    }
                }
                return null;
            };
            trW.Run(trW.TransactionTask);
            acadObj.GetType().InvokeMember("ZoomPrevious", System.Reflection.BindingFlags.InvokeMethod, null, acadObj, null);
        }

        [CommandMethod("Queeres")]
        public void CheckEntity()
        {
            ObjectId ent;
            if (Selector.Entity("Selecciona una entidad", out ent))
            {
                TransactionWrapper tr = new TransactionWrapper();
                //Declaración de un metodo anonimo
                tr.TransactionTask =
                    (Document doc, Transaction t, object[] input) =>
                    {
                        Entity e = ent.GetObject(OpenMode.ForRead) as Entity;
                        DictionaryManager dMan = new DictionaryManager();
                        //abrir dic
                        var dicCompuerta = dMan.GetExtensionD(t, doc, e);
                        String[] content = dMan.GetData(dicCompuerta, t, "Tipo");
                        Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
                        if (content.Length > 0)
                            ed.WriteMessage("Eres {0}", content[0]);
                        else
                            ed.WriteMessage("No se que eres");
                        return null;
                    };
                tr.Run(tr.TransactionTask);
            }
        }

        [CommandMethod("ConexionPulsoCompuerta")]
        public void Connect()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ObjectId inpId, outId;
            Point3d pt1;
            if (Selector.Entity("\nSelecciona un pulso", typeof(Polyline), out inpId) &&
                Selector.Entity("Selecciona una Entrada", out outId, out pt1))
            {
                Compuerta cmp = Commands.Compuertas.FirstOrDefault(x => x.Value.Block.ObjectId == outId).Value;
                cmp.InitBox(cmp.Name);
                ObjectId cableAId = cmp.Search("INPUTA").OfType<ObjectId>().FirstOrDefault(),
                         cableBId = cmp.Search("INPUTB").OfType<ObjectId>().FirstOrDefault();
                TransactionWrapper tr = new TransactionWrapper();
                tr.Run(ConnectionTask, cmp, cableAId, cableBId, pt1, inpId);
            }
        }

        [CommandMethod("ConexionCC")]
        public void ConnectCC()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ObjectId inpId, outId;
            Point3d pt1, pt2;
            if (Selector.Entity("\nSelecciona la salida de compuerta", out inpId, out pt1) &&
                Selector.Entity("\nSelecciona la entrada de conexión", out outId, out pt2))
            {
                Compuerta cmp = Commands.Compuertas.FirstOrDefault(x => x.Value.Block.ObjectId == outId).Value;
                Compuerta cmpFrom = Commands.Compuertas.FirstOrDefault(x => x.Value.Block.ObjectId == inpId).Value;
                cmp.InitBox(cmp.Name);
                cmpFrom.InitBox(cmpFrom.Name);
                ObjectId cableAId = cmp.Search("INPUTA").OfType<ObjectId>().FirstOrDefault(),
                         cableBId = cmp.Search("INPUTB").OfType<ObjectId>().FirstOrDefault(),
                         outputId = cmpFrom.Search("OUTPUT").OfType<ObjectId>().FirstOrDefault();
                TransactionWrapper tr = new TransactionWrapper();
                tr.Run(ConnectionTask2, cmp, cmpFrom, pt1, pt2, cableAId, cableBId, outputId);
            }
        }
        [CommandMethod("ConexionFC")]
        public void ConnectFC()
        {
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            ObjectId inpId, outId;
            Point3d pt1, pt2;
            if (Selector.Entity("\nSelecciona VCC o GND ", out inpId, out pt1) &&
                Selector.Entity("\nSelecciona la entrada de conexión", out outId, out pt2))
            {
                Compuerta cmp = Compuertas.FirstOrDefault(x => x.Value.Block.ObjectId == outId).Value;
                Input inpB = Entradas.FirstOrDefault(x => x.Value.Block.ObjectId == inpId).Value;
                cmp.InitBox(cmp.Name);
                inpB.InitBox(inpB.Name);
                ObjectId cableAId = cmp.Search("INPUTA").OfType<ObjectId>().FirstOrDefault(),
                         cableBId = cmp.Search("INPUTB").OfType<ObjectId>().FirstOrDefault(),
                         outputId = inpB.Search("OUTPUT").OfType<ObjectId>().FirstOrDefault();
                TransactionWrapper tr = new TransactionWrapper();
                tr.Run(ConnectionTask3, cmp, inpB, pt1, pt2, cableAId, cableBId, outputId);
            }
        }

        private object ConnectionTask2(Document doc, Transaction tr, object[] input)
        {
            Compuerta cmp = (Compuerta)input[0], cmpFrom = (Compuerta)input[1];
            cmp.InitBox(cmp.Name);
            cmpFrom.InitBox(cmpFrom.Name);
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            Point3d pt1 = (Point3d)input[3], pt2 = (Point3d)input[2];
            String zoneA;
            Point3dCollection zone;
            cmp.GetZone(pt1, out zoneA, out zone);
            if (((ObjectId)input[6]).IsNull)
            {
                switch (zoneA)
                {
                    case "INPUTA":
                        if (((ObjectId)input[4]).IsNull)
                        {
                            Drawer d = new Drawer(tr);
                            Line lA = new Line(cmpFrom.ConnectionPoints["OUTPUT"], cmp.ConnectionPoints[zoneA]);
                            d.Entity(lA);
                        }
                        else
                            ed.WriteMessage("Ya existe un elemento conectado a esta entrada");
                        break;
                    case "INPUTB":
                        if (((ObjectId)input[5]).IsNull)
                        {
                            Drawer d = new Drawer(tr);
                            Line lA = new Line(cmpFrom.ConnectionPoints["OUTPUT"], cmp.ConnectionPoints[zoneA]);
                            d.Entity(lA);
                        }
                        else
                            ed.WriteMessage("Ya existe un elemento conectado a esta entrada");
                        break;
                    case "OUTPUT":
                        ed.WriteMessage("Imposible conectar con una salida");
                        break;
                }
            }
            else
                ed.WriteMessage("Imposible conectar, prueba de nuevo");
            return null;
        }

        private object ConnectionTask3(Document doc, Transaction tr, object[] input)
        {
            Compuerta cmp = (Compuerta)input[0];
            Input cmpFrom = (Input)input[1];
            cmp.InitBox(cmp.Name);
            cmpFrom.InitBox(cmpFrom.Name);
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            Point3d pt1 = (Point3d)input[3], pt2 = (Point3d)input[2];
            String zoneA;
            Point3dCollection zone;
            cmp.GetZone(pt1, out zoneA, out zone);
            if (((ObjectId)input[6]).IsNull)
            {
                switch (zoneA)
                {
                    case "INPUTA":
                        if (((ObjectId)input[4]).IsNull)
                        {
                            Drawer d = new Drawer(tr);
                            Line lA = new Line(cmpFrom.ConnectionPoints["OUTPUT"], cmp.ConnectionPoints[zoneA]);
                            d.Entity(lA);
                        }
                        else
                            ed.WriteMessage("Ya existe un elemento conectado a esta entrada");
                        break;
                    case "INPUTB":
                        if (((ObjectId)input[5]).IsNull)
                        {
                            Drawer d = new Drawer(tr);
                            Line lA = new Line(cmpFrom.ConnectionPoints["OUTPUT"], cmp.ConnectionPoints[zoneA]);
                            d.Entity(lA);
                        }
                        else
                            ed.WriteMessage("Ya existe un elemento conectado a esta entrada");
                        break;
                    case "OUTPUT":
                        ed.WriteMessage("Imposible conectar con una salida");
                        break;
                }
            }
            else
                ed.WriteMessage("Imposible conectar, prueba de nuevo");
            return null;
        }

        private object ConnectionTask(Document doc, Transaction tr, object[] input)
        {
            Compuerta cmp = (Compuerta)input[0];
            cmp.InitBox(cmp.Name);
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            Polyline p1 = ((ObjectId)input[4]).GetObject(OpenMode.ForRead) as Polyline;
            Point3d pt1 = (Point3d)input[3];
            String zoneA;
            Point3dCollection zone;
            cmp.GetZone(pt1, out zoneA, out zone);
            switch (zoneA)
            {
                case "INPUTA":
                    if (((ObjectId)input[1]).IsNull)
                    {
                        Drawer d = new Drawer(tr);
                        Line lA = new Line(p1.EndPoint, cmp.ConnectionPoints[zoneA]);
                        d.Entity(lA);
                    }
                    else
                        ed.WriteMessage("Ya existe un elemento conectado a esta entrada");
                    break;
                case "INPUTB":
                    if (((ObjectId)input[2]).IsNull)
                    {
                        Drawer d = new Drawer(tr);
                        Line lA = new Line(p1.EndPoint, cmp.ConnectionPoints[zoneA]);
                        d.Entity(lA);
                    }
                    else
                        ed.WriteMessage("Ya existe un elemento conectado a esta entrada");
                    break;
                case "OUTPUT":
                    ed.WriteMessage("Imposible conectar con una salida");
                    break;
            }
            return null;
        }

        [CommandMethod("Calcular")]
        public void StartCalculo()
        {
            TransactionWrapper trW = new TransactionWrapper();
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            Object acadObj = Application.AcadApplication;
            acadObj.GetType().InvokeMember("ZoomExtents", System.Reflection.BindingFlags.InvokeMethod, null, acadObj, null);
            Compuerta cmpFrom = Commands.Compuertas.FirstOrDefault(x => x.Value.Block.Name == "OUTPUT").Value;
            if (cmpFrom != null)
            {
                
            }
            else
                ed.WriteMessage("No se encontro un Objeto de pulso salida");
            acadObj.GetType().InvokeMember("ZoomPrevious", System.Reflection.BindingFlags.InvokeMethod, null, acadObj, null);

        }
        
        /// <summary>
        /// Tests the connection task.
        /// </summary>
        /// <param name="doc">The document.</param>
        /// <param name="tr">The tr.</param>
        /// <param name="input">The input.</param>
        private object TestConnectionTask(Document doc, Transaction tr, object[] input)
        {
            Compuerta cmp = input[0] as Compuerta;
            Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
            if (((ObjectId)input[1]).IsValid && ((ObjectId)input[2]).IsValid)
            {
                DBObject cableA = ((ObjectId)input[1]).GetObject(OpenMode.ForRead);
                DBObject cableB = ((ObjectId)input[2]).GetObject(OpenMode.ForRead);
                if (cableA is Line && cableB is Line)
                {
                    Cable cabA = new Cable(cableA as Line),
                          cabB = new Cable(cableB as Line);
                    ObjectId pAId = cabA.Search(true).OfType<ObjectId>().FirstOrDefault(),
                             pBId = cabB.Search(true).OfType<ObjectId>().FirstOrDefault();
                    if (pAId.IsValid && pBId.IsValid)
                    {
                        DBObject pulsoA = pAId.GetObject(OpenMode.ForRead),
                             pulsoB = pBId.GetObject(OpenMode.ForRead);
                        if (pulsoA is Polyline && pulsoB is Polyline)
                        {
                            var inputA = Pulso.GetValues(pulsoA as Polyline);
                            var inputB = Pulso.GetValues(pulsoB as Polyline);
                            bool[] result = cmp.Solve(
                                new InputValue[]
                                {
                                    new InputValue() { Name = "INPUTA", Value = inputA },
                                    new InputValue() { Name = "INPUTB", Value = inputB }
                            });
                            Drawer d = new Drawer(tr);
                            Pulso output = new Pulso(cmp.ConnectionPoints["OUTPUT"], result);
                            output.Draw(d);
                        }
                    }
                    if (pAId.IsNull)
                        ed.WriteMessage("No se encontro un pulso conectado al cable A");
                    if (pBId.IsNull)
                        ed.WriteMessage("No se encontro un pulso conectado al cable B");
                }
            }
            if (((ObjectId)input[1]).IsNull)
                ed.WriteMessage("\nCable A desconectado");
            if (((ObjectId)input[2]).IsNull)
                ed.WriteMessage("\nCable B desconectado");

            return null;
        }
        
        
    }
}

