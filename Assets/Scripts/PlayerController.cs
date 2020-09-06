using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
    private GameObject _cameraContainer;

    public float Speed = 6.0F;
    public float JumpSpeed = 8.0F;
    public float Gravity = 20.0F;

    private Vector3 _moveDirection = Vector3.zero;

    /**************************************************/

    private void Start() {
        RePosition();
    }

    void Update() {
        if (_characterController.isGrounded) {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);// Input.GetAxis("Vertical"));
            Debug.Log(_moveDirection);
            _moveDirection = _cameraContainer.transform.TransformDirection(_moveDirection);
            Debug.Log(_moveDirection);
            _moveDirection *= Speed;
            if (Input.GetButton("Jump")) {
                _moveDirection.y = JumpSpeed;
            }
        }

        _moveDirection.y -= Gravity * Time.deltaTime;
        _characterController.Move(_moveDirection * Time.deltaTime);


        Ray ray = new Ray(this.transform.position, Vector3.down * 100);
        Debug.DrawRay(ray.origin, ray.direction);
    }

    public void RePosition() {
        Ray ray = new Ray(this.transform.position, Vector3.down);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 100.0f)) {
            GameObject platform = hit.collider.gameObject;
            Vector3 colliderPos = ((BoxCollider)(hit.collider)).center;
            Vector3 playerPos = platform.transform.InverseTransformPoint(this.transform.position);
            Vector3 newPos = new Vector3(playerPos.x - colliderPos.x, playerPos.y, playerPos.z - colliderPos.z);
            newPos = platform.transform.TransformPoint(newPos);

            this.transform.position = newPos;
        }
    }

    public void Enable() {
        this.enabled = true;
        _characterController.enabled = true;
    }

    public void Disable() {
        this.enabled = false;
        _characterController.enabled = false;
    }

}