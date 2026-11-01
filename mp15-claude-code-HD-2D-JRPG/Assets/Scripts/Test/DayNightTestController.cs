using UnityEngine;
using UnityEngine.InputSystem;

// 조명 반응 확인용 낮/밤 전환 테스트
public class DayNightTestController : MonoBehaviour
{
    [SerializeField] private InputActionReference _toggleAction;
    [SerializeField] private Light _directionalLight;

    [Header("낮")]
    [SerializeField] private Color _dayColor = Color.white;
    [SerializeField] private float _dayIntensity = 2f;
    [SerializeField] private float _dayAmbientIntensity = 1f;

    [Header("밤")]
    [SerializeField] private Color _nightColor = new Color(0.4f, 0.5f, 0.9f);
    [SerializeField] private float _nightIntensity = 0.3f;
    [SerializeField] private float _nightAmbientIntensity = 0.2f;

    private bool _isNight;

    private void OnEnable() => BindEvent();

    private void OnDisable() => UnBindEvent();

    private void Toggle(InputAction.CallbackContext context)
    {
        _isNight = !_isNight;

        _directionalLight.color = _isNight ? _nightColor : _dayColor;
        _directionalLight.intensity = _isNight ? _nightIntensity : _dayIntensity;
        RenderSettings.ambientIntensity = _isNight ? _nightAmbientIntensity : _dayAmbientIntensity;

        // 변경된 환경광 강도 반영
        DynamicGI.UpdateEnvironment();
    }

    private void BindEvent()
    {
        _toggleAction.action.performed += Toggle;
        _toggleAction.action.Enable();
    }

    private void UnBindEvent()
    {
        _toggleAction.action.Disable();
        _toggleAction.action.performed -= Toggle;
    }
}
