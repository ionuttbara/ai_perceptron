using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Project2_AI
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			FormBorderStyle = FormBorderStyle.FixedSingle;
			InitializeComponent();

		}
		private int numberOfHiddenLayers;
		private int[] layerHeights;
		private int numberOfOutputNeurons;
		private int numberOfInputNeurons;
		private Tuple<int, int> selectedHiddenNeuron;
		private List<double> inputNeuronValues = new List<double>();
		private List<Button> hiddenLayerButtons = new List<Button>();
		List<List<List<double>>> synapticWeights = new List<List<List<double>>>();
		private Button outputButton;


		private void buttonOpenInputDialog_Click(object sender, EventArgs e)
		{
			using (InputDialog inputDialog = new InputDialog())
			{
				// Inițializați valorile NumericUpDown cu 1
				inputDialog.numericUpDownHiddenLayer.Value = 1;
				inputDialog.numericUpDownInputLayer.Value = 1;
				inputDialog.numericUpDownOutputLayer.Value = 1;

				// Afizați fereastra modală
				if (inputDialog.ShowDialog() == DialogResult.OK)
				{
					// Obțineți valorile introduse de utilizator și le puteți folosi
					int hiddenLayerValue = (int)inputDialog.numericUpDownHiddenLayer.Value;
					int inputLayerValue = (int)inputDialog.numericUpDownInputLayer.Value;
					numberOfInputNeurons = (int)inputDialog.numericUpDownInputLayer.Value;
					int outputLayerValue = (int)inputDialog.numericUpDownOutputLayer.Value;
					int[] hiddenLayerNeurons = inputDialog.GetHiddenLayerNeurons();
					// Aici puteți utiliza valorile pentru a configura rețeaua neurală sau altceva, după caz
					InitializeNeuralNetwork(inputLayerValue, hiddenLayerValue, hiddenLayerNeurons, outputLayerValue);
					DrawClickableNeuralNetwork(inputLayerValue, hiddenLayerValue, hiddenLayerNeurons, outputLayerValue);
				}
			}
		}
		private void DrawClickableNeuralNetwork(int numberOfInputNeurons, int numberOfHiddenLayers, int[] hiddenLayerNeurons, int numberOfOutputNeurons)
		{
			inputNeuronValues = Enumerable.Repeat(0.0, numberOfInputNeurons).ToList(); // se face o lista de n hidden layere a.i. sa nu fie exceptie. toate elementele sunt initializate cu 0.
			using (Graphics g = AIGraphic.CreateGraphics())
			{
				g.Clear(Color.White);
				int inputX = 100;
				int hiddenX = 300;
				int verticalSpacing = 50;
				int neuronSize = 30;
				int textOffsetXInput = -50; // Ajustați această valoare pentru neuroni de intrare
				int textOffsetYHidden = -25;
				FlowLayoutPanel hiddenLayerButtonsPanel = new FlowLayoutPanel();
				hiddenLayerButtonsPanel.FlowDirection = FlowDirection.RightToLeft;
				hiddenLayerButtonsPanel.Dock = DockStyle.Top;
				// adaugare boton de output

				// Crearea și configurarea butonului "Output"
				outputButton = new Button();
				outputButton.Size = new Size(150, 40);
				outputButton.Text = "Output";
				outputButton.Tag = "Output"; // Atribuiți un tag pentru a identifica ulterior

				// Adăugați un eveniment de click pentru butonul "Output"
				outputButton.Click += (sender, e) =>
{
				  // Aici puteți trata acțiunea corespunzătoare pentru butonul "Output"
				 MessageBox.Show("Output Button selected.");
};
				// Adăugați butonul "Output" la panoul pentru butoanele stratului ascuns
				hiddenLayerButtonsPanel.Controls.Add(outputButton);

				List<Rectangle> inputNeuronRectangles = new List<Rectangle>();
				//		List<Rectangle> hiddenNeuronRectangles = new List<Rectangle>();
				List<List<Rectangle>> hiddenNeuronRectangles = new List<List<Rectangle>>();

				List<Rectangle> outputNeuronRectangles = new List<Rectangle>();
				// Calculează lățimea totală a stratului ascuns și a stratului de ieșire
				int totalHiddenWidth = numberOfHiddenLayers * 100;
				int outputX = inputX + totalHiddenWidth + 200; // 200 este spațiul între stratul ascuns și stratul de ieșire

				// Desenare pentru stratul de intrare
				int inputStartY = (AIGraphic.Height - numberOfInputNeurons * verticalSpacing) / 2;
				for (int i = 0; i < numberOfInputNeurons; i++)
				{
					int y = inputStartY + i * verticalSpacing;
					Rectangle neuronRect = new Rectangle(inputX - neuronSize / 2, y - neuronSize / 2, neuronSize, neuronSize);
					g.DrawEllipse(Pens.Blue, neuronRect);

					// Măsurați dimensiunea textului pentru a-l plasa corect în centrul cercurilor
					SizeF textSize = g.MeasureString($"Input {i}", Font);
					float textX = inputX - textSize.Width / 2 + textOffsetXInput; // Aici aplicăm ajustarea pentru neuroni de intrare
					float textY = y - textSize.Height / 2;

					g.DrawString($"Input {i}", Font, Brushes.Blue, textX, textY);
					inputNeuronRectangles.Add(neuronRect);
				}

				int currentX = hiddenX;
				int[] layerHeights = new int[numberOfHiddenLayers];

				// Adăugați butoane pentru fiecare strat ascuns
				for (int layer = 0; layer < numberOfHiddenLayers; layer++)
				{
					Button hiddenLayerButton = new Button();
					hiddenLayerButton.Size = new Size(150, 40); // Aici puteți ajusta dimensiunile în funcție de preferințe
					hiddenLayerButton.Text = $"Hidden Layer {layer}";
					hiddenLayerButton.Tag = layer; // Atribuiți stratului ascuns un tag pentru a putea identifica ulterior
				// Adăugați un eveniment de click pentru buton
					hiddenLayerButton.Click += HiddenLayerButton_Click;

					hiddenLayerButtons.Add(hiddenLayerButton); // Adăugați butonul la lista de butoane

					hiddenLayerButtonsPanel.Controls.Add(hiddenLayerButton);

					hiddenLayerButtonsPanel.Controls.Add(hiddenLayerButton);
				}
				this.Controls.Add(hiddenLayerButtonsPanel);

				// Desenare pentru straturile ascunse și calculul înălțimii fiecărui strat ascuns
				for (int layer = 0; layer < numberOfHiddenLayers; layer++)
				{
					int numberOfNeuronsInLayer = hiddenLayerNeurons[layer];

					int layerHeight = numberOfNeuronsInLayer * verticalSpacing;
					layerHeights[layer] = layerHeight;

					int startY = inputStartY + (numberOfInputNeurons * verticalSpacing - layerHeight) / 2;

					List<Rectangle> layerRectangles = new List<Rectangle>(); // Lista pentru neuronii stratului curent

					for (int neuron = 0; neuron < numberOfNeuronsInLayer; neuron++)
					{
				
						int y = startY + neuron * verticalSpacing;
						Rectangle neuronRect = new Rectangle(currentX - neuronSize / 2, y - neuronSize / 2, neuronSize, neuronSize);
						g.DrawEllipse(Pens.Green, neuronRect);
						g.DrawString($"Hidden {layer}-{neuron}", Font, Brushes.Green, currentX - 40, y - 10 + textOffsetYHidden);

						// Adăugați dreptunghiul neuronului la lista stratului curent
						layerRectangles.Add(neuronRect);
					}

					// Adăugați lista dreptunghiurilor stratului la lista generală
					hiddenNeuronRectangles.Add(layerRectangles);

					currentX += 100;
				}
				currentX = inputX + 100;
				int outputStartY = (AIGraphic.Height - numberOfOutputNeurons * verticalSpacing) / 2;

				// Desenare pentru stratul de ieșire
				for (int i = 0; i < numberOfOutputNeurons; i++)
				{
					int y = outputStartY + i * verticalSpacing;
					Rectangle neuronRect = new Rectangle(outputX - neuronSize / 2, y - neuronSize / 2, neuronSize, neuronSize);
					g.DrawEllipse(Pens.Red, neuronRect);
					g.DrawString($"Output {i}", Font, Brushes.Red, outputX + 40, y - 10);
					outputNeuronRectangles.Add(neuronRect);
				}

				for (int i = 0; i < numberOfInputNeurons; i++)
				{
					for (int j = 0; j < hiddenLayerNeurons[0]; j++)
					{
						int startY = inputStartY + i * verticalSpacing;
						int endY = inputStartY + (numberOfInputNeurons * verticalSpacing - layerHeights[0]) / 2;

						using (Pen connectionPen = new Pen(Color.Black, 2f)) // Grosimea liniei este setată la 2f (puteți ajusta grosimea)
						{
							g.DrawLine(Pens.Black, inputX + neuronSize / 2, startY,
							hiddenX - neuronSize / 2, endY + j * verticalSpacing);
						}
						// Adăugarea conexiunilor la lista de conexiuni
					}
				}

				currentX = hiddenX;
				for (int layer = 0; layer < numberOfHiddenLayers - 1; layer++)
				{
					int currentLayerNeurons = hiddenLayerNeurons[layer];
					int nextLayerNeurons = hiddenLayerNeurons[layer + 1];

					for (int i = 0; i < currentLayerNeurons; i++)
					{
						for (int j = 0; j < nextLayerNeurons; j++)
						{
							int startY = inputStartY + (numberOfInputNeurons * verticalSpacing - layerHeights[layer]) / 2;
							int endY = inputStartY + (numberOfInputNeurons * verticalSpacing - layerHeights[layer + 1]) / 2;
							using (Pen connectionPen = new Pen(Color.Black, 2f)) // Grosimea liniei este setată la 2f (puteți ajusta grosimea)
							{
								g.DrawLine(Pens.Black, currentX + neuronSize / 2, startY + i * verticalSpacing,
								currentX + 100 - neuronSize / 2, endY + j * verticalSpacing);
							}

						}
					}
					currentX += 100;
				}

				for (int i = 0; i < hiddenLayerNeurons[numberOfHiddenLayers - 1]; i++)
				{
					for (int j = 0; j < numberOfOutputNeurons; j++)
					{
						int startY = inputStartY + (numberOfInputNeurons * verticalSpacing - layerHeights[numberOfHiddenLayers - 1]) / 2;
						int endY = outputStartY + j * verticalSpacing;
						using (Pen connectionPen = new Pen(Color.Black, 2f)) // Grosimea liniei este setată la 2f (puteți ajusta grosimea)
						{
							g.DrawLine(Pens.Black, currentX + neuronSize / 2, startY + i * verticalSpacing,
							outputX - neuronSize / 2, endY);
						}

					}
				}
				// Aici adăugăm evenimentul de click pentru fiecare tip de neuron și conexiune
				AIGraphic.MouseClick += (sender, e) =>
				{
					int layerIndex = 0; 
					int neuronIndex = 0;

					foreach (Rectangle rect in inputNeuronRectangles)
					{
						if (rect.Contains(e.Location))
						{
							// Obțineți indexul neuronului de intrare din lista inputNeuronRectangles
						  neuronIndex = inputNeuronRectangles.IndexOf(rect);

							// Afișați fereastra de dialog pentru a introduce valoarea
							using (Form inputForm = new Form())
							{
								int neuronNumber = neuronIndex + 1;
								inputForm.Text = $"Value for Input Neuron {neuronNumber}";

								inputForm.Size = new Size(350, 150);

								Label label = new Label();
								label.Text = "Value:";
								label.Location = new Point(20, 20);
								inputForm.Controls.Add(label);

								NumericUpDown numericUpDown = new NumericUpDown();
								numericUpDown.DecimalPlaces = 3;
								numericUpDown.Minimum = 0;
								numericUpDown.Maximum = 99999999;
								numericUpDown.Location = new Point(10, 45);
								inputForm.Controls.Add(numericUpDown);

								Button okButton = new Button();
								okButton.Text = "OK";
								okButton.Location = new Point(10, 75);
								inputForm.Controls.Add(okButton);

								okButton.Click += (okSender, okEventArgs) =>
								{
									double inputValue = (double)numericUpDown.Value;

									// Actualizați valoarea corespunzătoare din lista inputNeuronValues
									inputNeuronValues[neuronIndex] = inputValue;

									// Afișați o confirmare
									MessageBox.Show($"Value for Input Neuron {neuronNumber}: {inputValue}");
									inputForm.Close();
								};

								inputForm.ShowDialog();
							}
							return;
						}
					}
					 layerIndex = -1;
					 neuronIndex = -1;
					foreach (List<Rectangle> layer in hiddenNeuronRectangles)
					{
						for (int neuron = 0; neuron < layer.Count; neuron++)
						{
							if (layer[neuron].Contains(e.Location))
							{
								layerIndex = hiddenNeuronRectangles.IndexOf(layer);
								neuronIndex = neuron;
								break;
							}
						}

						if (layerIndex >= 0)
						{
							break;
						}
					}

					if (layerIndex >= 0 && neuronIndex >= 0)
					{
						// Aici puteți trata acțiunile corespunzătoare stratului și neuronului identificat
						using (Form neuronInfoForm = new Form())
						{
							neuronInfoForm.Text = $"HiddenLayer {layerIndex} Neuron {neuronIndex}";

							neuronInfoForm.Size = new Size(400, 200);

							Label inputValuesLabel = new Label();
							inputValuesLabel.Text = "Input Values:";
							inputValuesLabel.Location = new Point(20, 20);
							neuronInfoForm.Controls.Add(inputValuesLabel);

							ListBox inputValuesListBox = new ListBox();
							inputValuesListBox.Location = new Point(20, 45);
							inputValuesListBox.Size = new Size(150, 100);

							// Adăugați valorile inputurilor relevante la ListBox
							for (int i = 0; i < numberOfInputNeurons; i++)
							{
								double inputValue = inputNeuronValues[i];
								inputValuesListBox.Items.Add($"Input {i}: {inputValue}");
							}

							neuronInfoForm.Controls.Add(inputValuesListBox);

							Label synapticWeightsLabel = new Label();
							synapticWeightsLabel.Text = "Synaptic Weights:";
							synapticWeightsLabel.Location = new Point(200, 20);
							neuronInfoForm.Controls.Add(synapticWeightsLabel);

							ListBox synapticWeightsListBox = new ListBox();
							synapticWeightsListBox.Location = new Point(200, 45);
							synapticWeightsListBox.Size = new Size(150, 100);

							for (int i = 0; i < synapticWeights[layerIndex][neuronIndex].Count; i++)
							{
								double synapticWeight = synapticWeights[layerIndex][neuronIndex][i];
								int weightIndex = i + 1;
								synapticWeightsListBox.Items.Add($"Synaptic Weight {weightIndex}: {synapticWeight}");

								// Adăugați buton pentru editarea ponderii sinaptice
								Button editWeightButton = new Button();
								editWeightButton.Text = "Edit";
								editWeightButton.Location = new Point(360, 45 + i * 20);
								editWeightButton.Tag = i; // Utilizăm Tag pentru a ține evidența ponderii care trebuie editată

								// Adăugați eveniment pentru a modifica valorile ponderilor
								editWeightButton.Click += (editButtonSender, editButtonE) =>
								{
									int selectedIndex = (int)editWeightButton.Tag;

									using (Form weightForm = new Form())
									{
										weightForm.Text = $"Edit Synaptic Weight {selectedIndex}";
										weightForm.Size = new Size(350, 150);

										Label label = new Label();
										label.Text = "Weight Value:";
										label.Location = new Point(20, 20);
										weightForm.Controls.Add(label);

										NumericUpDown numericUpDown = new NumericUpDown();
										numericUpDown.DecimalPlaces = 3;
										numericUpDown.Minimum = -9999999;
										numericUpDown.Maximum = 99999999;
										numericUpDown.Value = (decimal)synapticWeights[layerIndex][neuronIndex][selectedIndex]; // Setăm valoarea curentă a ponderii

										numericUpDown.Location = new Point(10, 45);
										weightForm.Controls.Add(numericUpDown);

										Button okButton = new Button();
										okButton.Text = "OK";
										okButton.Location = new Point(10, 75);
										weightForm.Controls.Add(okButton);

										okButton.Click += (okSender, okEventArgs) =>
										{
											double newWeightValue = (double)numericUpDown.Value;

											// Actualizați valoarea ponderii sinaptice în lista synapticWeights
											if (layerIndex >= 0 && layerIndex < synapticWeights.Count &&
												neuronIndex >= 0 && neuronIndex < synapticWeights[layerIndex].Count &&
												selectedIndex >= 0 && selectedIndex < synapticWeights[layerIndex][neuronIndex].Count)
											{
												// Actualizați valoarea ponderii sinaptice în lista synapticWeights
												synapticWeights[layerIndex][neuronIndex][selectedIndex] = newWeightValue;

												// Actualizați afișarea din ListBox pentru ponderile sinaptice ale neuronului curent
												synapticWeightsListBox.Items[selectedIndex] = $"Synaptic Weight {selectedIndex + 1}: {newWeightValue}";

												// Afișați o confirmare
												MessageBox.Show($"Synaptic Weight {selectedIndex + 1} updated: {newWeightValue}");
												weightForm.Close();
											}
											else
											{
												MessageBox.Show("Indicii specificați nu sunt valizi.");
											}
										};

										weightForm.ShowDialog();
									}
								};

								neuronInfoForm.Controls.Add(editWeightButton);
							}

							// ...

							neuronInfoForm.Controls.Add(synapticWeightsListBox);
							neuronInfoForm.ShowDialog();
						}

						selectedHiddenNeuron = Tuple.Create(layerIndex, neuronIndex);

					}
					else
					{
						// Dacă nu s-a găsit un strat și un neuron corespunzător clicului
						MessageBox.Show("Niciun neuron selectat.");
					}


					foreach (Rectangle rect in outputNeuronRectangles)
					{
						if (rect.Contains(e.Location))
						{
							MessageBox.Show("Neuron de ieșire selectat.");
							return;
						}
					}
				};
			};
		}

		private void AIGraphic_Click(object sender, EventArgs e)
		{

		}
		private void InitializeNeuralNetwork(int inputLayerValue, int hiddenLayerValue, int[] hiddenLayerNeurons, int outputLayerValue)
		{
			inputNeuronValues = Enumerable.Repeat(0.0, inputLayerValue).ToList();
			numberOfHiddenLayers = hiddenLayerValue;
			layerHeights = new int[numberOfHiddenLayers];
			numberOfOutputNeurons = outputLayerValue;

			// Inițializați lista de ponderi sinaptice
			synapticWeights.Clear();

			// Inițializați ponderile sinaptice pentru primul strat ascuns
			int firstHiddenLayerNeurons = hiddenLayerNeurons[0];
			List<List<double>> firstHiddenLayerWeights = new List<List<double>>();
			for (int i = 0; i < firstHiddenLayerNeurons; i++)
			{
				List<double> neuronWeights = new List<double>();
				for (int j = 0; j < numberOfInputNeurons; j++)
				{
					// Inițializați ponderile cu valori implicite (puteți le înlocuiți cu alte valori)
					neuronWeights.Add(0.0);
				}
				firstHiddenLayerWeights.Add(neuronWeights);
			}
			synapticWeights.Add(firstHiddenLayerWeights);
	
			// Inițializați ponderile sinaptice pentru celelalte straturi
			for (int layer = 1; layer < numberOfHiddenLayers + 1; layer++)
			{
				int currentLayerNeurons;
				int nextLayerNeurons;

				if (layer == numberOfHiddenLayers)
				{
					currentLayerNeurons = hiddenLayerNeurons[layer - 1];
					nextLayerNeurons = numberOfOutputNeurons;
				}
				else
				{
					currentLayerNeurons = hiddenLayerNeurons[layer - 1];
					nextLayerNeurons = hiddenLayerNeurons[layer];
				}

				List<List<double>> layerWeights = new List<List<double>>();

				for (int neuron = 0; neuron < currentLayerNeurons; neuron++)
				{
					List<double> neuronWeights = new List<double>();

					for (int i = 0; i < nextLayerNeurons; i++)
					{
						// Inițializați ponderile cu valori implicite (puteți le înlocuiți cu alte valori)
						neuronWeights.Add(0.0);
					}

					layerWeights.Add(neuronWeights);
				}

				synapticWeights.Add(layerWeights);
			}
		}



		private void buttonShowHiddenLayerSettings_Click(object sender, EventArgs e)
{
    using (HiddenLayerSettingsDialog settingsDialog = new HiddenLayerSettingsDialog())
    {
        // Populați combobox-urile cu opțiuni
        settingsDialog.inputFunctionComboBox.Items.AddRange(new string[] { "Suma", "Produs", "Min", "Max" });
        settingsDialog.activationFunctionComboBox.Items.AddRange(new string[] { "Tangentă hiperbolică", "Rampă", "Treaptă", "Signum", "Sigmoidală" });

        // Inițializați valorile NumericUpDown cu valorile implicite
        settingsDialog.thetaNumericUpDown.Value = 0;
        settingsDialog.gNumericUpDown.Value = 1;

        // Afizați fereastra de dialog
        if (settingsDialog.ShowDialog() == DialogResult.OK)
        {
            // Obțineți valorile selectate sau introduse de utilizator
            string inputFunction = settingsDialog.InputFunction;
            string activationFunction = settingsDialog.ActivationFunction;
            double theta = settingsDialog.Theta;
            double g = settingsDialog.G;
		    string ComportamentFunction = settingsDialog.ComportamentFunction;

					// Aici puteți folosi aceste valori cum doriți
					double globalInput = CalculateGlobalInput(inputNeuronValues, synapticWeights[0][selectedHiddenNeuron.Item2], "Suma");
					MessageBox.Show($"Funcția de intrare: {inputFunction}\nFuncția de activare: {activationFunction}\nTheta: {theta}\nG: {g}\nComportament: {ComportamentFunction}\nValoare global input de proba {globalInput}");
					Console.WriteLine($"Valoare global input de proba {globalInput}");
				}
			}
}
		private void HiddenLayerButton_Click(object sender, EventArgs e)
		{
			int selectedLayer = (int)((Button)sender).Tag;
			using (HiddenLayerSettingsDialog settingsDialog = new HiddenLayerSettingsDialog())
    {
				settingsDialog.Text = $"Hidden Layer  {selectedLayer} Information";
				// Populați combobox-urile cu opțiuni
				settingsDialog.inputFunctionComboBox.Items.AddRange(new string[] { "Suma", "Produs", "Min", "Max" });
        settingsDialog.activationFunctionComboBox.Items.AddRange(new string[] { "Tangentă hiperbolică", "Rampă", "Treaptă", "Signum", "Sigmoidală" });
				settingsDialog.compComboBox.Items.AddRange(new string[] { "Real", "Binar"});

				// Inițializați valorile NumericUpDown cu valorile implicite
				settingsDialog.thetaNumericUpDown.Value = 0;
        settingsDialog.gNumericUpDown.Value = 1;

        // Afizați fereastra de dialog
        if (settingsDialog.ShowDialog() == DialogResult.OK)
        {
            // Obțineți valorile selectate sau introduse de utilizator
            string inputFunction = settingsDialog.InputFunction;
            string activationFunction = settingsDialog.ActivationFunction;
            double theta = settingsDialog.Theta;
					double g = settingsDialog.G;
					string ComportamentFunction = settingsDialog.ComportamentFunction;

					// Aici puteți folosi aceste valori cum doriți
					double globalInput = CalculateGlobalInput(inputNeuronValues, synapticWeights[0][selectedHiddenNeuron.Item2], inputFunction);
					MessageBox.Show($"Funcția de intrare: {inputFunction}\nFuncția de activare: {activationFunction}\nTheta: {theta}\nG: {g}\nComportament: {ComportamentFunction}\nValoare global input de proba {globalInput}");
				}
			}
		}
		private void ShowNeuronInfo(int layer, int neuron)
		{
			using (Form neuronInfoForm = new Form())
			{
				neuronInfoForm.Text = $"Neuron Info - HiddenLayer {layer + 1}, Neuron {neuron + 1}";
				neuronInfoForm.Size = new Size(400, 200);

				// Aici puteți adăuga controale pentru afișarea informațiilor despre neuron,
				// input global și activare în interiorul acestui formular.
				// Exemplu: adăugați etichete, casete de text sau alte controale pentru afișarea datelor.

				neuronInfoForm.ShowDialog();
			}
		}
		// Funcție pentru calcularea valorii globale (global input) folosind funcția de intrare selectată
		private double CalculateGlobalInput(List<double> inputValues, List<double> weights, string inputFunction)
		{
			double globalInput = 0;

			if (inputFunction == "Suma")
			{
				for (int i = 0; i < inputValues.Count; i++)
				{
					globalInput += inputValues[i] * weights[i];
				}
			}
			else if (inputFunction == "Produs")
			{
				globalInput = 1;
				for (int i = 0; i < inputValues.Count; i++)
				{
					globalInput *= inputValues[i] * weights[i];
				}
			}
			else if (inputFunction == "Min")
			{
				globalInput = double.MaxValue;
				for (int i = 0; i < inputValues.Count; i++)
				{
					double product = inputValues[i] * weights[i];
					if (product < globalInput)
					{
						globalInput = product;
					}
				}
			}
			else if (inputFunction == "Max")
			{
				globalInput = double.MinValue;
				for (int i = 0; i < inputValues.Count; i++)
				{
					double product = inputValues[i] * weights[i];
					if (product > globalInput)
					{
						globalInput = product;
					}
				}
			}
			return globalInput;
		}
	}



}
