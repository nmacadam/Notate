using UnityEditor;
using UnityEngine;

namespace Notate.Runtime
{
    public class Note : MonoBehaviour
    {
        [SerializeField] private string _message;
        [SerializeField] private TextAnchor _alignment = TextAnchor.MiddleLeft;
        [SerializeField] private Color _color = new Color(1f, 1f, 1f, .05f);
        [SerializeField] private string _icon = "console.infoicon";

        private void Reset()
        {
            hideFlags = HideFlags.DontSaveInBuild;
        }
    }
}
