namespace DoorModule
{
    public class Door : IDoor
    {
        private readonly DoorAnimation _animation;

        private bool _isOpen;

        public Door(DoorAnimation animation)
        {
            _animation = animation;
        }

        public bool IsOpen => _isOpen;

        public void Open()
        {
            if (_isOpen)
                return;

            _animation.Open();
            _isOpen = true;
        }

        public void Close()
        {
            if (!_isOpen)
                return;

            _animation.Close();
            _isOpen = false;
        }
    }
}