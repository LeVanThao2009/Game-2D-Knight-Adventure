using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseScene : MonoBehaviour
{
    public static PauseScene ins;
    public GameObject PauseScren;
    public GameObject PauseButton;
    public int Health;
    public int Power;
    public int Boom;
    public Text slHealth;
    public Text slPower;
    public Text slBoom;
    public GameObject Shop;
    data a;
    bool GamePaused;
    // Start is called before the first frame update
    void Start()
    {
        INS();
        GamePaused = false;
        a = FindObjectOfType<data>();
    }
    void INS()
    {
        if (ins == null)
        {
            ins = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (GamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void PauseGame()
    {
        GamePaused = true;
        PauseScren.SetActive(true);
        PauseButton.SetActive(false);
    }
    public void ResumeGame()
    {
        GamePaused = false;
        PauseScren.SetActive(false);
        PauseButton.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Menu(int seneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(seneID);
    }
    public void useHealth()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (Health > 0 && playerHealth.currenHealth < playerHealth.maxHealth)
        {
            Health--;
            slHealth.text = Health.ToString();
            // Debug.Log("Tăng máu");
            playerHealth.addHealth(10);

        }

    }
    public void usePower()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (Health > 0 && playerHealth.currenHealth < playerHealth.maxHealth)
        {
            Health--;
            slPower.text = Health.ToString();
            // Debug.Log("Tăng máu");
            playerHealth.addHealth(50);

        }

    }
    public void ButtonShop()
    {
        Shop.SetActive(true);
    }
    public void buy(int sl1, int sl2, int sl3)
    {
        Health = sl1;
        Power = sl2;
        Boom = sl3;
        slHealth.text = Health.ToString();
        slPower.text = Power.ToString();
        slBoom.text = Boom.ToString();

    }
}
