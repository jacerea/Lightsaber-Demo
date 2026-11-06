using UnityEngine;
using UnityEngine.InputSystem;

public class SaberScript : MonoBehaviour
{
    [Range(0.01f, 1f)]
    public float extendSpeed = 0.1f;   

    public GameObject blade;           

    public AudioSource audioSource;
    public AudioClip onSound;
    public AudioClip offSound;

    private bool weaponActive;         // #2 on/off state
    private const float SCALE_MIN = 0f; // #3
    private float scaleMax;            // #4
    private float extendDelta;         // #5 scale change per second
    private float scaleCurrent;        // #6
    private float localScaleX;         // #7
    private float localScaleZ;         // #7

    void Start()
    {
        localScaleX = transform.localScale.x;
        localScaleZ = transform.localScale.z;

        scaleMax = transform.localScale.y;
        scaleCurrent = scaleMax;

        extendDelta = scaleMax / extendSpeed;

        weaponActive = true;
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            extendDelta = weaponActive ? -Mathf.Abs(extendDelta) : Mathf.Abs(extendDelta);

            if (audioSource != null)
            {
                AudioClip clip = weaponActive ? offSound : onSound;
                if (clip != null) audioSource.PlayOneShot(clip);
            }
        }

        scaleCurrent += extendDelta * Time.deltaTime;
        scaleCurrent = Mathf.Clamp(scaleCurrent, SCALE_MIN, scaleMax);
        transform.localScale = new Vector3(localScaleX, scaleCurrent, localScaleZ);

        weaponActive = scaleCurrent > 0;

        if (weaponActive && !blade.activeSelf)
        {
            blade.SetActive(true);
        }
        else if (!weaponActive && blade.activeSelf)
        {
            blade.SetActive(false);
        }
    }
}