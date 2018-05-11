﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GraphProcessor
{
	[System.Serializable]
	public class SerializableEdge : ISerializationCallbackReceiver
	{
		public string	GUID;

		[SerializeField]
		BaseGraph		owner;

		[SerializeField]
		string			inputNodeGUID;
		[SerializeField]
		string			outputNodeGUID;

		[System.NonSerialized]
		public BaseNode	inputNode;

		[System.NonSerialized]
		public BaseNode	outputNode;

		public string	inputFieldName;
		public string	outputFieldName;

		//Private constructor so we can't instantiate this class
		private SerializableEdge() {}

		public static SerializableEdge CreateNewEdge(BaseNode inputNode, string inputFieldName, BaseNode outputNode, string outputFieldName)
		{
			SerializableEdge	edge = new SerializableEdge();

			edge.GUID = System.Guid.NewGuid().ToString();
			edge.inputNode = inputNode;
			edge.inputFieldName = inputFieldName;
			edge.outputNode = outputNode;
			edge.outputFieldName = outputFieldName;

			return edge;
		}

		public void OnBeforeSerialize()
		{
			outputNodeGUID = outputNode.GUID;
			inputNodeGUID = inputNode.GUID;
		}

		public void OnAfterDeserialize()
		{
			outputNode = owner.nodesPerGUID[outputNodeGUID];
			inputNode = owner.nodesPerGUID[inputNodeGUID];
		}
	}
}
