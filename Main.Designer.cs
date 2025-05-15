namespace CantNuggerPorCarpeta
{
    partial class Main
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
            CmdActualizar = new Button();
            LblRootPath = new Label();
            TxtRootPath = new TextBox();
            DgvDirectorios = new DataGridView();
            LblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)DgvDirectorios).BeginInit();
            SuspendLayout();
            // 
            // CmdActualizar
            // 
            CmdActualizar.Location = new Point(6, 57);
            CmdActualizar.Name = "CmdActualizar";
            CmdActualizar.Size = new Size(75, 23);
            CmdActualizar.TabIndex = 0;
            CmdActualizar.Text = "Refrescar";
            CmdActualizar.UseVisualStyleBackColor = true;
            CmdActualizar.Click += CmdActualizar_Click;
            // 
            // LblRootPath
            // 
            LblRootPath.AutoSize = true;
            LblRootPath.Location = new Point(6, 10);
            LblRootPath.Name = "LblRootPath";
            LblRootPath.Size = new Size(100, 15);
            LblRootPath.TabIndex = 1;
            LblRootPath.Text = "Carpeta de Nuget";
            // 
            // TxtRootPath
            // 
            TxtRootPath.Location = new Point(119, 7);
            TxtRootPath.Name = "TxtRootPath";
            TxtRootPath.Size = new Size(653, 23);
            TxtRootPath.TabIndex = 2;
            // 
            // DgvDirectorios
            // 
            DgvDirectorios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DgvDirectorios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvDirectorios.Location = new Point(3, 86);
            DgvDirectorios.Name = "DgvDirectorios";
            DgvDirectorios.Size = new Size(775, 474);
            DgvDirectorios.TabIndex = 3;
            // 
            // LblInfo
            // 
            LblInfo.AutoSize = true;
            LblInfo.Location = new Point(87, 61);
            LblInfo.Name = "LblInfo";
            LblInfo.Size = new Size(44, 15);
            LblInfo.TabIndex = 4;
            LblInfo.Text = "LblInfo";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(LblInfo);
            Controls.Add(DgvDirectorios);
            Controls.Add(TxtRootPath);
            Controls.Add(LblRootPath);
            Controls.Add(CmdActualizar);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cantidad de Nuget por Caperta";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)DgvDirectorios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CmdActualizar;
        private Label LblRootPath;
        private TextBox TxtRootPath;
        private DataGridView DgvDirectorios;
        private Label LblInfo;
    }
}
