using Notate.Runtime;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Notate.Editor
{
    [CustomEditor(typeof(Note))]
    public class NoteEditor : UnityEditor.Editor
    {
        private SerializedProperty _message;
        private SerializedProperty _alignment;
        private SerializedProperty _color;
        private SerializedProperty _iconName;

        private GUIContent _textContent;
        private GUIContent _iconContent;

		private GenericMenu _iconMenu;

		private const int _maxIconWidth = 32;
		private const int _textAreaLeftPad = 52;
		private const int _iconPadLeft = 12;
		
		[MenuItem("CONTEXT/Note/Icon/Info")]
		private static void SetIconToInfo(MenuCommand command)
		{
			SetIcon(command.context, "console.infoicon");
		}
        
		[MenuItem("CONTEXT/Note/Icon/Warn")]
		private static void SetIconToWarning(MenuCommand command)
		{
			SetIcon(command.context, "console.warnicon");
		}
        
		[MenuItem("CONTEXT/Note/Icon/Error")]
		private static void SetIconToError(MenuCommand command)
		{
			SetIcon(command.context, "console.erroricon");
		}

		private static void SetIcon(Object context, string icon)
		{
			var serializedObject = new SerializedObject(context);
			serializedObject.FindProperty("_icon").stringValue = icon;
			serializedObject.ApplyModifiedProperties();
		}
		
		private void OnEnable()
		{
			_message = serializedObject.FindProperty("_message");
			_alignment = serializedObject.FindProperty("_alignment");
			_color = serializedObject.FindProperty("_color");
			_iconName = serializedObject.FindProperty("_icon");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			
			var textAreaStyle = new GUIStyle(EditorStyles.textArea)
			{
				normal = { background = Texture2D.blackTexture },
				richText = true,
				margin = new RectOffset { left = _iconContent == null ? 0 : _textAreaLeftPad },
				alignment = (TextAnchor)_alignment.enumValueIndex
			};

			// Get icon
			if (!string.IsNullOrEmpty(_iconName.stringValue))
			{
				_iconContent = EditorGUIUtility.IconContent(_iconName.stringValue);
			}
			else
			{
				_iconContent = null;
			}

			// Draw text area
			Rect textAreaRect = GUILayoutUtility.GetRect(new GUIContent(_message.stringValue), textAreaStyle);
			
			// Expand to full component window space (magic number warning)
			Rect backgroundRect = new Rect(textAreaRect);
			backgroundRect.x -= _textAreaLeftPad;
			backgroundRect.y -= 4;
			backgroundRect.height += 11;
			backgroundRect.width += _textAreaLeftPad + 4;
			
			// Draw background color
			EditorGUI.DrawRect(backgroundRect, _color.colorValue);
			
			// Draw icon
			if (_iconContent != null)
			{
				float iconSize = backgroundRect.height < EditorGUIUtility.singleLineHeight * 2f ? _maxIconWidth / 2 : _maxIconWidth;
				float iconHeight = _iconContent.image.height * (iconSize / _iconContent.image.width);
				var iconRect = new Rect(backgroundRect.x + _iconPadLeft, backgroundRect.y + (backgroundRect.height * .5f) - (iconHeight * .5f), iconSize, iconHeight);

				if (GUI.Button(iconRect, _iconContent, GUIStyle.none))
				{
					GetIconMenu().ShowAsContext();
				}
			}
			
			// Draw text
			_message.stringValue = EditorGUI.TextArea(textAreaRect, _message.stringValue, textAreaStyle);
			
			serializedObject.ApplyModifiedProperties();
		}

		private GenericMenu GetIconMenu()
		{
			// Need to make new instance so the selected value updates
			GenericMenu iconMenu = new GenericMenu();
			AddMenuItemIcon(iconMenu, "None", string.Empty);
			AddMenuItemIcon(iconMenu, "Info", "console.infoicon");
			AddMenuItemIcon(iconMenu, "Warning", "console.warnicon");
			AddMenuItemIcon(iconMenu, "Error", "console.erroricon");

			return iconMenu;
		}

		private void AddMenuItemIcon(GenericMenu menu, string optionName, string editorIcon)
		{
			menu.AddItem(new GUIContent(optionName), 
				_iconName.stringValue == editorIcon, 
				_ =>
				{
					_iconName.stringValue = editorIcon;
					if (!string.IsNullOrEmpty(editorIcon))
					{
						_iconContent = EditorGUIUtility.IconContent(_iconName.stringValue);
					}
					else
					{
						_iconContent = null;
					}
					serializedObject.ApplyModifiedProperties();
				}, 
				null);
		}
    }
}
