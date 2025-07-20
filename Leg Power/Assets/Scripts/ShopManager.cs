using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    [SerializeField] private SpriteRenderer spriteEquip;
    [SerializeField] private GameObject notEnought;
    private bool planet;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }       
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
            UIManager.Instance.ChangePowerText();
            if (item.itemName == "Planet")
            {              
                planet = true;
                BackgroundChange.instance.Change();
            }
        }
        else
        {
            StartCoroutine(Wait(1f));
            Debug.Log("Not enought leg power to buy");
        }
    }

    public void EquipItem(ShopItem item)
    {
        spriteEquip.sprite = item.itemSprite;
        GameManager.instance.ChangeBasePower(item.legPowerBonus);
        UIManager.Instance.ChangeBasePowerText();
    }

    private IEnumerator Wait(float delay)
    {
        notEnought.SetActive(true);
        yield return new WaitForSeconds(delay);
        notEnought.SetActive(false);
        
    }
}
