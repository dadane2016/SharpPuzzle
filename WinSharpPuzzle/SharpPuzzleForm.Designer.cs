
namespace SharpPuzzle
{
    partial class SharpPuzzleForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.PuzzleMenu = new System.Windows.Forms.MenuStrip();
            this.puzzleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.niveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemMedium = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemHard = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemViewResponse = new System.Windows.Forms.ToolStripMenuItem();
            this.PuzzleMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PuzzleMenu
            // 
            this.PuzzleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puzzleToolStripMenuItem});
            this.PuzzleMenu.Location = new System.Drawing.Point(0, 0);
            this.PuzzleMenu.Name = "PuzzleMenu";
            this.PuzzleMenu.Size = new System.Drawing.Size(789, 24);
            this.PuzzleMenu.TabIndex = 0;
            this.PuzzleMenu.Text = "menuStrip1";
            // 
            // puzzleToolStripMenuItem
            // 
            this.puzzleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemNewGame,
            this.niveauToolStripMenuItem,
            this.menuitemViewResponse});
            this.puzzleToolStripMenuItem.Name = "puzzleToolStripMenuItem";
            this.puzzleToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.puzzleToolStripMenuItem.Text = "Puzzle";
            // 
            // menuitemNewGame
            // 
            this.menuitemNewGame.Name = "menuitemNewGame";
            this.menuitemNewGame.Size = new System.Drawing.Size(180, 22);
            this.menuitemNewGame.Text = "Nouvelle partie";
            this.menuitemNewGame.Click += new System.EventHandler(this.nouvellePartieToolStripMenuItem_Click);
            // 
            // niveauToolStripMenuItem
            // 
            this.niveauToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemEasy,
            this.menuitemMedium,
            this.menuitemHard});
            this.niveauToolStripMenuItem.Name = "niveauToolStripMenuItem";
            this.niveauToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.niveauToolStripMenuItem.Text = "Niveau";
            // 
            // menuitemEasy
            // 
            this.menuitemEasy.Name = "menuitemEasy";
            this.menuitemEasy.Size = new System.Drawing.Size(180, 22);
            this.menuitemEasy.Text = "Facile";
            this.menuitemEasy.Click += new System.EventHandler(this.menuitemEasy_Click);
            // 
            // menuitemMedium
            // 
            this.menuitemMedium.Name = "menuitemMedium";
            this.menuitemMedium.Size = new System.Drawing.Size(180, 22);
            this.menuitemMedium.Text = "Intermédiaire";
            this.menuitemMedium.Click += new System.EventHandler(this.menuitemMedium_Click);
            // 
            // menuitemHard
            // 
            this.menuitemHard.Name = "menuitemHard";
            this.menuitemHard.Size = new System.Drawing.Size(180, 22);
            this.menuitemHard.Text = "Difficile";
            this.menuitemHard.Click += new System.EventHandler(this.menuitemHard_Click);
            // 
            // menuitemViewResponse
            // 
            this.menuitemViewResponse.Name = "menuitemViewResponse";
            this.menuitemViewResponse.Size = new System.Drawing.Size(180, 22);
            this.menuitemViewResponse.Text = "Voir la solution";
            this.menuitemViewResponse.Click += new System.EventHandler(this.menuitemViewResponse_Click);
            // 
            // SharpPuzzleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 450);
            this.Controls.Add(this.PuzzleMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.PuzzleMenu;
            this.MaximizeBox = false;
            this.Name = "SharpPuzzleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpPuzzle";
            this.Load += new System.EventHandler(this.SharpPuzzleForm_Load);
            this.Shown += new System.EventHandler(this.SharpPuzzleForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SharpPuzzleForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SharpPuzzleForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SharpPuzzleForm_KeyPress);
            this.PuzzleMenu.ResumeLayout(false);
            this.PuzzleMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip PuzzleMenu;
        private System.Windows.Forms.ToolStripMenuItem puzzleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuitemNewGame;
        private System.Windows.Forms.ToolStripMenuItem niveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuitemEasy;
        private System.Windows.Forms.ToolStripMenuItem menuitemMedium;
        private System.Windows.Forms.ToolStripMenuItem menuitemHard;
        private System.Windows.Forms.ToolStripMenuItem menuitemViewResponse;
    }
}

