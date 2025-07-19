using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int legPower {  get; private set; }
    public int basePower { get; private set; }
    public int amp;
    public TextMeshProUGUI powerText;
    public bool prestige {  get; private set; }
    public int prestigeCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
            legPower = 0;
        amp = 1;
        powerText.text = "Leg Power: " + legPower;
        basePower = 1;
    }
    public void ChangePowerText()
    {
        powerText.text = "Leg Power:" + legPower;
    }
    public void ChangeBasePower(int newPower)
    {
        basePower = newPower;
    }
    public void AddLegPower()
    {
        legPower += basePower*amp;
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
