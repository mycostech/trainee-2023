//Disclaimer, I don't really know that my syntax is actual right because i can't access to c# compiler so i will explain that what i've done.
class Equipment
{
    public int ItemLevel { get; set; }
    public string Type { get; set; }

    /** Current Refine level **/
    public int RefineLevel { get; set; }
}

class RefineCalculator
{

    // This function use to calculate the same thing when refining is fail.
    void calculateIfFail(){
                            {
                                if (isVIP)
                                    e.RefineLevel --;
                                else
                                    e.RefineLevel = 0;
                            }
                            return e.RefineLevel;

    }
    //This function use to calculate the same thing when refining is success.
    void calculateIfSuccess(){
        return e.RefineLevel++;
    }
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
                            calculateIfSuccess();
                        }
                        else if (e.RefineLevel < 9)
                        {
                            // I've change all the "r" value in to "valueOfRolling" and "x" to "failRate".
                            var valueOfRolling = new Random(); 
                            var failRate = valueOfRolling.Next(0, 100);
                            if (failRate < 60)
                            {
                                calculateIfSuccess();
                            }
                            // All of the code use to be the same thing so i changed that into just one function.
                            else
                            {
                                calculateIfFail();
                            }

                        }
                        else
                        {
                            var valueOfRolling = new Random();
                            var failRate = valueOfRolling.Next(0, 100);
                            if (failRate < 20)
                            {
                                calculateIfSuccess();
                            }
                            else{
                           calculateIfFail();
                        }
                        }
                    }
                    else if (e.ItemLevel == 2)
                    {
                        if (e.RefineLevel < 7)
                        {
                       calculateIfSuccess();
                        }
                        else if (e.RefineLevel < 9)
                        {
                            var valueOfRolling = new Random();
                            var failRate = valueOfRolling.Next(0, 100);
                            if (failRate < 30)
                            {
                                calculateIfSuccess();
                            }
                            else
                            {
                           calculateIfFail();
                            }
                        }
                        else
                        {
                            var valueOfRolling = new Random();
                            var failRate = valueOfRolling.Next(0, 100);
                            if (failRate < 15)
                            {
                                calculateIfSuccess();
                            }
                            else
                            {
                           calculateIfFail();
                            }
                        }
                    }
                    else
                    {
                        if (e.RefineLevel < 5)
                        {
                       calculateIfSuccess();
                        }
                        else if (e.RefineLevel < 7)
                        {
                            var valueOfRolling = new Random();
                            var failRate = valueOfRolling.Next(0, 100);
                            if (failRate < 40)
                            {
                                calculateIfSuccess();
                            }
                            else
                            {
                           calculateIfFail();
                            }
                        }
                        else
                        {
                            var valueOfRolling = new Random();
                            var failRate = valueOfRolling.Next(0, 100);
                            if (failRate < 10)
                            {
                                calculateIfSuccess();
                            }
                            else
                            {
                           calculateIfFail();
                            }
                        }
                    }
                }



                else if (e.Type == "Armor")
                {
                    if (e.RefineLevel < 5)
                    {
                        e.RefineLevel ++;
                    }
                    else
                    {
                        var valueOfRolling = new Random();
                        var failRate = valueOfRolling.Next(0, 100);
                        if (failRate < (10 - e.RefineLevel) * 10)
                        {
                            calculateIfSuccess();
                        }
                        else
                        {
                        calculateIfFail();
                        }
                    }
                }
            }
        }
    }
}