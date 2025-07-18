using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Squatting : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Sprite[] liftings;
    [SerializeField] private GameObject child;
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
        Debug.Log(liftings.Length);
        if (liftings.Length>0)
        {
            childSprite.sprite = liftings[0];
        }
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
        GameManager.instance.AddLegPower(ChangeLifiting());
        Debug.Log(GameManager.instance.legPower.ToString());

    }
}
