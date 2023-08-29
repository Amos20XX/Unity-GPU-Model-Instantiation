using System.Collections.Generic;
using UnityEngine;

namespace Amos20XX.Graphics
{
    [System.Serializable]
    public class ModelData
    {
        [SerializeField] private string m_name;

        [SerializeField] private List<Transform> m_markers;
        public List<Transform> Markers { get => m_markers; }

        [SerializeField] private MeshData[] m_meshData;
        public MeshData[] MeshData { get => m_meshData; }
    }
}