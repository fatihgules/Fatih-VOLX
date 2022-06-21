using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
   public static CollectManager Instance {get; private set;}
   public List<GameObject>BoxList=new List<GameObject>();
   public GameObject BoxPrefab;
   public Transform StackPoint;
   public int StackLimit;

   void Awake()
   {
      if(Instance==null)
      {
       Instance=this;
      }
   }

    void Start()
    {
        //Get Stack Limit Data
        StackLimit=PlayerPrefs.GetInt("StackLimit");
    }

     void OnEnable()
     {
         TriggerEvent.collectTrigger+=CollectBox;
         TriggerEvent.deliveryTrigger+=DeliveryBox;

     }

      void OnDisable()
     {
        TriggerEvent.collectTrigger-=CollectBox;
        TriggerEvent.deliveryTrigger-=DeliveryBox;
     }

     void CollectBox()//Stack Player Box
     {
        if(BoxList.Count<StackLimit)
        {
            GameObject BoxObj=Instantiate(BoxPrefab,StackPoint);
            BoxObj.transform.position=new Vector3(StackPoint.position.x,2.1f+(float)BoxList.Count+.5f,StackPoint.position.z);
            BoxList.Add(BoxObj);
            if(TriggerEvent.boxManager!=null)
            {
              TriggerEvent.boxManager.DeleteBox();
            }
        }

     }

     void DeleteStackBox()
     {
        Destroy(BoxList[BoxList.Count-1]);
        BoxList.RemoveAt(BoxList.Count-1);
        UIManager.Instance.ChangeMoneyText();
       
     }


     void DeliveryBox()
     {
        if(BoxList.Count>0)
        {
            TriggerEvent.deliveryManager.GiveDelivery();
            DeleteStackBox();//Player Stack - value

           

        }
     }
}
