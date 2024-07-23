using UnityEngine;

public abstract class FieldComponent : MonoBehaviour
{	
	[HideInInspector] public FieldHexes fieldHexes;
	
	public abstract void Initialize();
}