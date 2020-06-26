using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager current;

    // Start is called before the first frame update
    void Start()
    {
        if (current == null)
            current = this;
        else
            Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
