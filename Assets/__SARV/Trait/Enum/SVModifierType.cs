namespace __SARV.Trait.Enum
{
    /// <summary>
    /// Defines how a stat modifier is applied during final value calculation.
    /// Order of application: Flat → PercentAdd → PercentMult.
    /// </summary>
    public enum SVModifierType
    {
        Flat = 10, // Adds a constant value (e.g., +10)
        PercentAdd = 20, // Adds a percentage, additive with other PercentAdd modifiers (e.g., +20% +30% = +50%)
        PercentMult = 30 // Multiplies the current value (e.g., ×1.2, ×1.3 = ×1.56)
    }
}