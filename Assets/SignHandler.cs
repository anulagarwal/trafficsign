using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignHandler : MonoBehaviour
{

    [SerializeField] public ObjectType type;
    [SerializeField] List<Sign> signs;

    public cakeslice.Outline outline;
    // Start is called before the first frame update
    void Start()
    {
//        GetComponent<cakeslice.Outline>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplySigns()
    {
        
        foreach(Sign s in signs)
        {
            ApplySign(s.type, s);
        }
    }
    public void AddSign(Sign s)
    {
        if(signs.Contains(s)==false)
        signs.Add(s);
    }
    public void RemoveSign(Sign s)
    {
        if (signs.Contains(s) == true)

            signs.Remove(s);
    }
    public void ApplySign(SignType t, Sign s)
    {
        switch (t)
        {
            case SignType.Speed:
                if (type == ObjectType.Car)
                {
                    GetComponent<Car>().enabled = true;
                    GetComponent<Car>().SetSpeed(s.value);
                    GetComponent<Car>().Move();
                    GetComponent<Rigidbody>().isKinematic = false;
                }
                if(type == ObjectType.Platform)
                {
                    //Add speed
                    GetComponent<Platform>().SetSpeed(s.value/200);
                    GetComponent<Platform>().Move();
                }
                break;
       
            case SignType.Elevation:
                if (type == ObjectType.Car)
                {
                    GetComponent<Car>().Scale();
                }
                if (type == ObjectType.Platform)
                {                   
                    GetComponent<Platform>().Scale();
                }

                break;

        }
    }
}
