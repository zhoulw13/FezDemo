using UnityEngine;
using DG.Tweening;

public class CameraRotator : MonoBehaviour {

    public PlatformManager PlatformManager;
    public PlayerController PlayerController;

    public float Duration = 1f;

    private bool _onRotate = false;

    /**************************************************/

    private void Update() {
        CheckKeyboardInputs();
    }

    #region CheckKeyboardInputs

    private void CheckKeyboardInputs() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Rotate(RotateDirection.Left);

        } else if (Input.GetKeyDown(KeyCode.X)) {
            Rotate(RotateDirection.Right);

        }
    }

    #endregion

    #region Rotate

    public void Rotate(RotateDirection direction) {
        if (_onRotate) {
            return;
        }

        _onRotate = true;
        PlayerController.RePosition();
        PlayerController.Disable();

        Vector3 target = this.gameObject.transform.rotation.eulerAngles;

        switch (direction) {
            case RotateDirection.Left:
                target = new Vector3(0, target.y + 90, 0);
                break;
            case RotateDirection.Right:
                target = new Vector3(0, target.y - 90, 0);
                break;
        }

        this.gameObject.transform.DORotate(target, Duration)
            .OnComplete(() => OnRotateComplete());
    }

    private void OnRotateComplete() {
        PlatformManager.RePosition();
         PlayerController.Enable();
        _onRotate = false;
    }

    #endregion

}