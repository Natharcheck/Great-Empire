using UnityEngine;

public abstract class CameraComponent : MonoBehaviour
{
	[HideInInspector] public CameraController cameraController;
	
	public abstract void Initialize();
}