using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody _rigidbody;

    private void Awake() => CacheComponents();

    private void OnEnable() => BindEvent();

    private void FixedUpdate() => Move();

    private void OnDisable() => UnBindEvent();

    private void Move()
    {
        Vector2 moveInput = _moveAction.action.ReadValue<Vector2>();

        // 입력 X → 월드 X, 입력 Y → 월드 Z, 기존 Y 속도 유지
        _rigidbody.linearVelocity = new Vector3(
            moveInput.x * _moveSpeed,
            _rigidbody.linearVelocity.y,
            moveInput.y * _moveSpeed);
    }

    private void CacheComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void BindEvent()
    {
        _moveAction.action.Enable();
    }

    private void UnBindEvent()
    {
        _moveAction.action.Disable();
    }
}
