using CommandsModule;

namespace PlayerModule
{
    public class HealPlayerButton : ExecuteCommandButton<HealPlayerCommand, PlayerProvider, int, int>
    {
    }
}