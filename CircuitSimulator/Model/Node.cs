using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitSimulator.Model
{
    public class Node
    {
        public Object Data;
        public Node Parent;
        public List<Node> Children;
        public Boolean IsRoot { get { return this.Parent == null; } }
        public Boolean IsLeaf { get { return this.Children.Count == 0; } }

        public void Add(Object data)
        {
            this.Children.Add(new Node() { Parent = this, Children = new List<Node>() });
        }
    }
}
