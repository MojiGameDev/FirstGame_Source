using System;
using System.Linq;
using System.Runtime.CompilerServices;
using __MD.Script.Identifier.Contract;
using UnityEngine;
using Object = UnityEngine.Object;

namespace __MD.Script.Identifier
{
    /// <summary>
    /// A <see cref="ScriptableObject"/> which holds a <see cref="MDIdentifierReference"/>
    /// based on its <see cref="Object.name"/>.
    /// </summary>
    [CreateAssetMenu(fileName = "Identifier", menuName = "MD/Identifier/New")]
    public class MDIdentifier : ScriptableObject, IComparable<MDIdentifier>, IMDConvertable<MDIdentifierReference>, IMDConvertable<string>, IMDHasKey
    {
        /************************************************************************************************************************/

        private MDIdentifierReference _name;

        /// <summary>An <see cref="MDIdentifierReference"/> to the <see cref="Object.name"/>.</summary>
        /// <remarks>
        /// This value is gathered when first accessed, but will not be automatically updated after that
        /// because doing so causes some garbage allocation (except in the Unity Editor for convenience).
        /// </remarks>
        public MDIdentifierReference Name
        {
#if UNITY_EDITOR
            // Don't do this at runtime because it allocates garbage every time.
            // But in the Unity Editor things could get renamed at any time.
            get => _name = this ? name : "";
#else
            get => _name ??= name;
#endif
            set => _name = name = value;
        }

        /// <inheritdoc/>
        public object Key
            => Name;

        /************************************************************************************************************************/

        #region Comparison

        /************************************************************************************************************************/

        /// <summary>Compares the <see cref="MDIdentifierReference.String"/>s.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Compare(MDIdentifier a, MDIdentifier b)
            => a == b
                ? 0
                : a
                    ? a.CompareTo(b)
                    : -1;

        /// <summary>Compares the <see cref="MDIdentifierReference.String"/>s.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(MDIdentifier other)
            => other
                ? Name.String.CompareTo(other.Name.String)
                : 1;

        /************************************************************************************************************************/

        #endregion

        /************************************************************************************************************************/

        #region Conversion

        /************************************************************************************************************************/

        /// <summary>Returns the <see cref="Name"/>.</summary>
        public override string ToString()
            => Name;

        /// <inheritdoc/>
        MDIdentifierReference Contract.IMDConvertable<MDIdentifierReference>.Convert()
            => Name;

        /// <inheritdoc/>
        string Contract.IMDConvertable<string>.Convert()
            => Name;

        /************************************************************************************************************************/

        /// <summary>Returns the <see cref="Name"/>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator string(MDIdentifier key)
            => key?.Name;

        /// <summary>Returns the <see cref="Name"/>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator MDIdentifierReference(MDIdentifier key)
            => key?.Name;

        /************************************************************************************************************************/

        /// <summary>Creates a new array containing the <see cref="Name"/>s.</summary>
        public static MDIdentifierReference[] ToIdentifierReferences(params MDIdentifier[] keys)
        {
            if (keys == null)
                return null;

            if (keys.Length == 0)
                return Array.Empty<MDIdentifierReference>();

            var references = new MDIdentifierReference[keys.Length];
            for (int i = 0; i < keys.Length; i++)
                references[i] = keys[i];
            return references;
        }

        /// <summary>Creates a new array containing the <see cref="Name"/>s.</summary>
        public static string[] ToStrings(params MDIdentifier[] keys)
        {
            if (keys == null)
                return null;

            if (keys.Length == 0)
                return Array.Empty<string>();

            var strings = new string[keys.Length];
            for (int i = 0; i < keys.Length; i++)
                strings[i] = keys[i];
            return strings;
        }
        
        public string SkipWords(int skipCount)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return Name;
            }
    
            var parts = Name.ToString().Split('_');

            if (skipCount >= parts.Length)
            {
                return string.Empty;
            }
    
            return string.Join("_", parts.Skip(skipCount));
        }

        /************************************************************************************************************************/

        #endregion
    }
}