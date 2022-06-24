using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public static gamemanager ins;
    private int golds = 0;
    public Text GoldText;
    data a;
    public int GetGold()
    {
        return golds;
    }
    // Start is called before the first frame update
    void Start()
    {
        a = FindObjectOfType<data>();
        if (a)
            SetGold(a.getGold());
    }

    // Update is called once per frame
    void Update()
    {

    }
    void INS()
    {
        if (ins == null)
        {
            ins = this;
        }
    }
    private void Awake()
    {
        INS();
    }
    public void CountingGold(int c)
    {
        golds += c;
        GoldText.text = "" + golds;
        a.setGold(golds);

    }
    public void SetGold(int gold1)
    {
        golds = gold1;
        GoldText.text = "" + gold1;

    }
}
