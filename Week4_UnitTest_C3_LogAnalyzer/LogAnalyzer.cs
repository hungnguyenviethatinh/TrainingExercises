namespace Week4_UnitTest_C3_LogAnalyzer
{
    public class LogAnalyzer
    {
        readonly IExtensionManager _extensionManager;

        public LogAnalyzer(IExtensionManager extensionManager)
        {
            _extensionManager = extensionManager;
        }

        public bool IsValidLogFileName(string fileName)
        {
            bool isValid;
            try
            {
                isValid = _extensionManager.IsValid(fileName);
            }
            catch
            {
                isValid = false;
            }

            return isValid;
        }
    }

    public class LogAnalyzerSection345
    {
        public IExtensionManager ExtensionManager { get; set; }

        public LogAnalyzerSection345()
        {
            ExtensionManager = new FileExtensionManager();
        }

        public bool IsValidLogFileName(string fileName)
        {
            bool isValid;
            try
            {
                isValid = ExtensionManager.IsValid(fileName);
            }
            catch
            {
                isValid = false;
            }

            return isValid;
        }
    }

    public class LogAnalyzerSection346
    {
        public IExtensionManager _extensionManager;

        public LogAnalyzerSection346()
        {
            _extensionManager = ExtensionManagerFactory.Create();
        }

        public bool IsValidLogFileName(string fileName)
        {
            bool isValid;
            try
            {
                isValid = _extensionManager.IsValid(fileName);
            }
            catch
            {
                isValid = false;
            }

            return isValid;
        }
    }

    public class LogAnalyzerUseFactoryMethod
    {
        public bool IsValidLogFileName(string fileName)
        {
            return GetExtensionManager().IsValid(fileName);
        }

        protected virtual IExtensionManager GetExtensionManager()
        {
            return new FileExtensionManager();
        }
    }

    public class LogAnalyzerSection351
    {
        public bool IsValidLogFileName(string fileName)
        {
            return IsValid(fileName);
        }

        protected virtual bool IsValid(string fileName)
        {
            FileExtensionManager fileExtensionManger = new FileExtensionManager();

            return fileExtensionManger.IsValid(fileName);
        }
    }
}
