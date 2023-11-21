using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public int TestCoins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerPrefs.SetInt("PlayerCoins", TestCoins);
        }

    }

    public void run()
    {
        PlayerPrefs.SetInt("Gamemode", 0);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Jetpack()
    {
        PlayerPrefs.SetInt("Gamemode", 1);
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void shop()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }


}
