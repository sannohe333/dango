using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class StoppedScript : MonoBehaviour {

    private GameObject wall_parent;
	void Start () {

        wall_parent=transform.parent.parent.gameObject ;
		//var main = GetComponent<ParticleSystem>().main;

		// StopActionはCallbackに設定している必要がある
		//main.stopAction = ParticleSystemStopAction.Callback;
	}

	void OnParticleSystemStopped () {
        Destroy(wall_parent);
		//Debug.Log("System has stopped!");
	}

}