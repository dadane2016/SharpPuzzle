using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace SharpPuzzle
{
    public partial class SharpPuzzleForm : Form
    {
        enum GameLevel { glEasy, glMedium, glHard };

        private SharpPuzzleMatrix _GamePuzzle = new SharpPuzzleMatrix();
        private int RectangleHauteur;
        private GameLevel NiveauDuJeu;
        private bool EnModeVisualisationDeLaReponse = false;


        public SharpPuzzleForm()
        {
            InitializeComponent();
        }

        private void DrawRectangle(int X, int Y, int Width, int Height, Color pColor)
        {
            SolidBrush myBrush = new System.Drawing.SolidBrush(pColor);
            Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(X, Y, Width, Height));
            
            myBrush.Dispose();
            formGraphics.Dispose();
        }

        private void DrawNumber(int X, int Y, int Width, int Height, string NumberText, Color PenColor, Color RectangleColor)
        {
            Graphics formGraphics = this.CreateGraphics();

            Font drawFont = new Font("Arial", 24);
            SolidBrush PenBrush = new SolidBrush(PenColor);
            SolidBrush RectBrush = new SolidBrush(RectangleColor);
            StringFormat drawFormat = new StringFormat();
            SizeF stringSize = new SizeF();
            stringSize = formGraphics.MeasureString(NumberText, drawFont);

            Y += PuzzleMenu.Height;

            formGraphics.DrawRectangle(new Pen(Color.Black), new Rectangle(X, Y, Width, Height));
            formGraphics.FillRectangle(RectBrush, new Rectangle(X+1, Y+1, Width-1, Height-1));
            formGraphics.DrawString(NumberText, drawFont, PenBrush, X + (Math.Abs(Width-stringSize.Width)/2)  , Y + (Math.Abs(Height - stringSize.Height) / 2));
            drawFont.Dispose();
            PenBrush.Dispose();
            RectBrush.Dispose();
            formGraphics.Dispose();
        }

        private void DrawPuzzle()
        {
            int XPos = 1;
            int YPos = 1;

            for (byte i = 0; i < _GamePuzzle.MatrixLength; i++)
            {
                XPos = 1;
                for (byte j = 0; j < _GamePuzzle.MatrixLength; j++)
                {
                    if (_GamePuzzle.GameMatrix[i, j] != 0)
                    {
                        DrawNumber(XPos, YPos, RectangleHauteur, RectangleHauteur, _GamePuzzle.GameMatrix[i, j].ToString() , Color.White, Color.Green);
                    }
                    else
                    {
                        DrawNumber(XPos, YPos, RectangleHauteur, RectangleHauteur, "", Color.LightGray, Color.Gray);
                    }

                    XPos += RectangleHauteur + 2;
                 }

                YPos += RectangleHauteur + 2;
            }
        }


        private void SharpPuzzleForm_Shown(object sender, EventArgs e)
        {
            NewGame();
        }

        private void SharpPuzzleForm_Load(object sender, EventArgs e)
        {
            RectangleHauteur = 50;
            NiveauDuJeu = GameLevel.glEasy;
            ChangeMenuGameLevel(true, false, false);

            this.Width = (_GamePuzzle.MatrixLength*(RectangleHauteur + 5)) + 2;
            this.Height = (_GamePuzzle.MatrixLength*(RectangleHauteur + 5)) + (PuzzleMenu.Height*2) + 2; 
        }

        private void SharpPuzzleForm_Paint(object sender, PaintEventArgs e)
        {
            DrawPuzzle();
        }

        private void NewGame()
        {
            switch (NiveauDuJeu)
            {
                case GameLevel.glEasy:
                    _GamePuzzle.Shuffle(TShuffleMode.smEasy);
                    break;

                case GameLevel.glMedium:
                    _GamePuzzle.Shuffle(TShuffleMode.smMedium);
                    break;

                case GameLevel.glHard:
                    _GamePuzzle.Shuffle(TShuffleMode.smHard);
                    break;
            }

            DrawPuzzle();
        }

        private void SharpPuzzleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!EnModeVisualisationDeLaReponse)
            {
                switch (e.KeyCode)
                {
                case Keys.Left:
                    if (_GamePuzzle.CanGoLeft())
                    {
                       _GamePuzzle.GoLeft();
                       DrawPuzzle();
                    }
                    break;

                case Keys.Right:
                    if (_GamePuzzle.CanGoRight())
                    {
                        _GamePuzzle.GoRight();
                        DrawPuzzle();
                    }
                    break;

                case Keys.Up:
                    if (_GamePuzzle.CanGoUp())
                    {
                        _GamePuzzle.GoUp();
                        DrawPuzzle();
                    }
                    break;

                case Keys.Down:
                    if (_GamePuzzle.CanGoDown())
                    {
                        _GamePuzzle.GoDown();
                        DrawPuzzle();
                    }
                    break;
                }

                if (_GamePuzzle.GameComplete())
                {
                    var result = MessageBox.Show("La partie est complétée!" + Environment.NewLine + "Jouer une nouvelle partie?", "SharpPuzzle", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        NewGame();
                    }
                }
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

        private void nouvellePartieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }


        private void ChangeMenuGameLevel(bool EasyChecked, bool MediumChecked, bool HardChecked)
        {
            menuitemEasy.Checked = EasyChecked;
            menuitemMedium.Checked = MediumChecked;
            menuitemHard.Checked = HardChecked;
            NewGame();
        }

        private void menuitemEasy_Click(object sender, EventArgs e)
        {
            NiveauDuJeu = GameLevel.glEasy;
            ChangeMenuGameLevel(true,false,false);
        }

        private void menuitemMedium_Click(object sender, EventArgs e)
        {
            NiveauDuJeu = GameLevel.glMedium;
            ChangeMenuGameLevel(false, true, false);
        }

        private void menuitemHard_Click(object sender, EventArgs e)
        {
            NiveauDuJeu = GameLevel.glHard;
            ChangeMenuGameLevel(false, false, true);
        }

        private void menuitemViewResponse_Click(object sender, EventArgs e)
        {
            _GamePuzzle.RestoreGame();
            DrawPuzzle();
            EnModeVisualisationDeLaReponse = true;
            Thread.Sleep(1000);

            foreach (TDirection Direction in _GamePuzzle.GamePathFinder )
            {
                switch(Direction)
                {
                    case TDirection.tdDown:
                        _GamePuzzle.GoDown();
                        break;

                    case TDirection.tdUp:
                        _GamePuzzle.GoUp();
                        break;

                    case TDirection.tdLeft:
                        _GamePuzzle.GoLeft();
                        break;

                    case TDirection.tdRight:
                        _GamePuzzle.GoRight();
                        break;
                }

                DrawPuzzle();
                Thread.Sleep(700);
            }

            EnModeVisualisationDeLaReponse = false;

            MessageBox.Show("La partie est résolue!", "SharpPuzzle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SharpPuzzleForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = EnModeVisualisationDeLaReponse;
        }
    }
}
