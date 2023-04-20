class Equipment
{
    public int ItemLevel { get; set; }
    public string Type { get; set; }

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
                            var r = new Random();
                            var x = r.Next(0, 100);
                            if (x < 60)
                                e.RefineLevel = e.RefineLevel + 1;
                            else
                            {
                                if (isVIP)
                                    e.RefineLevel = e.RefineLevel - 1;
                                else
                                    e.RefineLevel = 0;
                            }

                        }
                        else
                        {
                            var r = new Random();
                            var x = r.Next(0, 100);
                            if (x < 20)
                                e.RefineLevel = e.RefineLevel + 1;
                            else
                            {
                                if (isVIP)
                                    e.RefineLevel = e.RefineLevel - 1;
                                else
                                    e.RefineLevel = 0;
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
                            var r = new Random();
                            var x = r.Next(0, 100);
                            if (x < 30)
                                e.RefineLevel = e.RefineLevel + 1;
                            else
                            {
                                if (isVIP)
                                    e.RefineLevel = e.RefineLevel - 1;
                                else
                                    e.RefineLevel = 0;
                            }
                        }
                        else
                        {
                            var r = new Random();
                            var x = r.Next(0, 100);
                            if (x < 15)
                                e.RefineLevel = e.RefineLevel + 1;
                            else
                            {
                                if (isVIP)
                                    e.RefineLevel = e.RefineLevel - 1;
                                else
                                    e.RefineLevel = 0;
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
                            var r = new Random();
                            var x = r.Next(0, 100);
                            if (x < 40)
                                e.RefineLevel = e.RefineLevel + 1;
                            else
                            {
                                if (isVIP)
                                    e.RefineLevel = e.RefineLevel - 1;
                                else
                                    e.RefineLevel = 0;
                            }
                        }
                        else
                        {
                            var r = new Random();
                            var x = r.Next(0, 100);
                            if (x < 10)
                                e.RefineLevel = e.RefineLevel + 1;
                            else
                            {
                                if (isVIP)
                                    e.RefineLevel = e.RefineLevel - 1;
                                else
                                    e.RefineLevel = 0;
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
                        var r = new Random();
                        var x = r.Next(0, 100);
                        if (x < (10 - e.RefineLevel) * 10)
                            e.RefineLevel = e.RefineLevel + 1;
                        else
                        {
                            if (isVIP)
                                e.RefineLevel = e.RefineLevel - 1;
                            else
                                e.RefineLevel = 0;
                        }
                    }
                }
            }
        }
    }
}