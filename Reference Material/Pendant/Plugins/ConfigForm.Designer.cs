using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Plugins {
	public partial class ConfigForm : global::System.Windows.Forms.Form {
		private global::System.ComponentModel.IContainer iContainer;

		private global::System.Windows.Forms.Label label;

		protected override void Dispose(bool disposing) {
			if (disposing && this.iContainer != null) {
				this.iContainer.Dispose(); }
			base.Dispose(disposing); }

		private void InitializeComponent() {
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label.Location = new System.Drawing.Point(12, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(276, 20);
            this.label.TabIndex = 0;
            this.label.Text = "There are no settings to configure, yet";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 43);
            this.Controls.Add(this.label);
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AshLabs Plugin Config";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
