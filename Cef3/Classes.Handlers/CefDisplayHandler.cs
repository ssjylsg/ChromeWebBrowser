namespace Cef3
{
    using Cef3.Interop;

    /// <summary>
    /// Implement this interface to handle events related to browser display state.
    /// The methods of this class will be called on the UI thread.
    /// </summary>
    public abstract unsafe partial class CefDisplayHandler
    {
        private void on_address_change(cef_display_handler_t* self, cef_browser_t* browser, cef_frame_t* frame, cef_string_t* url)
        {
            CheckSelf(self);

            var mBrowser = CefBrowser.FromNative(browser);
            var mFrame = CefFrame.FromNative(frame);
            var mUrl = cef_string_t.ToString(url);

            OnAddressChange(mBrowser, mFrame, mUrl);
        }

        /// <summary>
        /// Called when a frame's address has changed.
        /// </summary>
        protected virtual void OnAddressChange(CefBrowser browser, CefFrame frame, string url)
        {
        }


        private void on_title_change(cef_display_handler_t* self, cef_browser_t* browser, cef_string_t* title)
        {
            CheckSelf(self);

            var mBrowser = CefBrowser.FromNative(browser);
            var mTitle = cef_string_t.ToString(title);

            OnTitleChange(mBrowser, mTitle);
        }

        /// <summary>
        /// Called when the page title changes.
        /// </summary>
        protected virtual void OnTitleChange(CefBrowser browser, string title)
        {
        }


        private int on_tooltip(cef_display_handler_t* self, cef_browser_t* browser, cef_string_t* text)
        {
            CheckSelf(self);

            var mBrowser = CefBrowser.FromNative(browser);
            var mText = cef_string_t.ToString(text);

            return OnTooltip(mBrowser, mText) ? 1 : 0;
        }

        /// <summary>
        /// Called when the browser is about to display a tooltip. |text| contains the
        /// text that will be displayed in the tooltip. To handle the display of the
        /// tooltip yourself return true. Otherwise, you can optionally modify |text|
        /// and then return false to allow the browser to display the tooltip.
        /// When window rendering is disabled the application is responsible for
        /// drawing tooltips and the return value is ignored.
        /// </summary>
        protected virtual bool OnTooltip(CefBrowser browser, string text)
        {
            return false;
        }


        private void on_status_message(cef_display_handler_t* self, cef_browser_t* browser, cef_string_t* value)
        {
            CheckSelf(self);

            var mBrowser = CefBrowser.FromNative(browser);
            var mValue = cef_string_t.ToString(value);

            OnStatusMessage(mBrowser, mValue);
        }

        /// <summary>
        /// Called when the browser receives a status message. |text| contains the text
        /// that will be displayed in the status message and |type| indicates the
        /// status message type.
        /// </summary>
        protected virtual void OnStatusMessage(CefBrowser browser, string value)
        {
        }


        private int on_console_message(cef_display_handler_t* self, cef_browser_t* browser, cef_string_t* message, cef_string_t* source, int line)
        {
            CheckSelf(self);

            var mBrowser = CefBrowser.FromNative(browser);
            var mMessage = cef_string_t.ToString(message);
            var mSource = cef_string_t.ToString(source);

            return OnConsoleMessage(mBrowser, mMessage, mSource, line) ? 1 : 0;
        }

        /// <summary>
        /// Called to display a console message. Return true to stop the message from
        /// being output to the console.
        /// </summary>
        protected virtual bool OnConsoleMessage(CefBrowser browser, string message, string source, int line)
        {
            return false;
        }

    }
}
