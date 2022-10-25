using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Description : MonoBehaviour
{
    [SerializeField] private LevelInfo _levelInfo;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        _text.text = _levelInfo.Description;
    }
}
