﻿#if UNITY_EDITOR
using System;
using UnityEngine;

namespace UnityEditor.Experimental.EditorVR
{
	/// <summary>
	/// Gives decorated class access to the GameObject over which a particular ray is hovering
	/// </summary>
	public interface IManipulator
	{
		/// <summary>
		/// Delegate that processes the translation, using the vector3 passed in
		/// </summary>
		Action<Vector3> translate { set; }

		/// <summary>
		/// Delegate that processes the rotation, using the quaternion passed in
		/// </summary>
		Action<Quaternion> rotate { set; }

		/// <summary>
		/// Delegate that processes the scale, using the vector3 passed in
		/// </summary>
		Action<Vector3> scale { set; }

		/// <summary>
		/// Delegate that is called once after every drag
		/// </summary>
		event Action dragStarted;

		/// <summary>
		/// Bool denoting the drag-state of a manipulator that implements this interface
		/// </summary>
		bool dragging { get; }
	}
}
#endif
