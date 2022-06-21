using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryManager : MonoBehaviour
{

    public List<GameObject> DeliveryList=new List<GameObject>();
    public Transform DeliveryPoint;
    public GameObject DeliveryPrefab;
    public int DeliveryLimit;
    public TextMeshPro DeliveryInfoText;
    public GameObject DeliveryTruck;
   

    void Start()
    {
        DeliveryLimit=Random.Range(4,10);
        DeliveryInfoText.text=(DeliveryList.Count+"/"+DeliveryLimit).ToString();

    }


  

    public void GiveDelivery()
    {
       
      
       GameObject DeliveryObj=Instantiate(DeliveryPrefab,DeliveryPoint);
       DeliveryObj.transform.position=new Vector3(DeliveryPoint.position.x,DeliveryList.Count+.5f,DeliveryPoint.position.z);
       DeliveryList.Add(DeliveryObj);
       DeliveryInfoText.text=(DeliveryList.Count+"/"+DeliveryLimit).ToString();

       if(DeliveryList.Count==DeliveryLimit)
       {
          DeliveryTruck.gameObject.SetActive(true);
       }
       
       

    }

    void DeleteDelivery()
    {
        Destroy(DeliveryList[DeliveryList.Count-1]);
        DeliveryList.RemoveAt(DeliveryList.Count-1);
    }

    public void DeliveryClear()
    {
       DeliveryPoint.gameObject.SetActive(false);
    }




    IEnumerator DeliverySuccess()
    {
        while(true)
        {
          if(DeliveryList.Count>0)
          {
           DeleteDelivery();
          }

           yield return new WaitForSeconds(2f);
        }
    }


   


}
