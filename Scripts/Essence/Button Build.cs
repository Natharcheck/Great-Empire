using UnityEngine;
using UnityEngine.UI;

public class ButtonBuild : MonoBehaviour
{
	[SerializeField] Build build;
	
	private Button button;
	
	private void Start()
	{
		button = GetComponent<Button>();
		
		button.onClick.AddListener(OnButtonClick);
	}
	
	private void OnButtonClick()
	{
		
	}
}