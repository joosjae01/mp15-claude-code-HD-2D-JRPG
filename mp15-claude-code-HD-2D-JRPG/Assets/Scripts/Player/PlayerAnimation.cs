using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimation : MonoBehaviour
{
    private static readonly int IS_MOVING_HASH = Animator.StringToHash("IsMoving");
    private static readonly int IS_RUNNING_HASH = Animator.StringToHash("IsRunning");

    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private PlayerMovement _playerMovement;

    private void Awake() => CacheComponents();

    private void Update()
    {
        UpdateParameters();
        Flip();
    }

    private void UpdateParameters()
    {
        _animator.SetBool(IS_MOVING_HASH, _playerMovement.MoveInput != Vector2.zero);
        _animator.SetBool(IS_RUNNING_HASH, _playerMovement.IsRunning);
    }

    private void Flip()
    {
        float horizontal = _playerMovement.MoveInput.x;

        // 좌우 입력이 없으면 이전 방향 유지, 원본 스프라이트는 오른쪽 기준
        if (horizontal > 0f)
            _spriteRenderer.flipX = false;
        else if (horizontal < 0f)
            _spriteRenderer.flipX = true;
    }

    private void CacheComponents()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
}
