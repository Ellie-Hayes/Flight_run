using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Text Countdown;


    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("Background"))
        {
            Time.timeScale = 0;
        }
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        Countdown.text = "3";
        yield return new WaitForSeconds(1.0f);
        Countdown.text = "2";
        yield return new WaitForSeconds(1.0f);
        Countdown.text = "1";
        yield return new WaitForSeconds(1.0f);
        Countdown.text = "Go!";
        // start the game here
        yield return new WaitForSeconds(1.0f);
        Countdown.text = "";
        
        yield return null;

       
    }
}
