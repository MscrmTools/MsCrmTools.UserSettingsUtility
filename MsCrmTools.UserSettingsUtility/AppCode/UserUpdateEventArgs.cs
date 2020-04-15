using System;

namespace MsCrmTools.UserSettingsUtility.AppCode
{
    internal class UserUpdateEventArgs : EventArgs
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string UserName { get; set; }
    }
}