using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResetObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        ResetObstacle();
    }

    void ResetObstacle()
    {
        transform.localPosition = new Vector3(0, Random.Range(-1, -1), 0);

    }
}
