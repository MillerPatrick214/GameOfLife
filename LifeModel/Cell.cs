namespace LifeModel
{
    public class Cell
    {
        public bool isAlive;
        public readonly List<Cell> neighbors = new List<Cell>();
        private bool isAliveNext;

        public void DetermineAliveNext()
        {
            int live_neighbors = neighbors.Where(x => x.isAlive).Count(); //".Where" is a LINQ method, querying the list and checking a property (thru anon func x => ...)

            //should look more into LINQ

            /*
            could also do it the way I normally would
            int alive_count = 0;
            for (Cell cell in neighbors) {if (cell.isAlive){ ++alive_count;}}
            */

            if (isAlive)
            {
                isAliveNext = (neighbors.Count >= 2 && neighbors.Count <= 3);
                return;
            }
        
            else
            {
                isAliveNext = (neighbors.Count == 3);
                return;
            }
        }

        public void Tick()
        {
            isAlive = isAliveNext;
        }
    }
}