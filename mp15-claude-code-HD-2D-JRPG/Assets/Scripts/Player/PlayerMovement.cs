using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private InputActionReference _runAction;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _runSpeed = 8f;

    private Rigidbody _rigidbody;

    public Vector2 MoveInput { get; private set; }
    public bool IsRunning { get; private set; }

    private void Awake() => CacheComponents();

    private void OnEnable() => BindEvent();

    private void FixedUpdate() => Move();

    private void OnDisable() => UnBindEvent();

    private void Move()
    {
        MoveInput = _moveAction.action.ReadValue<Vector2>();

        // 이동 입력이 있을 때만 달리기 상태
        IsRunning = MoveInput != Vector2.zero && _runAction.action.IsPressed();

        float speed = IsRunning ? _runSpeed : _moveSpeed;

        // 입력 X → 월드 X, 입력 Y → 월드 Z, 기존 Y 속도 유지
        _rigidbody.linearVelocity = new Vector3(
            MoveInput.x * speed,
            _rigidbody.linearVelocity.y,
            MoveInput.y * speed);
    }

    private void CacheComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void BindEvent()
    {
        _moveAction.action.Enable();
        _runAction.action.Enable();
    }

    private void UnBindEvent()
    {
        _moveAction.action.Disable();
        _runAction.action.Disable();
    }
}
