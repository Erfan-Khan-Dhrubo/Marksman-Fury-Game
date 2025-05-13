using UnityEngine;

public class EnemyCollectableDrops : MonoBehaviour
{
   [SerializeField] float chanceOfCollectableDrop;

   private CollectableSpawner _collectableSpawner;

   private void Awake()
   {
      _collectableSpawner = FindFirstObjectByType<CollectableSpawner>();
   }

   public void RandomlyDropCollectable()
   {
      float random = Random.Range(0f, 1f);
      
      //Debug.Log("Random value: " + random);

      if (chanceOfCollectableDrop >= random)
      {
         _collectableSpawner.SpawnCollectable(transform.position);
      }
   }
}
