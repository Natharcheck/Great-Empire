using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexReplacement : FieldComponent
{
	[SerializeField] private HexType hexType;

	[Range(0, 1f)]
	[SerializeField] private float hight = 0.5f;
	[SerializeField] private bool isHighness = false;
	
	public override void Initialize()
	{
		StartCoroutine(Replacement());
	}

	private IEnumerator Replacement()
	{
		var hexes = fieldHexes.hexes;
		var parent = Parent(hexType.ToString()); 
		 
		for (int i = 0; i < hexes.Count; i++)
		{
			var positionHex = hexes[i].transform.position.y;

			if (isHighness)
			{
				if (positionHex >= hight)
					Swap(hexes[i], parent);
			}
			else
			{
				if (positionHex <= hight)
					Swap(hexes[i], parent);
			}
		}
		
		yield break;
	}

	private void Swap(Hex hex, Transform parent)
	{				
		hex.gameObject.name = hexType.ToString();
		hex.transform.parent = parent;
		
		hex.InitializeType(hexType);
		hex.InitializeFirstType();
		hex.Select();
	}
	
	private Transform Parent(string name)
	{
		var parent = Instantiate(new GameObject(), transform.position, Quaternion.identity);
			parent.gameObject.name = name; 
			
		parent.transform.parent = transform;
		
		return parent.transform;
	}
}