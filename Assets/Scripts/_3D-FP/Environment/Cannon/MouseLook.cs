using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Vector2 _clampInDegrees = new (360f, 180f);
    [SerializeField] private Vector2 _sensitivity = new (0.1f, 0.1f);
    [SerializeField] private Vector2 _smoothing = new (1f, 1f);

    [SerializeField] private bool _lockCursor;
    [SerializeField] private GameObject _horizontalRotationBody;
    [SerializeField] private GameObject _verticalRotationBody;
    
    private PlayerInputActions _input;
    
    private Vector2 _mouseFinal;
    private Vector2 _smoothMouse;
    private Vector2 _targetDirection;
    private Vector2 _targetCharacterDirection;
    
    private void OnEnable()
    {
        _input = new PlayerInputActions();
        _input.Enable();
    }

    private void Start()
    {
        _targetDirection = transform.localRotation.eulerAngles;
        _targetCharacterDirection = _horizontalRotationBody.transform.localRotation.eulerAngles;
    }

    private void LateUpdate()
    {
        if (_lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        Vector2 mouseDelta = _input.pActionMap.MouseLook.ReadValue<Vector2>();
        _mouseFinal += ScaleAndSmooth(mouseDelta);

        ClampValues();
        AlignToBody();
    }

    private Vector2 ScaleAndSmooth(Vector2 delta)
    {
        delta = Vector2.Scale(delta, new Vector2(_sensitivity.x * _smoothing.x, _sensitivity.y * _smoothing.y));

        _smoothMouse.x = Mathf.Lerp(_smoothMouse.x, delta.x, 1f / _smoothing.x);
        _smoothMouse.y = Mathf.Lerp(_smoothMouse.y, delta.y, 1f / _smoothing.y);

        return _smoothMouse;
    }

    private void ClampValues()
    {
        if (_clampInDegrees.x < 360)
        {
            _mouseFinal.x = Mathf.Clamp(_mouseFinal.x, -_clampInDegrees.x * 0.5f, _clampInDegrees.x * 0.5f);
        }

        if (_clampInDegrees.y < 360)
        {
            _mouseFinal.y = Mathf.Clamp(_mouseFinal.y, -_clampInDegrees.y * 0.5f, _clampInDegrees.y * 0.5f);
        }

        var targetOrientation = Quaternion.Euler(_targetDirection);
        transform.localRotation = Quaternion.AngleAxis(-_mouseFinal.y, targetOrientation * Vector3.right) * targetOrientation;

    }

    private void AlignToBody()
    {
        Quaternion yRotation = Quaternion.AngleAxis(_mouseFinal.x, Vector3.up) * Quaternion.Euler(_targetCharacterDirection);
        Quaternion xRotation = Quaternion.AngleAxis(_mouseFinal.y, -Vector3.right) * Quaternion.Euler(_targetCharacterDirection);
        
        _horizontalRotationBody.transform.localRotation = Quaternion.Euler(0, yRotation.eulerAngles.y, 0);
        _verticalRotationBody.transform.localRotation = Quaternion.Euler(0, 0, xRotation.eulerAngles.x);
    }
}