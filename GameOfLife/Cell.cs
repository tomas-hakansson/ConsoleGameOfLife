namespace GameOfLife
{
    public class Cell
    {
        public readonly State State;
        public LivingNeighbours LivingNeighbours { get; set; }

        public Cell(State state)
        {
            this.State = state;
        }

        public Cell(State state, LivingNeighbours livingNeighbours)
        {
            this.State = state;
            this.LivingNeighbours = livingNeighbours;
        }

        public State NextState()
        {
            var nextState = State;

            switch (LivingNeighbours)
            {
                case LivingNeighbours.C0:
                case LivingNeighbours.C1:
                    if (State == State.Alive)
                        nextState = State.Dead;
                    break;
                case LivingNeighbours.C2:
                case LivingNeighbours.C3:
                    if (State == State.Alive)
                        nextState = State.Alive;
                    else if (State == State.Dead && LivingNeighbours == LivingNeighbours.C3)
                        nextState = State.Alive;
                    break;
                case LivingNeighbours.C4:
                case LivingNeighbours.C5:
                case LivingNeighbours.C6:
                case LivingNeighbours.C7:
                case LivingNeighbours.C8:
                    nextState = State.Dead;
                    break;
                default:
                    //shit!
                    break;
            }
            return nextState;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;

            var cell = (Cell)obj;
            return (this.State == cell.State) && (this.LivingNeighbours == cell.LivingNeighbours);
        }
    }
}
