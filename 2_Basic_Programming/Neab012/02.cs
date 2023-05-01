/////////////////////////////////////////////////
/////
/// FileName: 02.cs
/// TypeFile: Visual C# Source file.
/// Last Modified On: 
/// Description: Class is calculate refine equipments.
////// 
///////////////////////////////////////////////////


class Equipment
{
    public int ItemLevel { get; set; } 
    public string Type { get; set; }

    /** Current Refine level **/
    public int RefineLevel { get; set; }
}

class RefineCalculator
{
    /// <summary>
    /// Description: Refine the list of equiments.
    /// </summary>
    /// <param name="equipments"> List of class Equipment </param>
    /// <param name="isVIP"> Boolean to verify protection. </param>
    public void RefineEquipments(List<Equipment> equipments, bool isVIP)
    {
        for (var index = 0; index < equipments.Count(); index++)
        {
            var equipment = equipments[index];
            if (equipment.ItemLevel < 10)
            {
                equipment.RefineLevel = ResultEnchantedEquipments(equipment, isVIP);
            }
        }
    }

    /// <summary>
    /// Description: Enhanced equiment by check success rate.
    /// </summary>
    /// <param name="chance"> Integer percentage. </param>
    /// <param name="equipment"> Object type class Equipment </param>
    /// <param name="typeEquipment"> String type equipment. </param>
    /// <param name="isVip"> Boolean to verify protection. </param>
    /// <returns> The level that has been enhanced. </returns>
    public int EnchantedEquipmentsWithRate(int chance,var equipment,string typeEquipment,bool isVip)
    {
        var randomize = new Random();
        var rateFail = randomize.Next(0,100);

        if (typeEquipment == "Weapon")
        {
            if (rateFail < chance)
            {
                return equipment.RefineLevel + 1;
            }
            else
            {
                return VipProtection(isVip,equipment.RefineLevel);
            }
        }

        if (typeEquipment == "Armor")
        {
            if (rateFail < (chance - equipment.RefineLevel)*10)
            {
                return equipment.RefineLevel + 1;
            }
            else
            {
                return VipProtection(isVip,equipment.RefineLevel);
            }
        }

        return 0;
    }

    /// <summary>
    /// Description: Verify for VIP.
    /// </summary>
    /// <param name="isVip"> Boolean to verify protection. </param>
    /// <param name="level"> Integer of level equipment. </param>
    /// <returns> The level that has been enhanced false. </returns>
    public int VipProtection(bool isVip,int level)
    {
        if (isVip)
        {
            return level - 1;
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Description: Refine equipment by verify condition and calculate chance success.
    /// </summary>
    /// <param name="equipment"> Object class Equipment. </param>
    /// <param name="isVip"> Boolean to verify protection. </param>
    /// <returns> the level of equipment that has been enhanced. </returns>
    public int ResultEnchantedEquipments(var equipment, bool isVip)
    {
        if (equipment.Type == "Weapon")
        {
            if (equipment.ItemLevel == 1)
            {
                return EnchanteWeapon(equipment,60,20,isVip);
            }

            if (equipment.ItemLevel == 2)
            {
                return EnchanteWeapon(equipment,30,15,isVip);
            }

            return EnchanteWeapon(equipment,40,10,isVip);
        }

        if (equipment.Type == "Armor")
        {
            return EnchantedArmor(equipment,isVip);
        }

        return 0;
    }

    /// <summary>
    /// Description: Verify chance to upgrade level refines of weapon.
    /// </summary>
    /// <param name="equipment"></param>
    /// <param name="chanceLevel7"> Integer. </param>
    /// <param name="chanceLevelOver7"> Integer. </param>
    /// <param name="isVip"> Boolean. </param>
    /// <returns> The level that has been enhanced equipments type weapon. </returns>
    public int EnchanteWeapon(var equipment, int chanceLevel7, int chanceLevelOver7, bool isVip)
    {
        if (equipment.RefineLevel < 5)
        {
            return equipment.RefindLevel + 1;
        }
        else if (equipment.RefineLevel < 7)
        {
            return EnchantedEquipmentsWithRate(chanceLevel7, equipment, equipment.Type, isVip);
        }

        return EnchantedEquipmentsWithRate(chanceLevelOver7, equipment, equipment.Type, isVip)
    }


    /// <summary>
    /// Description: Verify chance to upgrade level refines of armor.
    /// </summary>
    /// <param name="equipment"> Object type class Equipment. </param>
    /// <param name="isVip"> Boolean to verify protection. </param>
    /// <returns> The level that has been enhanced type integer. </returns>
    public int EnchantedArmor(var equipment, bool isVip)
    {
        if (equipment.RefineLevel < 5)
        {
            return equipment.RefineLevel + 1;
        }
        else
        {
            return EnchantedEquipmentsWithRate(10,equipment,equipment.Type,isVip);
        }
    }
}