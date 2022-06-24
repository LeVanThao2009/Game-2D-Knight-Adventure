using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopUI : MonoBehaviour
{
    public InputField red;
    public InputField yellow;
    public InputField black;
    int health;
    int power;
    int boom;
    public Text cost;
    public int costhealth;
    public int costpower;
    public int costboom;
    private int tong;
    public GameObject shop;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (int.TryParse(red.text.ToString(), out health) == false)
        {
            health = 0;
        }
        if (int.TryParse(yellow.text.ToString(), out power) == false)
        {
            power = 0;
        }
        if (int.TryParse(black.text.ToString(), out boom) == false)
        {
            boom = 0;
        }
        tong = health * costhealth + power * costpower + boom * costboom;
        cost.text = "Cost: " + tong.ToString();

    }
    public void AddHealth()
    {
        health++;
        red.text = health.ToString();
    }
    public void ReduceHealth()
    {
        if (health > 0)
        {
            health--;
            red.text = health.ToString();
        }

    }
    public void AddBoom()
    {
        boom++;
        black.text = boom.ToString();
    }
    public void ReduceBoom()
    {
        if (boom > 0)
        {
            boom--;
            black.text = boom.ToString();
        }

    }
    public void AddPower()
    {
        power++;
        yellow.text = power.ToString();
    }
    public void ReducePower()
    {
        if (power > 0)
        {
            power--;
            yellow.text = power.ToString();
        }

    }
    public void Cancel()
    {
        shop.SetActive(false);
    }
    public void Buy()
    {
        data a = FindObjectOfType<data>();
        if (a.getGold() < 0)
        {
            shop.SetActive(false);
            return;
        }

        a.setHealth(health + a.getHealth());
        a.setPower(power + a.getPower());
        a.setBoom(boom + a.getBoom());
        Debug.Log(a.getPower() + "=" + a.getHealth());
        PauseScene.ins.buy(a.getHealth(), a.getPower(), a.getBoom());
        a.setGold(a.getGold() - tong);
        shop.SetActive(false);
    }
}
