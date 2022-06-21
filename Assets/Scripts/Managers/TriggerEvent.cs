using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public delegate void CollectTrigger();
    public static event CollectTrigger collectTrigger;
    
    public delegate void DeliveryTrigger();
    public static event DeliveryTrigger deliveryTrigger;
    bool delivery;

    public static BoxManager boxManager;
    public static CollectManager collectManager;
    public static DeliveryManager deliveryManager;
    bool isCollect;
    
    void Start()
    {
        StartCoroutine(CollectStack());
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("BoxArea"))
        {
          isCollect=true;
          boxManager=other.GetComponent<BoxManager>();
        }


          if(other.CompareTag("DeliveryArea"))
        {

            deliveryManager=other.GetComponent<DeliveryManager>();

            if(deliveryManager.DeliveryList.Count<deliveryManager.DeliveryLimit)
            {
               delivery=true;

            }
            else
            {
                delivery=false;
               
            }
          
        }

    }

      void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Upgrade"))
        {
           UIManager.Instance.UpgradeOpen();
        }
    }

      void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("BoxArea"))
        {
          isCollect=false;
          boxManager=null;
        }

           if(other.CompareTag("DeliveryArea"))
        {
          delivery=false;
          deliveryManager=null;
        }

        if(other.CompareTag("Upgrade"))
        {
           UIManager.Instance.UpgradeClose();
        }

    }



    IEnumerator CollectStack()
    {
        while(true)
        {
            if(isCollect==true)
            {
               collectTrigger();
            }

            if(delivery==true)
            {
             deliveryTrigger();
            }

            yield return new WaitForSeconds(.5f);
        }

    }


}
