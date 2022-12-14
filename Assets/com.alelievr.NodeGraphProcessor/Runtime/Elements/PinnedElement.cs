using UnityEngine.UIElements;
using UnityEngine;
using System;

namespace GraphProcessor
{
	/// <summary>
	/// Element that overlays the graph like the blackboard
	/// </summary>
	[System.Serializable]
	public class PinnedElement
	{
		public static readonly Vector2	defaultSize = new Vector2(300, 200);
		public static readonly Vector2	defaultPos = new Vector2(5, 25);

		public Rect				position = new Rect(defaultPos , defaultSize);
		public bool				opened = true;
		public SerializableType	editorType;

		public PinnedElement(Type editorType)
		{
			this.editorType = new SerializableType(editorType);
		}
	}
}