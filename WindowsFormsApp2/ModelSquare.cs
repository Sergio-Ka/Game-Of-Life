namespace WindowsFormsApp2
{
    class ModelSquare
    {
        public int Value { get; set; }
        public int ValueOnLastGeneration { get; set; }
        public int ValueOnPenultimateGeneration { get; set; }

        public void ChangeValue()
        {
            if (this.Value == 0)
            {
                this.Value = 1;
            }
            else
            {
                this.Value = 0;
            }
        }
    }
}