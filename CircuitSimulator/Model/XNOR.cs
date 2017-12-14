using AutoCADAPI.Lab2;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Model
{
    public class XNOR : Compuerta
    {
        /// <summary>
        /// Inicializa una nueva instancia de la compuerta XNOR
        /// </summary>
        public XNOR(int numInp)
            : base("XNOR", numInp)
        {
            char letraInp = 'A';
            this.InputNames = new String[this.InputNumber + 1];
            for (int i = 0; i < this.InputNumber; i++)
            {
                this.InputNames[i] = "INPUT" + letraInp;
                letraInp++;
            }
        }
        /// <summary>
        /// Resuelve la función de la compuerta
        /// </summary>
        /// <param name="input">La entrada de la compuerta.</param>
        /// <returns>
        /// Resuelve la entrada
        /// </returns>
        public override bool Solve(params bool[] input)
        {
            return input[0] == input[1];
        }
        /// <summary>
        /// Resuelve la función de la compuerta
        /// </summary>
        /// <param name="input">La entrada de la compuerta.</param>
        /// <returns>
        /// Resuelve la entrada
        /// </returns>
        public override bool[] Solve(params InputValue[] input)
        {
            InputValue inputA = input.FirstOrDefault(x => x.Name == "INPUTA"),
                inputB = input.FirstOrDefault(x => x.Name == "INPUTB");
            List<Boolean> result = new List<Boolean>();
            if (inputA != null && inputB != null)
            {
                int size = inputA.Value.Length > inputB.Value.Length ?
                    inputA.Value.Length : inputB.Value.Length;
                for (int i = 0; i < size; i++)
                {
                    Boolean valA = i < inputA.Value.Length ? inputA.Value.ElementAt(i) : inputA.Value.Last(),
                            valB = i < inputB.Value.Length ? inputB.Value.ElementAt(i) : inputB.Value.Last();
                    result.Add(this.Solve(valA, valB));
                }
            }
            return result.ToArray();
        }
        /// <summary>
        /// Establece el valor de la compuerta.
        /// </summary>
        /// <param name="tr">La transacción activa</param>
        /// <param name="doc">Active document</param>
        /// <param name="input">The input.</param>
        public override void SetData(Transaction tr, Document doc, params bool[] input)
        {
            BlockManager.SetAttribute(this.Block, "INPUTA", input[0] ? "1" : "0", doc, tr);
            BlockManager.SetAttribute(this.Block, "INPUTB", input[1] ? "1" : "0", doc, tr);
            Boolean res = this.Solve(input[0], input[1]);
            BlockManager.SetAttribute(this.Block, "OUTPUT", res ? "1" : "0", doc, tr);
        }

    }
}
