using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScaleSlider : MonoBehaviour
{
    public Slider scaleSlider;
    public Slider leftSlider;
    public RectTransform T;

    public float scalenumber;
    public float leftnumber;
    private void Start()
    {
        scaleSlider.value = 1;
    }
    private void Update()
    {
        scalenumber = scaleSlider.value;
        leftnumber = leftSlider.value;
        
        Vector3 SCALE = new Vector3(scalenumber, scalenumber, scalenumber);
        
        this.transform.localScale = SCALE;
        T.anchoredPosition = new Vector3(leftnumber *-200, 0, 0);
    }
}
