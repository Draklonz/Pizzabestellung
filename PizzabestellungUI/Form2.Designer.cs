namespace PizzabestellungUI
{
    partial class Form2
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
            comboBoxExtraZutaten = new ComboBox();
            buttonAddZutat = new Button();
            buttonRemoveZutat = new Button();
            listExtraZutaten = new ListBox();
            buttonConfirm = new Button();
            buttonDelete = new Button();
            SuspendLayout();
            // 
            // comboBoxExtraZutaten
            // 
            comboBoxExtraZutaten.FormattingEnabled = true;
            comboBoxExtraZutaten.Location = new Point(50, 74);
            comboBoxExtraZutaten.Name = "comboBoxExtraZutaten";
            comboBoxExtraZutaten.Size = new Size(182, 33);
            comboBoxExtraZutaten.TabIndex = 1;
            // 
            // buttonAddZutat
            // 
            buttonAddZutat.Location = new Point(265, 51);
            buttonAddZutat.Name = "buttonAddZutat";
            buttonAddZutat.Size = new Size(112, 77);
            buttonAddZutat.TabIndex = 2;
            buttonAddZutat.Text = "Extrazutat hinzufügen";
            buttonAddZutat.UseVisualStyleBackColor = true;
            buttonAddZutat.Click += buttonAddZutat_Click;
            // 
            // buttonRemoveZutat
            // 
            buttonRemoveZutat.Location = new Point(265, 151);
            buttonRemoveZutat.Name = "buttonRemoveZutat";
            buttonRemoveZutat.Size = new Size(112, 66);
            buttonRemoveZutat.TabIndex = 3;
            buttonRemoveZutat.Text = "Extra Zutat entfernen";
            buttonRemoveZutat.UseVisualStyleBackColor = true;
            buttonRemoveZutat.Click += buttonRemoveZutat_Click;
            // 
            // listExtraZutaten
            // 
            listExtraZutaten.FormattingEnabled = true;
            listExtraZutaten.Location = new Point(512, 51);
            listExtraZutaten.Name = "listExtraZutaten";
            listExtraZutaten.Size = new Size(209, 204);
            listExtraZutaten.TabIndex = 4;
            // 
            // buttonConfirm
            // 
            buttonConfirm.Location = new Point(609, 315);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(112, 34);
            buttonConfirm.TabIndex = 5;
            buttonConfirm.Text = "zurück";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(265, 254);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(112, 65);
            buttonDelete.TabIndex = 6;
            buttonDelete.Text = "Pizza löschen";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonDelete);
            Controls.Add(buttonConfirm);
            Controls.Add(listExtraZutaten);
            Controls.Add(buttonRemoveZutat);
            Controls.Add(buttonAddZutat);
            Controls.Add(comboBoxExtraZutaten);
            Name = "Form2";
            Text = "Position bearbeiten";
            ResumeLayout(false);
        }

        #endregion
        private ComboBox comboBoxExtraZutaten;
        private Button buttonAddZutat;
        private Button buttonRemoveZutat;
        private ListBox listExtraZutaten;
        private Button buttonConfirm;
        private Button buttonDelete;
    }
}