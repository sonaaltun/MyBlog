using MyBlog.Domain.Utilities.Interfaces;


namespace MyBlog.Domain.Utilities.Concretes
{
    public class Result : IResult
    {
        public bool IsSuccess { get; }
        public string Messages { get; }

        public Result()
        {
            IsSuccess = false;
            Messages = string.Empty;
        }
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public Result(bool isSuccess, string messages) : this(isSuccess)
        {
            Messages = messages;
        }
    }
}
