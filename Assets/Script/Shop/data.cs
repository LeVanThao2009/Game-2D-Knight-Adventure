using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{
    private int gold;
    private int Health;
    private int Power;
    private int Boom;
    public void setGold(int gold1)
    {
        gold = gold1;
    }
    public int getGold()
    {
        return gold;
    }
    public void setHealth(int health)
    {
        Health = health;
    }
    public int getHealth()
    {
        return Health;
    }
    public void setPower(int power)
    {
        Power = power;
    }
    public int getPower()
    {
        return Power;
    }
    public void setBoom(int boom)
    {
        Boom = boom;
    }
    public int getBoom()
    {
        return Boom;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
