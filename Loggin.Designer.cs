namespace ordinario_ofi_wen
{
    partial class Loggin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txbUSUARIO = new TextBox();
            txbCONTRASENIA = new TextBox();
            btnINGRESAR = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(382, 48);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(370, 161);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "Contrasenia";
            // 
            // txbUSUARIO
            // 
            txbUSUARIO.Location = new Point(354, 92);
            txbUSUARIO.Name = "txbUSUARIO";
            txbUSUARIO.Size = new Size(100, 23);
            txbUSUARIO.TabIndex = 2;
            // 
            // txbCONTRASENIA
            // 
            txbCONTRASENIA.Location = new Point(354, 200);
            txbCONTRASENIA.Name = "txbCONTRASENIA";
            txbCONTRASENIA.Size = new Size(100, 23);
            txbCONTRASENIA.TabIndex = 3;
            // 
            // btnINGRESAR
            // 
            btnINGRESAR.Location = new Point(365, 247);
            btnINGRESAR.Name = "btnINGRESAR";
            btnINGRESAR.Size = new Size(75, 23);
            btnINGRESAR.TabIndex = 4;
            btnINGRESAR.Text = "Ingresar";
            btnINGRESAR.UseVisualStyleBackColor = true;
            btnINGRESAR.Click += btnINGRESAR_Click;
            // 
            // Loggin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnINGRESAR);
            Controls.Add(txbCONTRASENIA);
            Controls.Add(txbUSUARIO);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Loggin";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txbUSUARIO;
        private TextBox txbCONTRASENIA;
        private Button btnINGRESAR;
    }
}
