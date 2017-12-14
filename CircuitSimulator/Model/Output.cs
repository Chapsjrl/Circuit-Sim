﻿using AutoCADAPI.Lab2;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Model
{
    public class Output : Compuerta
    {
        /// <summary>
        /// Inicializa una nueva instancia de la compuerta NOT
        /// </summary>
        public Output()
            : base("OUTPUT", 1)
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
            return input[0];
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
            InputValue inputA = input.FirstOrDefault(x => x.Name == "INPUTA");
            List<Boolean> result = new List<Boolean>();
            if (inputA != null)
            {
                int size = inputA.Value.Length;
                for (int i = 0; i < size; i++)
                {
                    Boolean valA = i < inputA.Value.Length ? inputA.Value.ElementAt(i) : inputA.Value.Last();
                    result.Add(this.Solve(valA));
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
            Boolean res = this.Solve(input[0]);
            BlockManager.SetAttribute(this.Block, "OUTPUT", res ? "1" : "0", doc, tr);
        }

    }
}
