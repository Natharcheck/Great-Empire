using System.Collections;
using UnityEngine;

public class EnvironmentReplacement : FieldComponent
{
	[SerializeField] private EnvironmentType environmentType;
	[SerializeField] private HexType hexType;


	[Range(0.5f, 1)]
	[SerializeField] private float hightPos;
	[Range(0, 1)]
	[SerializeField] private float maxHight;

	[Range(0, 1)]
	[SerializeField] private float minHight;

	private Environment environment;

	public override void Initialize()
	{
		switch (environmentType)
		{
			case EnvironmentType.Forest:
				environment = ContainerPrefabs.Instance.Forest;
				break;

			case EnvironmentType.Mountains:
				environment = ContainerPrefabs.Instance.Mountains;
				break;
		}

		StartCoroutine(Replacement());
	}

	private IEnumerator Replacement()
	{
		var hexes = fieldHexes.hexes;
		var environments = fieldHexes.environments;
		var speed = fieldHexes.speedGeneration;

		for (int i = 0; i < hexes.Count; i++)
		{
			yield return new WaitForSeconds(speed);

			var hex = hexes[i];
			var hexPosY = hex.transform.position.y;

			if (hex.firstType == hexType && hexPosY < maxHight && hexPosY > minHight)
			{
				var position = new Vector3(hex.transform.position.x, hex.transform.position.y + hightPos, hex.transform.position.z);

				var newObject = Instantiate(environment, position, Quaternion.identity, hex.transform);
					newObject.InitializeType(environmentType);
					newObject.InitializeFirstType();

					newObject.gameObject.name = environmentType.ToString();
					
				environments.Add(newObject);
			}
		}
	}
}