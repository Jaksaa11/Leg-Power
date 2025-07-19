using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    [SerializeField] private SpriteRenderer spriteEquip;
    
    private void Start()
    {
        instance = this;
        
    }

    public void PurchaseItem(ShopItem item)
    {
        if (GameManager.instance.legPower >= item.price)
        {
            
            spriteEquip.sprite = item.itemSprite;
            item.bought = true;           
            GameManager.instance.RemoveLegPower(item.price);
            GameManager.instance.ChangeBasePower(item.legPowerBonus);
            UIManager.Instance.ChangeBasePowerText(); 
            GameManager.instance.ChangePowerText();          
        }
        else
        {
            Debug.Log("Not enought leg power to buy");
        }
    }

    public void EquipItem(ShopItem item)
    {
        spriteEquip.sprite = item.itemSprite;
        GameManager.instance.ChangeBasePower(item.legPowerBonus);
        UIManager.Instance.ChangeBasePowerText();
    }
}
