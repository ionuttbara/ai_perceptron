namespace Project2_AI
{
	partial class InputDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			inputLayerLabel = new System.Windows.Forms.Label();
			hiddenLayerLabel = new System.Windows.Forms.Label();
			outputLayerLabel = new System.Windows.Forms.Label();
			numericUpDownHiddenLayer = new System.Windows.Forms.NumericUpDown();
			numericUpDownInputLayer = new System.Windows.Forms.NumericUpDown();
			numericUpDownOutputLayer = new System.Windows.Forms.NumericUpDown();
			buttonOK = new System.Windows.Forms.Button();
			buttonCancel = new System.Windows.Forms.Button();
			panel1 = new System.Windows.Forms.Panel();
			hiddenLayerNeuronInfoLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)numericUpDownHiddenLayer).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownInputLayer).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownOutputLayer).BeginInit();
			SuspendLayout();
			// 
			// inputLayerLabel
			// 
			inputLayerLabel.AutoSize = true;
			inputLayerLabel.Location = new System.Drawing.Point(12, 44);
			inputLayerLabel.Name = "inputLayerLabel";
			inputLayerLabel.Size = new System.Drawing.Size(115, 13);
			inputLayerLabel.TabIndex = 0;
			inputLayerLabel.Text = "Number of Input Layer:";
			// 
			// hiddenLayerLabel
			// 
			hiddenLayerLabel.AutoSize = true;
			hiddenLayerLabel.Location = new System.Drawing.Point(12, 18);
			hiddenLayerLabel.Name = "hiddenLayerLabel";
			hiddenLayerLabel.Size = new System.Drawing.Size(130, 13);
			hiddenLayerLabel.TabIndex = 1;
			hiddenLayerLabel.Text = "Number of Hidden Layers:";
			// 
			// outputLayerLabel
			// 
			outputLayerLabel.AutoSize = true;
			outputLayerLabel.Location = new System.Drawing.Point(12, 70);
			outputLayerLabel.Name = "outputLayerLabel";
			outputLayerLabel.Size = new System.Drawing.Size(123, 13);
			outputLayerLabel.TabIndex = 2;
			outputLayerLabel.Text = "Number of Output Layer:";
			// 
			// numericUpDownHiddenLayer
			// 
			numericUpDownHiddenLayer.Location = new System.Drawing.Point(264, 16);
			numericUpDownHiddenLayer.Name = "numericUpDownHiddenLayer";
			numericUpDownHiddenLayer.Size = new System.Drawing.Size(76, 20);
			numericUpDownHiddenLayer.TabIndex = 3;
			numericUpDownHiddenLayer.ValueChanged += numericUpDownHiddenLayer_ValueChanged;
			// 
			// numericUpDownInputLayer
			// 
			numericUpDownInputLayer.Location = new System.Drawing.Point(264, 42);
			numericUpDownInputLayer.Name = "numericUpDownInputLayer";
			numericUpDownInputLayer.Size = new System.Drawing.Size(76, 20);
			numericUpDownInputLayer.TabIndex = 4;
			// 
			// numericUpDownOutputLayer
			// 
			numericUpDownOutputLayer.Location = new System.Drawing.Point(264, 68);
			numericUpDownOutputLayer.Name = "numericUpDownOutputLayer";
			numericUpDownOutputLayer.Size = new System.Drawing.Size(76, 20);
			numericUpDownOutputLayer.TabIndex = 5;
			// 
			// buttonOK
			// 
			buttonOK.Location = new System.Drawing.Point(172, 309);
			buttonOK.Name = "buttonOK";
			buttonOK.Size = new System.Drawing.Size(75, 23);
			buttonOK.TabIndex = 6;
			buttonOK.Text = "OK";
			buttonOK.UseVisualStyleBackColor = true;
			buttonOK.Click += buttonOK_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new System.Drawing.Point(266, 309);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new System.Drawing.Size(75, 23);
			buttonCancel.TabIndex = 7;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += buttonCancel_Click;
			// 
			// panel1
			// 
			panel1.AutoScroll = true;
			panel1.Location = new System.Drawing.Point(12, 114);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(328, 178);
			panel1.TabIndex = 8;
			panel1.Paint += panel1_Paint;
			// 
			// hiddenLayerNeuronInfoLabel
			// 
			hiddenLayerNeuronInfoLabel.AutoSize = true;
			hiddenLayerNeuronInfoLabel.Location = new System.Drawing.Point(24, 98);
			hiddenLayerNeuronInfoLabel.Name = "hiddenLayerNeuronInfoLabel";
			hiddenLayerNeuronInfoLabel.Size = new System.Drawing.Size(168, 13);
			hiddenLayerNeuronInfoLabel.TabIndex = 9;
			hiddenLayerNeuronInfoLabel.Text = "Hidden Layers Neuron Information";
			// 
			// InputDialog
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoSize = true;
			ClientSize = new System.Drawing.Size(358, 344);
			Controls.Add(hiddenLayerNeuronInfoLabel);
			Controls.Add(panel1);
			Controls.Add(buttonCancel);
			Controls.Add(buttonOK);
			Controls.Add(numericUpDownOutputLayer);
			Controls.Add(numericUpDownInputLayer);
			Controls.Add(numericUpDownHiddenLayer);
			Controls.Add(outputLayerLabel);
			Controls.Add(hiddenLayerLabel);
			Controls.Add(inputLayerLabel);
			MaximizeBox = false;
			Name = "InputDialog";
			Text = "InputDialog";
			((System.ComponentModel.ISupportInitialize)numericUpDownHiddenLayer).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownInputLayer).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownOutputLayer).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Label inputLayerLabel;
		private System.Windows.Forms.Label hiddenLayerLabel;
		private System.Windows.Forms.Label outputLayerLabel;
		public System.Windows.Forms.NumericUpDown numericUpDownHiddenLayer;
		public System.Windows.Forms.NumericUpDown numericUpDownInputLayer;
		public System.Windows.Forms.NumericUpDown numericUpDownOutputLayer;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label hiddenLayerNeuronInfoLabel;

	}
}