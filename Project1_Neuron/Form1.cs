using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Proiect1AI_NET
{
    public partial class Form1 : Form
    {
        List<float> inputgini = new List<float>();
        float rez = 0;
        double en = Math.E;
        double fxsig = -999;
        double tsig;
        public Form1()
        {
            InitializeComponent();
            oTextBox.Text = "0";
            gTextBox.Text = "1";
        }

        private void treaptaBtn_Click(object sender, EventArgs e)
        {

            sigmonBtn.Enabled = true;
            tanhBtn.Enabled = true;
            treaptaBtn.Enabled = false;
            rampaBtn.Enabled = true;
            signumBtn.Enabled = true; 
            checkBoxBinary.Visible = false;
            binaryLabel.Visible = false;
            omegaLabel.Visible = true;
            oTextBox.Visible = true;
            gLabel.Visible = false;
            gTextBox.Visible = false;

            double t;
            if (double.TryParse(oTextBox.Text, out t))
            {
                double rezultat = (rez > t) ? 1 : 0;
                rezultatLabel.Text = "Rezultat: " + rezultat.ToString();
                actrezLabel.Text = rezultat.ToString();
            }
            else
            {

                actrezLabel.Text = "θ";
            }
        }


        private void sigmonBtn_Click(object sender, EventArgs e)
        {
            sigmonBtn.Enabled = false;
            tanhBtn.Enabled = true;
            treaptaBtn.Enabled = true;
            rampaBtn.Enabled = true;
            signumBtn.Enabled = true;
            omegaLabel.Visible = true;
            oTextBox.Visible = true;
            gLabel.Visible = true;
            gTextBox.Visible = true;
            gLabel.Text = "g";
            checkBoxBinary.Visible = true;
            binaryLabel.Visible = true;
            if (double.TryParse(oTextBox.Text, out double t) && double.TryParse(gTextBox.Text, out double g))
            {
                tsig = t;
                fxsig = 1 / (1 + (Math.Pow(en, -g * (rez - t))));
                rezultatLabel.Text = "Rezultat: " + fxsig;

                if (checkBoxBinary.Checked)
                {
                    if (tsig > 0.5)
                    {
                        rezultatLabel.Text = "Rezultat: 1";
                        actrezLabel.Text = "1";
                    }
                    else
                    {
                        rezultatLabel.Text = "Rezultat: 0";
                        actrezLabel.Text = "0";
                    }
                }
                else
                {
                    rezultatLabel.Text = "Rezultat: " + fxsig.ToString("F4");
                    actrezLabel.Text = fxsig.ToString("F4");
                }
            }
            else
            {
                MessageBox.Show("Introduceți valori valide pentru 'θ' și 'g'.");
            }
        }

        private void tanhBtn_Click(object sender, EventArgs e)
        {

            sigmonBtn.Enabled = true;
            tanhBtn.Enabled = false;
            treaptaBtn.Enabled = true;
            rampaBtn.Enabled = true;
            signumBtn.Enabled = true; 
            omegaLabel.Visible = true;
            oTextBox.Visible = true;
            gLabel.Visible = true;
            gTextBox.Visible = true;
            gLabel.Text = "g";
            checkBoxBinary.Visible = true;
            binaryLabel.Visible = true;

            if (double.TryParse(oTextBox.Text, out double t) && double.TryParse(gTextBox.Text, out double g))
            {
                double fx = Math.Pow(en, g * (rez - t)) - Math.Pow(en, -g * (rez - t));
                rezultatLabel.Text = "Rezultat: " + fx.ToString("F4");
                actrezLabel.Text = fx.ToString("F4");
            }
        }

        private void rampaBtn_Click(object sender, EventArgs e)
        {

            sigmonBtn.Enabled = true;
            tanhBtn.Enabled = true;
            treaptaBtn.Enabled = true;
            rampaBtn.Enabled = false;
            signumBtn.Enabled = true;
            omegaLabel.Visible = true;
            oTextBox.Visible = true;
            gLabel.Text = "a";
            gLabel.Visible = true;
            gTextBox.Visible = true;
            if (double.TryParse(oTextBox.Text, out double t) && double.TryParse(gTextBox.Text, out double a))
            {
                if (rez < -a)
                {
                    actrezLabel.Text = "-1";
                    rezultatLabel.Text = "Rezultat: -1 ";
                }
                else
                { // intervalul [-a, a]
                    if (rez >= -a && rez <= a)
                    {
                        actrezLabel.Text = (rez / a).ToString("F4");
                        rezultatLabel.Text = "Rezultat: " + (rez / a).ToString("F4");
                    }
                    else
                    {
                        if (rez > a)
                        {
                            actrezLabel.Text = "1";
                            rezultatLabel.Text = "Rezultat: 1 ";
                        }
                    }

                }
            }
        }

        private void signumBtn_Click(object sender, EventArgs e)
        {

            sigmonBtn.Enabled = true;
            tanhBtn.Enabled = true;
            treaptaBtn.Enabled = true;
            rampaBtn.Enabled = true;
            signumBtn.Enabled = false;
            omegaLabel.Visible = true;
            oTextBox.Visible = true;
            gLabel.Visible = false;
            gTextBox.Visible = false;
            checkBoxBinary.Visible = false;
            double t;
            if (double.TryParse(oTextBox.Text, out t))
            {
                double rezultat = (rez >= t) ? 1 : -1;
                rezultatLabel.Text = "Rezultat: " + rezultat.ToString();
                actrezLabel.Text = rezultat.ToString();
            }
            else
            {

                MessageBox.Show("Introduceți o valoare pentru 'θ'.");
            }
        }

        private void sumBtn_Click(object sender, EventArgs e)
        {
            float sum = 0;
            CalculareSiPunereInVector();
            int contrl = listEntires1.Controls.Count;
            for (int index2 = 0; index2 < contrl; index2++)
            {
                sum = inputgini[index2] + sum;
            }
            globalInputLabel.Text = sum.ToString("F4");
            checkBoxBinary.Visible = true;
            rez = sum;
            rezultatLabel.Text = "Rezultat: " + rez.ToString("F4");
            treaptaBtn.Visible = true;
            sigmonBtn.Visible = true;
            tanhBtn.Visible = true;
            signumBtn.Visible = true;
            rampaBtn.Visible = true;
            label5.Visible = true;
            actrezLabel.Visible = true;
        }

        private void CalculareSiPunereInVector()
        {
            int index = 0; // Index for inputgini 
            foreach (Control control in listEntires1.Controls)
            {
                if (control is LabelTextBoxControl)
                {
                    LabelTextBoxControl textBoxControl = (LabelTextBoxControl)control;
                    if (float.TryParse(textBoxControl.TextBoxText, out float val1) &&
                        float.TryParse(textBoxControl.TextBox2Text, out float val2))
                    {
                        float result = val1 * val2;
                        inputgini[index] = result;
                        index++;
                        /*
						// Afișare rezultate input
						MessageBox.Show($"Rezultatul pentru input {index}: {result} ");
						*/
                    }
                    else
                    {

                        MessageBox.Show($"Date invalide {index + 1}");
                    }
                }

            }
        }

        private void produsBtn_Click(object sender, EventArgs e)
        {
            float prd = 1;
            CalculareSiPunereInVector();
            int contrl = listEntires1.Controls.Count;
            for (int index2 = 0; index2 < contrl; index2++)
            {
                prd = inputgini[index2] * prd;
            }
            globalInputLabel.Text = prd.ToString("F4");
            checkBoxBinary.Visible = true;
            rez = prd;
            rezultatLabel.Text = "Rezultat: " + rez.ToString("F4");
            treaptaBtn.Visible = true;
            sigmonBtn.Visible = true;
            tanhBtn.Visible = true;
            signumBtn.Visible = true;
            rampaBtn.Visible = true;
            label5.Visible = true;
            actrezLabel.Visible = true;

        }

        private void minimBtn_Click(object sender, EventArgs e)
        {
            CalculareSiPunereInVector();
            float min = inputgini[0];
            int contrl = listEntires1.Controls.Count;
            for (int index2 = 0; index2 < contrl; index2++)
            {
                if (inputgini[index2] < min)
                {
                    min = inputgini[index2];
                }
            }
            globalInputLabel.Text = min.ToString("F4");
            checkBoxBinary.Visible = true;
            rez = min;
            rezultatLabel.Text = "Rezultat: " + rez.ToString("F4");
            treaptaBtn.Visible = true;
            sigmonBtn.Visible = true;
            tanhBtn.Visible = true;
            signumBtn.Visible = true;
            rampaBtn.Visible = true;
            label5.Visible = true;
            actrezLabel.Visible = true;
        }

        private void maximBtn_Click(object sender, EventArgs e)
        {
            CalculareSiPunereInVector();
            float max = inputgini[0];
            int contrl = listEntires1.Controls.Count;
            for (int index2 = 0; index2 < contrl; index2++)
            {
                if (inputgini[index2] > max)
                {
                    max = inputgini[index2];
                }
            }
            globalInputLabel.Text = max.ToString("F4");
            checkBoxBinary.Visible = true;
            rez = max;
            rezultatLabel.Text = "Rezultat: " + rez.ToString("F4");
            treaptaBtn.Visible = true;
            sigmonBtn.Visible = true;
            tanhBtn.Visible = true;
            signumBtn.Visible = true;
            rampaBtn.Visible = true;
            label5.Visible = true;
            actrezLabel.Visible = true;
        }
        Dictionary<string, (string, string)> customValues = new Dictionary<string, (string, string)>();
        List<(string, string)> textBoxValues = new List<(string, string)>();
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int controlCount = (int)numericUpDown1.Value;

            // Păstrați valorile TextBox-urilor existente
            var textBoxValues = new List<(string, string)>();
            foreach (Control control in listEntires1.Controls)
            {
                if (control is LabelTextBoxControl textBoxControl)
                {
                    textBoxValues.Add((textBoxControl.TextBoxText, textBoxControl.TextBox2Text));
                }
            }

            // Ștergeți controalele
            listEntires1.Controls.Clear();

            // Adăugați controale noi și reatribuiți valorile
            for (int i = 1; i <= controlCount; i++)
            {
                string labelText = "x" + i;
                string label2Text = "w" + i;
                string textBoxText = "0,01";
                string textBox2Text = "0,01";

                // Verificați dacă există valori salvate și le reatribuiți
                if (textBoxValues.Count > 0)
                {
                    (textBoxText, textBox2Text) = textBoxValues[0];
                    textBoxValues.RemoveAt(0);
                }

                var control1 = new LabelTextBoxControl
                {
                    LabelText = labelText,
                    TextBoxText = textBoxText,
                    Label2Text = label2Text,
                    TextBox2Text = textBox2Text
                };
                listEntires1.Controls.Add(control1);
            }
        }


        private void rezultatLabel_Click(object sender, EventArgs e)
        {

        }

        private string originalLabelText = "";
        private double originalNumericValue = 0;
        private bool isBinaryMode = false;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isBinaryMode = !isBinaryMode;
            if (isBinaryMode)
            {
                if (fxsig != 999)
                {
                    originalLabelText = rezultatLabel.Text;
                    if (double.TryParse(originalLabelText.Replace("Rezultat: ", ""), out originalNumericValue))
                    {
                        string binaryRepresentation = Convert.ToString((long)originalNumericValue, 2);
                        rezultatLabel.Text = "Rezultat: " + binaryRepresentation;
                    }
                    else
                    {
                        MessageBox.Show("Invalid number format.");
                    }
                }
                else
                {
                    if (tsig > 0.5)
                    {
                        rezultatLabel.Text = "Rezultat: 1";
                    }
                    else
                    {
                        rezultatLabel.Text = "Rezultat: 0";
                    }
                }
            }
            else
            {
                rezultatLabel.Text = originalLabelText;
            }
        }

        private void listEntires1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
