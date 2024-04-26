using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proiect1AI_NET
{
	public partial class LabelTextBoxControl : UserControl
	{
		public string LabelText
		{
			get { return label1.Text; }
			set { label1.Text = value; }
		}
		public string TextBoxText
		{
			get { return textBox1.Text; }
			set { textBox1.Text = value; }
		}

		public string Label2Text
		{
			get { return label2.Text; }
			set { label2.Text = value; }
		}
		public string TextBox2Text
		{
			get { return textBox2.Text; }
			set { textBox2.Text = value; }
		}

		public LabelTextBoxControl()
		{
			InitializeComponent();
		}
		// Update the UI elements when the properties are set
		private void UpdateUI()
		{
			label1.Text = LabelText;
			textBox1.Text = TextBoxText;
			label2.Text = Label2Text;
			textBox2.Text= TextBox2Text;
		}

		private void LabelTextBoxControl_Load(object sender, EventArgs e)
		{
			UpdateUI();  // cand se incarca
		}

		private void LabelTextBoxControl_TextChanged(object sender, EventArgs e)
		{
			UpdateUI(); // cand se schimba valorile
		}

		private void LabelTextBoxControl_Load_1(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
