using UnityEngine;

public class FogDispersal : MonoBehaviour
{
   public void OnTriggerEnter(Collider collider)
   {
		if(collider.gameObject.layer == 0)
		{
			var cell = collider.gameObject.GetComponent<Cell>();
				cell.Enter();
		}
   }
}