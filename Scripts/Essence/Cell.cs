using UnityEngine;

public abstract class Cell : MonoBehaviour
{
 	[HideInInspector] public MeshRenderer meshRenderer;
 	protected Animator animator;
	
	void OnEnable()
	{
		animator = GetComponent<Animator>();
		meshRenderer = GetComponent<MeshRenderer>();
	}
	
	void OnDisable()
	{
		animator = null;
		meshRenderer = null;
	}
	
	public abstract void Initialize();
	
	public abstract void Enter();
	public abstract void Select();	
	public abstract void Exit();
}