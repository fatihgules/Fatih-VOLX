using UnityEngine;

namespace PathCreation.Examples
{
  
    public class DeliveryTruck : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;
        public bool isDelivery;

        void Start() {
            if (pathCreator != null)
            {
                
                pathCreator.pathUpdated += OnPathChanged;
            }
        }


     



        void Update()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }
        }

       
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

         void OnTriggerEnter(Collider other)
   {
    if(other.CompareTag("DeliveryArea"))
    {
      if(isDelivery==false)
      {
        var deliverManager=other.GetComponent<DeliveryManager>();//Other GameObject(Delivery area GetComponents)
        deliverManager.DeliveryClear();
        deliverManager.DeliveryInfoText.text="OK";//Set other GameObject Text value;
        isDelivery=true;
        GameManager.Instance.AddGoalScore();//Singleton call function
      }
    }
     
    if(other.CompareTag("DeliveryOk"))
    {
         if(isDelivery==true)
         {
             this.gameObject.SetActive(false);
             isDelivery=false;
             UIManager.Instance.LevelComplete();
         }
    } 



   }


    }

}