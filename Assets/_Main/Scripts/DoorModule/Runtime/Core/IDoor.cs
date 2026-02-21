namespace DoorModule
{
    public interface IDoor
    {
        bool IsOpen { get; }

        void Open();
        void Close();
    }
}