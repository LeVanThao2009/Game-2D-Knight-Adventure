using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text RaiCaText;
    public static int SLraica;
    // Start is called before the first frame update
    void Start()
    {
        SLraica = 5;
    }

    // Update is called once per frame
    public void IncrementRaiCa()
    {
        SLraica++;
        RaiCaText.text = SLraica + "/5";
    }
}
