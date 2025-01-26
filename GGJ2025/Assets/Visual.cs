using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Visual : MonoBehaviour
{
    [SerializeField] private Sprite[] defaultFaces;
    [SerializeField] private Sprite[] angryFaces;
    [SerializeField] private Sprite[] makingForce;
    [SerializeField] private SpriteRenderer sr;

    private int default_size;
    private int angry_size;
    private int making_force_size;
    private LastFace last_face;
    
    enum LastFace {
        DEFAULT,
        ANGRY,
        MAKINGFORCE,
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        default_size = defaultFaces.Length;
        angry_size = angryFaces.Length;
        making_force_size = makingForce.Length;



        ChangeToDefault();
    }

    public void ChangeToAngry()
    {
        if (last_face == LastFace.ANGRY) return;
        last_face = LastFace.ANGRY;
        sr.sprite = angryFaces[Random.Range(0, angry_size)];
    }

    public void ChangeToMakingForce()
    {
        if (last_face == LastFace.MAKINGFORCE) return;
        last_face = LastFace.MAKINGFORCE;
        sr.sprite = makingForce[Random.Range(0, making_force_size)];
    }

    public void ChangeToDefault()
    {
        if (last_face == LastFace.DEFAULT) return;
        last_face = LastFace.DEFAULT;
        sr.sprite = defaultFaces[Random.Range(0, default_size)];
    }
}
