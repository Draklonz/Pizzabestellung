namespace PizzabestellungUI
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
            BestellListe = new ListView();
            BestellcolName = new ColumnHeader();
            BestellcolAnzahl = new ColumnHeader();
            BestellcolGroesse = new ColumnHeader();
            bestellcolZutaten = new ColumnHeader();
            bestellcolPreis = new ColumnHeader();
            groupGroesse = new GroupBox();
            groesseGross = new RadioButton();
            groesseNormal = new RadioButton();
            groesseKlein = new RadioButton();
            Speisekarte = new ListView();
            SKcolName = new ColumnHeader();
            SKcolPreis = new ColumnHeader();
            buttonAddPos = new Button();
            label1 = new Label();
            buttonChangePos = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            buttonBestell = new Button();
            groupGroesse.SuspendLayout();
            SuspendLayout();
            // 
            // BestellListe
            // 
            BestellListe.Columns.AddRange(new ColumnHeader[] { BestellcolName, BestellcolAnzahl, BestellcolGroesse, bestellcolZutaten, bestellcolPreis });
            BestellListe.Location = new Point(497, 42);
            BestellListe.Name = "BestellListe";
            BestellListe.Size = new Size(633, 420);
            BestellListe.TabIndex = 0;
            BestellListe.UseCompatibleStateImageBehavior = false;
            BestellListe.View = View.Details;
            // 
            // BestellcolName
            // 
            BestellcolName.Text = "Pizza";
            BestellcolName.Width = 150;
            // 
            // BestellcolAnzahl
            // 
            BestellcolAnzahl.Text = "Anzahl";
            BestellcolAnzahl.Width = 70;
            // 
            // BestellcolGroesse
            // 
            BestellcolGroesse.Text = "Größe";
            BestellcolGroesse.Width = 80;
            // 
            // bestellcolZutaten
            // 
            bestellcolZutaten.Text = "extraZutaten";
            bestellcolZutaten.Width = 200;
            // 
            // bestellcolPreis
            // 
            bestellcolPreis.Text = "Preis";
            // 
            // groupGroesse
            // 
            groupGroesse.Controls.Add(groesseGross);
            groupGroesse.Controls.Add(groesseNormal);
            groupGroesse.Controls.Add(groesseKlein);
            groupGroesse.Location = new Point(330, 42);
            groupGroesse.Name = "groupGroesse";
            groupGroesse.Size = new Size(150, 180);
            groupGroesse.TabIndex = 1;
            groupGroesse.TabStop = false;
            groupGroesse.Text = "Größe";
            // 
            // groesseGross
            // 
            groesseGross.AutoSize = true;
            groesseGross.Location = new Point(30, 122);
            groesseGross.Name = "groesseGross";
            groesseGross.Size = new Size(75, 29);
            groesseGross.TabIndex = 2;
            groesseGross.Text = "groß";
            groesseGross.UseVisualStyleBackColor = true;
            // 
            // groesseNormal
            // 
            groesseNormal.AutoSize = true;
            groesseNormal.Checked = true;
            groesseNormal.Location = new Point(30, 87);
            groesseNormal.Name = "groesseNormal";
            groesseNormal.Size = new Size(93, 29);
            groesseNormal.TabIndex = 1;
            groesseNormal.TabStop = true;
            groesseNormal.Text = "normal";
            groesseNormal.UseVisualStyleBackColor = true;
            // 
            // groesseKlein
            // 
            groesseKlein.AutoSize = true;
            groesseKlein.Location = new Point(30, 52);
            groesseKlein.Name = "groesseKlein";
            groesseKlein.Size = new Size(73, 29);
            groesseKlein.TabIndex = 0;
            groesseKlein.Text = "klein";
            groesseKlein.UseVisualStyleBackColor = true;
            // 
            // Speisekarte
            // 
            Speisekarte.Columns.AddRange(new ColumnHeader[] { SKcolName, SKcolPreis });
            Speisekarte.Location = new Point(31, 42);
            Speisekarte.MultiSelect = false;
            Speisekarte.Name = "Speisekarte";
            Speisekarte.Size = new Size(280, 420);
            Speisekarte.TabIndex = 2;
            Speisekarte.UseCompatibleStateImageBehavior = false;
            Speisekarte.View = View.Details;
            // 
            // SKcolName
            // 
            SKcolName.Text = "Name";
            SKcolName.Width = 200;
            // 
            // SKcolPreis
            // 
            SKcolPreis.Text = "Preis";
            // 
            // buttonAddPos
            // 
            buttonAddPos.Location = new Point(317, 249);
            buttonAddPos.Name = "buttonAddPos";
            buttonAddPos.Size = new Size(150, 75);
            buttonAddPos.TabIndex = 3;
            buttonAddPos.Text = "Zu Bestellung hinzufügen";
            buttonAddPos.UseVisualStyleBackColor = true;
            buttonAddPos.Click += buttonAddPos_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 9);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // buttonChangePos
            // 
            buttonChangePos.Location = new Point(341, 342);
            buttonChangePos.Name = "buttonChangePos";
            buttonChangePos.Size = new Size(150, 75);
            buttonChangePos.TabIndex = 5;
            buttonChangePos.Text = "Pizza bearbeiten";
            buttonChangePos.UseVisualStyleBackColor = true;
            buttonChangePos.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(31, 517);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(460, 31);
            textBox1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 489);
            label2.Name = "label2";
            label2.Size = new Size(153, 25);
            label2.TabIndex = 7;
            label2.Text = "Adresse eingeben";
            // 
            // buttonBestell
            // 
            buttonBestell.Location = new Point(773, 556);
            buttonBestell.Name = "buttonBestell";
            buttonBestell.Size = new Size(112, 34);
            buttonBestell.TabIndex = 8;
            buttonBestell.Text = "Bestellen";
            buttonBestell.UseVisualStyleBackColor = true;
            buttonBestell.Click += buttonBestell_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1142, 887);
            Controls.Add(buttonBestell);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(buttonChangePos);
            Controls.Add(label1);
            Controls.Add(buttonAddPos);
            Controls.Add(Speisekarte);
            Controls.Add(groupGroesse);
            Controls.Add(BestellListe);
            Name = "Form1";
            Text = "Pizzabestellung";
            groupGroesse.ResumeLayout(false);
            groupGroesse.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView BestellListe;
        private ColumnHeader BestellcolAnzahl;
        private ColumnHeader BestellcolName;
        private ColumnHeader BestellcolGroesse;
        private GroupBox groupGroesse;
        private RadioButton groesseGross;
        private RadioButton groesseNormal;
        private RadioButton groesseKlein;
        private ListView Speisekarte;
        private ColumnHeader SKcolName;
        private ColumnHeader SKcolPreis;
        private Button buttonAddPos;
        private Label label1;
        private ColumnHeader bestellcolZutaten;
        private ColumnHeader bestellcolPreis;
        private Button buttonChangePos;
        private TextBox textBox1;
        private Label label2;
        private Button buttonBestell;
    }
}
