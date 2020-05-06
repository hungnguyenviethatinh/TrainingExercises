namespace Week4_UnitTest_C3_LogAnalyzer
{
    public static class ExtensionManagerFactory
    {
        static IExtensionManager _extensionManager;

        public static IExtensionManager Create()
        {
            if (_extensionManager == null)
            {
                _extensionManager = new FileExtensionManager();
            }

            return _extensionManager;
        }

        public static void SetExtensionManager(IExtensionManager extensionManager)
        {
            _extensionManager = extensionManager;
        }
    }
}
