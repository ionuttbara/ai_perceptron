using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAI3
{
	public partial class Form1 : Form
	{
		string c;
		DataTable dt = new DataTable();
		DataTable valoriRamase = new DataTable();
		DataTable dtn = new DataTable(); // normal values
		normal[] x = new normal[13];
		public Form1()
		{
			InitializeComponent();
			for (int i = 0; i < 12; ++i)
			{
				x[i] = new normal();
				switch (i)
				{
					case 0:
						x[i].setNorm(0, 10);
						break;
					case 1:
						x[i].setNorm(0, 1);
						break;
					case 2:
						x[i].setNorm(0,1);
						break;
					case 3:
						x[i].setNorm(0, 20);
						break;
					case 4:
						x[i].setNorm(0, 1);
						break;
					case 5:
						x[i].setNorm(0, 70);
						break;
					case 6:
						x[i].setNorm(0, 225);
						break;
					case 7:
						x[i].setNorm(0, 1);
						break;
					case 8:
						x[i].setNorm(0, 5);
						break;
					case 9:
						x[i].setNorm(0, 1);
						break;
					case 10:
						x[i].setNorm(0, 35);
						break;
					case 11:
						x[i].setNorm(0, 10);
						break;
				}
			}
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.Title = "Select a data file";
			openFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
			openFileDialog1.InitialDirectory = @"E:\Projects\Development\Visual Studio\ProjectAI3\ProjectAI3\datasFolder";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				c = openFileDialog1.FileName;
				getDataCSV(c);
				valoriRamase = dtn.Copy();
			}
		}

		// metoda care citește date din CSV și apoi le normalizează
		public void getDataCSV(string path)
		{

			string[] lines = System.IO.File.ReadAllLines(path);
			if (lines.Length > 0)
			{
				string firstLine = lines[0];
				string[] headerLabels = firstLine.Split(';');
				foreach (string headerWord in headerLabels)
				{
					dt.Columns.Add(new DataColumn(headerWord));
					dtn.Columns.Add(new DataColumn(headerWord));
				dataAntrenament.Columns.Add(new DataColumn(headerWord));
				}
				for (int r = 1; r < lines.Length; r++)
				{
					string[] dataWords = lines[r].Split(';');
					DataRow dr = dt.NewRow();
					DataRow drn = dtn.NewRow();
					int columnIndex = 0;
					foreach (string headerWord in headerLabels)
					{
						dr[headerWord] = Convert.ToDecimal(dataWords[columnIndex]);
						decimal dataA = Convert.ToDecimal(dataWords[columnIndex]);
						drn[headerWord] = x[columnIndex].m * dataA + x[columnIndex].n;
						columnIndex++;

					}
					dt.Rows.Add(dr);
					dtn.Rows.Add(drn);
				}
			}
			if (dt.Rows.Count > 0)
			{
				dataGridView1.DataSource = dt;
			dataGridView2.DataSource = dtn;
			}
		}


		// boton de citit date
		private void importDataBtn_Click(object sender, EventArgs e)
		{
			Button b = (Button)sender;
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.Title = "Alege fișierul de date:";
			openFileDialog1.Filter = "FișierCSV (*.csv)|*.csv";
			openFileDialog1.InitialDirectory = @"E:\Projects\Development\Visual Studio\ProjectAI3\ProjectAI3\datasFolder";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				c = openFileDialog1.FileName;
				getDataCSV(c);
				valoriRamase = dtn.Copy();
			}
		}


		//selectare date de Antrenament
		DataRow[] listaDt = new DataRow[1000]; // randuri de antrenament
		DataTable dataAntrenament = new DataTable();
		List<int> listRand = new List<int>();
		public void selectTDatat()
		{
			var rand = new Random();

			for (int i = 0; i < 1000; i++)
			{

				int rd = rand.Next(4500);
				Console.WriteLine(rd);
				listaDt[i] = dtn.Rows[rd];
				dataGridView2.Rows[rd].DefaultCellStyle.BackColor = Color.FromArgb(254, 0, 250);
				listRand.Add(rd);
			}
			listRand.Sort();
			foreach (DataRow row in listaDt)
			{
				dataAntrenament.ImportRow(row);
			}
			dataGridView3.DataSource =dataAntrenament;
			for (int i = 999; i >= 0; i--)
			{
				valoriRamase.Rows[listRand[i]].Delete();
			}

		}

		bool colortab = true;


		//normalizare
		struct normal
		{
			public decimal m;
			public decimal n;
			public decimal a, b;

			public void calculM()
			{
				m = 1 / (b - a);
			}
			public void calculN()
			{
				n = (-a) / (b - a);
			}
			public void setNorm(decimal a, decimal b)
			{
				this.a = a;
				this.b = b;
				calculM();
				calculN();

			}
		}
		// initalizarea retea
		public Layer outputL = new Layer();
		public Layer inputL = new Layer();
		public List<Layer> listHidden = new List<Layer>();
		public void initializaerReteaN()
		{//in
			var rand = new Random();
			inputL.listaNeuroni = new List<Neuron>();
			inputL.nrNeuroni = dataAntrenament.Columns.Count - 1;
			for (int i = 0; i < dataAntrenament.Columns.Count - 1; i++)
			{
				Neuron n = new Neuron();
				inputL.listaNeuroni.Add(n);
			}

			listHidden = new List<Layer>();
			//hidden
			for (int i = 0; i < listaNrNeuroniHiddenLAyer.Count; i++)
			{
				Layer l = new Layer();
				l.nrNeuroni = Convert.ToInt32(listaNrNeuroniHiddenLAyer[i]);
				l.listaNeuroni = new List<Neuron>();
				listHidden.Add(l);


				for (int j = 0; j < listaNrNeuroniHiddenLAyer[i]; j++)
				{
					Neuron n = new Neuron();
					n.tari = new List<decimal>();
					n.input = new List<decimal>();
					if (i == 0)
					{
						for (int k = 0; k < inputL.nrNeuroni; k++)
						{
							if (rand.Next() % 2 == 0)
							{
								n.tari.Add(Convert.ToDecimal(rand.NextDouble()));
								n.input.Add(0);
							}
							else
							{
								n.tari.Add(-Convert.ToDecimal(rand.NextDouble()));
								n.input.Add(0);
							}
						}
					}
					else
					{
						for (int k = 0; k < listaNrNeuroniHiddenLAyer[i - 1]; k++)
						{
							n.tari.Add(Convert.ToDecimal(rand.NextDouble()));
							n.input.Add(0);
						}
					}

					listHidden[i].listaNeuroni.Add(n);
				}

			}

			//out
			outputL.listaNeuroni = new List<Neuron>();
			outputL.nrNeuroni = 1;
			Neuron n1 = new Neuron();
			n1.tari = new List<decimal>();
			n1.input = new List<decimal>();
			for (int k = 0; k < listaNrNeuroniHiddenLAyer[listaNrNeuroniHiddenLAyer.Count - 1]; k++)
			{
				n1.tari.Add(Convert.ToDecimal(rand.NextDouble()));
				n1.input.Add(0);
			}
			outputL.listaNeuroni.Add(n1);

		}
		public void numericUDsaveNr_ValueChanged(object sender, EventArgs e)
		{
			listaNrNeuroniHiddenLAyer = new List<decimal>();
			for (int i = 0; i < numericUpDown4.Value; i++)
			{
				listaNrNeuroniHiddenLAyer.Add(listnNmericUpDowns[i].Value);
				initializaerReteaN();
				// Console.WriteLine(listaNrNeuroniHiddenLAyer[i]);
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
				if (colortab)
				{
					selectTDatat();
					colortab = false;
				}
				//   dataGridView2. = Color.FromArgb(200, 0, 100);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			chart1.Series.Clear();
			chart1.Series.Add("Eroare Epoca");
			chart1.Series.Add("Eroare Admisa");

			chart1.Series["Eroare Epoca"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart1.Series["Eroare Admisa"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

	  invatare();
			listaEepoca = new List<decimal>();
		   testare();
			initializaerReteaN();
		}

		public bool stop = true;
		public decimal EepocaCurenta;
		public List<decimal> listaEpas;
		public List<decimal> listaEepoca;
		decimal primul = 0;
		public void invatare()
		{
			decimal nrEpoci = numericUpDown3.Value;
			listaEepoca = new List<decimal>();
			decimal Q = 0;
			decimal auxEpas;
			decimal auxTy;
			EepocaCurenta = 1;

			for (int i = 0; i < nrEpoci; i++)
			{
				listaEpas = new List<decimal>();
				DataRow[] dr = dataAntrenament.Select();
				Q = 0;
				if (EepocaCurenta < numericUpDown2.Value == false)
				{
					for (int j = 0; j < 1000; j++)
					{
						Q++;
						string[] elemente = new string[12];

						elemente[0] = dr[j].Field<string>("fixed acidity");
						elemente[1] = dr[j].Field<string>("volatile acidity");
						elemente[2] = dr[j].Field<string>("citric acid");
						elemente[3] = dr[j].Field<string>("residual sugar");
						elemente[4] = dr[j].Field<string>("chlorides");
						elemente[5] = dr[j].Field<string>("free sulfur dioxide");
						elemente[6] = dr[j].Field<string>("total sulfur dioxide");
						elemente[7] = dr[j].Field<string>("density");
						elemente[8] = dr[j].Field<string>("pH");
						elemente[9] = dr[j].Field<string>("sulphates");
						elemente[10] = dr[j].Field<string>("alcohol");
						elemente[11] = dr[j].Field<string>("quality");

						//incarc valorile in neuroni si calculez output retea
						for (int l = 0; l < inputL.listaNeuroni.Count; l++)
						{
							Neuron n = inputL.listaNeuroni[l];

							n.output = Convert.ToDecimal(elemente[l]);
							inputL.listaNeuroni[l] = n;
						}
						Neuron nt = outputL.listaNeuroni[0];
						//	nt.output = calculaOutputRetea();//neuron temporar
						outputL.listaNeuroni[0] = nt;
						//calcul eroare pas
						decimal x = Convert.ToDecimal(elemente[11]);
						decimal y = outputL.listaNeuroni[0].output;
						auxEpas = x - y;
						auxTy = (auxEpas * auxEpas) / 2;
						listaEpas.Add(auxTy);
	

						Neuron no = outputL.listaNeuroni[0];

						no.eroareNeuron = outputL.listaNeuroni[0].calculEroareOut(Convert.ToDecimal(elemente[11]));//rezultat-tinta * derivataAct
						outputL.listaNeuroni[0] = no;
						outputL.listaNeuroni[0].recalculTariiEroare(numericUpDown1.Value);



						for (int k = listHidden.Count - 1; k >= 0; k--)
						{
							if (k == listHidden.Count - 1)
							{

								for (int p = 0; p < listHidden[k].listaNeuroni.Count; p++)
								{
									Neuron n = listHidden[k].listaNeuroni[p];
									n.eroareNeuron = 0;
									for (int u = 0; u < outputL.listaNeuroni.Count; u++)
									{
										n.eroareNeuron += outputL.listaNeuroni[u].eroareNeuron * outputL.listaNeuroni[u].tari[p];

									}
									n.eroareNeuron *= n.activare * (1 - n.activare);


									n.tari = listHidden[k].listaNeuroni[p].recalculTariiEroare(numericUpDown1.Value);
									listHidden[k].listaNeuroni[p] = n;
								}


							}
							else
							{
								for (int p = 0; p < listHidden[k].listaNeuroni.Count; p++)
								{
									Neuron n = listHidden[k].listaNeuroni[p];
									n.eroareNeuron = 0;
									for (int u = 0; u < listHidden[k + 1].listaNeuroni.Count; u++)
									{
										n.eroareNeuron += listHidden[k + 1].listaNeuroni[u].eroareNeuron * listHidden[k + 1].listaNeuroni[u].tari[p];

									}
									n.eroareNeuron *= n.activare * (1 - n.activare);
									n.tari = listHidden[k].listaNeuroni[p].recalculTariiEroare(numericUpDown1.Value);
									listHidden[k].listaNeuroni[p] = n;
								}

							}
						}

					}
					EepocaCurenta = calculEepoca(Q);
					textBox1.Text = EepocaCurenta.ToString();
					//if (primul == 0) primul = EepocaCurenta;
					 chart1.Series["Eroare Epoca"].Points.AddXY(i, primul);
					chart1.Series["Eroare Epoca"].Points.AddXY(i, EepocaCurenta);
					chart1.Series["Eroare Admisa"].Points.AddXY(i, numericUpDown2.Value);
					  chart1.Invalidate();
					listaEepoca.Add(EepocaCurenta);

				}
			}
			// MessageBox.Show("terminare ant");
	//		testare();
		}
		public decimal calculEepoca(decimal Q)
		{
			decimal Eepoca = 0;
			for (int i = 1; i < Q; i++)
			{
				Eepoca += listaEpas[i];
			}
			return Eepoca / Q;

		}

		private void button2_Click(object sender, EventArgs e)
		{
		stop = false;
		}

		private void tabPage5_Click(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			chart1.Series.Clear();
			chart1.Series.Add("Eroare Epoca");
			chart1.Series.Add("Eroare Admisa");

			chart1.Series["Eroare Epoca"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart1.Series["Eroare Admisa"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
		}

		public struct Layer
		{
			public List<Neuron> listaNeuroni { get; set; }
			public int nrNeuroni;
			public string numeL;
			public List<decimal> listOutpuLayerAnterior;
			public List<decimal> listaOutpuLayerActual;

			public List<decimal> setOutputLActual()
			{
				listaOutpuLayerActual = new List<decimal>();
				for (int i = 0; i < listaNeuroni.Count; i++)
				{
					listaOutpuLayerActual.Add(listaNeuroni[i].output);
				}
				return listaOutpuLayerActual;
			}
		}
		//initializare layer
		List<decimal> listaNrNeuroniHiddenLAyer;
		List<NumericUpDown> listnNmericUpDowns;
		private void numericUpDown4_ValueChanged(object sender, EventArgs e)
		{
			creareIntrari(Convert.ToInt32(numericUpDown4.Value));
			numericUDsaveNr_ValueChanged(sender, e);
		}
		public void testare()
		{
			dataGridView3.DataSource = valoriRamase;
			DataRow[] r = valoriRamase.Select();
			decimal p = 0;
			for (int j = 0; j < valoriRamase.Rows.Count; j++)
			{
				string[] elemente = new string[12];
				elemente[0] = r[j].Field<string>("fixed acidity");
				elemente[1] = r[j].Field<string>("volatile acidity");
				elemente[2] = r[j].Field<string>("citric acid");
				elemente[3] = r[j].Field<string>("residual sugar");
				elemente[4] = r[j].Field<string>("chlorides");
				elemente[5] = r[j].Field<string>("free sulfur dioxide");
				elemente[6] = r[j].Field<string>("total sulfur dioxide");
				elemente[7] = r[j].Field<string>("density");
				elemente[8] = r[j].Field<string>("pH");
				elemente[9] = r[j].Field<string>("sulphates");
				elemente[10] = r[j].Field<string>("alcohol");
				elemente[11] = r[j].Field<string>("quality");


				for (int l = 0; l < inputL.listaNeuroni.Count; l++)
				{
					Neuron n = inputL.listaNeuroni[l];

					n.output = Convert.ToDecimal(elemente[l]);
					inputL.listaNeuroni[l] = n;
				}
				//calculaOutputRetea();
				//   outputL.listaNeuroni[0].output;
				if (j % 100 == 0)
				{
					chart2.Series["Valoare Calculata"].Points.AddXY(j, outputL.listaNeuroni[0].output);
					chart2.Series["Valoare Initiala"].Points.AddXY(j, Convert.ToDecimal(elemente[11]));
				}
				if (outputL.listaNeuroni[0].output - Convert.ToDecimal(elemente[11]) >= 0 && outputL.listaNeuroni[0].output - Convert.ToDecimal(elemente[11]) < numericUpDown2.Value * 2)
				{
					p++;
				}

			}

			decimal c = (p * 100) / valoriRamase.Rows.Count;

			label16.Text = c.ToString() + "%";

		}

		public void creareIntrari(int nrIntrari)
		{
			panel1.Controls.Clear();
			listnNmericUpDowns = new List<NumericUpDown>();
			for (int i = 0; i < nrIntrari; ++i)
			{
				NumericUpDown n = new NumericUpDown();
				Label l = new Label();
				int index = i;

				n.Size = new System.Drawing.Size(60, 30);
				n.Top = i * 40;
				n.Left = 220;
				n.Name = "NumUD1-" + i.ToString();
				n.Maximum = 1000;
				n.Minimum = 1;
				panel1.Controls.Add(n);

				n.ValueChanged += new EventHandler(this.numericUDsaveNr_ValueChanged);

				listnNmericUpDowns.Add(n);

				l.Size = new System.Drawing.Size(200, 30);
				l.Top = i * 40;
				l.Left = 3;
				l.BackColor = Color.Transparent;
				l.Text = "Numar de neuroni pe Hidden layer" + i.ToString() + ":";
				l.Name = "Hlayer" + i.ToString();
				panel1.Controls.Add(l);
			}
		}
		public struct Neuron
		{
			public List<decimal> input;
			public List<decimal> tari;
			public decimal output;
			public decimal gin;
			public decimal activare;
			public string nume;
			public decimal eroareNeuron;
			public decimal dTarii;
			public void outputN()//setare output
			{
				output = functieActivare();
			}
			public decimal functieActivare()//functie activare
			{
				gin = functieIntrare();
				activare = fSigmoidala(gin);
				return activare;

			}

			public decimal fSigmoidala(decimal x)
			{
				decimal g = 1;
				decimal teta = 0;
				return Convert.ToDecimal(1 / (1 + Math.Exp(Convert.ToDouble(-g * (x - teta)))));
			}

			public decimal functieIntrare()//functie intrare
			{
				decimal sum = 0;
				for (int i = 0; i < input.Count; ++i)
				{
					sum += input[i] * tari[i];
				}
				gin = sum;
				return sum;
			}

			public decimal calculEroareOut(decimal tinta)
			{
				return (output - tinta) * activare * (1 - activare);
			}

			public List<decimal> recalculTariiEroare(decimal pas)
			{

				dTarii = -pas * activare * eroareNeuron;
				for (int i = 0; i < tari.Count; i++)
					tari[i] = tari[i] + dTarii;

				return tari;
			}
		}
	}
}
