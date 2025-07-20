using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource source;
    [SerializeField] AudioClip mouseEnter;
    [SerializeField] AudioClip MouseClick;
    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

    public void PointerEnter()
    {
        source.PlayOneShot(mouseEnter);
    }
    public void PointerClick()
    {
        source.PlayOneShot(MouseClick);
    }

}
