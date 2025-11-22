using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MoreMulticlass.Content.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MoreMulticlass.Content.Items.Armor.PalladiumArmorSet
{
    public class PalladiumMaskOverride : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
            => entity.type == ItemID.PalladiumMask; 
    }
}