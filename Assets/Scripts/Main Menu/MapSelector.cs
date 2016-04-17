using UnityEngine;
using System.Collections;

public class MapSelector : MonoBehaviour 
{
	public void SelectMap1()
	{
		Application.LoadLevel ("MAP1");
	}

	public void SelectMap2()
	{
		Application.LoadLevel ("MAP2");
	}

	public void SelectMap3()
	{
		Application.LoadLevel ("MAP3");
	}
}
