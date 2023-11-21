using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hmm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetObstacle()
    {
        transform.GetChild(0).localPosition = new Vector3(0, Random.Range(-1, -1), 0);
    }
}
