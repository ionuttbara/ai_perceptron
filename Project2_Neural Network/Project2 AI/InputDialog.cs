using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Project2_AI
{
	public partial class InputDialog : Form
	{
		// Declarați vectorul pentru numărul de neuroni din fiecare strat ascuns
		private int[] hiddenLayerNeurons;

		public InputDialog()
		{
			InitializeComponent();
		}

		private void numericUpDownHiddenLayer_ValueChanged(object sender, EventArgs e)
		{
			int numberOfHiddenLayers = (int)numericUpDownHiddenLayer.Value;

			// Eliminați toate controalele existente din Panel
			panel1.Controls.Clear();

			// Creați și afișați dinamic controalele pentru fiecare strat ascuns
			for (int i = 0; i < numberOfHiddenLayers; i++)
			{
				Label label = new Label();
				label.Text = $"Hidden Layer {i + 1}:";
				label.Location = new Point(10, 30 * i + 10);

				NumericUpDown numericUpDown = new NumericUpDown();
				numericUpDown.Name = $"numericUpDownHiddenLayer{i}";
				numericUpDown.Location = new Point(150, 30 * i + 5);
				numericUpDown.Minimum = 1;
				numericUpDown.Maximum = 100;
				numericUpDown.Value = 1;

				// Adăugați controalele la Panel, nu direct la formular
				panel1.Controls.Add(label);
				panel1.Controls.Add(numericUpDown);
			}
		}


		private void buttonOK_Click(object sender, EventArgs e)
		{
			// Obțineți numărul total de straturi ascunse
			int numberOfHiddenLayers = (int)numericUpDownHiddenLayer.Value;

			// Inițializați vectorul pentru numărul de neuroni din fiecare strat ascuns
			hiddenLayerNeurons = new int[numberOfHiddenLayers];

			// În acest bucle, obțineți numărul de neuroni pentru fiecare strat ascuns
			for (int i = 0; i < numberOfHiddenLayers; i++)
			{
				NumericUpDown numericUpDown = (NumericUpDown)panel1.Controls[$"numericUpDownHiddenLayer{i}"];
				hiddenLayerNeurons[i] = (int)numericUpDown.Value;
			}

			// Setați DialogResult pe OK pentru a închide fereastra modală și a returna valorile
			DialogResult = DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			// În cazul în care utilizatorul dorește să anuleze introducerea, setați DialogResult pe Cancel
			DialogResult = DialogResult.Cancel;
			Close();
		}

		public int[] GetHiddenLayerNeurons()
		{
			// Metoda publică pentru a obține vectorul de neuroni din straturile ascunse
			return hiddenLayerNeurons;
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}

