using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubFootstepSource
{
    public abstract class SubFootstepSourceTerrain : SubFootstepSourceSetting
    {
        private float[,,] _splatmapData;

        protected override void Awake()
        {
            base.Awake();
            var terrainData = terrain.terrainData;
            _splatmapData = terrainData.GetAlphamaps(
                0, 0,
                terrainData.alphamapWidth,
                terrainData.alphamapHeight);
        }

        protected Texture GetTerrainTextureAt(Vector3 position)
        {
            var texture = GetTextureAt(position);
            return texture;
        }

        private Texture GetTextureAt(Vector3 position)
        {
            var data = terrain.terrainData;

            var xCoord = Mathf.Clamp((int)(((position.x - terrain.transform.position.x) /
                                            data.size.x) * data.alphamapWidth),
                0, data.alphamapWidth - 1);

            var zCoord = Mathf.Clamp((int)(((position.z - terrain.transform.position.z) /
                                            data.size.z) * data.alphamapHeight),
                0, data.alphamapHeight - 1);

            var index = 0;
            var comp = 0f;

            for (var i = 0; i < data.alphamapLayers; i++)
            {
                var weight = _splatmapData[zCoord, xCoord, i];

                if (weight > comp)
                {
                    index = i;
                    comp = weight;
                }
            }

            return data.terrainLayers[index].diffuseTexture;
        }
    }
}