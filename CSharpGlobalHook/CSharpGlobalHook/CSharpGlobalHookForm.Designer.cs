namespace CSharpGlobalHook
{
	partial class CSharpGlobalHookForm
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
			this.lblLastKeys = new System.Windows.Forms.Label();
			this.lblLastKeysValue = new System.Windows.Forms.Label();
			this.cbxBlockKeys = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// lblLastKeys
			// 
			this.lblLastKeys.AutoSize = true;
			this.lblLastKeys.Location = new System.Drawing.Point(12, 9);
			this.lblLastKeys.Name = "lblLastKeys";
			this.lblLastKeys.Size = new System.Drawing.Size(96, 13);
			this.lblLastKeys.TabIndex = 0;
			this.lblLastKeys.Text = "Last Pressed keys:";
			// 
			// lblLastKeysValue
			// 
			this.lblLastKeysValue.AutoSize = true;
			this.lblLastKeysValue.Location = new System.Drawing.Point(114, 9);
			this.lblLastKeysValue.Name = "lblLastKeysValue";
			this.lblLastKeysValue.Size = new System.Drawing.Size(16, 13);
			this.lblLastKeysValue.TabIndex = 1;
			this.lblLastKeysValue.Text = "...";
			// 
			// cbxBlockKeys
			// 
			this.cbxBlockKeys.AutoSize = true;
			this.cbxBlockKeys.Location = new System.Drawing.Point(15, 34);
			this.cbxBlockKeys.Name = "cbxBlockKeys";
			this.cbxBlockKeys.Size = new System.Drawing.Size(144, 17);
			this.cbxBlockKeys.TabIndex = 2;
			this.cbxBlockKeys.Text = "Block Keys System-Wide";
			this.cbxBlockKeys.UseVisualStyleBackColor = true;
			this.cbxBlockKeys.CheckedChanged += new System.EventHandler(this.cbxBlockKeys_CheckedChanged);
			// 
			// CSharpGlobalHookForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 63);
			this.Controls.Add(this.cbxBlockKeys);
			this.Controls.Add(this.lblLastKeysValue);
			this.Controls.Add(this.lblLastKeys);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CSharpGlobalHookForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "C# Global Hook";
			this.Load += new System.EventHandler(this.CSharpGlobalHookForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblLastKeys;
		private System.Windows.Forms.Label lblLastKeysValue;
		private System.Windows.Forms.CheckBox cbxBlockKeys;
	}
}

