using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : CameraComponent, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] private Transform target;
	[SerializeField] private Vector3 offsetPosition;
	[Range(0,5)]
	[SerializeField] private float speedMovement;
	[Range(0,1)]
	[SerializeField] private float speedRotation;
	
	private float clampX;
	private float clampZ;
	
	private Camera mainCamera;
	private Transform cameraTransform;
	
	private Transform select;
	
	public override void Initialize()
	{	
		mainCamera = Camera.main;
		cameraTransform = mainCamera.transform;
		
		var fieldHexes = FindObjectOfType<FieldHexes>();
		
		var hex = fieldHexes.FindCenterHex();
		SetTarget(hex.transform);
		
		clampX = fieldHexes.FindMaxPosition().x + 1;
		clampZ = fieldHexes.FindMaxPosition().y + 1;
		
	}
	
	private void FixedUpdate()
	{	
		SelectToTarget();
		LookAtTarget();
		Move();
	}
	
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}
	
	private void LookAtTarget()
	{	
		var direction = target.position - cameraTransform.position;
		cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, Quaternion.LookRotation(direction, Vector3.up), speedRotation * Time.deltaTime);
	}
	
	private void Move()
	{
		var position = cameraTransform.position;
			position = Vector3.Lerp(cameraTransform.position, target.position + offsetPosition, speedMovement * Time.deltaTime);
			
		position.x = Mathf.Clamp(position.x, 0, clampX);
		position.z = Mathf.Clamp(position.z, clampZ + offsetPosition.z, 0);
		position.y = Mathf.Clamp(position.y, offsetPosition.y - 5, offsetPosition.y);
		
		cameraTransform.position = position;
	}
	
	private void SelectToTarget()
	{	
		if(Input.GetMouseButton(0))
		{
			//var touch = Input.GetTouch(0);
			
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
		
			Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 100, Color.yellow);
		
			if(Physics.Raycast(ray, out hit))
			{
				var hex = hit.collider.gameObject.GetComponent<Hex>();
				
				if(hex)
				{
					if(hex.type != HexType.Fog)
					{
						SetTarget(hex.transform);
						hex.Select();
					}
				}
			}
		}
	}

	public void OnDrag(PointerEventData eventData)
	{	
		
	}

	public void OnPointerDown(PointerEventData eventData)
	{

	}

	public void OnPointerUp(PointerEventData eventData)
	{

	}
}