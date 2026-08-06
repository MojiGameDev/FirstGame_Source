using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using __MD.Script.Identifier.Contract;

namespace __MD.Script.Identifier
{
    /// <summary>
    /// A <see cref="string"/> wrapper which allows fast reference equality checks and dictionary usage
    /// by ensuring that users of identical strings are given the same <see cref="MDIdentifierReference"/>
    /// instead of needing to compare each character in the strings.
    /// </summary>
    /// <remarks>
    /// Rather than a constructor, instances of this class are acquired via <see cref="Get(string)"/>
    /// or via implicit conversion from <see cref="string"/> (which calls the same method).
    /// <para></para>
    /// Unlike <c>UnityEngine.InputSystem.Utilities.InternedString</c>,
    /// this implementation is case-sensitive and treats <c>null</c> and <c>""</c> as not equal.
    /// It's also a class to allow usage as a key in a dictionary keyed by <see cref="object"/> without boxing.
    /// <para></para>
    /// <strong>Example:</strong>
    /// <code>
    /// public static readonly IdentifierReference MyIdentifier = "My String";
    /// </code>
    /// </remarks>
    public class MDIdentifierReference : IComparable<MDIdentifierReference>, IMDConvertable<string>
    {
        /************************************************************************************************************************/

        /// <summary>The encapsulated <see cref="string"/>.</summary>
        /// <remarks>This field will never be null.</remarks>
        public readonly string String;

        /************************************************************************************************************************/

        private static readonly Dictionary<string, MDIdentifierReference>
            StringToReference = new(256);

        /// <summary>Returns an <see cref="MDIdentifierReference"/> containing the `value`.</summary>
        /// <remarks>
        /// The returned reference is cached and the same one will be
        /// returned each time this method is called with the same `value`.
        /// <para></para>
        /// Returns <c>null</c> if the `value` is <c>null</c>.
        /// <para></para>
        /// The `value` is case sensitive.
        /// </remarks>
        public static MDIdentifierReference Get(string value)
        {
            if (value is null)
                return null;

            if (!StringToReference.TryGetValue(value, out var reference))
                StringToReference.Add(value, reference = new(value));

            // This system could be made case insensitive based on a static bool.
            // If true, convert the value to lower case for the dictionary key but still reference the original.
            // When changing the setting, rebuild the dictionary with the appropriate keys.

            return reference;
        }

        /************************************************************************************************************************/

        /// <summary>Creates a new array of <see cref="MDIdentifierReference"/>s to the `strings`.</summary>
        public static MDIdentifierReference[] Get(params string[] strings)
        {
            if (strings == null)
                return null;

            if (strings.Length == 0)
                return Array.Empty<MDIdentifierReference>();

            var references = new MDIdentifierReference[strings.Length];
            for (int i = 0; i < strings.Length; i++)
                references[i] = strings[i];
            return references;
        }

        /************************************************************************************************************************/

        /// <summary>Returns an <see cref="MDIdentifierReference"/> containing the `value` if one has already been created.</summary>
        /// <remarks>The `value` is case sensitive.</remarks>
        public static bool TryGet(string value, out MDIdentifierReference reference)
        {
            if (value is not null && StringToReference.TryGetValue(value, out reference))
                return true;

            reference = null;
            return false;
        }

        /************************************************************************************************************************/

        /// <summary>Creates a new <see cref="MDIdentifierReference"/>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private MDIdentifierReference(string value)
            => String = value;

        /// <summary>Calls <see cref="Get(string)"/>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator MDIdentifierReference(string value)
            => Get(value);

        /// <summary>[Internal]
        /// Returns a new <see cref="MDIdentifierReference"/> which will not be shared by regular calls to
        /// <see cref="Get(string)"/>.
        /// </summary>
        /// <remarks>
        /// This means the reference will never be equal to others
        /// even if they contain the same <see cref="String"/>.
        /// </remarks>
        internal static MDIdentifierReference Unique(string value)
            => new(value);

        /************************************************************************************************************************/

        /// <summary>Returns the <see cref="String"/>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
            => String;

        /// <summary>Returns the <see cref="String"/>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator string(MDIdentifierReference value)
            => value?.String;

        /************************************************************************************************************************/

        /// <inheritdoc/>
        string IMDConvertable<string>.Convert()
            => String;

        /************************************************************************************************************************/

        /// <summary>Compares the <see cref="String"/>s.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(MDIdentifierReference other)
            => String.CompareTo(other?.String);

        /************************************************************************************************************************/
    }
}