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
            var equipment = equipments[i];
            if (equipment.ItemLevel < 10)
            {
                //If the equipment is a Weapon type
                if (equipment.Type == "Weapon")
                {
                    if (equipment.ItemLevel == 1)
                    {
                        if (equipment.RefineLevel < 7)
                        {
                            AddRefineLevel(equipment.RefineLevel);
                        }
                        else if (equipment.RefineLevel < 9)
                        {
                            // create a random object
                            var random = new Random();
                            // random value
                            var value = random.Next(0, 100);
                            if (value < 60)
                                AddRefineLevel(equipment.RefineLevel);
                            else
                            {
                                CheckVip(equipment.RefineLevel, isVIP);
                            }

                        }
                        else
                        {
                            // create a random object
                            var random = new Random();
                            // random value
                            var value = random.Next(0, 100);
                            if (value < 20)
                                AddRefineLevel(equipment.RefineLevel);
                            else
                            {
                                CheckVip(equipment.RefineLevel, isVIP);
                            }
                        }
                    }
                    else if (equipment.ItemLevel == 2)
                    {
                        if (equipment.RefineLevel < 7)
                        {
                            AddRefineLevel(equipment.RefineLevel);
                        }
                        else if (equipment.RefineLevel < 9)
                        {
                            // create a random object
                            var random = new Random();
                            // random value
                            var value = random.Next(0, 100);
                            if (value < 30)
                                AddRefineLevel(equipment.RefineLevel);
                            else
                            {
                                CheckVip(equipment.RefineLevel, isVIP);
                            }
                        }
                        else
                        {
                            // create a random object
                            var random = new Random();
                            // random value
                            var value = random.Next(0, 100);
                            if (value < 15)
                                AddRefineLevel(equipment.RefineLevel);
                            else
                            {
                                CheckVip(equipment.RefineLevel, isVIP);
                            }
                        }
                    }
                    else
                    {
                        if (equipment.RefineLevel < 5)
                        {
                            AddRefineLevel(equipment.RefineLevel);
                        }
                        else if (equipment.RefineLevel < 7)
                        {
                            // create a random object
                            var random = new Random();
                            // random value
                            var value = random.Next(0, 100);
                            if (value < 40)
                                AddRefineLevel(equipment.RefineLevel);
                            else
                            {
                                CheckVip(equipment.RefineLevel, isVIP);
                            }
                        }
                        else
                        {
                            // create a random object
                            var random = new Random();
                            // random value
                            var value = random.Next(0, 100);
                            if (value < 10)
                                AddRefineLevel(equipment.RefineLevel);
                            else
                            {
                                CheckVip(equipment.RefineLevel, isVIP);
                            }
                        }
                    }
                }
                //If the equipment is a Armor type
                else if (equipment.Type == "Armor")
                {
                    if (equipment.RefineLevel < 5)
                    {
                        AddRefineLevel(equipment.RefineLevel);
                    }
                    else
                    {
                        // create a random object
                        var random = new Random();
                        // random value
                        var value = random.Next(0, 100);
                        if (value < (10 - equipment.RefineLevel) * 10)
                            AddRefineLevel(equipment.RefineLevel);
                        else
                        {
                            CheckVip(equipment.RefineLevel, isVIP);
                        }
                    }
                }
            }
        }
        // method for add increase the refineLevel value
        public int AddRefineLevel(int RefineLevel)
        {
            RefineLevel = RefineLevel + 1;
            return RefineLevel;
        }
        // method for check if the player is vip or not.
        public int CheckVip(int RefineLevel, bool isVIP)
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
}