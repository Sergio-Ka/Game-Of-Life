namespace WindowsFormsApp2
{
    class ModelChangeField
    {
        public void FieldManipulatorByAlgorithm(ModelField ModelField)
        {
            int[,] RecountedField = new int[ModelField.X, ModelField.Y];
            int Summ;

            for (int i = 0; i < ModelField.X; i++)
            {
                for (int j = 0; j < ModelField.Y; j++)
                {
                    if (i == 0 || i == ModelField.X - 1 || j == 0 || j == ModelField.Y - 1)
                    {
                        RecountedField[i, j] = 0;
                    }
                    else
                    {
                        Summ = 0;
                        for (int k = i - 1; k < i + 2; k++)
                        {
                            for (int l = j - 1; l < j + 2; l++)
                            {
                                Summ += ModelField.ReadSquareValueByCoordinate(k, l);
                            }
                        }
                        if (ModelField.ReadSquareValueByCoordinate(i, j) == 0 && Summ == 3)
                        {
                            RecountedField[i, j] = 1;
                        }
                        else if (ModelField.ReadSquareValueByCoordinate(i, j) == 1 && (Summ == 3 || Summ == 4))
                        {
                            RecountedField[i, j] = 1;
                        }
                        else if (ModelField.ReadSquareValueByCoordinate(i, j) == 1 && (Summ < 3 || Summ > 4))
                        {
                            RecountedField[i, j] = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < ModelField.X; i++)
            {
                for (int j = 0; j < ModelField.Y; j++)
                {
                    ModelField.SetSquareValueOnPGByCoordinate(i, j, ModelField.ReadSquareValueByCoordinateOnLastGen(i, j));
                    ModelField.SetSquareValueOnLGByCoordinate(i, j, ModelField.ReadSquareValueByCoordinate(i, j));
                    ModelField.SetSquareValueByCoordinate(i, j, RecountedField[i, j]);
                }
            }

            ModelField.Generation++; 
        }
    }
}
