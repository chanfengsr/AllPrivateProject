   internal class Win32ClipboardHelper
    {
        public static Bitmap GetImage(IntPtr hwnd)
        {
            try
            {
                if (OpenClipboard(hwnd))
                {
                    IntPtr data = GetClipboardData(14); // CF_ENHMETAFILE      14
                    if (data != IntPtr.Zero)
                    {
                        using (Metafile mf = new Metafile(data, true))
                        {
                            Bitmap b = new Bitmap(mf);
                            return b;
                        }
                    }
                }
            }
            finally
            {
                CloseClipboard();
            }
            return null;
        }


        #region Clipboard Functions
        /// <summary>
        ///   The OpenClipboard function opens the clipboard for examination and prevents 
        ///   other applications from modifying the clipboard content.
        /// </summary>
        /// <param name="hWndNewOwner">
        ///   Handle to the window to be associated with the open clipboard. If this 
        ///   parameter is NULL, the open clipboard is associated with the current task.
        /// </param>
        /// <returns>
        ///   If the function succeeds, the return value is nonzero. If the function 
        ///   fails, the return value is zero.
        /// </returns>
        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenClipboard(IntPtr hWndNewOwner);

        /// <summary>
        ///   The CloseClipboard function closes the clipboard.
        /// </summary>
        /// <returns>
        ///   If the function succeeds, the return value is nonzero.
        ///   If the function fails, the return value is zero.
        /// </returns>
        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseClipboard();

        /// <summary>
        ///   The EmptyClipboard function empties the clipboard and frees handles to data 
        ///   in the clipboard. The function then assigns ownership of the clipboard to 
        ///   the window that currently has the clipboard open.
        /// </summary>
        /// <returns>
        ///   If the function succeeds, the return value is nonzero. 
        ///   If the function fails, the return value is zero.
        /// </returns>
        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EmptyClipboard();

        /// <summary>
        ///   The SetClipboardData function places data on the clipboard 
        ///   in a specified clipboard format.
        /// </summary>
        /// <param name="uFormat">
        ///   Specifies a clipboard format. This parameter can be a registered format 
        ///   or any of the standard clipboard formats.
        /// </param>
        /// <param name="hMem">
        ///   Handle to the data in the specified format. This parameter can be NULL, 
        ///   indicating that the window provides data in the specified clipboard 
        ///   format (renders the format) upon request. If a window delays rendering, 
        ///   it must process the WM_RENDERFORMAT and WM_RENDERALLFORMATS messages.
        /// </param>
        /// <returns>
        ///   If the function succeeds, the return value is the handle to the data.
        ///   If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("User32.dll")]
        public static extern IntPtr SetClipboardData(System.UInt32 uFormat, IntPtr hMem);

        /// <summary>
        ///   The IsClipboardFormatAvailable function determines whether the clipboard 
        ///   contains data in the specified format.
        /// </summary>
        /// <param name="format">
        ///   Specifies a standard or registered clipboard format.
        /// </param>
        /// <returns>
        ///   If the clipboard format is available, the return value is nonzero.
        ///   If the clipboard format is not available, the return value is zero.
        /// </returns>
        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsClipboardFormatAvailable(System.UInt32 format);

        /// <summary>
        ///   The GetClipboardData function retrieves data from the clipboard in a 
        ///   specified format. The clipboard must have been opened previously.
        /// </summary>
        /// <param name="uFormat">
        ///   Specifies a clipboard format.
        /// </param>
        /// <returns>
        ///   If the function succeeds, the return value is the handle to a clipboard object 
        ///   in the specified format. If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("User32.dll")]
        public static extern IntPtr GetClipboardData(System.UInt32 uFormat);

        /// <summary>
        ///   The SetClipboardViewer function adds the specified window to the chain 
        ///   of clipboard viewers. Clipboard viewer windows receive a WM_DRAWCLIPBOARD 
        ///   message whenever the content of the clipboard changes.
        /// </summary>
        /// <param name="hWndNewViewer">
        ///   Handle to the window to be added to the clipboard chain.
        /// </param>
        /// <returns>
        ///   If the function succeeds, the return value identifies the next window in 
        ///   the clipboard viewer chain. If an error occurs or there are no other 
        ///   windows in the clipboard viewer chain, the return value is NULL.
        /// </returns>
        [DllImport("User32.dll")]
        public static extern IntPtr SetClipboardViewer(System.IntPtr hWndNewViewer);

        #endregion
    }