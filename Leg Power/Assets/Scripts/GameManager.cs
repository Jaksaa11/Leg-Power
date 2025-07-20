using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int legPower {  get; private set; }
    public int basePower { get; private set; }
    public int amp;
    public bool prestige {  get; private set; }
    public int prestigeCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;            
        }
       
       
            legPower = 0;
        amp = 1;
        basePower = 1;
    }
 
    public void ChangeBasePower(int newPower)
    {
        basePower = newPower;
    }
    public void AddLegPower()
    {
        if (legPower + (basePower * amp) < 10000000)
            legPower += basePower * amp;
        else if (legPower + (basePower * amp) > 10000000)
            legPower = 10000000;
        else if (legPower + (basePower * amp) < 0)
            legPower = 10000000;

        if (legPower >= 10000000)
        {
            UIManager.Instance.WinMenu();
        }
    }

    public void RemoveLegPower(int amount)
    {
        legPower -= amount;
    }
    public void PrestigeStatus(bool status)
    {
        prestige = status;
    }
}
