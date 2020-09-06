using UnityEngine;

public class PlatformManager : MonoBehaviour {

    public PlayerController PlayerController;

    /**************************************************/

    private void Start() {
        RePosition();
    }

    public void RePosition() {
        Vector3 playerPosition = PlayerController.transform.position;

        GameObject[] allPlatforms = GameObject.FindGameObjectsWithTag("Platform");

        for (int i = 0; i < allPlatforms.Length; i++) {
            GameObject platform = allPlatforms[i];
            BoxCollider collider = platform.GetComponentInChildren<BoxCollider>();
            collider.center = Vector3.zero;

            //convert pos vec into world space
            Vector3 colliderPos = collider.transform.TransformPoint(collider.center);

            Vector3 newColliderPos;

            //move platform collider depending on what side the camera is facing 
            Vector3 normalCam = Camera.main.transform.position.normalized;
            if (Mathf.Abs(Mathf.Round(normalCam.x)) == 1.0f) {
                newColliderPos = new Vector3(playerPosition.x, colliderPos.y, colliderPos.z);
            } else {
                newColliderPos = new Vector3(colliderPos.x, colliderPos.y, playerPosition.z);
            }

            //converts back into local space
            newColliderPos = collider.transform.InverseTransformPoint(newColliderPos);

            collider.center = newColliderPos;
        }
    }

}