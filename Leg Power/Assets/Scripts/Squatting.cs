using System.Collections;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Squatting : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Sprite[] liftings;
    [SerializeField] private GameObject child;
    [SerializeField] private Button butt;
    [SerializeField] private AudioClip grunt;
    
    private SpriteRenderer childSprite;


    private void Awake()
    {
        
        childSprite = child.GetComponent<SpriteRenderer>();
        
    
    }

    public void Squat()
    {
        
        anim.SetTrigger("Squat");
        SoundManager.instance.PlaySound(grunt);
        GameManager.instance.AddLegPower();
        UIManager.Instance.ChangePowerText();
        StartCoroutine(Wait(0.4f));
    }

    private IEnumerator Wait(float delay)
    {
        butt.enabled = false;
        butt.GetComponent<EventTrigger>().enabled = false;
        yield return new WaitForSeconds(delay);
        butt.enabled = true;
        butt.GetComponent<EventTrigger>().enabled = true;
    }
}
