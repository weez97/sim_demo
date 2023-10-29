namespace CharacterAnimator
{
    public enum Direction
    {
        none, up, right, down, left
    }

    public enum State
    {
        idle, walking, running
    }

    public delegate void MoveEvent(float inputX, float inputY, State state, Direction direction);
    public static class EventHandler
    {
        public static event MoveEvent MoveEvent;

        public static void AnimMovement(float inputX, float inputY, State state, Direction direction)
        {
            MoveEvent?.Invoke(inputX, inputY, state, direction);
        }

    }
}
