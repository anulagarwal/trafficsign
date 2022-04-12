using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
[RequireComponent(typeof(SignHandler))]
[RequireComponent(typeof(MMF_Player))]
[RequireComponent(typeof(BoxCollider))]
public class Platform : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] float speed;
    [SerializeField] Vector3 moveForce;
    [SerializeField] public ObjectState state;



    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
      
        if (state == ObjectState.Moving)
        {
            transform.Translate(moveForce * speed);
        }

        if (state == ObjectState.Rotating)
        {
            /* print(transform.rotation.eulerAngles.x);
             if(Mathf.Abs(transform.rotation.eulerAngles.x) - Mathf.Abs(targRotation.rotation.eulerAngles.x) >3)
             transform.Rotate(new Vector3(-1 * speed, 0, 0)); */
        }

    }

    public void Move()
    {
        UpdateState(ObjectState.Moving);
    }

    public void Rotate(float targetAngle)
    {
        UpdateState(ObjectState.Rotating);
    }

    public void SetSpeed(float s)
    {
        speed = s;
    }

    public void Scale()
    {
       
            if (GetComponent<MMF_Player>() != null)
            {
            print("Scale");
            GetComponent<MMF_Player>().GetFeedbackOfType<MMF_Scale>("Scale").AnimateScaleTarget = transform;
            GetComponent<MMF_Player>().enabled = true;
            }
        
    }

    public void UpdateState(ObjectState s)
    {
        state = s;
    }
}
