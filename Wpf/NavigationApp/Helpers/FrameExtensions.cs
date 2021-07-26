namespace System.Windows.Controls
{
    public static class FrameExtensions
    {
        public static object GetDataContext(this Frame frame)
        {
            if (frame.Content is FrameworkElement element)
            {
                return element.DataContext;
            }
            return null;
        }
    }
}
