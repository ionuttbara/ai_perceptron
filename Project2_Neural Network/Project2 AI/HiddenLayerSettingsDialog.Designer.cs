namespace Project2_AI
{
	partial class HiddenLayerSettingsDialog
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
			okBtn = new System.Windows.Forms.Button();
			CancelButton = new System.Windows.Forms.Button();
			inputFunctionComboBox = new System.Windows.Forms.ComboBox();
			activationFunctionComboBox = new System.Windows.Forms.ComboBox();
			thetaNumericUpDown = new System.Windows.Forms.NumericUpDown();
			gNumericUpDown = new System.Windows.Forms.NumericUpDown();
			label1 = new System.Windows.Forms.Label();
			activationFctLabel = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			compComboBox = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)thetaNumericUpDown).BeginInit();
			((System.ComponentModel.ISupportInitialize)gNumericUpDown).BeginInit();
			SuspendLayout();
			// 
			// okBtn
			// 
			okBtn.Location = new System.Drawing.Point(69, 188);
			okBtn.Name = "okBtn";
			okBtn.Size = new System.Drawing.Size(75, 23);
			okBtn.TabIndex = 0;
			okBtn.Text = "OK";
			okBtn.UseVisualStyleBackColor = true;
			okBtn.Click += okBtn_Click;
			// 
			// CancelButton
			// 
			CancelButton.Location = new System.Drawing.Point(266, 188);
			CancelButton.Name = "CancelButton";
			CancelButton.Size = new System.Drawing.Size(75, 23);
			CancelButton.TabIndex = 1;
			CancelButton.Text = "Cancel";
			CancelButton.UseVisualStyleBackColor = true;
			CancelButton.Click += CancelButton_Click;
			// 
			// inputFunctionComboBox
			// 
			inputFunctionComboBox.FormattingEnabled = true;
			inputFunctionComboBox.Location = new System.Drawing.Point(196, 22);
			inputFunctionComboBox.Name = "inputFunctionComboBox";
			inputFunctionComboBox.Size = new System.Drawing.Size(121, 21);
			inputFunctionComboBox.TabIndex = 2;
			// 
			// activationFunctionComboBox
			// 
			activationFunctionComboBox.FormattingEnabled = true;
			activationFunctionComboBox.Location = new System.Drawing.Point(196, 51);
			activationFunctionComboBox.Name = "activationFunctionComboBox";
			activationFunctionComboBox.Size = new System.Drawing.Size(121, 21);
			activationFunctionComboBox.TabIndex = 3;
			// 
			// thetaNumericUpDown
			// 
			thetaNumericUpDown.Location = new System.Drawing.Point(50, 97);
			thetaNumericUpDown.Name = "thetaNumericUpDown";
			thetaNumericUpDown.Size = new System.Drawing.Size(120, 20);
			thetaNumericUpDown.TabIndex = 4;
			// 
			// gNumericUpDown
			// 
			gNumericUpDown.Location = new System.Drawing.Point(253, 97);
			gNumericUpDown.Name = "gNumericUpDown";
			gNumericUpDown.Size = new System.Drawing.Size(120, 20);
			gNumericUpDown.TabIndex = 5;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(95, 25);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(75, 13);
			label1.TabIndex = 6;
			label1.Text = "Input Function";
			// 
			// activationFctLabel
			// 
			activationFctLabel.AutoSize = true;
			activationFctLabel.Location = new System.Drawing.Point(69, 54);
			activationFctLabel.Name = "activationFctLabel";
			activationFctLabel.Size = new System.Drawing.Size(98, 13);
			activationFctLabel.TabIndex = 7;
			activationFctLabel.Text = "Activation Function";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(19, 99);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(25, 13);
			label2.TabIndex = 8;
			label2.Text = "teta";
			label2.Click += label2_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(228, 99);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(13, 13);
			label3.TabIndex = 9;
			label3.Text = "g";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(69, 148);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(75, 13);
			label4.TabIndex = 11;
			label4.Text = "Comportament";
			// 
			// compComboBox
			// 
			compComboBox.FormattingEnabled = true;
			compComboBox.Location = new System.Drawing.Point(196, 145);
			compComboBox.Name = "compComboBox";
			compComboBox.Size = new System.Drawing.Size(121, 21);
			compComboBox.TabIndex = 10;
			// 
			// HiddenLayerSettingsDialog
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(430, 229);
			Controls.Add(label4);
			Controls.Add(compComboBox);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(activationFctLabel);
			Controls.Add(label1);
			Controls.Add(gNumericUpDown);
			Controls.Add(thetaNumericUpDown);
			Controls.Add(activationFunctionComboBox);
			Controls.Add(inputFunctionComboBox);
			Controls.Add(CancelButton);
			Controls.Add(okBtn);
			Name = "HiddenLayerSettingsDialog";
			Text = "HiddenLayerSettingsDialog";
			((System.ComponentModel.ISupportInitialize)thetaNumericUpDown).EndInit();
			((System.ComponentModel.ISupportInitialize)gNumericUpDown).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Button okBtn;
		private new System.Windows.Forms.Button CancelButton;
		public System.Windows.Forms.ComboBox inputFunctionComboBox;
		public System.Windows.Forms.ComboBox activationFunctionComboBox;
		public System.Windows.Forms.NumericUpDown thetaNumericUpDown;
		public System.Windows.Forms.NumericUpDown gNumericUpDown;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label activationFctLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.ComboBox compComboBox;
	}
}