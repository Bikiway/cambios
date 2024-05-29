namespace cambios
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            txt_valor = new TextBox();
            label2 = new Label();
            label3 = new Label();
            cbx_Origem = new ComboBox();
            cbx_Destino = new ComboBox();
            btn_converter = new Button();
            lbl_resultado = new Label();
            lbl_status = new Label();
            progressBar1 = new ProgressBar();
            label5 = new Label();
            btn_troca = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(55, 90);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "Valor:";
            // 
            // txt_valor
            // 
            txt_valor.Location = new Point(111, 90);
            txt_valor.Name = "txt_valor";
            txt_valor.Size = new Size(354, 23);
            txt_valor.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(55, 155);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 2;
            label2.Text = "Moeda de Origem:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(55, 220);
            label3.Name = "label3";
            label3.Size = new Size(138, 20);
            label3.TabIndex = 4;
            label3.Text = "Moeda de Destino:";
            // 
            // cbx_Origem
            // 
            cbx_Origem.FormattingEnabled = true;
            cbx_Origem.Location = new Point(198, 156);
            cbx_Origem.Name = "cbx_Origem";
            cbx_Origem.Size = new Size(267, 23);
            cbx_Origem.TabIndex = 5;
            // 
            // cbx_Destino
            // 
            cbx_Destino.FormattingEnabled = true;
            cbx_Destino.Location = new Point(198, 220);
            cbx_Destino.Name = "cbx_Destino";
            cbx_Destino.Size = new Size(267, 23);
            cbx_Destino.TabIndex = 6;
            // 
            // btn_converter
            // 
            btn_converter.BackColor = Color.DarkOrange;
            btn_converter.Enabled = false;
            btn_converter.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_converter.ForeColor = SystemColors.ButtonHighlight;
            btn_converter.Location = new Point(233, 300);
            btn_converter.Name = "btn_converter";
            btn_converter.Size = new Size(267, 65);
            btn_converter.TabIndex = 7;
            btn_converter.Text = "Converter";
            btn_converter.UseVisualStyleBackColor = false;
            btn_converter.Click += btn_converter_Click;
            // 
            // lbl_resultado
            // 
            lbl_resultado.AutoSize = true;
            lbl_resultado.Location = new Point(55, 258);
            lbl_resultado.Name = "lbl_resultado";
            lbl_resultado.Size = new Size(248, 15);
            lbl_resultado.TabIndex = 8;
            lbl_resultado.Text = "Escolha um valor, moeda de origem e destino";
            // 
            // lbl_status
            // 
            lbl_status.BorderStyle = BorderStyle.FixedSingle;
            lbl_status.Location = new Point(12, 315);
            lbl_status.Name = "lbl_status";
            lbl_status.Size = new Size(215, 36);
            lbl_status.TabIndex = 9;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 367);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(215, 23);
            progressBar1.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.Location = new Point(198, 28);
            label5.Name = "label5";
            label5.Size = new Size(87, 25);
            label5.TabIndex = 11;
            label5.Text = "Câmbios";
            // 
            // btn_troca
            // 
            btn_troca.BackgroundImage = (Image)resources.GetObject("btn_troca.BackgroundImage");
            btn_troca.BackgroundImageLayout = ImageLayout.Zoom;
            btn_troca.Enabled = false;
            btn_troca.Location = new Point(471, 156);
            btn_troca.Name = "btn_troca";
            btn_troca.Size = new Size(40, 84);
            btn_troca.TabIndex = 12;
            btn_troca.UseVisualStyleBackColor = true;
            btn_troca.Click += btn_troca_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(530, 419);
            Controls.Add(btn_troca);
            Controls.Add(label5);
            Controls.Add(progressBar1);
            Controls.Add(lbl_status);
            Controls.Add(lbl_resultado);
            Controls.Add(btn_converter);
            Controls.Add(cbx_Destino);
            Controls.Add(cbx_Origem);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txt_valor);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Cambios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_valor;
        private Label label2;
        private Label label3;
        private ComboBox cbx_Origem;
        private ComboBox cbx_Destino;
        private Button btn_converter;
        private Label lbl_resultado;
        private Label lbl_status;
        private ProgressBar progressBar1;
        private Label label5;
        private Button btn_troca;
    }
}