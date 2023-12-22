using System;
using System.Collections.Generic;

namespace SharpPuzzle
{
    public enum TDirection { tdUp = 0, tdDown = 1, tdLeft = 2, tdRight = 3, tdNone = 4 };

    public enum TShuffleMode { smEasy , smMedium, smHard };

    public class SharpPuzzleMatrix
    {
        private int[,] fMatrix;
        private int[,] fSavedMatrix; // pour pouvoir revenir au début
        // Position de la cellule vide =>> valeur = 0
        private byte fxFreeCellPos;
        private byte fyFreeCellPos;
        private byte fxSavedFreeCellPos;
        private byte fySavedFreeCellPos;
        private List<TDirection> fPathFinder = new List<TDirection>();


        public int[,] GameMatrix 
        {
            get { return fMatrix; }
        }

        public List<TDirection> GamePathFinder
        {
            get { return fPathFinder;}
        }

        public int MatrixLength
        {
            get { return fMatrix.GetLength(0); }
        }

        public SharpPuzzleMatrix()
        {
            fMatrix = new int[5,5];
            fSavedMatrix = new int[5, 5];
            InitMatrix();
        }

        private void InitMatrix()
        {
            int _Number = 1;
            int _MaxItems = fMatrix.GetLength(0) * fMatrix.GetLength(0);

            fxFreeCellPos = (byte)(fMatrix.GetLength(0) - 1);
            fyFreeCellPos = (byte)(fMatrix.GetLength(0) - 1);

            for (byte i = 0; i < fMatrix.GetLength(0); i++)
            {
                for (byte j = 0; j < fMatrix.GetLength(0); j++)
                {
                    fMatrix[i, j] = _Number;
                    _Number++;

                    if (_Number == _MaxItems)
                    {
                        _Number = 0;
                    }
                }
            }
        }

        public bool GameComplete()
        {
            bool _Ordered = true;

            int _Number = 1;
            int _MaxItems = fMatrix.GetLength(0) * fMatrix.GetLength(0);

            for (byte i = 0; i < fMatrix.GetLength(0); i++)
            {
                for (byte j = 0; j < fMatrix.GetLength(0); j++)
                {
                    if (_Number == _MaxItems)
                    {
                        if (fMatrix[i, j] != 0)
                        {
                            _Ordered = false;
                            break;
                        }
                    }
                    else
                    {
                        if (fMatrix[i, j] != _Number)
                        {
                            _Ordered = false;
                            break;
                        }
                    }

                    _Number++;
                }
            }

            return _Ordered;
        }

        public bool CanGoLeft()
        {
            return fxFreeCellPos < fMatrix.GetLength(0) - 1;
        }

        public bool CanGoRight()
        {
            return fxFreeCellPos > 0;
        }

        public bool CanGoUp()
        {
            return fyFreeCellPos < fMatrix.GetLength(0) - 1;
        }

        public bool CanGoDown()
        {
            return fyFreeCellPos > 0;
        }

        public void GoLeft()
        {
            if (CanGoLeft())
            {
                fMatrix[fyFreeCellPos, fxFreeCellPos] = fMatrix[fyFreeCellPos, fxFreeCellPos + 1];
                fxFreeCellPos++;
                fMatrix[fyFreeCellPos, fxFreeCellPos] = 0;
            }
        }

        public void GoRight()
        {
            if (CanGoRight())
            {
                fMatrix[fyFreeCellPos, fxFreeCellPos] = fMatrix[fyFreeCellPos, fxFreeCellPos-1];
                fxFreeCellPos--;
                fMatrix[fyFreeCellPos, fxFreeCellPos] = 0;
            }
        }

        public void GoUp()
        {
            if (CanGoUp())
            {
                fMatrix[fyFreeCellPos, fxFreeCellPos] = fMatrix[fyFreeCellPos+1, fxFreeCellPos];
                fyFreeCellPos++;
                fMatrix[fyFreeCellPos, fxFreeCellPos] = 0;
            }
        }

        public void GoDown()
        {
            if (CanGoDown())
            {
                fMatrix[fyFreeCellPos, fxFreeCellPos] = fMatrix[fyFreeCellPos - 1, fxFreeCellPos];
                fyFreeCellPos--;
                fMatrix[fyFreeCellPos, fxFreeCellPos] = 0;
            }
        }

        public void Shuffle(TShuffleMode ModeShuffle = TShuffleMode.smEasy)
        {
            Random _RandomDirection = new Random();
            int _Number = 0;
            int _MaxMoves = 0;
            TDirection _LastMove = TDirection.tdNone;
            
            InitMatrix(); // Toujours revenir à une matrice ordonnée et après faire le mèlange, sinon avec un niveau facile et plusieurs mélanges sans revenir à la matrice ordonnée ca deviendrait difficile même pour le niveau facile.

            fPathFinder.Clear();

            switch (ModeShuffle)
            {
                case TShuffleMode.smEasy: 
                    _MaxMoves = 10;
                    break;

                case TShuffleMode.smMedium:
                    _MaxMoves = 25;
                    break;

                case TShuffleMode.smHard:
                    _MaxMoves = 50;
                    break;
            }

            while (_MaxMoves != 0) 
            {
                _Number = _RandomDirection.Next(4);

                if ((int)TDirection.tdDown == _Number)
                {
                    if (CanGoDown() && (_LastMove != TDirection.tdUp))
                    {
                        _MaxMoves--;
                        GoDown();
                        fPathFinder.Add(TDirection.tdUp);
                        _LastMove = TDirection.tdDown;
                    }
                }
                else
                if ((int)TDirection.tdUp == _Number)
                {
                    if (CanGoUp() && (_LastMove != TDirection.tdDown))
                    {
                        _MaxMoves--;
                        GoUp();
                        fPathFinder.Add(TDirection.tdDown);
                        _LastMove = TDirection.tdUp;
                    }
                }
                else
                if ((int)TDirection.tdLeft == _Number)
                {
                    if (CanGoLeft() && (_LastMove != TDirection.tdRight))
                    {
                        _MaxMoves--;
                        GoLeft();
                        fPathFinder.Add(TDirection.tdRight);
                        _LastMove = TDirection.tdLeft;
                    }
                }
                else
                if ((int)TDirection.tdRight == _Number)
                {
                    if (CanGoRight() && (_LastMove != TDirection.tdLeft))
                    {
                        _MaxMoves--;
                        GoRight();
                        fPathFinder.Add(TDirection.tdLeft);
                        _LastMove = TDirection.tdRight;
                    }
                }
            }

            fPathFinder.Reverse(); // La solution est là!
            Array.Copy(fMatrix, fSavedMatrix, fMatrix.Length); // Sauvegarder cette combinaisaon
            fxSavedFreeCellPos = fxFreeCellPos;
            fySavedFreeCellPos = fyFreeCellPos;
        }

        public void RestoreGame()
        {
            Array.Copy(fSavedMatrix, fMatrix, fMatrix.Length); // Sauvegarder cette combinaisaon
            fxFreeCellPos = fxSavedFreeCellPos;
            fyFreeCellPos = fySavedFreeCellPos;
        }
    }
}
