using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInfo : MonoBehaviour
{
    private ResourcesLoad resLoad;
    public SpriteRenderer renderSpr;

    public void InitGame(GameObject gm)
    {
        renderSpr = gm.GetComponent<SpriteRenderer>();
    }
}
