using System.Windows.Forms;
using GTA;
using Screen = GTA.UI.Screen;

namespace SlowMoEvents
{
    internal class OnKeyPress : Script
    {
        public OnKeyPress()
        {
            KeyUp += OnKeyDown;
        }
        void OnKeyDown(object sender, KeyEventArgs e)
        {
            //Toggle script
            if (e.KeyCode == Main.tog)
            {
                Main.modEnabled = !Main.modEnabled;
                if (Main.modEnabled)
                {
                    Screen.ShowHelpText("SlowMo Events Detector ~g~enabled", 1000, true, false);
                }
                else if (!Main.modEnabled)
                {
                    Screen.ShowHelpText("SlowMo Events Detector ~r~disabled", 1000, true, false);
                }
            }
            //Instant slow mo toggle
            if (e.KeyCode == Main.tog1 && Main.modEnabled && Game.TimeScale == 1.0f)
            {
                Main.slowMo(true);
            }
        }
    }
}
