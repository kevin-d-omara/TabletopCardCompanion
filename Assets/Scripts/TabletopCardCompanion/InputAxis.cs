namespace TabletopCardCompanion
{
    /// <summary>
    /// Container class for input axis names.
    /// </summary>
    /// <example>
    /// <code>
    /// void Update()
    /// {
    ///     if (Input.GetButtonDown(InputAxis.Rotate))
    ///     {
    ///         // do stuff
    ///     }
    /// }
    /// </code>
    /// </example>
    public static class InputAxis
    {
        public const string FlipOver = "FlipOver";
        public const string Rotate = "Rotate";
        public const string Scale = "Scale";
    }
}
