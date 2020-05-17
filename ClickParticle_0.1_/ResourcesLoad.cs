using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesLoad : MonoBehaviour
{
    public static ResourcesLoad InstanceRes = null;

    public Sprite[] MainSprite;
    public Material[] MainMat;
    public GameObject MainObj;
    public GameObject MainSus;

    private void Awake()
    {
        if (InstanceRes == null)
        {
            InstanceRes = this;

        }
        else if (InstanceRes != null)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        MainObj = Resources.Load("Objects/MainObject") as GameObject;
        MainSus = Resources.Load<GameObject>("Objects/SusPart");

        MainSprite = Resources.LoadAll<Sprite>("Sprites");
        MainMat = Resources.LoadAll<Material>("Material");
    }
}
