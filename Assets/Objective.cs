using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    [SerializeField]
    int numberOfCars;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Attachable")
        {
            if(GameManager.Instance.GetState()== GameState.InGame && other.gameObject.GetComponent<Car>()!= null)
            {
                GameManager.Instance.WinLevel();
            }
        }
    }
}
