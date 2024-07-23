using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogReplacement : FieldComponent
{
	private HexType hexType;
	private EnvironmentType environmentType;
	
	public override void Initialize()
	{	
		StartCoroutine(Replacement());
	}
	
	private IEnumerator Replacement()
	{
		hexType = HexType.Fog;
		environmentType = EnvironmentType.Fog;
		
		var hexes = fieldHexes.hexes;
		var environments = fieldHexes.environments;
		
		foreach (var hex in hexes)
		{
			yield return new WaitForSeconds(0);
			SwapHex(hex); 
		}
		
		foreach (var environ in environments)
		{
			yield return new WaitForSeconds(0);
			SwapEnvironment(environ); 
		}
		
		yield break;
	}	

	private void SwapHex(Hex cell)
	{
		cell.InitializeType(hexType);
		cell.Select();
	}
	private void SwapEnvironment(Environment cell)
	{
		cell.InitializeType(environmentType);
		cell.Select();
	}
}