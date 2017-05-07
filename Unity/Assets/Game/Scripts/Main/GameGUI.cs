using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class GameGUI : PanelStack
{

	static GameGUI _instance;

	public static GameGUI instance {
		get {
			return _instance;
		}
	}
	[Header ("-----Panels-----")]
	public List<PanelController> panels;

	public PanelController defaultPanel;


	#region Monobehavior

	void Awake ()
	{		
		_instance = this;
		DontDestroyOnLoad (gameObject);	

	}

	IEnumerator Start ()
	{

		//yield return new WaitForSeconds (0.5f);
		yield return null;
		if (defaultPanel != null) {
			PushPanel (defaultPanel);
		}

	}

	public virtual void PushPanel (string panelName)
	{
		PanelController panel = GetPanel (panelName);
		PushPanel (panel);
	}

	public PanelController GetPanel (string panelName)
	{
		return panels.Where (s => s).FirstOrDefault (s => s.name == panelName);
	}

	public virtual void PopPanel (string panelName)
	{
		PanelController panel = GetPanel (panelName);
		PopPanel (panel);
	}



	#endregion

}
