using System;

namespace WindowsFormsApp2
{
    class ModelField
    {
        private int x = 4;
        private int y = 4;
        public ModelSquare[,] Field { get; set; }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value > 3)
                {
                    x = value + 2;
                }
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value > 3)
                {
                    y = value + 2;
                }
            }
        }

        public void CreateRandomField()
        {
            ModelSquare[,] Field = new ModelSquare[X, Y];
            Random rnd = new Random();

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    Field[i, j] = new ModelSquare();
                    if (i == 0 || i == X - 1 || j == 0 || j == Y - 1)
                    {
                        Field[i, j].Value = 0;
                    }
                    else
                    {
                        Field[i, j].Value = rnd.Next(0, 2);
                    }
                }
            }

            this.Field = Field;
        }

        public void ClearField()
        {
            ModelSquare[,] Field = new ModelSquare[X, Y];

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    Field[i, j] = new ModelSquare();
                    Field[i, j].Value = 0;
                }
            }

            this.Field = Field;
        }

        public int ReadSquareValueByCoordinate(int X, int Y)
        {
            return this.Field[X, Y].Value;
        }

        public int ReadSquareValueByCoordinateOnLastGen(int X, int Y)
        {
            return this.Field[X, Y].ValueOnLastGeneration;
        }

        public int ReadSquareValueByCoordinateOnPenultGen(int X, int Y)
        {
            return this.Field[X, Y].ValueOnPenultimateGeneration;
        }

        public void ChangeSquareValueByCoordinate(int X, int Y)
        {
            if (X == 0 || X == this.X - 1 || Y == 0 || Y == this.Y - 1)
            {
                this.Field[X, Y].Value = 0;
            }
            else
            {
                this.Field[X, Y].ChangeValue();
            }
        }

        public void SetSquareValueByCoordinate(int X, int Y, int Value)
        {
            this.Field[X, Y].Value = Value;
        }

        public void SetSquareValueOnLGByCoordinate(int X, int Y, int Value)
        {
            this.Field[X, Y].ValueOnLastGeneration = Value;
        }

        public void SetSquareValueOnPGByCoordinate(int X, int Y, int Value)
        {
            this.Field[X, Y].ValueOnPenultimateGeneration = Value;
        }
    }
}