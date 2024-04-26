using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project2_AI
{
	public class InputNeuron
	{
		public string Name { get; set; }
		public float Value { get; set; }
		public InputNeuron(string name)
		{
			Name = name;
			Value = 0.0f; // Valoarea inițială poate fi setată aici
		}
	}

}
