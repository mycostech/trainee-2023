class Equipment
{
    public int ItemLevel { get; set; }
    // Type of the item
    public string? Type { get; set; }

    /** Current Refine level **/
    public int RefineLevel { get; set; }
}

class RefineCalculator
{
    public void RefineEquipments(List<Equipment> equipments, bool isVIP)
    {

        for (var i = 0; i < equipments.Count(); i++)
        {
            var e = equipments[i];
            if (e.ItemLevel < 10)
            {
                if (e.Type == "Weapon")
                {
                    if (e.ItemLevel == 1)
                    {
                        UpgardeWeaponLevel(e.RefineLevel, isVIP, 60, 20);
                    }
                    else if (e.ItemLevel == 2)
                    {
                        UpgardeWeaponLevel(e.RefineLevel, isVIP, 30, 15);
                    }
                    else
                    {
                        if (e.RefineLevel < 5)
                        {
                            e.RefineLevel = e.RefineLevel + 1;
                        }
                        else 
                        {
                            UpgardeWeaponLevel(e.RefineLevel, isVIP, 40, 10);
                        }
                    }
                }
                else if (e.Type == "Armor")
                {
                    if (e.RefineLevel < 5)
                    {
                        e.RefineLevel = e.RefineLevel + 1;
                    }
                    else
                    {
                        if (RandomNumber() < (10 - e.RefineLevel) * 10)
                            e.RefineLevel = e.RefineLevel + 1;
                        else
                        {
                            VipCheck(e.RefineLevel, isVIP);
                        }
                    }
                }
            }
        }
    }

    //Random level number
    public int RandomNumber()
    {
        var r = new Random();
        var x = r.Next(0, 100);
        return x;
    }

    // Checking wherther player is vip or not
    public int VipCheck(int RefineLevel ,bool isVIP)
    {
        if (isVIP)
        {
            RefineLevel = RefineLevel - 1;
        }
        else
        {
            RefineLevel = 0;
        }
        return RefineLevel;
    }

    public int UpgardeWeaponLevel(int RefineLevel, bool isVIP, int criterionOne, int criterionTwo)
    {
        if (RefineLevel < 7)
        {
            RefineLevel = RefineLevel + 1;
        }
        else if (RefineLevel < 9)
        {
            if (RandomNumber() < criterionOne)
            {
                RefineLevel = RefineLevel + 1;
            }
            else
            {
                VipCheck(RefineLevel, isVIP);
            }
        }
        else
        {
            if (RandomNumber() < criterionTwo)
                RefineLevel = RefineLevel + 1;
            else
            {
                VipCheck(RefineLevel, isVIP);
            }
        }
        return RefineLevel;
    }

}