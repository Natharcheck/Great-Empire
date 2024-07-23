using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class HightReplacement : FieldComponent
{
	[SerializeField] private int sid;
	[Range(0, 25f)]
	[SerializeField] private float scale;

	public override void Initialize()
	{
		StartCoroutine(Replacement());
	}

	private IEnumerator Replacement()
	{
		var hexes = fieldHexes.hexes;

		foreach (var hex in hexes)
		{
			var position = hex.transform.position;

			var hight = Mathf.PerlinNoise((position.x + sid) * scale, (position.z + sid) * scale);
				hight = ((float)(int)(hight * 10)) / 10;

			position.y = hight;

			hex.transform.position = position;
			hex.Select();
		}

		yield break;
	}
}