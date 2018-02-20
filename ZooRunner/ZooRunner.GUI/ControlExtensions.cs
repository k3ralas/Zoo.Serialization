namespace System.Windows.Forms
{
    public static class ControlExtensions
    {
        static bool? _designMode;

        /// <summary>
        /// Extension method to return if the control is in design mode.
        /// </summary>
        /// <param name="this">Control to examine</param>
        /// <returns>True if in design mode, otherwise false</returns>
        public static bool IsInDesignMode(this Control @this)
        {
            return _designMode ?? (_designMode = ResolveDesignMode(@this)).Value;
        }

        /// <summary>
        /// Extension method to return if the control is in runtime mode.
        /// </summary>
        /// <param name="this">Control to examine</param>
        /// <returns>True if in runtime mode, otherwise false</returns>
        public static bool IsInRuntimeMode(this Control @this)
        {
            return !IsInDesignMode(@this);
        }

        static bool ResolveDesignMode(Control control)
        {
            System.Reflection.PropertyInfo designModeProperty;
            bool designMode;

            // Get the protected property
            designModeProperty = control.GetType().GetProperty(
                                    "DesignMode",
                                    System.Reflection.BindingFlags.Instance
                                    | System.Reflection.BindingFlags.NonPublic);


            // Get the controls DesignMode value
            designMode = (bool)designModeProperty.GetValue(control, null);


            // Test the parent if it exists
            if (control.Parent != null)
            {
                designMode |= ResolveDesignMode(control.Parent);
            }

            return designMode;
        }
    }
}
