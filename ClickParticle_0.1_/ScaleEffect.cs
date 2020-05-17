using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleEffect : MonoBehaviour
{
    public GameObject Gm;

    public void RunEffect(int number)
    {
        switch (number)
        {
            case 1:
                StartCoroutine("mainFade");
                break;
            case 2:
                break;
        }
    }
    IEnumerator mainFade()
    {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        float alphaVa = 1.0f;
        Color color = spr.color;

        while(alphaVa >= 0.0f)
        {
            alphaVa -= 0.04f;
            color.a = alphaVa;
            spr.color = color;

            yield return new WaitForSeconds(0.01f);
        }
        StopCoroutine("mainFade");
    }
}
