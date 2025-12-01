using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform camTransform;
    public float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    public float frequency = 25f;
    
    private Vector3 originalPos;
    private float noiseSeedX;
    private float noiseSeedY;
    private float noiseSeedZ;
    private bool isShaking = false;
    private float initDuration;

    void Start()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent<Transform>();
        }

        initDuration = shakeDuration;
        noiseSeedX = Random.value * 100f;
        noiseSeedY = Random.value * 100f;
        noiseSeedZ = Random.value * 100f;
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {

        if (isShaking && shakeDuration > 0)
        {
            float time = Time.time * frequency;

            float offsetX = (Mathf.PerlinNoise(noiseSeedX, time) - 0.5f) * 2f;
            float offsetY = (Mathf.PerlinNoise(noiseSeedY, time) - 0.5f) * 2f;
            float offsetZ = (Mathf.PerlinNoise(noiseSeedZ, time) - 0.5f) * 2f;

            Vector3 smoothShake = new Vector3(offsetX, offsetY, offsetZ) * shakeAmount;
            camTransform.localPosition = Vector3.Lerp(camTransform.localPosition, originalPos + smoothShake, Time.deltaTime * frequency);

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {

            camTransform.localPosition = Vector3.Lerp(camTransform.localPosition, originalPos, Time.deltaTime * frequency);
            isShaking = false;
        }
    }
    
    public void SetIsShakingTrue()
    {
        isShaking = true;
        shakeDuration = initDuration;
    }
}
