namespace LifeModel
{
    public class Board{
        public readonly Cell[,] Cells;
        public readonly int CellSize;

        public int Columns {get { return Cells.GetLength(0);} }
        public int Rows {get { return Cells.GetLength(1);} }

        public int Width {get { return Columns * CellSize;}}
        public int Height {get { return Rows * CellSize;}} 

        public Board(int width, int height, int cellSize, float liveDensity = .1f)
        {
            CellSize = cellSize;

            Cells = new Cell[width / cellSize, height / cellSize];
            for (int x = 0; x < Columns; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    Cells[x, y] = new Cell();
                }
            }

            ConnectNeighbors();
            Randomize(liveDensity);
        }

        readonly Random rand = new Random();
        public void Randomize(float liveDensity)
        {
            foreach(Cell cell in Cells)
            {
                cell.isAlive = (float)rand.NextDouble() < liveDensity;
            }
        }

        public void Tick()
        {
            foreach(Cell cell in Cells)
            {
                cell.DetermineAliveNext();
            }
            foreach(Cell cell in Cells)
            {
                cell.Tick();
            }
        }

        private void ConnectNeighbors()
        {
            for (int x = 0; x < Columns; ++x)
            {
                for (int y = 0; y < Rows; ++y)
                {
                    //Determine left/right cells
                    int xl = (x > 0) ? x - 1 : Columns - 1;
                    int xr = (x < Columns - 1) ? x + 1 : 0;

                    //top/bottom
                    int yt = (y > 0) ? y - 1 : Rows - 1;
                    int yb = (y < Rows - 1) ? y + 1 : 0;

                    //Add the 8 Neighbors surrounding the cell
                    Cells[x, y].neighbors.Add(Cells[xl, yt]);
                    Cells[x, y].neighbors.Add(Cells[xl, yb]);
                    Cells[x, y].neighbors.Add(Cells[xl, y]);
                    Cells[x, y].neighbors.Add(Cells[xr, yt]);
                    Cells[x, y].neighbors.Add(Cells[xr, yb]);
                    Cells[x, y].neighbors.Add(Cells[xr, y]);
                    Cells[x, y].neighbors.Add(Cells[x, yt]);
                    Cells[x, y].neighbors.Add(Cells[x, yb]);

                }
            }
        }
    }
}

