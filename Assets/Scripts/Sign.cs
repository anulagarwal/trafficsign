using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    [SerializeField] public SignType type;

    public float value;
    public SignHandler handler;

    bool isSelected;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider == GetComponent<BoxCollider>())
                {
                    transform.parent = null;
                    if (handler != null)
                    {
                        handler.RemoveSign(this);
                        handler = null;
                    }
                  /*  if (hit.collider.gameObject.layer == LayerMask.GetMask("Platform"))
                    {
                        GetComponent<cakeslice.Outline>().enabled = false;
                        hit.collider.gameObject.AddComponent<SignHandler>();
                    }*/

                    isSelected = true;
                }

            }
        }

        //Dragging works here
       
        if (Input.GetMouseButton(0) && isSelected)
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            int layer_mask = LayerMask.GetMask("Platform");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer_mask))
            {
                transform.position = new Vector3(hit.point.x , hit.point.y ,hit.point.z);
                                     
            }
        }

        if (Input.GetMouseButtonUp(0) && isSelected)
        {            
                isSelected = false;
            if (handler != null)
            {
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attachable" && GameManager.Instance.GetState()!= GameState.InGame)
        {           
            other.GetComponent<SignHandler>().AddSign(this);
            handler = other.GetComponent<SignHandler>();
            transform.SetParent(handler.transform);
           gameObject.AddComponent<cakeslice.Outline>();
            if (other.GetComponent<SignHandler>().type == ObjectType.Car)
            {
                other.transform.GetChild(0).gameObject.AddComponent<cakeslice.Outline>();
            }


            else
            {
                other.gameObject.AddComponent<cakeslice.Outline>();
            }


        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Attachable" && GameManager.Instance.GetState() != GameState.InGame)
        {
            other.GetComponent<SignHandler>().RemoveSign(this);
            handler = null;
            transform.SetParent(null);
            Destroy(GetComponent<cakeslice.Outline>());

            if (other.GetComponent<SignHandler>().type == ObjectType.Car)
            {
               Destroy(other.transform.GetChild(0).gameObject.GetComponent<cakeslice.Outline>());
            }


            else
            {
                Destroy(other.gameObject.GetComponent<cakeslice.Outline>());

            }
        }

    }
}
