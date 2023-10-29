namespace EventTools
{
    public delegate void MoveEvent(float inputX, float inputY, Player.State state, Player.Direction direction, float posY);
    public delegate void InputEvent(string id);

    public static class CustomEventHandler
    {
        public static event MoveEvent MoveEvent;
        public static event InputEvent InputEvent;

        public static void AnimMovement(float inputX, float inputY, Player.State state, Player.Direction direction, float posY)
        {
            MoveEvent?.Invoke(inputX, inputY, state, direction, posY);
        }

        public static void CallUiScreen(string id)
        {
          InputEvent?.Invoke(id);  
        }

    }
}
