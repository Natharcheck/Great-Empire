using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HightReplacement))]
public class FieldHexes : MonoBehaviour
{
	[SerializeField] private List<FieldComponent> fieldComponents = new List<FieldComponent>();
	public Vector2 size;
	
	[Range(0, 0.05f)]
	public float speedGeneration;
	
	[Space]
	public List<UnityEvent> AdditionalEvent;
	
	public List<Hex> hexes;
	public List<Environment> environments;
	
	[HideInInspector] public Hex defaultHex;
	
	private void Start()
	{	
		StartCoroutine(GenerationField());
		
		StartCoroutine(InitializeComponents());
	}
	
	public void InitComponents()
	{
		StartCoroutine(InitializeComponents());
	}
	
	private IEnumerator InitializeComponents()
	{			
		foreach (var component in fieldComponents)
		{
			yield return new WaitForSeconds(0);
			
			component.fieldHexes = this;
			component.Initialize();
		}
	}
	
	
	private IEnumerator GenerationField()
	{
		var rotation = Quaternion.identity;
		
		for(int y = 0; y < size.y; y++)
		{
			for (int x = 0; x < size.x; x++)
			{	
				//yield return new WaitForSeconds(speedGeneration - 0.01f);
				var position = new Vector3(x, 0 , y);
				var newObject = Instantiate(defaultHex, PositionHex(position), rotation, transform);
				
				hexes.Add(newObject);		
			}
		}
		
		yield break;
	}

	public int FindCenter()
	{
		var center = hexes.Count / 2;
		return center;
	}
	
	public Hex FindCenterHex()
	{
		var center = FindCenter();
	
		return hexes[center];
	}

	public Vector2 FindMinPosition()
	{
		var value = new Vector2(0, 0);
		
		foreach (var hex in hexes)
		{
			var position = hex.transform.position;
			
			if (position.x < value.x)
				value.x = hex.transform.position.x;

			if (position.z > value.y)
				value.y = hex.transform.position.z;
		}
		
		return value;
	}

	public Vector2 FindMaxPosition()
	{
		var value = new Vector2(0, 0);
		
		foreach (var hex in hexes)
		{
			var position = hex.transform.position;
			
			if (position.x > value.x)
				value.x = hex.transform.position.x;

			if (position.z < value.y)
				value.y = hex.transform.position.z;
		}
		
		return value;
	}
	
	private Vector3 PositionHex(Vector3 coordinate)
	{
		var column = (int) coordinate.x;
		var row = (int) coordinate.z;

		var modelBounds = defaultHex.GetComponent<Renderer>().bounds.size;

		var hexWidth = modelBounds.x;
		var hexHeight = modelBounds.z;

		var horizontalDistance = hexWidth;
		var verticalDistance = hexHeight * 0.75f;

		var offset = (row % 2 == 0) ? 0 : horizontalDistance / 2f;

		var xPosition = column * horizontalDistance + offset;
		var yPosition = -row * verticalDistance;

		return new Vector3(xPosition, 0, yPosition);
	}
}