using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using Steamworks;
using System.IO;

namespace DeathEffects
{
    public class DeathEffects : RocketPlugin<DeathEffects.Config>
    {
        public static DeathEffects Instance;
        public string Creator = "xXThe_HunterXx";

        protected override void Load()
        {
            Instance = this;
            if (Configuration.Instance.Enabled)
            {
                Logger.Log("Plugin Loaded!");
                Logger.Log("Plugin created by: " + Creator);
                Logger.Log("Have Fun! :)");
                UnturnedPlayerEvents.OnPlayerDeath += UnturnedPlayerEvents_OnPlayerDeath;
            }
            else
            {
                Instance = null;
                base.UnloadPlugin();
                {
                    Logger.Log("The plugin is disabled via the config file!");
                }
                return;
            }
        }

        protected override void Unload()
        {
            Logger.Log("Plugin unloaded!");
            UnturnedPlayerEvents.OnPlayerDeath += UnturnedPlayerEvents_OnPlayerDeath;
        }

        private void UnturnedPlayerEvents_OnPlayerDeath(UnturnedPlayer player, SDG.Unturned.EDeathCause cause, SDG.Unturned.ELimb limb, CSteamID murderer)
        {
            if (Configuration.Instance.EffectOnDeathEnabled)
            {
                ushort? id1 = Configuration.Instance.DeathEffectID1;
                ushort? id2 = Configuration.Instance.DeathEffectID2;
                ushort? id3 = Configuration.Instance.DeathEffectID3;
                ushort? id4 = Configuration.Instance.DeathEffectID4;
                ushort? id5 = Configuration.Instance.DeathEffectID5;
                if (Configuration.Instance.ID1Enabled)
                {
                    player.TriggerEffect(id1.Value);
                }
                else { return; }
                if (Configuration.Instance.ID2Enabled)
                {
                    player.TriggerEffect(id2.Value);
                }
                else { return; }
                if (Configuration.Instance.ID3Enabled)
                {
                    player.TriggerEffect(id3.Value);
                }
                else { return; }
                if (Configuration.Instance.ID4Enabled)
                {
                    player.TriggerEffect(id4.Value);
                }
                else { return; }
                if (Configuration.Instance.ID5Enabled)
                {
                    player.TriggerEffect(id5.Value);
                }
                else { return; }
            }
        }

        public class Config : IRocketPluginConfiguration
        {

            public bool Enabled;
            public bool EffectOnDeathEnabled;
            public bool ID1Enabled;
            public ushort DeathEffectID1;
            public bool ID2Enabled;
            public ushort DeathEffectID2;
            public bool ID3Enabled;
            public ushort DeathEffectID3;
            public bool ID4Enabled;
            public ushort DeathEffectID4;
            public bool ID5Enabled;
            public ushort DeathEffectID5;

            public void LoadDefaults()
            {
                Enabled = true;
                EffectOnDeathEnabled = true;
                DeathEffectID1 = 120;
                ID1Enabled = true;
                DeathEffectID2 = 133;
                ID2Enabled = true;
                DeathEffectID3 = 127;
                ID3Enabled = true;
                DeathEffectID4 = 119;
                ID4Enabled = true;
                DeathEffectID5 = 128;
                ID5Enabled = true;
            }
        }
    }
}
