using System.Collections.Generic;
using __SARV.Common.Base;
using __SARV.Framework.Module.Footstep.Entity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace __SARV.Framework.Module.Footstep.SubSurfaceDatabase
{
    public abstract class SVSubSurfaceDatabaseData : SVScriptableObject
    {
        [FoldoutGroup("Data")] [SerializeField] [RequiredListLength(1, 15)] [OnValueChanged(nameof(OnSurfacesChanged))]
        private List<SVSurface> surfaces = new();
        
        public IReadOnlyList<SVSurface> Surfaces => surfaces;

        private void OnSurfacesChanged()
        {
            
        }
    }
}