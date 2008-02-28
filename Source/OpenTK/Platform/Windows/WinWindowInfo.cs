﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OpenTK.Platform.Windows
{
    /// <internal />
    /// <summary>Describes a win32 window.</summary>
    internal sealed class WinWindowInfo : IWindowInfo
    {
        IntPtr handle;
        WinWindowInfo parent;

        #region --- Constructors ---

        internal WinWindowInfo()
        {
        }

        internal WinWindowInfo(IntPtr handle, WinWindowInfo parent)
        {
            this.handle = handle;
            this.parent = parent;
        }

        #endregion

        #region --- Methods ---

        internal IntPtr Handle { get { return handle; } set { handle = value; } }
        internal WinWindowInfo Parent { get { return parent; } set { parent = value; } }

        #region public override string ToString()

        /// <summary>Returns a System.String that represents the current window.</summary>
        /// <returns>A System.String that represents the current window.</returns>
        public override string ToString()
        {
            return String.Format("Windows.WindowInfo: Handle {0}, Parent ({1})",
                this.Handle, this.Parent != null ? this.Parent.ToString() : "null");
        }

        /// <summary>Checks if <c>this</c> and <c>obj</c> reference the same win32 window.</summary>
        /// <param name="obj">The object to check against.</param>
        /// <returns>True if <c>this</c> and <c>obj</c> reference the same win32 window; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            WinWindowInfo info = (WinWindowInfo)obj; 

            if (info == null) return false;
            // TODO: Assumes windows will always have unique handles.
            return handle.Equals(info.handle);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A hash code for the current <c>WinWindowInfo</c>.</returns>
        public override int GetHashCode()
        {
            return handle.GetHashCode();
        }

        #endregion

        #endregion
    }
}
