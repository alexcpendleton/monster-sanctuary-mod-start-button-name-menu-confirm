using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Configuration;
using MonoMod;
using UnityEngine;

namespace owl7829wg.StartButtonNameMenuConfirm
{
    // You use BepInDependency to mark a mod that your mod requires to work. This is not required if you don't have dependencies.
    [BepInDependency("evaisa.MonSancAPI")]
    // BepInPlugin is required to make BepInEx properly load your mod, this tells BepInEx the ID, Name and Version of your mod.
    [BepInPlugin(ModGUID, ModName, ModVersion)]
    public class StartButtonNameMenuConfirmPlugin : BaseUnityPlugin
    {
        public const string ModGUID = "owl7829wg.StartButtonNameMenuConfirmPlugin";
        public const string ModName = "StartButtonNameMenuConfirmPlugin";
        public const string ModVersion = "1.0.0";

        // This is the first code that runs when your mod gets loaded.
        public StartButtonNameMenuConfirmPlugin()
        {
            On.NameMenu.Update += NameMenu_Update;
        }

        private void NameMenu_Update(On.NameMenu.orig_Update orig, NameMenu self)
        {
            var startButtons = new[]
            {
                KeyCode.JoystickButton7             
            };

            foreach(var button in startButtons)
            {
                if(Input.GetKeyUp(button))
                {
                    Logger.LogInfo($"Pressed {button}");
                    self.MenuList.SelectMenuItem(self.ConfirmKey);
                }
            }
            orig(self);
        }
    }
}
