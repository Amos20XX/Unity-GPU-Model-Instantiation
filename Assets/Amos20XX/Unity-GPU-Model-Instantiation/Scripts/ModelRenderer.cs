using System.Collections.Generic;
using UnityEngine;

namespace Amos20XX.Graphics
{
    public class ModelRenderer : MonoBehaviour
    {
        [SerializeField] private ModelData[] m_modelData;

        [SerializeField] private bool m_isTurnOn = true;

        public void TurnOn() => m_isTurnOn = true;
        public bool TurnOff() => m_isTurnOn = false;

        private void LateUpdate()
        {
            if (m_isTurnOn)
            {
                for(int i = 0; i < m_modelData.Length; i++)
                {
                    InstantiateModel(m_modelData[i]);
                }
            }
        }

        /// <summary>
        /// 实例化模型
        /// </summary>
        /// <param name="modelData">模型数据</param>
        public void InstantiateModel(ModelData modelData)
        {
            for(int i = 0; i < modelData.MeshData.Length; i++)
            {
                InstantiateMesh(modelData.Markers, modelData.MeshData[i]);
            }
        }

        /// <summary>
        /// 实例化网格
        /// </summary>
        /// <param name="markers">标记位置</param>
        /// <param name="meshData">网格数据</param>
        public void InstantiateMesh(List<Transform> markers, MeshData meshData)
        {
            Quaternion quat_Offset = Quaternion.Euler(meshData.Rotation);
            //Vector3 scale = Vector3.one;
            Matrix4x4 localOffestMatrix = Matrix4x4.TRS(meshData.Position, quat_Offset, meshData.Scale);

            Matrix4x4[] targetMatrix = new Matrix4x4[markers.Count];
            for (int i = 0; i < markers.Count; i++)
            {
                if (markers[i] == null) continue;

                Transform marker = markers[i];
                if (marker.gameObject.activeInHierarchy)
                {
                    Matrix4x4 matrix;
                    if (meshData.RelativeTo == Space.Self)
                    {
                        matrix = marker.localToWorldMatrix;
                    }
                    else
                    {
                        Quaternion fromTo = marker.rotation;
                        matrix = Matrix4x4.TRS(marker.position, fromTo, Vector3.one);
                    }

                    matrix = matrix * localOffestMatrix;
                    targetMatrix[i] = matrix;
                }
            }

            for (int i = 0; i < meshData.Materials.Length; i++)
            {
                UnityEngine.Graphics.DrawMeshInstanced(meshData.Mesh, i, meshData.Materials[i], targetMatrix);
            }
        }
    }
}