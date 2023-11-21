using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatInvul : MonoBehaviour
{
    private Renderer rend;
    private Color grey;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        grey = rend.material.color;
    }

    IEnumerator Invincible()
    {
        rend.material.color = new Color32(85, 85, 85, 255);
        yield return new WaitForSeconds(7f);
        rend.material.color = new Color32(255, 255, 255, 255);

        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.5f);
            if (i % 2 == 0) { rend.material.color = new Color32(85, 85, 85, 255); }
            else { rend.material.color = new Color32(255, 255, 255, 255); }
        } 

        rend.material.color = new Color32(255, 255, 255, 255);

    }
}
