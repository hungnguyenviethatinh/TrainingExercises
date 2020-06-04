namespace FinalUnitTestBigExercise.Helpers
{
    public static class Constants
    {
        public const string BaseUrl = "https://www.otosaigon.com";

        public const string LastPageNodeSelector = "ul.pageNav-main > li:last-child > a";
        public const string PostNodeSelector = "article.message.message--post";
        public const string ReactionLinkNodeSelector = "a.reactionsBar-link";
        public const string ReactionNodeSelector = "a.tabs-tab--reaction0";
        public const string UserNodeSelector = "div.message-userDetails > div.message-name > a";

        public const string PrefixReactionText = "All (";
        public const string SubfixReactionText = ")";
    }
}
