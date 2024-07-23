public class Hex : Cell
{
	public HexType firstType;
	public HexType type;

	public override void Initialize()
    {

    }

	public void InitializeType(HexType hexType)
	{	
		var material = meshRenderer.material;
		var containerMaterials = ContainerMaterials.Instance;
		
		switch (hexType)
		{
			case HexType.Earth:
				material = containerMaterials.Earth;
				break;
			case HexType.Water: 
				material = containerMaterials.Water;
				break;
			case HexType.Stone: 
				material = containerMaterials.Stone;
				break;
			case HexType.Fog:
				material = containerMaterials.Fog;
			break;
		}
		
		type = hexType;
		meshRenderer.material = material;
	}
	
	
	public void InitializeFirstType()
	{
		if(firstType != HexType.Default || firstType != HexType.Fog)
			firstType = type;
	}
	
	public override void Enter()
	{
		animator.SetTrigger("Select");
		
		InitializeType(firstType);
	}
	public override void Select()
	{
		animator.SetTrigger("Select");
	}
	
	public override void Exit()
	{	
		InitializeType(HexType.Fog);
	}
	
}