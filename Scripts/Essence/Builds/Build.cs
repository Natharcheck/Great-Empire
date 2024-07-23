using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;

public abstract class Build : Cell
{
	public BuildType buildType;
	public Vector2 size;
	public int level;
	
	public List<Hex> hexes;	
	public List<UnityEvent> additionalEvents;
	public Dictionary<Type, IBuildState> buildStates;
	
	public override void Enter()
	{
		animator.SetTrigger("Select");
	}

	public override void Select()
	{
		animator.SetTrigger("Select");
	}

	public override void Exit()
	{
		
	}
}