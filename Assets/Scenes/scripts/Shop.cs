using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI coinText;
    public Image[] shopBorders;
    private int hatselected;

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("PlayerCoins");
        ResetColours();

        hatselected = PlayerPrefs.GetInt("PlayerHat");
        OpenShop();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = ("x") + coins.ToString();
    }

    public void ResetColours()
    {
        for (int i = 0; i < shopBorders.Length; i++)
        {
           Image imagerend = shopBorders[i].GetComponent<Image>();
           imagerend.color = new Color32(255, 255, 255, 100);
        }
    }

    public void SelectHat(int HatNumber)
    {
        PlayerPrefs.SetInt("PlayerHat", HatNumber);
    }

    void OpenShop()
    {
        Image imagerend = shopBorders[hatselected].GetComponent<Image>();
        imagerend.color = new Color32(51, 204, 51, 100);
    }
}
