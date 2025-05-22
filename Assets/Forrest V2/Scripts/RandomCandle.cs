using System.Collections.Generic;
using UnityEngine;

public class RandomCandle : MonoBehaviour
{
    SpriteRenderer SR;
    public Sprite FirstSprite;
    public int Rand;
    [SerializeField] List<Sprite> _candleSprites = new();


    private void Start()
    {
        
        SR = GetComponent<SpriteRenderer>();
        Rand = UnityEngine.Random.Range(1, 10);
        FirstSprite = _candleSprites[Random.Range(0, _candleSprites.Count - 1)];


        SR.sprite = FirstSprite;
    }







}
