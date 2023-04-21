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
    /// Get equipment enhancement results
    /// </summary>
    /// <param name="equipments"></param>
    /// <param name="isVIP"></param>
    public void RefineEquipments(List<Equipment> equipments, bool isVIP)
    {
        var r = new Random();
        var x = r.Next(0, 100);
        for (var i = 0; i < equipments.Count(); i++)
        {
            var e = equipments[i];
            if (e.ItemLevel < 10)
            {
                RefineEquipment(e, isVIP, x);
            }
        }
    }
    //Equipment enhancement classification function
    public void RefineEquipment(Equipment e, bool isVIP, int x)
    {
        if (e.Type == "Weapon")
        {
            RefineWeapond(e, isVIP, x);
        }
        else if (e.Type == "Armor")
        {
            RefineArmor(e, isVIP, x);
        }
    }
    //Calculate weapon enhancement
    public void RefineWeapond(Equipment e, bool isVIP, int x)
    {
        if (e.ItemLevel == 1)
        {
            if (e.RefineLevel < 7)
            {
                e.RefineLevel = RefineSucceed(e);
            }
            else if (e.RefineLevel < 9)
            {
                if (x < 60)
                    e.RefineLevel = RefineSucceed(e);
                else
                {
                    CheckVip(e, isVIP);
                }

            }
            else
            {
                if (x < 20)
                    e.RefineLevel = RefineSucceed(e);
                else
                {
                    CheckVip(e, isVIP);
                }
            }
        }
        else if (e.ItemLevel == 2)
        {
            if (e.RefineLevel < 7)
            {
                e.RefineLevel = RefineSucceed(e);
            }
            else if (e.RefineLevel < 9)
            {
                if (x < 30)
                    e.RefineLevel = RefineSucceed(e);
                else
                {
                    CheckVip(e, isVIP);
                }
            }
            else
            {
                if (x < 15)
                    e.RefineLevel = RefineSucceed(e);
                else
                {
                    CheckVip(e, isVIP);
                }
            }
        }
        else
        {
            if (e.RefineLevel < 5)
            {
                e.RefineLevel = RefineSucceed(e);
            }
            else if (e.RefineLevel < 7)
            {
                if (x < 40)
                    e.RefineLevel = RefineSucceed(e);
                else
                {
                    CheckVip(e, isVIP);
                }
            }
            else
            {
                if (x < 10)
                    e.RefineLevel = RefineSucceed(e);
                else
                {
                    CheckVip(e, isVIP);
                }
            }
        }
    }
    //Calculate armor enhancement
    public void RefineArmor(Equipment e, bool isVIP, int x)
    {
        if (e.RefineLevel < 5)
        {
            e.RefineLevel = RefineSucceed(e);
        }
        else
        {
            if (x < (10 - e.RefineLevel) * 10)
                e.RefineLevel = RefineSucceed(e);
            else
            {
                CheckVip(e, isVIP);
            }
        }
    }
    //Check VIP player
    public void CheckVip(Equipment e, bool isVIP)
    {
        if (isVIP)
            e.RefineLevel = RefineFailed(e);
        else
            e.RefineLevel = RefineRecovry(e);
    }
    //Calculate the enhancement value when the enhancement is successful.
    public int RefineSucceed(Equipment e)
    {
        var equipmentLevel = e.RefineLevel + 1;
        return equipmentLevel;
    }
    //Calculate the enhancement value when the enhancement is unsuccessful and is VIP player.
    public int RefineFailed(Equipment e)
    {
        var equipmentLevel = e.RefineLevel - 1;
        return equipmentLevel;
    }
    //Calculate the enhancement value when the enhancement is unsuccessful and is not VIP player.
    public int RefineRecovry(Equipment e)
    {
        var equipmentLevel = 0;
        return equipmentLevel;
    }
}