namespace Luftborn.Models
{
    public class ResponseModel
    {
        public bool Success { get; set; } = true;
        public List<string> Errors { get; set; }

        public void AddError(string error)
        {
            if (Errors == null)
            {
                Errors = new List<string>();
            }
            Errors.Add(error);
        }
    }


    //In case that we have a response
    public class ResponseModel<T> : ResponseModel
        where T : new()
    {
        public T Response { get; set; }
    }
}
