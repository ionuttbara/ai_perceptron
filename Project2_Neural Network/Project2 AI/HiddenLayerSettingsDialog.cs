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
	public partial class HiddenLayerSettingsDialog : Form
	{
		public HiddenLayerSettingsDialog()
		{
			InitializeComponent();
		}
		public string InputFunction { get; private set; }
		public string ActivationFunction { get; private set; }
		public string ComportamentFunction { get; private set; }
		public double Theta { get; private set; }
		public double G { get; private set; }

		private void CancelButton_Click(object sender, EventArgs e)
		{
			// Setati rezultatul dialogului ca Cancel si inchideti fereastra
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
			// Salvati valorile selectate sau introduse de utilizator
			InputFunction = inputFunctionComboBox.SelectedItem.ToString();
			ActivationFunction = activationFunctionComboBox.SelectedItem.ToString();
			Theta = (double)thetaNumericUpDown.Value;
			G = (double)gNumericUpDown.Value;
			ComportamentFunction = compComboBox.SelectedItem.ToString();

			// Setati rezultatul dialogului ca OK si inchideti fereastra
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}
	}
}
