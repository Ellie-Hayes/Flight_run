using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public int hatcorrelation;
    public bool BoughtHat;
    public int hatCost;
    public GameObject price;
    private Image imagerend;
    Shop shop;

    void Start()
    {
        shop = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shop>();
        imagerend = GetComponent<Image>();

        bool val = PlayerPrefs.GetInt("HatBought" + hatcorrelation) == 1 ? true : false;
        if (val)
        {
            price.SetActive(false);
            BoughtHat = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HatButtonPressed()
    {
        if (!BoughtHat)
        {
            if (shop.coins >= hatCost)
            {
                BoughtHat = true;
                shop.coins -= hatCost;
                shop.ResetColours();
                shop.SelectHat(hatcorrelation); //passes the hat that the button is attached to to the shop to set it into the player prefs xxx
                price.SetActive(false);
                imagerend.color = new Color32(51, 204, 51, 100);

                PlayerPrefs.SetInt("PlayerCoins", shop.coins);
                bool val = true;
                PlayerPrefs.SetInt("HatBought" + hatcorrelation, val ? 1 : 0);
                PlayerPrefs.Save();
            }
            else
            {
                imagerend.color = new Color32(204, 0, 0, 100); // changes the border colour numbers are RGB and then alpha (opacity)
                StartCoroutine("wait");
            }
        }
        if (BoughtHat)
        {
            shop.ResetColours();
            shop.SelectHat(hatcorrelation);
            imagerend.color = new Color32(51, 204, 51, 100);
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        imagerend.color = new Color32(255, 255, 255, 100);
    }
}
