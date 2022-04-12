using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
          
            //GetComponent<Outline>().enabled = !GetComponent<Outline>().enabled;
            OutlineManager.Instance.ApplyOutline(gameObject, Color.red, true);
        }
    }
}
