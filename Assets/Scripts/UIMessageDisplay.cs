using System.Collections;
using UnityEngine;
using TMPro;

// Put this on any GameObject in the scene (e.g. your Canvas) and drag your existing UI text into the _messageText slot in the Inspector
// Any script can then call: UIMessageDisplay.Show("your message");
public class UIMessageDisplay : MonoBehaviour
{
    public static UIMessageDisplay Instance { get; private set; }

    [SerializeField] private TMP_Text _messageText;
    // How long a message stays on screen (seconds)
    [SerializeField] private float _defaultDuration = 3f;

    private Coroutine _hideRoutine;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        if (_messageText != null)
            _messageText.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    // Static shortcut so other classes don't need a reference
    public static void Show(string message, float duration = -1f)
    {
        if (Instance == null)
        {
            // Fallback so you still see it in the editor if the UI is missing
            Debug.LogWarning("UIMessageDisplay not found in scene. Message: " + message);
            return;
        }
        Instance.ShowMessage(message, duration);
    }

    public void ShowMessage(string message, float duration = -1f)
    {
        if (_messageText == null || string.IsNullOrEmpty(message))
            return;

        _messageText.text = message;
        _messageText.gameObject.SetActive(true);

        // Restart the timer if a new message comes in while one is showing
        if (_hideRoutine != null)
            StopCoroutine(_hideRoutine);

        float time = duration > 0f ? duration : _defaultDuration;
        _hideRoutine = StartCoroutine(HideAfter(time));
    }

    private IEnumerator HideAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _messageText.gameObject.SetActive(false);
        _hideRoutine = null;
    }
}
