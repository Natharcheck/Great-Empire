using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
	[SerializeField] private List<CameraComponent> cameraComponents;
	
	private Camera mainCamera;
	
	private void Start()
	{
		mainCamera = Camera.main;
		
		StartCoroutine(InitializeComponents());
	}
	
	private IEnumerator InitializeComponents()
	{
		foreach (var component in cameraComponents)
		{
			yield return new WaitForSeconds(0);
			
			component.cameraController = this;
			component.Initialize();
		}
	}
}