using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class Squatting : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Sprite[] liftings;
    [SerializeField] private GameObject child;
    [SerializeField] private Button butt;
    
    private SpriteRenderer childSprite;
    private int baseAmp;
    private int nextSquat;
    private int i;


    private void Awake()
    {
        nextSquat = 10;
        baseAmp = 1;
        i = 0;
        childSprite = child.GetComponent<SpriteRenderer>();
        
    
    }

    private int ChangeLifiting()
    {
        for (; i < liftings.Length; i++)
        {
            while (GameManager.instance.legPower < nextSquat)
            {
                childSprite.sprite = liftings[i];
                Debug.Log(childSprite.sprite.ToString());
                return baseAmp;
            }
            baseAmp *= 5;
            nextSquat *= 10;
        }
        return baseAmp;
    }


    public void Squat()
    {
        
        anim.SetTrigger("Squat");
        GameManager.instance.AddLegPower();
        GameManager.instance.ChangePowerText();
        StartCoroutine(Wait(0.38f));
    }

    private IEnumerator Wait(float delay)
    {
        butt.enabled = false;
        yield return new WaitForSeconds(delay);
        butt.enabled = true;
    }
}
