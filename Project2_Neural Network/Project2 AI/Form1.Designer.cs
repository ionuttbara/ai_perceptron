namespace Project2_AI
{
	partial class Form1
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
			AIGraphic = new System.Windows.Forms.PictureBox();
			buttonOpenInputDialog = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)AIGraphic).BeginInit();
			SuspendLayout();
			// 
			// AIGraphic
			// 
			AIGraphic.Anchor = System.Windows.Forms.AnchorStyles.Left;
			AIGraphic.Location = new System.Drawing.Point(102, 45);
			AIGraphic.Name = "AIGraphic";
			AIGraphic.Size = new System.Drawing.Size(797, 352);
			AIGraphic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			AIGraphic.TabIndex = 0;
			AIGraphic.TabStop = false;
			AIGraphic.Click += AIGraphic_Click;
			// 
			// buttonOpenInputDialog
			// 
			buttonOpenInputDialog.Location = new System.Drawing.Point(12, 66);
			buttonOpenInputDialog.Name = "buttonOpenInputDialog";
			buttonOpenInputDialog.Size = new System.Drawing.Size(75, 64);
			buttonOpenInputDialog.TabIndex = 2;
			buttonOpenInputDialog.Text = "Create Neural Network";
			buttonOpenInputDialog.UseVisualStyleBackColor = true;
			buttonOpenInputDialog.Click += buttonOpenInputDialog_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(904, 421);
			Controls.Add(AIGraphic);
			Controls.Add(buttonOpenInputDialog);
			MaximizeBox = false;
			Name = "Form1";
			ShowIcon = false;
			Text = "Neural Network";
			((System.ComponentModel.ISupportInitialize)AIGraphic).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.PictureBox AIGraphic;
		private System.Windows.Forms.Button buttonOpenInputDialog;
	}
}

