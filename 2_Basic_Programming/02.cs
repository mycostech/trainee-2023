class Equipment
{
    public int ItemLevel { get; set; }
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
                        if (e.RefineLevel < 7)
                        {
                            e.RefineLevel = e.RefineLevel + 1;
                        }
                        else if (e.RefineLevel < 9)
                        {
                            if (RandomNumber() < 60)
                            {
                                e.RefineLevel = e.RefineLevel + 1;
                            }
                            else
                            {
                                vipCheck(e.RefineLevel, isVIP);
                            }

                        }
                        else
                        {
                            if (RandomNumber() < 20)
                                e.RefineLevel = e.RefineLevel + 1;
                            else
                            {
                                vipCheck(e.RefineLevel, isVIP);
                            }
                        }
                    }
                    else if (e.ItemLevel == 2)
                    {
                        if (e.RefineLevel < 7)
                        {
                            e.RefineLevel = e.RefineLevel + 1;
                        }
                        else if (e.RefineLevel < 9)
                        {
                            if (RandomNumber() < 30)
                                e.RefineLevel = e.RefineLevel + 1;
                            else
                            {
                                vipCheck(e.RefineLevel, isVIP);
                            }
                        }
                        else
                        {
                            if (RandomNumber() < 15)
                                e.RefineLevel = e.RefineLevel + 1;
                            else
                            {
                                vipCheck(e.RefineLevel, isVIP);
                            }
                        }
                    }
                    else
                    {
                        if (e.RefineLevel < 5)
                        {
                            e.RefineLevel = e.RefineLevel + 1;
                        }
                        else if (e.RefineLevel < 7)
                        {
                            if (RandomNumber() < 40)
                                e.RefineLevel = e.RefineLevel + 1;
                            else
                            {
                                vipCheck(e.RefineLevel, isVIP);
                            }
                        }
                        else
                        {
                            if (RandomNumber() < 10)
                                e.RefineLevel = e.RefineLevel + 1;
                            else
                            {
                                vipCheck(e.RefineLevel, isVIP);
                            }
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
                            vipCheck(e.RefineLevel, isVIP);
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
    public int vipCheck(int RefineLevel ,bool isVIP)
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
}