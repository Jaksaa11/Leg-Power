using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrestigeManager : MonoBehaviour
{
    [SerializeField] private Button prestigeButton;
    [SerializeField] private Button[] buyButtons;
    [SerializeField] private TextMeshProUGUI prestigeNumber;
    [SerializeField] private TextMeshProUGUI Conditions;
    
    [SerializeField] private SpriteRenderer spriteEquip;

    private void Start()
    {
        prestigeButton.interactable = false;     
        if (GameManager.instance.prestigeCount == 0)
        {
            prestigeNumber.text = "Prestige " + GameManager.instance.prestigeCount + 1;
            Conditions.text = "\n-Buy a Police car \n\n-Have over 10000 Leg Power";
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.prestigeCount == 0)
        {
            if (GameManager.instance.prestige == true && GameManager.instance.legPower > 10000)
                prestigeButton.interactable = true;
        }
        else if (GameManager.instance.prestigeCount == 1)
        {
            if (GameManager.instance.prestige == true && GameManager.instance.legPower > 1000000)
                prestigeButton.interactable = true;
        }
       
    }
   
    public void Prestige()
    {
        GameManager.instance.RemoveLegPower(GameManager.instance.legPower);
        spriteEquip.sprite= null;
        GameManager.instance.ChangeBasePower(1);
        GameManager.instance.amp *= 5;
        GameManager.instance.prestigeCount++;
        GameManager.instance.PrestigeStatus(false);
        prestigeButton.interactable = false;
        UIManager.Instance.ChangeAmplifierText();
        UIManager.Instance.ChangeBasePowerText();
        GameManager.instance.ChangePowerText();
        for (int i = 0; i < buyButtons.Length; i++)
        {
            buyButtons[i].interactable = true;
            buyButtons[i].transform.parent.GetComponent<ShopItem>().bought = false;
        }
        if (GameManager.instance.prestigeCount == 1)
        {
            prestigeNumber.text = "Prestige " + (GameManager.instance.prestigeCount + 1);
            Conditions.text = "\n-Buy a Truck Tank \n\n-Have over 1000000 Leg Power";
        }
        else
        {
            Conditions.text = "\n There are no more Prestiges";
        }
    }
}
