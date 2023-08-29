using UnityEngine;

namespace Amos20XX.Graphics
{
    [System.Serializable]
    public class MeshData
    {
        [SerializeField] private Mesh m_mesh;
        /// <summary>
        /// 要实例的网格
        /// </summary>
        public Mesh Mesh { get => m_mesh; }

        [SerializeField] private Material[] m_materials;
        /// <summary>
        /// 网格对应的材质
        /// </summary>
        public Material[] Materials { get => m_materials; }

        [SerializeField] private Vector3 m_position;
        /// <summary>
        /// 网格相对于标记的位置
        /// </summary>
        public Vector3 Position { get => m_position; }

        [SerializeField] private Vector3 m_rotation;
        /// <summary>
        /// 网格相对于标记的角度
        /// </summary>
        public Vector3 Rotation { get => m_rotation; }

        [SerializeField] private Vector3 m_scale;
        public Vector3 Scale { get => m_scale; }

        [SerializeField] private Space m_relativeTo;
        /// <summary>
        /// 是否在本地坐标系
        /// </summary>
        public Space RelativeTo { get => m_relativeTo; }
    }
}