using Notate.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class IsNoteRemovedInBuild : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        var note = GetComponent<Note>();
        _text.text = note == null ? "Note is null." : "Note is not null!";
    }
}
