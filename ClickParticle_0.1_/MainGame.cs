using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainGame : MonoBehaviour
{
    const int MAX_TOUCH = 5;

    private ParticleSystem partSys;

    public ScaleEffect scaleEf;
    public GameObject[] touchInfo = new GameObject[MAX_TOUCH];


    [SerializeField]
    private ResourcesLoad resource;
    

    [SerializeField]
    private int clickCnt;
    private int sprCount;
    private void SpwanParticle()
    {
        partSys = touchInfo[clickCnt].transform.GetChild(0).GetComponent<ParticleSystem>();
        partSys.Play(true);
    }

    private void sustainSpr()
    {
        Color color = new Color(0.3f, 0.4f, 0.6f);
        Sprite spr = resource.MainSprite[sprCount];
    }
    private void SpriteChange(GameObject gm)
    {
        SpriteRenderer sprRend = gm.GetComponent<SpriteRenderer>(); 
        ParticleSystemRenderer partRend = gm.transform.GetChild(0).GetComponent<ParticleSystemRenderer>();
        Debug.Log(partRend);
        partRend.material = resource.MainMat[sprCount];
        sprRend.sprite = resource.MainSprite[sprCount];
    }

    private void Start()
    {
        resource = ResourcesLoad.InstanceRes;
        
        for (int i = 0; i < MAX_TOUCH; i++)
        {
            touchInfo[i] = Instantiate(resource.MainObj, new Vector3(0, 0, 0), Quaternion.identity);
            touchInfo[i].name = "Click" + i;
            touchInfo[i].SetActive(false);
        }

        clickCnt = 0;
        sprCount = 0;
    }
    private void Update()
    { 
        if(Input.GetMouseButtonDown(0))
        {
            SpriteChange(touchInfo[clickCnt]);

            touchInfo[clickCnt].SetActive(true);
            SpwanParticle();
            touchInfo[clickCnt].GetComponent<ScaleEffect>().RunEffect(1);
            touchInfo[clickCnt].transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchInfo[clickCnt].transform.position = new Vector3(touchInfo[clickCnt].transform.position.x, touchInfo[clickCnt].transform.position.y, 1);

            if (clickCnt != MAX_TOUCH - 1) clickCnt++;
            else clickCnt = 0;
        }

        if(Input.GetMouseButton(0))
        {
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (sprCount < resource.MainMat.GetLength(0) - 1) sprCount++;
            else sprCount = 0;
        }
    }
}
