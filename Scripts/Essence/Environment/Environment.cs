public class Environment : Cell
{
	public EnvironmentType firstType;
	public EnvironmentType type;
	
	public override void Initialize()
    {

    }
	
	public void InitializeType(EnvironmentType environType)
	{	
		var material = meshRenderer.material;
		var containerMaterials = ContainerMaterials.Instance;
		
		switch (environType)
		{
			case EnvironmentType.Forest:
				material = containerMaterials.Forest;
				break;
			case EnvironmentType.Mountains: 
				material = containerMaterials.Mountains;
				break;
				
			case EnvironmentType.Fog: 
				meshRenderer.enabled = false;
				break;
		}
		
		type = environType;
		meshRenderer.material = material;
	}

	public void InitializeFirstType()
	{
		if(firstType != EnvironmentType.Fog)
			firstType = type;
	}
	
	public override void Enter()
	{
		InitializeType(firstType);
		meshRenderer.enabled = true;
	}
	public override void Select()
	{
		animator.SetTrigger("Select");
	}
	
	public override void Exit()
	{	
		meshRenderer.enabled = false;
	}
}