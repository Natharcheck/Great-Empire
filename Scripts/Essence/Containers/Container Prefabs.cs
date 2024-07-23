using UnityEngine;

public class ContainerPrefabs : MonoBehaviour
{
	public static ContainerPrefabs Instance;
	
	public Environment Forest;
	public Environment Mountains;
	
	private void Awake() => Instance = this;
}