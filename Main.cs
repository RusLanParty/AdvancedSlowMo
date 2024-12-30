using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;
<<<<<<< Updated upstream
=======
using Screen = GTA.UI.Screen;
using Notification = GTA.UI.Notification;
>>>>>>> Stashed changes
using GTA.Native;

namespace SlowMoEvents
{
    public class Main : Script
    {
        public static bool modEnabled;
        public static bool debugEnabled;
        private static string logFilePath = Path.Combine("scripts", "SlowMoEvents.log");
        public static string settingsFilePath = Path.Combine("scripts", "SlowMoEvents.ini");
        public static ScriptSettings settings = ScriptSettings.Load(settingsFilePath);

        static int currentTime;
        static int newTime;
        static int delay;
        static float gameSpeed;
        static float mod;

        static bool onExp;
        static bool onCollision;
        static bool onPedCollision;
        static bool onPedRagdoll;
        // public static bool _switch; // ModEnabled
        static int coolDown;
        public static Keys tog;
        public static Keys tog1;
        static int length;
        static float transition;
<<<<<<< Updated upstream
=======

        private static void LogException(string message, Exception ex)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"[{DateTime.Now}] {message}");
                    writer.WriteLine(ex.ToString());
                    writer.WriteLine("----------------------------------------------");
                }
            }
            catch
            {
                // Fallback incase logging fails. Avoid throwing further exceptions here.
            }
        }
        private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                Screen.ShowSubtitle($"~r~Unhandled Exception Error: " + ex, 2000);
                LogException("Unhandled exception caught", ex);
            }
        }

>>>>>>> Stashed changes
        public Main()
        {
            loadSettings();
            Tick += onTick;
        }
<<<<<<< Updated upstream
        void loadSettings()
=======

        public static void CreateIni(string filePath)
>>>>>>> Stashed changes
        {
            coolDown = Settings.GetValue<int>("SETTINGS", "coolDown", 5000);
            length = Settings.GetValue<int>("SETTINGS", "length", 110);
            gameSpeed = Settings.GetValue<float>("SETTINGS", "gameSpeed", 0.1f);
            if (gameSpeed > 0.9f || gameSpeed < 0.1f)
            {
<<<<<<< Updated upstream
                gameSpeed = 0.1f;
=======
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("[SETTINGS]");
                    // 
                    writer.WriteLine($"modEnabled = {modEnabled}");
                    writer.WriteLine($"debugEnabled = {debugEnabled}");
                    writer.WriteLine($"coolDown = {coolDown}");
                    writer.WriteLine($"length = {length}");
                    writer.WriteLine($"gameSpeed = {gameSpeed}");
                    writer.WriteLine($"toggle = {tog}");
                    writer.WriteLine($"instantToggle = {tog1}");
                    writer.WriteLine($"onExp = {onExp}");
                    writer.WriteLine($"onCollision = {onCollision}");
                    writer.WriteLine($"onPedCollision = {onPedCollision}");
                    writer.WriteLine($"onPedRagdoll = {onPedRagdoll}");
                    writer.WriteLine($"transition = {transition}");
                    // writer.WriteLine($"");
                }
            }
            catch (Exception ex)
            {
                LogException("SettingsManager.CreateIni", ex);
>>>>>>> Stashed changes
            }
            _switch = Settings.GetValue<bool>("SETTINGS", "activeByDefault", true);
            tog = Settings.GetValue<Keys>("SETTINGS", "toggle", Keys.Insert);
            tog1 = Settings.GetValue<Keys>("SETTINGS", "instantToggle", Keys.NumPad0);
            onExp = Settings.GetValue<bool>("TRIGGERS", "onExp", false);
            onCollision = Settings.GetValue<bool>("TRIGGERS", "onCollision", false);
            onPedCollision = Settings.GetValue<bool>("TRIGGERS", "onPedCollision", true);
            onPedRagdoll = Settings.GetValue<bool>("TRIGGERS", "onPedRagdoll", true);
            transition = Settings.GetValue<float>("SETTINGS", "transition", 0.02f);
        }
<<<<<<< Updated upstream
        public static void slowMo(bool instant)
=======


        public static void LoadSettings()
        {
            try
            {
                if (!File.Exists(settingsFilePath))
                {
                    CreateIni(settingsFilePath);
                }

                settings = ScriptSettings.Load(settingsFilePath);

                if (settings != null)
                {
                    modEnabled = settings.GetValue<bool>("SETTINGS", "modEnabled", true);
                    debugEnabled = settings.GetValue<bool>("SETTINGS", "debugEnabled", false);
                    coolDown = settings.GetValue<int>("SETTINGS", "coolDown", 5000);
                    length = settings.GetValue<int>("SETTINGS", "length", 110);
                    gameSpeed = settings.GetValue<float>("SETTINGS", "gameSpeed", 0.1f);
                    if (gameSpeed > 0.9f || gameSpeed < 0.1f)
                    {
                        gameSpeed = 0.1f;
                    }
                    tog = settings.GetValue<Keys>("SETTINGS", "toggle", Keys.Delete);
                    tog1 = settings.GetValue<Keys>("SETTINGS", "instantToggle", Keys.NumPad0);
                    onExp = settings.GetValue<bool>("TRIGGERS", "onExp", false);
                    onCollision = settings.GetValue<bool>("TRIGGERS", "onCollision", false);
                    onPedCollision = settings.GetValue<bool>("TRIGGERS", "onPedCollision", true);
                    onPedRagdoll = settings.GetValue<bool>("TRIGGERS", "onPedRagdoll", true);
                    transition = settings.GetValue<float>("SETTINGS", "transition", 0.02f);

                    SaveSettings();

                    if (debugEnabled)
                        Notification.Show($"Loaded SlowMoEvents Settings.", true);
                }
                else
                {
                    // Loading Failed! 
                    if (debugEnabled)
                        Screen.ShowSubtitle($"~r~Warning!~s~: Failed to Load Settings for ~b~SlowMoEvents~s~.", 500);
                }
            }
            catch (Exception ex)
            {
                LogException("LoadSettings", ex);
            }



        }
        public static void SaveSettings()
        {
            try
            {
                if (settings != null)
                {
                    settings.SetValue<bool>("Options", "Mod Enabled", modEnabled);
                    settings.SetValue<bool>("Options", "Debug Enabled", debugEnabled);
                    settings.SetValue<int>("SETTINGS", "coolDown", coolDown);
                    settings.SetValue<int>("SETTINGS", "length", length);
                    settings.SetValue<float>("SETTINGS", "gameSpeed", gameSpeed);
                    if (gameSpeed > 0.9f || gameSpeed < 0.1f)
                    {
                        gameSpeed = 0.1f;
                    }
                    settings.SetValue<Keys>("SETTINGS", "toggle", tog);
                    settings.SetValue<Keys>("SETTINGS", "instantToggle", tog1);
                    settings.SetValue<bool>("TRIGGERS", "onExp", onExp);
                    settings.SetValue<bool>("TRIGGERS", "onCollision", onCollision);
                    settings.SetValue<bool>("TRIGGERS", "onPedCollision", onPedCollision);
                    settings.SetValue<bool>("TRIGGERS", "onPedRagdoll", onPedRagdoll);
                    settings.SetValue<float>("SETTINGS", "transition", transition);

                    settings.Save();

                    if (debugEnabled)
                        Notification.Show($"SlowMoEvents Settings Saved.", true);
                }
                else
                {
                    // Saving Failed!
                    if (debugEnabled)
                        Screen.ShowSubtitle($"~r~Warning!: SlowMoEvents Settings Failed to Save.~s~", 500);
                }
            }
            catch (Exception ex)
            {
                Screen.ShowSubtitle($"~r~LoadSettings Error: " + ex, 2000);
                LogException($"~r~LoadSettings Error: ", ex);
            }
        }

        public static void SlowMo(bool instant)
>>>>>>> Stashed changes
        {
            mod = 1.0f;
            while (mod >= gameSpeed)
            {
                mod += -transition;
                if(mod < gameSpeed)
                {
                    mod = gameSpeed;
                    Game.TimeScale = mod;
<<<<<<< Updated upstream
                    break;
=======
                    if (debugEnabled)
                    {
                        Screen.ShowSubtitle("mod " + mod, 2000);
                    }
                    Wait(10);
                }
                if (debugEnabled)
                {
                    Screen.ShowSubtitle("MAX SLOW");
                }
                if (instant)
                {
                    currentTime = Game.GameTime;
                    Wait(currentTime, true);
                }
                else
                {
                    currentTime = Game.GameTime;
                    Wait(currentTime, false);
>>>>>>> Stashed changes
                }
                Game.TimeScale = mod;
                //GTA.UI.Screen.ShowSubtitle("mod " + mod, 2000);
                Wait(10);
            }
            //GTA.UI.Screen.ShowSubtitle("MAX SLOW");
            if (instant)
            {
<<<<<<< Updated upstream
                currentTime = Game.GameTime;
                _wait(currentTime, true);
            }
            if (!instant)
            {
                currentTime = Game.GameTime;
                _wait(currentTime, false);
=======
                Screen.ShowSubtitle($"~r~SlowMo Error: " + ex, 2000);
                LogException($"~r~SlowMo Error: ", ex);
>>>>>>> Stashed changes
            }
        }
        public static void regularMo()
        {
            mod = gameSpeed;
            while (mod < 1.0f)
            {
                mod += transition;
                if (mod > 1.0f)
                {
                    mod = 1.0f;
                    Game.TimeScale = mod;
<<<<<<< Updated upstream
                    break;
                }
                Game.TimeScale = mod;
               // GTA.UI.Screen.ShowSubtitle("mod " + mod, 2000);
                Wait(10);
=======
                    if (debugEnabled)
                    {
                        Screen.ShowSubtitle("mod " + mod, 2000);
                    }
                    Wait(10);
                }
                if (debugEnabled)
                {
                    Screen.ShowSubtitle("REG SPEED");
                }
            }
            catch (Exception ex)
            {
                Screen.ShowSubtitle($"~r~RegularMo Error: " + ex, 2000);
                LogException($"~r~RegularMo Error: ", ex);
>>>>>>> Stashed changes
            }
           // GTA.UI.Screen.ShowSubtitle("REG SPEED");
        }
       static void _wait(int time, bool instant)
        {
            delay = 0;
            while (delay <= length)
            {
                newTime = Game.GameTime;
                delay = newTime - time;
                if (delay >= length)
                {
                    regularMo();
                }
                Wait(1);
                if (!instant)
                {
                    while (delay < coolDown && delay >= length)
                    {
                        newTime = Game.GameTime;
                        delay = newTime - time;                        
                        Wait(1);
                    }
                }
            }
<<<<<<< Updated upstream
=======
            catch (Exception ex)
            {
                Screen.ShowSubtitle($"~r~Wait Error: " + ex, 2000);
                LogException($"~r~Wait Error: ", ex);
            }
>>>>>>> Stashed changes
        }
       
        void onTick(object sender, EventArgs e)
        {
            if (_switch)
            {
<<<<<<< Updated upstream
=======
                if (!modEnabled) return;

>>>>>>> Stashed changes
                Ped player = Game.Player.Character;
                if (Game.TimeScale == 1.0f)
                {
                    if (onExp)
                    {
                        if (Function.Call<bool>(Hash.IS_EXPLOSION_IN_SPHERE, -1, player.Position.X, player.Position.Y, player.Position.Z, 10f))
                            if (!Function.Call<bool>(Hash.IS_EXPLOSION_IN_SPHERE, 19, player.Position.X, player.Position.Y, player.Position.Z, 10f) && !Function.Call<bool>(Hash.IS_EXPLOSION_IN_SPHERE, 20, player.Position.X, player.Position.Y, player.Position.Z, 10f) && !Function.Call<bool>(Hash.IS_EXPLOSION_IN_SPHERE, 21, player.Position.X, player.Position.Y, player.Position.Z, 10f) && !Function.Call<bool>(Hash.IS_EXPLOSION_IN_SPHERE, 22, player.Position.X, player.Position.Y, player.Position.Z, 10f) && !Function.Call<bool>(Hash.IS_EXPLOSION_IN_SPHERE, 35, player.Position.X, player.Position.Y, player.Position.Z, 10f))
                            {
                                {
<<<<<<< Updated upstream
                                    //GTA.UI.Screen.ShowHelpText("EXPLOSION");
                                    slowMo(false);
=======
                                    if (debugEnabled)
                                    {
                                        Screen.ShowHelpText("EXPLOSION");
                                    }
                                    SlowMo(false);
>>>>>>> Stashed changes
                                }
                            }
                    }
                    if (onCollision)
                    {
                        if (player.IsInVehicle())
                        {
                            Vehicle car = player.CurrentVehicle;
                            if (car.Speed > 25)
                            {
                                if (car.HasCollided)
                                {
<<<<<<< Updated upstream
                                    //GTA.UI.Screen.ShowHelpText("COLLISION PLAYER");
                                    slowMo(false);
=======
                                    if (debugEnabled)
                                    {
                                        Screen.ShowHelpText("COLLISION PLAYER");
                                    }
                                    SlowMo(false);
>>>>>>> Stashed changes
                                }
                            }
                        }
                    }
                    if (onPedCollision)
                    {
                        var pedVehs = World.GetNearbyVehicles(player, 25f).Where(v => v.Speed > 10 && v.HasCollided).ToList();
<<<<<<< Updated upstream
=======
                        // null check here? 
                        if (pedVehs == null) return;

>>>>>>> Stashed changes
                        foreach (Vehicle v in pedVehs)
                        {
                            if (Function.Call<bool>(Hash.IS_ENTITY_ON_SCREEN, v))
                            {
                                if (!player.IsInVehicle())
                                {
<<<<<<< Updated upstream
                                    //GTA.UI.Screen.ShowHelpText("PED COLLISION");
                                    slowMo(false);
=======
                                    if (debugEnabled)
                                    {
                                        Screen.ShowHelpText("PED COLLISION");
                                    }
                                    SlowMo(false);
>>>>>>> Stashed changes
                                }
                                else
                                {
                                    if (player.IsInVehicle() && !v.IsTouching(player.CurrentVehicle))
                                    {
<<<<<<< Updated upstream
                                       // GTA.UI.Screen.ShowHelpText("PED COLLISION");
                                        slowMo(false);
=======
                                        if (debugEnabled)
                                        {
                                            Screen.ShowHelpText("PED COLLISION");
                                        }
                                        SlowMo(false);
>>>>>>> Stashed changes
                                    }
                                }
                            }
                        }
                    }
                    if (onPedRagdoll)
                    {
                        var peds = World.GetNearbyPeds(player, 100f).Where(p => p.IsJumping || p.IsInAir || p.IsRagdoll && !p.IsOnFire).ToList();
                        if (peds == null) return;

                        foreach (Ped ped in peds)
                        {
                            if (Function.Call<bool>(Hash.IS_ENTITY_ON_SCREEN, ped) && !ped.IsDead)
                            {
<<<<<<< Updated upstream
                                // GTA.UI.Screen.ShowHelpText("PED RAGDOLL");
                                slowMo(false);
=======
                                if (debugEnabled)
                                {
                                    Screen.ShowHelpText("PED RAGDOLL");
                                }
                                SlowMo(false);
>>>>>>> Stashed changes
                            }
                        }
                    }

                }
            }
<<<<<<< Updated upstream
           
=======
            catch (Exception ex)
            {
                Screen.ShowSubtitle($"~r~OnTick Error: " + ex, 2000);
                LogException($"~r~OnTick Error: ", ex);
            }
>>>>>>> Stashed changes
        }
    }
}
