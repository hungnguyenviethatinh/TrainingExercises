using System;

namespace Final_UnitTest_BigExercise.Models
{
    public sealed class Result : IEquatable<Result>
    {
        public string UserName { get; set; }
        public int LikeCount { get; set; }

        public bool Equals(Result other)
        {
            if (other == null)
            {
                return false;
            }

            return UserName.Equals(other.UserName, StringComparison.CurrentCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var resultObj = obj as Result;
            if (resultObj == null)
            {
                return false;
            }

            return Equals(resultObj);
        }

        public override int GetHashCode()
        {
            return UserName.GetHashCode();
        }
    }
}
