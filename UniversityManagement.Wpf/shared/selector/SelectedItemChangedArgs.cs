using System;

namespace UniversityManagement.Wpf
{
    public class SelectedItemChangedArgs<T> : EventArgs
    {
        #region Properties

        public T SelectedItem { get; set; }

        #endregion
    }
}
