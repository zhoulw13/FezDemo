using UnityEngine;

public class LookAtCamera : MonoBehaviour {

    [SerializeField]
    private GameObject _cameraContainer;

    /**************************************************/

    void Update() {
        this.gameObject.transform.rotation = _cameraContainer.transform.rotation;
    }

}