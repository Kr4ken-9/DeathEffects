using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using Steamworks;
using SDG.Unturned;
using System.Collections.Generic;

namespace DeathEffects
{
    public class DeathEffects : RocketPlugin<Config>
    {
        public static DeathEffects Instance;

        protected override void Load()
        {
            Instance = this;
            if (!Configuration.Instance.Enabled)
            {
                Logger.Log("The plugin is disabled via the config file!");
                base.UnloadPlugin();
                return;
            }
            Logger.Log("Plugin Loaded!\r\nCreated by xXThe_HunterXx\r\nHave Fun! :)");
            UnturnedPlayerEvents.OnPlayerDeath += OnPlayerDeath;
        }

        protected override void Unload()
        {
            Logger.Log("Plugin unloaded!");
            UnturnedPlayerEvents.OnPlayerDeath += OnPlayerDeath;
        }

        private void OnPlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            //Check for enable is pointless here, if it were disabled the event is never subscribed
            ushort[] Effects = Instance.Configuration.Instance.Effects.ToArray();
            for (int i = 0; i < Effects.Length; i++)
                player.TriggerEffect(Effects[i]);
        }
    }
}
