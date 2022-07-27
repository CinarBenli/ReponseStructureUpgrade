using Rocket.API;
using Rocket.Core.Commands;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ReponseStructureUpgrade
{
    public class Class1 : RocketPlugin
    {
        protected override void Load()
        {
            base.Load();
            UnturnedPlayerEvents.OnPlayerUpdateGesture += sa;
        }

    

        private void sa(UnturnedPlayer player, UnturnedPlayerEvents.PlayerGesture gesture)
        {
            if (gesture == UnturnedPlayerEvents.PlayerGesture.PunchRight)
            {
                if (Physics.Raycast(player.Player.look.aim.position, player.Player.look.aim.forward, out var hit, 10f, RayMasks.STRUCTURE_INTERACT))
                {
                  
                    var structure = StructureManager.FindStructureByRootTransform(hit.transform);
                    var data = structure.GetServersideData();

                  
                    

                    

                    switch (structure.asset.id)
                    {
                        case 3711:
                            StructureManager.dropStructure(new Structure(3712), data.point, data.angle_x * 2, data.angle_y * 2, data.angle_z * 2, player.CSteamID.m_SteamID, player.Player.quests.groupID.m_SteamID);
                            StructureManager.damage(hit.transform, structure.model.position, structure.asset.health, 3, true);
                            break;
                        case 3712:
                            StructureManager.dropStructure(new Structure(3713), data.point, data.angle_x * 2, data.angle_y * 2, data.angle_z * 2, player.CSteamID.m_SteamID, player.Player.quests.groupID.m_SteamID);
                            StructureManager.damage(hit.transform, structure.model.position, structure.asset.health, 3, true);
                            break;
                        case 3713:
                            StructureManager.dropStructure(new Structure(3714), data.point, data.angle_x * 2, data.angle_y * 2, data.angle_z * 2, player.CSteamID.m_SteamID, player.Player.quests.groupID.m_SteamID);
                            StructureManager.damage(hit.transform, structure.model.position, structure.asset.health, 3, true);
                            break;


                    }
                 


                }
                return;
            }
            else if (gesture == UnturnedPlayerEvents.PlayerGesture.Point)
            {
                if (Physics.Raycast(player.Player.look.aim.position, player.Player.look.aim.forward, out var hit, 10f, RayMasks.STRUCTURE_INTERACT))
                {
                    var structure = StructureManager.FindStructureByRootTransform(hit.transform);
                    var data = structure.GetServersideData();

                    UnturnedChat.Say (data.structure.health + data.owner.ToString());
                


                }
                return;
            }
            return;
        }

    }
}
