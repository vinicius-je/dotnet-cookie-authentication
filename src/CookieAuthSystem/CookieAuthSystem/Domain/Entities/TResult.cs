namespace CookieAuthSystem.Domain.Entities
{
    public class TResult<T>
    {
        public bool IsSuccess = true;
        public T? Value { get; set; }
        public string? ErrorMessage { get; set; }

        public TResult()
        {
        }

        public void Success(T? value)
        {
            Value = value;
        }

        public void AddError(string error)
        {
            IsSuccess = !IsSuccess;
            ErrorMessage = error;
        }
    }
}
