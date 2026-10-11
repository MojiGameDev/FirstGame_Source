namespace __SARV.Identifier.Contract
{
    public interface ISVConvertable<out T>
    {
        /************************************************************************************************************************/

        /// <summary>Returns the equivalent of this object as <typeparamref name="T"/>.</summary>
        T Convert();

        /************************************************************************************************************************/
    }
}