using UnityEngine;

public class ContainerMaterials : MonoBehaviour
{
	public static ContainerMaterials Instance;
	
	public Material Fog;
	public Material Earth;
	public Material Water;
	public Material Stone;
	public Material Forest;
	public Material Mountains;
	
	private void Awake() => Instance = this;
}